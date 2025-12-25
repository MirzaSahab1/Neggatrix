using Neggatrix.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Neggatrix.Core
{
    public class Game
    {
        public List<GameObject> Objects = new List<GameObject>();

        public AudioManager Audio { get; private set; }

        public LevelManager Level { get; private set; }

        public Game()
        {
            Audio = new AudioManager();
            Level = new LevelManager(this);
        }
        public void AddObject(GameObject obj)
        {
            obj.Scene = this;
            Objects.Add(obj);
        }
        public void Update(float deltaTime)
        {
            foreach (var go in Objects)
            {
                go.Update(deltaTime);
            }
        }
        public void Render(Graphics g, int viewWidth, int viewHeight)
        {
            var cameraObj = Objects.FirstOrDefault(go => go.GetComponent<Camera>() != null);
            var camera = cameraObj?.GetComponent<Camera>();
            if (camera != null)
            {
                g.TranslateTransform(viewWidth / 2, viewHeight / 2);
                g.ScaleTransform(camera.Zoom, camera.Zoom);


                g.TranslateTransform(-camera.Position.X + camera.CurrentShake.X, -camera.Position.Y + camera.CurrentShake.Y);
            }
       

            foreach (var go in Objects)
            {
                // Inside Game.Render loop:
                go.Render(g);
            }
            g.ResetTransform();
        }
    }
}
