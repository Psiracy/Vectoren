using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Gameplay_Vectoren : AbstractGame
    {
        private List<Level> levels = null;
        int level = 0;
        bool start = true;

        public enum Levels
        {
            Main,
            Curling,
            Pool,
            Golf
        }

        public override void GameStart()
        {
            //Everything that has to happen when the game starts happens here.

            levels = new List<Level>();

            levels.Add(new Main_Level());
            levels.Add(new Curling_Level(Color.Yellow));
            levels.Add(new Pool_Level(Color.White));
            levels.Add(new Golf_Level(Color.White));
        }

        public override void GameEnd()
        {
            //Clean up unmanaged objects here (F.e. bitmaps & fonts)
            levels.Clear();
        }

        public override void Update()
        {
            //Update everything here.
            if (GAME_ENGINE.GetMouseButtonDown(1))
            {
                Console.WriteLine(GAME_ENGINE.GetMousePosition().X);
                Console.WriteLine(GAME_ENGINE.GetMousePosition().Y);
                Console.WriteLine(level);
            }

            if (start == true)
            {
                levels[level].OnEnter();
                start = false;
            }

            if (GAME_ENGINE.GetKeyDown(Key.Escape))
            {
                levels[level].OnExit();
                level = (int)Levels.Main;
                levels[level].OnEnter();
            }
            if (GAME_ENGINE.GetKeyDown(Key.D1))
            {
                levels[level].OnExit();
                level = (int)Levels.Curling;
                levels[level].OnEnter();
            }
            if (GAME_ENGINE.GetKeyDown(Key.D2))
            {
                levels[level].OnExit();
                level = (int)Levels.Pool;
                levels[level].OnEnter();
            }
            if (GAME_ENGINE.GetKeyDown(Key.D3))
            {
                levels[level].OnExit();
                level = (int)Levels.Golf;
                levels[level].OnEnter();
            }

            levels[level].Update();
        }

        public override void Paint()
        {
            //Draw everything here.
            levels[level].Paint();
        }
    }
}
