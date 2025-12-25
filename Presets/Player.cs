using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Neggatrix.Core;
using Neggatrix.Components;
using Neggatrix.Interfaces;

namespace Neggatrix.Presets
{
    public class Player : GameObject
    {
        public float Health { get; set; }

        public Transform transform;
        public PolygonRenderer renderer;
        public BoxCollider collider;
        public PhysicsBody physicsBody;
        public Animator animator;
        public Camera camera;
        public IMovement movement;

        public Player(PointF position, Color color, SizeF size)
        {
            Health = 100.0f;
            transform = AddComponent<Transform>();
            transform.Position = position;

            renderer = AddComponent<PolygonRenderer>();
            renderer.FillColor = color;
            renderer.Vertices = new PointF[]
            {
                new PointF(-25, -25),
                new PointF(25, -25),
                new PointF(25, 25),
                new PointF(-25, 25)
            };

            collider = AddComponent<BoxCollider>();
            collider.Size = size;

            physicsBody = AddComponent<PhysicsBody>();

            animator = AddComponent<Animator>();

            camera = AddComponent<Camera>();

            movement = AddComponent<KBPMovement>();
        }

        public void TakeDamage(float amount)
        {
            Health -= amount;
            if (Health < 0) Health = 0;
        }
        public void PowerUp(float amount)
        {
            Health += amount;
            if (Health > 100) Health = 100;
        }
    }
}
