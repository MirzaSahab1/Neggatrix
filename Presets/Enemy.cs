using Neggatrix.Components;
using Neggatrix.Core;
using Neggatrix.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Script script;

        private GameObject? _cachedPlayer;
        public Enemy(PointF startPos, IMovement movementLogic)
        {
            Name = "Sentinel";

            transform = AddComponent<Transform>();
            transform.Position = startPos;
            transform.Scale = new PointF(1.0f, 1.0f); 

            physicsBody = AddComponent<PhysicsBody>();
            physicsBody.GravityScale = 0f; 
            physicsBody.Friction = 0.9f;

            bodyRenderer = AddComponent<PolygonRenderer>();
            bodyRenderer.FillColor = Color.FromArgb(50, 20, 25); 
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
            eyeRenderer.BGColor = Color.FromArgb(200, 255, 0, 50); 
            eyeRenderer.Size = new SizeF(10, 10);
            eyeRenderer.Offset = new PointF(0, -10); 

            coneRenderer = AddComponent<PolygonRenderer>();
            coneRenderer.FillColor = Color.FromArgb(100, 255, 0, 50); 
            coneRenderer.Vertices = new PointF[] {
                new PointF(5, -5),
                new PointF(-5, -5),// Tip
                new PointF(-200, 400),  // Base Right
                new PointF(200, 400)  // Base Left
            };

            coneCollider = AddComponent<PolygonCollider>();
            coneCollider.IsTrigger = true;
            coneCollider.Vertices = coneRenderer.Vertices;

            animator = AddComponent<Animator>();

            script = AddComponent<Script>();
            script.OnUpdate = (deltaTime) =>
            {
                if (_cachedPlayer == null)
                {
                    _cachedPlayer = Scene.Objects.FirstOrDefault(o => o.Name == "Player");
                    if (_cachedPlayer == null) return;
                }

               
                var playerCol = _cachedPlayer.GetComponent<BoxCollider>();
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

               
                if (spotted)
                {
                    var myRenderer = GetComponent<PolygonRenderer>(); 
                    myRenderer.FillColor = Color.FromArgb(128, 0, 255, 0);               
                    Console.WriteLine("PLAYER DETECTED!");
                }
            };
        }
    }
}
