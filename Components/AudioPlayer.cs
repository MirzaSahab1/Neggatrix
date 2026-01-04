using NAudio.Wave.SampleProviders;
using Neggatrix.Common;
using Neggatrix.Core;
using Neggatrix.Interfaces;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Neggatrix.Components
{
    public class AudioPlayer : IComponent
    {
        // We don't need this to be public, we fetch it internally
        private AudioManager? _audioManager;
        private VolumeSampleProvider? _spatialSound;

        public required GameObject Owner { get; set; }

        public string filePath { get; set; }
        public float MaxDistance { get; set; }
        public bool Loop { get; set; }

        private Transform? _listenerTransform;

        [SetsRequiredMembers]
        public AudioPlayer()
        {
            Owner = null!;
            MaxDistance = 500f;
            filePath = string.Empty;
            Loop = true;
            _audioManager = null;
        }

        public void Start()
        {
            // 1. LINK TO THE ENGINE
            // Your Game class assigns 'Scene' to the GameObject, so we use that path.
            if (Owner.Game != null)
            {
                _audioManager = Owner.Game.Audio;
            }

            // 2. PLAY THE SOUND
            if (_audioManager != null && !string.IsNullOrEmpty(filePath))
            {
                // Ensure PlaySpatialSound is defined in your AudioManager!
                //_spatialSound = _audioManager.PlaySpatialSound(filePath, Loop);
            }
        }

        public void Update(float deltaTime)
        {
            // Safety checks
            if (_spatialSound == null || _audioManager == null) return;

            // 1. FIND LISTENER (Camera)
            if (_listenerTransform == null)
            {
                // Accessing Scene directly through Owner
                var listenerObj = Owner.Game?.Objects.FirstOrDefault(g => g.GetComponent<Camera>() != null);
                if (listenerObj != null)
                {
                    _listenerTransform = listenerObj.GetComponent<Transform>();
                }
            }

            // 2. CALCULATE VOLUME
            if (_listenerTransform != null)
            {
                var transform = Owner.GetComponent<Transform>();
                if (transform == null) return;

                float distance = Utils.Distance(transform.Position, _listenerTransform.Position);

                if (distance < MaxDistance)
                {
                    float newVol = 1.0f - (distance / MaxDistance);
                    if (newVol < 0f) newVol = 0f;

                    // Multiply by the Master Volume from the Manager
                    _spatialSound.Volume = newVol * _audioManager.SfxVolume;
                }
                else
                {
                    _spatialSound.Volume = 0f;
                }
            }
        }

        public void Destroy()
        {
            // Good practice to mute on destroy, even if we let GC handle the stream
            if (_spatialSound != null) _spatialSound.Volume = 0f;
        }
    }
}

