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
            Friction = 1f;
            GravityScale = 1.0f;
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

            Velocity = new PointF(
                Velocity.X * Friction * deltaTime,
                Velocity.Y
            );
            foreach (var otherGO in Owner.Scene.Objects)
            {
                if (otherGO == Owner) continue;

                var otherCollider = otherGO.GetComponent<BoxCollider>();
                if (otherCollider != null)
                {
                    if (myCollider.Bounds.IntersectsWith(otherCollider.Bounds))
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
