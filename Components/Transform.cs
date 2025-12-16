using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

        public PointF Position { get; set; }

        public PointF Pivot { get; set; }
        public float Rotation { get; set; }

        public PointF Scale { get; set; }

        [SetsRequiredMembers]
        public Transform() 
        {
            Owner = null!;
            Position = new PointF(0.0f, 0.0f);
            Pivot = new PointF(0.5f, 0.5f);
            Rotation = 0.0f;
            Scale = new PointF(1f, 1f);
        }

        [SetsRequiredMembers]
        public Transform(PointF position) : this()
        {
            Position = position;
        }


        public void Start() { }
        public void Update(float deltaTime) { }
        public void Destroy() { }
    }
}
