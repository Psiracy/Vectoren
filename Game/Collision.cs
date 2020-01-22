using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class Collision
    {
        private GameEngine engine;
        public Vector2f holepos = new Vector2f(528, 125);
        int straal = 0;
        int straal2 = 0;
        public int score;
        public bool collision = false;
        public Collision()
        {
            engine = GameEngine.GetInstance();
        }

        public void Currling(Curling_Steen steen)
        {
            holepos = new Vector2f(500, 125);
            Vector2f line = new Vector2f(holepos.X - steen.GetPosition().X, holepos.Y - steen.GetPosition().Y);
            straal = 15;
            straal2 = 20;
            if (CalcLength(line) < straal + straal2 && steen.clicked == false)
            {
                score = 3;
            }
            else if (CalcLength(line) < straal + straal2+60 && steen.clicked == false)
            {
                score = 2;
            }
            else if (CalcLength(line) < straal + straal2 + 80 && steen.clicked == false)
            {
                score = 1;
            }
        }

        public void PoolWall(Circle poolbal)
        {
            //wall bounce
            //left
            if (poolbal.GetPosition().X < 0+(10+poolbal.GetStraal()))
            {
                poolbal.GetClass().velocity.X *= -1;
                poolbal.GetClass().friction.X *= -1;
            }
            //right
            if (poolbal.GetPosition().X > 640-(10 + poolbal.GetStraal()))
            {
                poolbal.GetClass().velocity.X *= -1;
                poolbal.GetClass().friction.X *= -1;
            }
            //up
            if (poolbal.GetPosition().Y < 0 + (10 + poolbal.GetStraal()))
            {
                poolbal.GetClass().velocity.Y *= -1;
                poolbal.GetClass().friction.Y *= -1;
            }
            //down
            if (poolbal.GetPosition().Y > 240 - (10 + poolbal.GetStraal()))
            {
                poolbal.GetClass().velocity.Y *= -1;
                poolbal.GetClass().friction.Y *= -1;
            }
        }

        float CalcLength(Vector2f vel)
        {
            double x = Math.Pow(vel.X, 2);
            double y = Math.Pow(vel.Y, 2);
            double ans = x + y;
            double len = Math.Sqrt(ans);
            return Convert.ToSingle(len);
        }
    }
}

