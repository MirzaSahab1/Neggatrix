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
        public Enemy(PointF startPos, IMovement movementLogic)
        {
            Name = "Sentinel";

            // 1. TRANSFORM
            transform = AddComponent<Transform>();
            transform.Position = startPos;
            transform.Scale = new PointF(1.0f, 1.0f); // Important for breathing animation

            // 2. PHYSICS
            physicsBody = AddComponent<PhysicsBody>();
            physicsBody.GravityScale = 0f; // It floats!
            physicsBody.Friction = 0.9f;

            // 3. MAIN BODY (The "Horned" Shadow)
            bodyRenderer = AddComponent<PolygonRenderer>();
            bodyRenderer.FillColor = Color.FromArgb(50, 20, 25); // Almost black
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

            // 4. THE GLOWING EYE (Scanning Red Light)
            eyeRenderer = AddComponent<Renderer>();
            eyeRenderer.BGColor = Color.FromArgb(200, 255, 0, 50); // Bright Red
            eyeRenderer.Size = new SizeF(10, 10);
            eyeRenderer.Offset = new PointF(0, -10); // Start at center of face

            coneRenderer = AddComponent<PolygonRenderer>();
            coneRenderer.FillColor = Color.FromArgb(100, 255, 0, 50); // Semi-Transparent Red
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
        }
    }
}
