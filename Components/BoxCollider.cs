using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neggatrix.Components
{
    public class BoxCollider : Collider
    {
        public SizeF Size { get; set; }
        public override RectangleF Bounds
        {
            get
            {
                var transform = Owner.GetComponent<Transform>();
                if (transform == null) return RectangleF.Empty;

                float width = Size.Width * transform.Scale.X;
                float height = Size.Height * transform.Scale.Y;

                float x = transform.Position.X + Offset.X - (width * transform.Pivot.X);
                float y = transform.Position.Y + Offset.Y - (height * transform.Pivot.Y);

                return new RectangleF(x, y, width, height);
            }
        }
        [SetsRequiredMembers]
        public BoxCollider()
        {
            Size = new SizeF(64f, 64f);
        }
    }
}
