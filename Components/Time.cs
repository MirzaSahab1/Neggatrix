using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neggatrix.Core;
using Neggatrix.Interfaces;

namespace Neggatrix.Components
{
    public class Time : IComponent
    {
        public GameObject Owner { get; set; }

        public float Duration { get; set; }
        public bool Loop { get; set; }
        public bool AutoStart { get; set; }

        public float Elapsed {  get; set; }
        public bool IsRunning { get; set; }
        public bool IsFinished { get; set; }

        

        public Time() 
        {
            Owner = null!;
            Duration = 0;
            Loop = false;
            AutoStart = true;
            Elapsed = 0;
            IsRunning = false;
            IsFinished = false;
        }

        public void Start() 
        {
            if (AutoStart) Play();
        }
        public void Update(float deltaTime)
        {
            if (!IsRunning) return;

            Elapsed += deltaTime;

            if (Duration > 0 && Elapsed >= Duration)
            {
                if (Loop)
                {
                    Elapsed -= Duration;
                }
                else
                {
                    Elapsed = Duration;
                    IsFinished = true;
                    IsRunning = false;
                }
            }
        }
        public void Destroy() { }

        public void Play()
        {
            IsRunning = true;
            IsFinished = false;
        }
        public void Pause()
        {
            IsRunning = false;
        }
        public void Stop()
        {
            IsRunning = false;
            Elapsed = 0;
            IsFinished = false;
        }
        public void Restart()
        {
            Stop();
            Play();
        }
    }
}
