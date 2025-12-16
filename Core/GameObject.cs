using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negatrix.Interfaces;

namespace Neggatrix.Core
{
    public class GameObject
    {
        private List<IComponent> _components = new List<IComponent>();

        public void AddComponent(IComponent component)
        {
            component.Owner = this;
            _components.Add(component);
        }

        public void RemoveComponent(IComponent component)
        {
            _components.Remove(component);
        }

        public T GetComponent<T>()
        {
            return _components.OfType<T>().FirstOrDefault();
        }
    }
}
