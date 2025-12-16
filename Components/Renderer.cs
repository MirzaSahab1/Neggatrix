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
    public class Renderer : IComponent, IRenderable
    {
        public required GameObject Owner { get; set; }

        public Image? Sprite { get; set; }
        public Color? BGColor { get; set; }

        public SizeF Size { get; set; }

        private Transform? _transform;

        [SetsRequiredMembers]
        public Renderer() 
        {
            Owner = null!;
            BGColor = Color.Transparent;
            Size = new SizeF(64f, 64f);
        }

        public void Start () 
        {
            _transform = Owner.GetComponent<Transform>();
        }

        public void Render (Graphics g)
        {
            if (_transform == null) return;

            // 1. Save the current state of the graphics (to avoid affecting other objects)
            var state = g.Save();

            // 2. Move the coordinate system to the GameObject's position
            g.TranslateTransform(_transform.Position.X, _transform.Position.Y);

            // 3. Rotate the coordinate system
            g.RotateTransform(_transform.Rotation);

            // 4. Calculate the Draw Area relative to (0,0)
            // We only need to account for Pivot and Scale here
            SizeF finalSize = new SizeF(
                Size.Width * _transform.Scale.X,
                Size.Height * _transform.Scale.Y
            );

            // This rectangle is centered (or pivoted) around (0,0)
            RectangleF relativeRect = new RectangleF(
                -(_transform.Pivot.X * finalSize.Width),
                -(_transform.Pivot.Y * finalSize.Height),
                finalSize.Width,
                finalSize.Height
            );

            // 5. Draw
            if (BGColor.HasValue && BGColor.Value.A > 0)
            {
                using (Brush bgBrush = new SolidBrush(BGColor.Value))
                    g.FillRectangle(bgBrush, relativeRect);
            }

            if (Sprite != null)
            {
                g.DrawImage(Sprite, relativeRect);
            }

            // 6. Restore the state for the next object
            g.Restore(state);
        }
        public void Update (float deltaTime) { }
        public void Destroy () { }

    }
}
