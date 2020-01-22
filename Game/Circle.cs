using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class Circle
    {
        protected GameEngine engine;
        protected Vector2f pos;
        protected float straal;
        public Circle(Vector2f position, float radius)
        {
            engine = GameEngine.GetInstance();
            straal = radius;
            pos = position;
        }

        public virtual void OnCollisionEnter(Circle collider2)
        {

        }

        public virtual void Steen_Physics()
        {

        }

        public virtual void Draw(Color ballcolor)
        {

        }

        public Vector2f GetPosition()
        {
            return pos;
        }

        public void SetPos(Vector2f newpos)
        {
            pos = newpos;
        }

        public virtual Vector2f GetVelocity()
        {
            return Vector2f.zero;
        }

        public virtual void SetVelocity(Vector2f vel)
        {

        }

        public void SetStraal(float newstraal)
        {
            straal = newstraal;
        }

        public float GetStraal()
        {
            return straal;
        }

        public virtual Curling_Steen GetClass()
        {
            return null;
        }

        public virtual void CalcFriction(Vector2f vel)
        {

        }

        public virtual bool GetShoot()
        {
            return true;
        }

        public virtual void SetShoot(bool canshoot)
        {

        }
    }
}
