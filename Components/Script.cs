using Neggatrix.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neggatrix.Interfaces;

namespace Neggatrix.Components
{
    public class Script : IComponent
    {
        public GameObject Owner { get; set; }

        public Script() 
        {
            Owner = null!;
        }
        public Action<float>? OnUpdate { get; set; }

        public void Update(float deltaTime)
        {
            OnUpdate?.Invoke(deltaTime);
        }

        public void Start() { }
        public void Destroy() { }
    }
}
