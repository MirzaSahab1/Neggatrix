using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Neggatrix.Core;
using Neggatrix.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace Neggatrix.Components
{
    // Owner must have Transform component
    public class Renderer : IComponent, IRenderable
    {
        public required GameObject Owner { get; set; }

        public Image? Sprite { get; set; }
        public Color BGColor { get; set; }


        public SizeF Size { get; set; }
        public PointF Offset { get; set; }

        private Transform? _transform;

        [SetsRequiredMembers]
        public Renderer() 
        {
            Owner = null!;
            BGColor = Color.Transparent;
            Size = new SizeF(64f, 64f);
            Offset = new PointF(0, 0);
        }

        public void Start () 
        {
            _transform = Owner.GetComponent<Transform>();
        }

        public void Render(Graphics g)
        {
            if (_transform == null) return;

            var state = g.Save();

            // 1. Move to World Position
            g.TranslateTransform(_transform.Position.X, _transform.Position.Y);

            // 2. Rotate
            g.RotateTransform(_transform.Rotation);

            // 3. Apply Local Offset (NEW CODE)
            // We multiply by Scale so the offset grows if the object grows
            g.TranslateTransform(
                Offset.X * _transform.Scale.X,
                Offset.Y * _transform.Scale.Y
            );

            // 4. Calculate Size
            SizeF finalSize = new SizeF(
                Size.Width * _transform.Scale.X,
                Size.Height * _transform.Scale.Y
            );

            // 5. Calculate Draw Rect (Relative to the new Offset center)
            RectangleF relativeRect = new RectangleF(
                -(_transform.Pivot.X * finalSize.Width),
                -(_transform.Pivot.Y * finalSize.Height),
                finalSize.Width,
                finalSize.Height
            );

            // 6. Draw
            if (BGColor != Color.Transparent)
            {
                using (Brush bgBrush = new SolidBrush(BGColor))
                    g.FillRectangle(bgBrush, relativeRect);
            }

            if (Sprite != null)
            {
                g.DrawImage(Sprite, relativeRect);
            }

            g.Restore(state);
        }
        public void Update (float deltaTime) { }
        public void Destroy () { }

    }
}
