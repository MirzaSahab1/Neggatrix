using Neggatrix.Core;
using Neggatrix.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neggatrix.Components
{
    public class PolygonCollider : IComponent
    {
        public GameObject Owner { get; set; } = null!;

        // 1. The Local Shape (Defined around 0,0)
        // Keep this simple (e.g., a 100x100 square)
        public PointF[] Vertices { get; set; } = new PointF[0];

        // 2. Trigger Flag (For Coins, Portals, etc.)
        public bool IsTrigger { get; set; } = false;

        // 3. Dynamic Property: Calculates where the vertices actually ARE on screen
        // This applies Position + Rotation + Scale
        public PointF[] WorldVertices
        {
            get
            {
                var t = Owner.GetComponent<Transform>();
                if (t == null) return Vertices;

                PointF[] worldVerts = new PointF[Vertices.Length];

                // Pre-calculate Rotation Math
                float rads = t.Rotation * (MathF.PI / 180.0f);
                float cos = MathF.Cos(rads);
                float sin = MathF.Sin(rads);

                for (int i = 0; i < Vertices.Length; i++)
                {
                    // A. Apply Scale
                    float sx = Vertices[i].X * t.Scale.X;
                    float sy = Vertices[i].Y * t.Scale.Y;

                    // B. Apply Rotation
                    float rx = sx * cos - sy * sin;
                    float ry = sx * sin + sy * cos;

                    // C. Apply Translation (Position)
                    worldVerts[i] = new PointF(rx + t.Position.X, ry + t.Position.Y);
                }
                return worldVerts;
            }
        }

        // 4. Bounds (Required for PhysicsBody Broad Phase)
        // Calculates a flat box around the rotated polygon
        public RectangleF Bounds
        {
            get
            {
                var verts = WorldVertices;
                if (verts.Length == 0) return RectangleF.Empty;

                float minX = verts[0].X, maxX = verts[0].X;
                float minY = verts[0].Y, maxY = verts[0].Y;

                foreach (var v in verts)
                {
                    if (v.X < minX) minX = v.X;
                    if (v.X > maxX) maxX = v.X;
                    if (v.Y < minY) minY = v.Y;
                    if (v.Y > maxY) maxY = v.Y;
                }

                return new RectangleF(minX, minY, maxX - minX, maxY - minY);
            }
        }

        // 5. The Actual "Is Point Inside" Check (Ray Casting Algorithm)
        // Now we check against WorldVertices, so it matches what you see on screen.
        public bool IsPointInside(PointF worldPoint)
        {
            var verts = WorldVertices;
            bool isInside = false;
            int j = verts.Length - 1;

            for (int i = 0; i < verts.Length; i++)
            {
                // This is the "Ray Casting" math
                if ((verts[i].Y > worldPoint.Y) != (verts[j].Y > worldPoint.Y) &&
                     worldPoint.X < (verts[j].X - verts[i].X) * (worldPoint.Y - verts[i].Y) / (verts[j].Y - verts[i].Y) + verts[i].X)
                {
                    isInside = !isInside;
                }
                j = i;
            }
            return isInside;
        }

        public void Start() { }
        public void Update(float deltaTime) { }
        public void Destroy() { }
    }
}
