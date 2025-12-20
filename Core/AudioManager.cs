using System;
using System.Linq;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

public class AudioManager : IDisposable
{
    private readonly IWavePlayer _outputDevice;
    private readonly MixingSampleProvider _mixer;

    private ISampleProvider? _currentMusic;

    public float MusicVolume { get; set; } = 1.0f;
    public float SfxVolume { get; set; } = 1.0f;

    public AudioManager(int sampleRate = 44100, int channelCount = 2)
    {
        _outputDevice = new WaveOutEvent();

        _mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, channelCount));

        _mixer.ReadFully = true;

        _outputDevice.Init(_mixer);
        _outputDevice.Play();
    }

    public void PlaySound(string filePath)
    {
        try
        {
            var input = new AudioFileReader(filePath);

            input.Volume = SfxVolume;

            var autoDispose = new AutoDisposeFileReader(input);
            _mixer.AddMixerInput(autoDispose);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error playing sound: {ex.Message}");
        }
    }

    public void PlayMusic(string filePath)
    {
        StopMusic();

        try
        {
            var reader = new AudioFileReader(filePath);

            var loop = new LoopStream(reader);

            var volumeProvider = new VolumeSampleProvider(loop.ToSampleProvider());
            volumeProvider.Volume = MusicVolume;

            _currentMusic = volumeProvider;
            _mixer.AddMixerInput(_currentMusic);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error playing music: {ex.Message}");
        }
    }

    public void StopMusic()
    {
        if (_currentMusic != null)
        {
            _mixer.RemoveMixerInput(_currentMusic);
            _currentMusic = null;
        }
    }

    public void Dispose()
    {
        _outputDevice.Stop();
        _outputDevice.Dispose();
    }
}

public class LoopStream : WaveStream
{
    WaveStream sourceStream;

    public LoopStream(WaveStream sourceStream)
    {
        this.sourceStream = sourceStream;
        this.EnableLooping = true;
    }

    public bool EnableLooping { get; set; }

    public override WaveFormat WaveFormat => sourceStream.WaveFormat;
    public override long Length => sourceStream.Length;
    public override long Position
    {
        get => sourceStream.Position;
        set => sourceStream.Position = value;
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
        int totalBytesRead = 0;

        while (totalBytesRead < count)
        {
            int bytesRead = sourceStream.Read(buffer, offset + totalBytesRead, count - totalBytesRead);
            if (bytesRead == 0)
            {
                if (sourceStream.Position == 0 || !EnableLooping) break;
                sourceStream.Position = 0;
            }
            totalBytesRead += bytesRead;
        }
        return totalBytesRead;
    }
}

public class AutoDisposeFileReader : ISampleProvider
{
    private readonly AudioFileReader _reader;
    private bool _isDisposed;

    public AutoDisposeFileReader(AudioFileReader reader)
    {
        _reader = reader;
        WaveFormat = reader.WaveFormat;
    }

    public WaveFormat WaveFormat { get; }

    public int Read(float[] buffer, int offset, int count)
    {
        if (_isDisposed) return 0;

        int read = _reader.Read(buffer, offset, count);

        if (read == 0)
        {
            _reader.Dispose();
            _isDisposed = true;
        }
        return read;
    }
}