using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class Main_Level:Level
    {

        private GameEngine engine;

        public bool music = true;
        Bitmap spelen = new Bitmap("spelen.png");
        Audio thema = new Audio("Olympics 2018 OBS theme song.mp3");

        public Main_Level()
        {
            engine = GameEngine.GetInstance();
        }

        public override void OnEnter()
        {
            thema.Reset();
            thema.IsLooping();
            engine.PlayAudio(thema);
        }

        public override void OnExit()
        {
            engine.StopAudio(thema);
        }

        override public void Update()
        {
            if (engine.GetKeyDown(Key.Q))
            {
                Environment.Exit(1);
            }
        }

        override public void Paint()
        {
            engine.SetBackgroundColor(Color.AppelBlauwZeeGroen);
            engine.SetColor(Color.Black);
            engine.DrawBitmap(spelen, 210, 0);
            engine.DrawString("press 1 for curling", 0, 0, 100, 100);
            engine.DrawString("press 2 for pool", 230, 0, 100, 100);
            engine.DrawString("press 3 for golf", 550, 0, 100, 100);
            engine.DrawString("press Q to exit the game", 260, 220, 1000, 100);
        }
    }
}
