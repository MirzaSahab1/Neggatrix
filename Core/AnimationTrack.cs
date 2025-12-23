using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Neggatrix.Interfaces;

namespace Neggatrix.Core
{
    public class AnimationTrack
    {
        public IComponent? TargetComponent { get; set; }
        public PropertyInfo? Property { get; set; }
        public object? StartValue { get; set; }
        public object? EndValue { get; set; }
        public float Duration { get; set; }
        public float Elapsed { get; set; }
        public bool IsFinished => Elapsed >= Duration;
    }
}
