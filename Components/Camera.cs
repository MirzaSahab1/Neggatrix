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

        public float Zoom { get; set; }
        public float Smoothing { get; set; }
        public float ShakeIntensity { get; set; }

        public PointF Position { get; private set; }

        [SetsRequiredMembers]
        public Camera()
        {
            Owner = null!;
            Zoom = 1.0f;
            Smoothing = 5f;
            ShakeIntensity = 0.0f;
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

        public void Start() 
        {
            var target = Owner.GetComponent<Transform>();
            if (target != null) Position = target.Position;
        }
        public void Update(float deltaTime) 
        {
            var target = Owner.GetComponent<Transform>();
            if (target == null) return;

            float weight = Smoothing * deltaTime;
            Position = new PointF(
                Position.X + (target.Position.X - Position.X) * weight,
                Position.Y + (target.Position.Y - Position.Y) * weight
            );
            if (ShakeIntensity > 0.0f)
            {
                ShakeIntensity -= deltaTime * 10f;
                if (ShakeIntensity < 0.0f) ShakeIntensity = 0.0f;
            }

        }
        public void Destroy() { }
    }
}
