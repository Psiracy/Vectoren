using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class Curling_Level: Level
    {
        private GameEngine engine;

        private Curling_Steen ball=new Curling_Steen(45, new Vector2f(150, 125), 15, false); 
        private Collision collision = new Collision();
        private Color ballcolor;
        private Draw paint;

        public Curling_Level(Color color)
        {
            engine = GameEngine.GetInstance();
            paint = new Draw(collision);
            ballcolor = color;
        }

        override public void Update()
        {
            ball.Steen_Physics();
            collision.Currling(ball);
        }

        override public void Paint()
        {
            paint.DrawCurling();
            if (collision.collision == false)
            {
                ball.Draw(ballcolor);
            }
        }
    }
}
