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
        public int Score { get; private set; }
        public int level { get; private set; }

        public Transform transform;
        public PolygonRenderer renderer;
        public BoxCollider collider;
        public PhysicsBody physicsBody;
        public Animator animator;
        public Camera camera;
        public IMovement movement;
        public Time timer;
        public Script script;

        public Player(PointF position, Color color, SizeF size, int level)
        {
            this.level = level;
            Health = 100.0f;
            Score = 0;
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
            camera.Zoom = 0.5f;

            movement = AddComponent<KBPMovement>();

            timer = AddComponent<Time>();
            timer.Duration = 10f;

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
                        if (level == 1)
                        {
                            Game?.Level.LoadLevel(new LevelTwo());
                            level++;
                        }
                        else if (level == 2)
                        {
                            Game?.Level.LoadLevel(new LevelThree());
                            level++;
                        }
                        else if (level == 3)
                        {
                            Game?.Level?.LoadLevel(new LevelFour());
                            level++;
                        }
                        else if (level == 4)
                        {
                            Game?.Level?.LoadLevel(new LevelFive());
                            level++;
                        }
                    }
                    if (hitObject.Name == "RedOrb")
                    {
                        renderer.FillColor = Color.Red;
                        timer.Play();
                        Game?.Objects.Remove(hitObject);
                    }
                    else if (hitObject.Name == "BlueOrb")
                    {
                        renderer.FillColor = Color.Blue;
                        timer.Play();
                        Game?.Objects.Remove(hitObject);
                    }
                    else if (hitObject.Name == "GreenOrb")
                    {
                        renderer.FillColor = Color.Green;
                        timer.Play();
                        Game?.Objects.Remove(hitObject);
                    }
                    else if (hitObject.Name == "ScorePoint")
                    {
                        ScorePoint point = (ScorePoint)hitObject;
                        Score += point.Score;
                        Game?.Objects.Remove(hitObject);
                        if (Game != null) Game.gamePlayForm.score.Text += point.Score;
                    }
                }

                if (timer.IsFinished) { renderer.FillColor = Color.Black; timer.Stop(); }

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
