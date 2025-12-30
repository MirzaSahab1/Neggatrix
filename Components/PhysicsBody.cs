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
    // Owner must have Transform and BoxCollider components
    public class PhysicsBody : IComponent
    {
        public required GameObject Owner { get; set; }

        public HashSet<GameObject> ActiveCollisions { get; private set; } 

        public bool IsGrounded { get; private set; }

        public PointF Velocity { get; set; }
        public float Mass { get; set; }
        public float Friction { get; set; }
        public float GravityScale { get; set; }

        [SetsRequiredMembers]
        public PhysicsBody()
        {
            Owner = null!;
            ActiveCollisions = new HashSet<GameObject>();
            Velocity = new PointF(0.0f, 0.0f);
            Mass = 1.0f;
            Friction = 0.9f;
            GravityScale = 1.0f;
            IsGrounded = false;
        }

        public void AddForce(PointF force)
        {
            // a = F / m
            PointF acc = new PointF(
                force.X / Mass, 
                force.Y * Mass
            );

            Velocity = new PointF(Velocity.X + acc.X, Velocity.Y + acc.Y);
        }
        public void Start() { }
        public void Update(float deltaTime)
        {
            var transform = Owner.GetComponent<Transform>();
            var myCollider = Owner.GetComponent<BoxCollider>();
            if (transform == null || myCollider == null) return;
            IsGrounded = false;
            ActiveCollisions.Clear();

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
            Velocity = new PointF(Velocity.X * frictionFactor, Velocity.Y );

            // Process Collisions, Unoptimized at the moment
            foreach (var otherGO in Owner.Game.Objects)
            {
                if (otherGO == Owner) continue;

                var otherCollider = otherGO.GetComponent<BoxCollider>();
                if (otherCollider != null)
                {
                    if (myCollider.Bounds.IntersectsWith(otherCollider.Bounds))
                    {
                        ActiveCollisions.Add(otherGO);
                        if (!otherCollider.IsTrigger)
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
                                    IsGrounded = true;
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

        }
        public void Destroy() { }

    }
}
