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
        // Owner must have Transform component
        public required GameObject Owner { get; set; }

        public float Zoom { get; set; }
        public float Smoothing { get; set; }
        public float ShakeIntensity { get; set; }

        public PointF Position { get; private set; }

        public PointF CurrentShake { get; private set; }

        private Random _random;

        [SetsRequiredMembers]
        public Camera()
        {
            Owner = null!;
            Zoom = 1.0f;
            Smoothing = 5f;
            ShakeIntensity = 0.0f;
            _random = new Random();
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
                float offsetX = ((float)_random.NextDouble() * 2f - 1f) * ShakeIntensity;
                float offsetY = ((float)_random.NextDouble() * 2f - 1f) * ShakeIntensity;
                CurrentShake = new PointF(offsetX, offsetY);

                ShakeIntensity = Math.Max(0.0f, ShakeIntensity - deltaTime * 5f);
                if (ShakeIntensity < 0f) ShakeIntensity = 0f;
            }
            else
            {
                CurrentShake = new PointF(0f, 0f);
            }

        }
        public void Destroy() { }
    }
}
