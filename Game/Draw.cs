using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class Draw
    {
        private GameEngine engine;
        private Collision goal;

        public Draw(Collision m_goal)
        {
            engine = GameEngine.GetInstance();
            goal = m_goal;
        }

        public void DrawPool()
        {
            goal.holepos = new Vector2f(528, 125);
            engine.SetColor(Color.Black);
            engine.SetBackgroundColor(0, 128, 0);
            engine.SetColor(139, 69, 19);
            engine.FillRectangle(0, 0, 10, 240);
            engine.FillRectangle(630, 0, 10, 240);
            engine.FillRectangle(0, 0, 640, 10);
            engine.FillRectangle(0, 230, 640, 10);
        }

        public void DrawCurling()
        {
            engine.SetColor(Color.Black);
            engine.DrawString(goal.score.ToString(), 10, 10, 100, 100);
            engine.SetBackgroundColor(165, 242, 243);
            engine.SetColor(Color.White);
            engine.FillEllipse(500, 125, 100, 100);
            engine.SetColor(Color.Blue);
            engine.DrawEllipse(500, 125, 100, 100, 25);
            engine.SetColor(Color.Red);
            engine.DrawEllipse(500, 125, 40, 40, 15);
        }

        public void DrawGolf()
        {
            engine.SetColor(Color.Black);
            engine.SetBackgroundColor(22, 91, 19);
            engine.SetColor(Color.Yellow);
            engine.FillRectangle(0, 0, 10, 240);
            engine.FillRectangle(630, 0, 10, 240);
            engine.FillRectangle(0, 0, 640, 10);
            engine.FillRectangle(0, 230, 640, 10);
        }
    }
}
