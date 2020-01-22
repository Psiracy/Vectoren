using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class Physics_World
    {
        List<Circle> colliders = new List<Circle>();

        Vector2f line;

        //coliders
        public void AddCollider(Circle collider)
        {
            colliders.Add(collider);
        }

        //update
        public void Update()
        {
            for (int a = 0; a < colliders.Count - 1; a++)
            {
                for (int b = a+1; b < colliders.Count; b++)
                {
                    //calculate collider      
                    line = new Vector2f(colliders[a].GetPosition().X - colliders[b].GetPosition().X, colliders[a].GetPosition().Y - colliders[b].GetPosition().Y);
                    float straal = colliders[a].GetStraal();
                    float straal2 = colliders[b].GetStraal();
                    if (CalcLength(line) < straal + straal2)
                    {
                        //ontriggerstay
                        colliders[a].OnCollisionEnter(colliders[b]);
                    }
                }
            }
        }

        //calculate length
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
