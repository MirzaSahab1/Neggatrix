using Neggatrix.Common;
using Neggatrix.Components;
using Neggatrix.Core;
using Neggatrix.Interfaces;
using Neggatrix.Presets.Levels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

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
        public Script script;

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

            script = AddComponent<Script>();
            script.OnUpdate = (deltaTime) =>
            {
                movement.Move();

                foreach (var hitObject in physicsBody.ActiveCollisions)
                {
                    if (hitObject.Name == "LevelExit")
                    {
                        transform.Position = new PointF(0, -200);
                        camera.Start();
                        Scene.Level.LoadLevel(new LevelTwo());
                    }
                }

                if (Input.IsDown(Keys.W) && physicsBody.IsGrounded)
                {
                    animator.AddTrack("Transform", "Rotation", 0f, 360f, 1f, true, () => !physicsBody.IsGrounded);
                }
            };
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
