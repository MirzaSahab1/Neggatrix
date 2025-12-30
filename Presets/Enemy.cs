using Neggatrix.Common;
using Neggatrix.Components;
using Neggatrix.Core;
using Neggatrix.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neggatrix.Scenes;
using MessageBox = Neggatrix.Scenes.MessageBox;

namespace Neggatrix.Presets
{
    public class Enemy : GameObject
    {
        public Transform transform;
        public PhysicsBody physicsBody;
        public PolygonRenderer bodyRenderer;
        public Renderer eyeRenderer;
        public PolygonRenderer coneRenderer;
        public PolygonCollider coneCollider;
        public Animator animator;
        public PatrolMovement movement;
        public Script script;

        private MessageBox mb { get; set; }
        public float Range { get; private set; }

        private GameObject? _cachedPlayer;
        public Enemy(PointF startPos, Color eyecolor, float range, float speed, float height = 0)
        {
            Name = "Sentinel";
            Range = range;
            mb = new MessageBox("You got Deleted!", "Restart");
            mb.exitButton.Click += mb.exitButton_Click;

            transform = AddComponent<Transform>();
            transform.Position = startPos;
            transform.Scale = new PointF(1.0f, 1.0f);

            physicsBody = AddComponent<PhysicsBody>();
            physicsBody.GravityScale = 0f;
            physicsBody.Friction = 0.9f;

            bodyRenderer = AddComponent<PolygonRenderer>();
            bodyRenderer.FillColor = Color.Black;
            bodyRenderer.Vertices = new PointF[] {
                new PointF(0, -40),   // Top Center
                new PointF(30, -60),  // Right Horn Tip
                new PointF(20, -20),  // Right Shoulder
                new PointF(40, 0),    // Right Wing
                new PointF(0, 30),    // Bottom Point
                new PointF(-40, 0),   // Left Wing
                new PointF(-20, -20), // Left Shoulder
                new PointF(-30, -60)  // Left Horn Tip
            };

            eyeRenderer = AddComponent<Renderer>();
            eyeRenderer.BGColor = eyecolor;
            eyeRenderer.Size = new SizeF(10, 10);
            eyeRenderer.Offset = new PointF(0, -10);

            if (height == 0) height = (float)Utils.Distance(transform.Position, new PointF(startPos.X, 0)) - 25;
            float radAngle = (30 / 2) * (MathF.PI / 180);
            float b = (float)(2 * height * MathF.Tan(radAngle));
            float r = b / 2;

            coneRenderer = AddComponent<PolygonRenderer>();
            coneRenderer.FillColor = Color.FromArgb(128, eyecolor);
            coneRenderer.Vertices = new PointF[] {
                new PointF(5, -5),
                new PointF(-5, -5),// Tip
                new PointF(-b, height),  // Base Right
                new PointF(b, height)  // Base Left
            };

            coneCollider = AddComponent<PolygonCollider>();
            coneCollider.IsTrigger = true;
            coneCollider.Vertices = coneRenderer.Vertices;

            animator = AddComponent<Animator>();

            movement = AddComponent<PatrolMovement>();
            movement.StartPoint = transform.Position.X;
            movement.EndPoint = transform.Position.X + Range;
            movement.Speed = speed;

            script = AddComponent<Script>();
            script.OnUpdate = (deltaTime) =>
            {
                movement.Move();
                Player player = (Player)Game.Objects.FirstOrDefault(o => o is Player);
                    
                var playerCol = player.GetComponent<BoxCollider>();
                if (playerCol == null) return;

                
                if (!coneCollider.Bounds.IntersectsWith(playerCol.Bounds)) return;

                RectangleF pBounds = playerCol.Bounds;

                PointF[] checkPoints = new PointF[] {
                    new PointF(pBounds.Left, pBounds.Top),     // Top-Left
                    new PointF(pBounds.Right, pBounds.Top),    // Top-Right
                    new PointF(pBounds.Left, pBounds.Bottom),  // Bottom-Left
                    new PointF(pBounds.Right, pBounds.Bottom)  // Bottom-Right
                };

                bool spotted = false;
                foreach (var point in checkPoints)
                {
                    bool v = coneCollider.IsPointInside(point);
                    if (v)
                    {
                        spotted = true;
                        break;
                    }
                }

               
                if (spotted && player.renderer.FillColor.ToArgb() != eyeRenderer.BGColor.ToArgb() && !Game.IsPaused)
                {

                    // mb.Location = new Point(Game.gamePlayForm.Width / 4, Game.gamePlayForm.Height / 4);
                    //Game.gamePlayForm.Controls.Add(mb);
                    //Game.IsStopped = true;
                    Game.Restart();
                }
            };
        }
    }
}
