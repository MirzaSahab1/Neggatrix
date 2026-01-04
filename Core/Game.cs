using Neggatrix.Common;
using Neggatrix.Components;
using Neggatrix.Interfaces;
using Neggatrix.Presets;
using Neggatrix.Presets.Levels;
using Neggatrix.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using MessageBox = Neggatrix.Scenes.MessageBox;

namespace Neggatrix.Core
{
    public class Game
    {
        public List<GameObject> Objects = new List<GameObject>();
        public GamePlay gamePlayForm { get; set; }

        public bool IsPaused { get; set; }
        public bool IsStopped { get; set; }

        public AudioManager Audio { get; private set; }

        public LevelManager Level { get; private set; }

        private MessageBox mb;

        public Game(GamePlay gamePlay)
        {
            IsPaused = false;
            IsStopped = false;
            Audio = new AudioManager();
            Level = new LevelManager(this);
            gamePlayForm = gamePlay;
            mb = new MessageBox("Paused", "Resume");
            
        }
        public void AddObject(GameObject obj)
        {
            obj.Game = this;
            Objects.Add(obj);
        }

        public void Start(string level)
        {
            Audio.MusicVolume = float.Parse(FileUtils.GetField("data.txt", 2));
            Audio.SfxVolume = float.Parse(FileUtils.GetField("data.txt", 3));
            Audio.PlayMusic("D:\\Neggatrix\\Neggatrix\\Assets\\Audio\\BackgroundMusic.mp3");

            ILevel startLevel;
            if (level == "1") startLevel = new LevelOne();
            else if (level == "2") startLevel = new LevelTwo();
            else if (level == "3") startLevel = new LevelThree();
            else if (level == "4") startLevel = new LevelFour();
            else if (level == "5") startLevel = new LevelFive();
            else startLevel = new LevelOne();

            Level.LoadLevel(startLevel);
            // Player
            Player player = new Player(new PointF(0, -200), Color.Black, new SizeF(50, 50), int.Parse(level));
            player.Name = "Player";

            AddObject(player);
        }

        public void Update(float deltaTime)
        {
            if (Input.IsPressed(Keys.Escape))
            {
                IsPaused = !IsPaused;
                mb.PauseStatus = true;
            }
            if (IsPaused)
            {
                IsPaused = mb.PauseStatus;
                mb.Location = new Point(gamePlayForm.Width / 4, gamePlayForm.Height / 4);
                gamePlayForm.Controls.Add(mb);
            }
            if (!IsPaused)
            {
                gamePlayForm.Controls.Remove(mb);
                gamePlayForm.Focus();
            }
            foreach (var go in Objects.ToList())
            {
                go.Update(IsPaused || IsStopped ? 0 : deltaTime);
            }
        }
        public void Restart()
        {
            Objects.Clear();
            IsPaused = false;
            IsStopped = false;
            Audio = new AudioManager();
            Audio.MusicVolume = float.Parse(FileUtils.GetField("data.txt", 2));
            Audio.SfxVolume = float.Parse(FileUtils.GetField("data.txt", 3));
            Audio.PlaySound("D:\\Neggatrix\\Neggatrix\\Assets\\Audio\\Death.mp3");

            //Level = new LevelManager(this);
            //mb = new MessageBox("Paused", "Resume");
            string level = "1";
            if (Level.currentLevel is LevelOne) level = "1";
            else if (Level.currentLevel is LevelTwo) level = "2";
            else if (Level.currentLevel is LevelThree) level = "3";
            else if (Level.currentLevel is LevelFour) level = "4";
            else if (Level.currentLevel is LevelFive) level = "5";
            Start(level);
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
                go.Render(g);
            }
            g.ResetTransform();
        }
    }
}
