using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neggatrix.Interfaces;
using Neggatrix.Core;
using System.Diagnostics.CodeAnalysis;
using Neggatrix.Common;

namespace Neggatrix.Components
{
    public class PhysicsBody : IComponent
    {
        public required GameObject Owner { get; set; }

        public PointF Velocity { get; set; }
        public float Mass { get; set; }
        public float Friction { get; set; }
        public float GravityScale { get; set; }

        [SetsRequiredMembers]
        public PhysicsBody()
        {
            Owner = null!;
            Velocity = new PointF(0.0f, 0.0f);
            Mass = 1.0f;
            Friction = 0.9f;
            GravityScale = 1.0f;
        }

        public void AddForce(PointF force)
        {
            // a = F / m
            float accX = force.X / Mass;
            float accY = force.Y / Mass;

            // We add this acceleration directly to our current velocity
            Velocity = new PointF(Velocity.X + accX, Velocity.Y + accY);
        }
        public void Start() { }
        public void Update(float deltaTime)
        {
            var transform = Owner.GetComponent<Transform>();
            var myCollider = Owner.GetComponent<BoxCollider>();
            if (transform == null || myCollider == null) return;

            // Apply gravity
            float gravityForce = Utils.GlobalGravity * GravityScale * Mass;
            Velocity = new PointF(
                Velocity.X,
                Velocity.Y + gravityForce * deltaTime
            );

            transform.Position = new PointF(
                transform.Position.X + Velocity.X * deltaTime,
                transform.Position.Y + Velocity.Y * deltaTime
            );

            float frictionFactor = MathF.Pow(Friction, deltaTime * 10);
            Velocity = new PointF(Velocity.X * frictionFactor, Velocity.Y * frictionFactor);
            foreach (var otherGO in Owner.Scene.Objects)
            {
                if (otherGO == Owner) continue;

                var otherCollider = otherGO.GetComponent<BoxCollider>();
                if (otherCollider != null)
                {
                    if (myCollider.Bounds.IntersectsWith(otherCollider.Bounds) && !otherCollider.IsTrigger)
                    {
                        // Simple Resolution: Stop falling if we hit something from above
                        if (Velocity.Y > 0 && myCollider.Bounds.Bottom > otherCollider.Bounds.Top)
                        {
                            Velocity = new PointF(Velocity.X, 0);
                            // Snap to the top of the other object
                            transform.Position = new PointF(
                                transform.Position.X,
                                otherCollider.Bounds.Top - (myCollider.Size.Height * (1 - transform.Pivot.Y))
                            );
                        }
                    }
                }
            }

        }
        public void Destroy() { }

    }
}
