using Neggatrix.Core;
using Neggatrix.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neggatrix.Components
{
    public class PatrolMovement : IMovement, IComponent
    {
        public GameObject Owner {  get; set; }

        public void Move()
        {

        }

        public void Start() { }
        public void Update(float deltaTime) { }
        public void Destroy() { }
    }
}
