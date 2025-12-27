using Neggatrix.Core;
using Neggatrix.Interfaces;
using Neggatrix.Presets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neggatrix.Components
{
    public class PatrolMovement : IMovement, IComponent
    {
        public GameObject Owner { get; set; }

        public float StartPoint { get; set; }
        public float EndPoint { get; set; }
        public float Speed { get; set; }

        private bool _movingRight;
        private float _lastDeltaTime;

        public PatrolMovement()
        {
            Owner = null!;
            Speed = 100f;
            _lastDeltaTime = 0.016f;
            _movingRight = true;
        }
        public void Move()
        {
            var transform = Owner.GetComponent<Transform>();
            if (transform == null) return;

            float step = Speed * _lastDeltaTime;

            if (_movingRight)
            {
                if (transform.Position.X >= EndPoint)
                {
                    _movingRight = false;
                }
            }
            else
            {
                if (transform.Position.X <= StartPoint)
                {
                    _movingRight = true;
                }
            }

            float newX = _movingRight ? transform.Position.X + step : transform.Position.X - step;

            transform.Position = new PointF(newX, transform.Position.Y);
        }
        public void Start() { }

        public void Update(float deltaTime)
        {
            _lastDeltaTime = deltaTime;
        }

        public void Destroy() { }
    }
}
