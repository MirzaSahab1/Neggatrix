using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neggatrix.Core;
using Neggatrix.Interfaces;

namespace Neggatrix.Components
{
    public class Transform : IComponent
    {
        public required GameObject Owner {  get; set; }

        public PointF Position { get; set; } = new PointF(0.0f, 0.0f);

        public PointF Pivot { get; set; } = new PointF(0.5f, 0.5f);
        public float Rotation { get; set; }

        public PointF Scale { get; set; } = new PointF(1f, 1f);

       
        public void Start() { }
        public void Update() { }
        public void Destroy() { }
    }
}
