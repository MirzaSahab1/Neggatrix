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
    public class Camera : IComponent
    {
        public required GameObject Owner { get; set; }

        [SetsRequiredMembers]
        public Camera()
        {
            Owner = null!;
        }

        public PointF GetOffset(int screenWidth, int screenHeight)
        {
            var transform = Owner.GetComponent<Transform>();
            if (transform == null)
            {
                return new PointF(0, 0);
            }
            float offsetX = screenWidth / 2f - transform.Position.X;
            float offsetY = screenHeight / 2f - transform.Position.Y;
            return new PointF(offsetX, offsetY);
        }

        public void Start() { }
        public void Update(float deltaTime) { }
        public void Destroy() { }
    }
}
