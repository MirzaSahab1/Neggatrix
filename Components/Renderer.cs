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

            var state = g.Save();

            g.TranslateTransform(_transform.Position.X, _transform.Position.Y);

            g.RotateTransform(_transform.Rotation);

            SizeF finalSize = new SizeF(
                Size.Width * _transform.Scale.X,
                Size.Height * _transform.Scale.Y
            );

            RectangleF relativeRect = new RectangleF(
                -(_transform.Pivot.X * finalSize.Width),
                -(_transform.Pivot.Y * finalSize.Height),
                finalSize.Width,
                finalSize.Height
            );

            if (BGColor.HasValue && BGColor.Value.A > 0)
            {
                using (Brush bgBrush = new SolidBrush(BGColor.Value))
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
