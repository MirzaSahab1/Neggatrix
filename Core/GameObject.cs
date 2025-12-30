using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neggatrix.Interfaces;

namespace Neggatrix.Core
{
    public class GameObject
    {
        public Game? Game { get; set; }
        public string Name { get; set; } = "GameObject";
        private List<IComponent> _components = new List<IComponent>();

        
        public T AddComponent<T>() where T : IComponent, new()
        {
            T component = new T{ Owner = this};
            component.Owner = this;
            _components.Add(component);
            component.Start();
            return component;
        }

        public void RemoveComponent(IComponent component)
        {
            _components.Remove(component);
        }

        public T GetComponent<T>()
        {
            return _components.OfType<T>().FirstOrDefault();
        }

        public IComponent GetComponentByName(string name)
        {
            return _components.FirstOrDefault(c => c.GetType().Name == name);
        }
        public void Update(float deltaTime)
        {
            foreach (var component in _components)
            {
                component.Update(deltaTime);
            }
        }
        public void Render(System.Drawing.Graphics g)
        {
            foreach (var component in _components)
            {
                if (component is IRenderable renderable)
                {
                    renderable.Render(g);
                }
            }
        }
    }
}
