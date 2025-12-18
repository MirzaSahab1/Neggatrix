using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neggatrix.Interfaces;
using Neggatrix.Core;
using System.Diagnostics.CodeAnalysis;

namespace Neggatrix.Components
{
    public abstract class Collider : IComponent
    {
        public required GameObject Owner { get; set; }

        public bool IsTrigger { get; set; }

        public PointF Offset { get; set; }

        public abstract RectangleF Bounds { get; }

        [SetsRequiredMembers]
        public Collider()
        {
            Owner = null!;
            IsTrigger = false;
            Offset = new PointF(0.0f, 0.0f);
        }

        public void Start() { }
        public void Update(float deltaTime) { }
        public void Destroy() { }
    }
}
