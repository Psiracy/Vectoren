using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class Golf_Level:Level
    {
        private GameEngine engine;
        private Curling_Steen ball = new Curling_Steen(45, new Vector2f(150, 125), 15, false);
        private Collision col = new Collision();
        private Draw paint;
        private Color ballcolor;
        private Hole hole;
        private Physics_World physics = new Physics_World();
        List<Circle> balls = new List<Circle>();
        public Golf_Level(Color color)
        {
            engine = GameEngine.GetInstance();
            paint = new Draw(col);
            ballcolor = color;
            hole = new Hole(this, new Vector2f(528, 125), 15);
            balls.Add(ball);
            physics.AddCollider(hole);
            physics.AddCollider(ball);
        }
        public override void OnEnter()
        {
        }

        public override void OnExit()
        {
        }

        override public void Update()
        {
            for (int i = 0; i < balls.Count; i++)
            {
                balls[i].Steen_Physics();
                col.PoolWall(balls[i]);
            }
            physics.Update();
        }

        override public void Paint()
        {
            hole.HolePaint();
            paint.DrawGolf();
            for (int i = 0; i < balls.Count; i++)
            {
                balls[i].Draw(ballcolor);
            }
        }

        override public void DeleteBall(Circle deleted_ball)
        {
            balls.Remove(deleted_ball);
        }
    }
}
