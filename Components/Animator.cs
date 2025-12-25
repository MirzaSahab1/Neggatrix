using Neggatrix.Core;
using Neggatrix.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Neggatrix.Components
{
    public class Animator : IComponent
    {
        public GameObject Owner { get; set; } = null!;
        private readonly List<AnimationTrack> _tracks = new List<AnimationTrack>();




        public void AddTrack(string componentName, string propertyName, object startValue, object endValue, float duration)
        {
            var comp = Owner.GetComponentByName(componentName);
            
            PropertyInfo? prop = comp.GetType().GetProperty(propertyName);

            object? startVal = startValue;
            if (startVal == null) return;

            _tracks.Add(new AnimationTrack
            {
                TargetComponent = comp,
                Property = prop,
                StartValue = startVal,
                EndValue = endValue,
                Duration = duration,
                Elapsed = 0
            });
        }

        public void Update(float deltaTime)
        {
            if (_tracks.Count == 0) return;

            for (int i = _tracks.Count - 1; i >= 0; i--)
            {
                var track = _tracks[i];
                track.Elapsed += deltaTime;

                float t = Math.Clamp(track.Elapsed / track.Duration, 0, 1);

                ApplyLerp(track, t);

                if (track.IsFinished)
                {
                    _tracks.RemoveAt(i);
                }
            }
        }

        private void ApplyLerp(AnimationTrack track, float t)
        {
            try
            {
                if (track.EndValue is PointF endP && track.StartValue is PointF startP)
                {
                    float x = startP.X + (endP.X - startP.X) * t;
                    float y = startP.Y + (endP.Y - startP.Y) * t;
                    track.Property.SetValue(track.TargetComponent, new PointF(x, y));
                }
                else if (track.EndValue is float endF && track.StartValue is float startF)
                {
                    track.Property.SetValue(track.TargetComponent, startF + (endF - startF) * t);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Animation failed: {ex.Message}");
                track.Elapsed = track.Duration;
            }
        }

        public void Start() { }
        public void Destroy() { _tracks.Clear(); }
    }
}

