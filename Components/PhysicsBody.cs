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
                        RectangleF myBounds = myCollider.Bounds;
                        RectangleF otherBounds = otherCollider.Bounds;

                        RectangleF intersection = RectangleF.Intersect(myBounds, otherBounds);

                        if (intersection.Width < intersection.Height)
                        {
                            Velocity = new PointF(0, Velocity.Y);

                            if (myBounds.Left < otherBounds.Left) 
                            {
                                transform.Position = new PointF(
                                    otherBounds.Left - (myBounds.Width * (1 - transform.Pivot.X)),
                                    transform.Position.Y
                                );
                            }
                            else 
                            {
                                transform.Position = new PointF(
                                    otherBounds.Right + (myBounds.Width * transform.Pivot.X),
                                    transform.Position.Y
                                );
                            }
                        }
                        else 
                        {
                            Velocity = new PointF(Velocity.X, 0);

                            if (myBounds.Top < otherBounds.Top) 
                            {
                                transform.Position = new PointF(
                                    transform.Position.X,
                                    otherBounds.Top - (myBounds.Height * (1 - transform.Pivot.Y))
                                );
                            }
                            else 
                            {
                                transform.Position = new PointF(
                                    transform.Position.X,
                                    otherBounds.Bottom + (myBounds.Height * transform.Pivot.Y)
                                );
                            }
                        }
                    }
                }
            }

        }
        public void Destroy() { }

    }
}
