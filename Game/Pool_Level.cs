using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class Pool_Level : Level
    {
        private GameEngine engine;

        private Curling_Steen ball = new Curling_Steen(25, new Vector2f(200, 125), 12, false);
        private Curling_Steen ball2 = new Curling_Steen(25, new Vector2f(450, 125), 12, true);
        private Curling_Steen ball3 = new Curling_Steen(25, new Vector2f(485, 110), 12, true);
        private Curling_Steen ball4 = new Curling_Steen(25, new Vector2f(485, 140), 12, true);
        private Curling_Steen ball5 = new Curling_Steen(25, new Vector2f(520, 90), 12, true);
        private Curling_Steen ball6 = new Curling_Steen(25, new Vector2f(520, 125), 12, true);
        private Curling_Steen ball7 = new Curling_Steen(25, new Vector2f(520, 160), 12, true);
        private Collision col = new Collision();
        private Draw paint;
        private Physics_World physics = new Physics_World();
        List<Circle> balls = new List<Circle>();
        List<Hole> holes = new List<Hole>();
        List<Color> ballcolor = new List<Color>();
        public Pool_Level(Color color)
        {
            engine = GameEngine.GetInstance();
            paint = new Draw(col);
            holes.Add(new Hole(this, new Vector2f(13, 8), 15));
            holes.Add(new Hole(this, new Vector2f(627, 8), 15));
            holes.Add(new Hole(this, new Vector2f(320, 8), 15));
            holes.Add(new Hole(this, new Vector2f(13, 232), 15));
            holes.Add(new Hole(this, new Vector2f(627, 232), 15));
            holes.Add(new Hole(this, new Vector2f(320, 232), 15));
            Random rand = new Random();
            balls.Add(ball);
            balls.Add(ball2);
            balls.Add(ball3);
            balls.Add(ball4);
            balls.Add(ball5);
            balls.Add(ball6);
            balls.Add(ball7);
            for (int i = 0; i < holes.Count; i++)
            {
                physics.AddCollider(holes[i]);
            }
            for (int i = 0; i < balls.Count; i++)
            {
                physics.AddCollider(balls[i]);
            }
            ballcolor.Add(Color.White);
            for (int i = 1; i < balls.Count; i++)
            {
                int r = rand.Next(0, 255);
                int g = rand.Next(0, 255);
                int b = rand.Next(0, 255);
                ballcolor.Add(new Color(r, g, b));
            }
        }

        override public void Update()
        {
            for (int i = 0; i < balls.Count; i++)
            {
                balls[i].Steen_Physics();
                col.PoolWall(balls[i]);
            }
            physics.Update();
            if (engine.GetKeyDown(Key.S))
            {
                for (int i = 0; i < balls.Count; i++)
                {
                    if (balls[i].GetShoot() == false)
                    {
                        balls[i].SetShoot(true);
                        if (i + 1 < balls.Count)
                        {
                            balls[i + 1].SetShoot(false);
                        }
                        else
                        {
                            balls[0].SetShoot(false);
                        }
                        return;
                    }
                }
            }
        }

        override public void Paint()
        {
            paint.DrawPool();
            for (int i = 0; i < holes.Count; i++)
            {
                holes[i].HolePaint();
            }
            for (int i = 0; i < balls.Count; i++)
            {
                balls[i].Draw(ballcolor[i]);
            }
        }

        //Functie om de bal te verwijderen
        override public void DeleteBall(Circle deleted_ball)
        {
            balls.Remove(deleted_ball);
            int num = 0;
            for (int i = 0; i < balls.Count; i++)
            {
                if (balls[i].GetShoot() == false)
                {
                    num++;
                }
                if (num == 0)
                {
                    balls[0].SetShoot(false);
                }
            }
        }
    }
}
