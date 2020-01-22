using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class Curling_Steen : Circle
    {
        int mousex;
        int mousey;
        public Vector2f velocity = new Vector2f(0, 0);
        public Vector2f friction = new Vector2f(0, 0);
        public bool clicked;
        int constant = 0;
        bool checkx1;
        bool checkx2;
        bool checky1;
        bool checky2;
        protected bool shoot;

        public Curling_Steen(int con, Vector2f ballpos, float straal, bool canshoot) : base(ballpos, straal)
        {
            constant = con;
            shoot = canshoot;
        }

        override public void Steen_Physics()
        {
            //get mouseposition
            mousex = engine.GetMousePosition().X;
            mousey = engine.GetMousePosition().Y;
            float deltatime = engine.GetDeltaTime();
            //calculation velovity and friction on click
            if (engine.GetMouseButtonDown(0))
            {
                if (shoot == false)
                {
                    velocity = new Vector2f(pos.X - mousex, pos.Y - mousey);
                }
                friction = Normalize(velocity);
                friction.X *= -1;
                friction.Y *= -1;
                friction.X *= constant;
                friction.Y *= constant;
                clicked = true;
            }

            //check if pos or neg before and after you calculate the velocity
            checkx1 = CheckIfPosOrNeg(velocity.X);
            checky1 = CheckIfPosOrNeg(velocity.Y);
            velocity += new Vector2f(friction.X * deltatime, friction.Y * deltatime);
            checkx2 = CheckIfPosOrNeg(velocity.X);
            checky2 = CheckIfPosOrNeg(velocity.Y);

            //move the ball
            if (checkx1 != checkx2 || checky1 != checky2)
            {
                clicked = false;
                velocity = Vector2f.zero;
                friction = Vector2f.zero;
            }
            else if (clicked == true)
            {
                pos += new Vector2f(velocity.X * deltatime, velocity.Y * deltatime);
            }
        }

        override public void Draw(Color ballcolor)
        {
            //draw line
            if (clicked == false && shoot == false)
            {
                engine.SetColor(Color.Black);
                engine.DrawLine(pos.X, pos.Y, mousex, mousey);
            }

            //draw ball
            engine.SetColor(ballcolor);
            engine.FillEllipse(pos.X, pos.Y, straal, straal);
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

        //normalize
        Vector2f Normalize(Vector2f vel)
        {
            float len = CalcLength(vel);
            if (len != 0)
            {
                float ans1 = vel.X / len;
                float ans2 = vel.Y / len;
                Vector2f norm = new Vector2f(ans1, ans2);
                return norm;
            }
            return Vector2f.zero;
        }

        //check if positive or negitive
        bool CheckIfPosOrNeg(float velocity)
        {
            return (velocity >= 0);
        }

        override public Curling_Steen GetClass()
        {
            return this;
        }

        public void SetCanShoot(bool canshoot)
        {
            shoot = canshoot;
        }

        public override Vector2f GetVelocity()
        {
            return velocity;
        }

        public override void SetVelocity(Vector2f vel)
        {
            velocity = vel;
        }

        public override void OnCollisionEnter(Circle collider2)
        {
            //unit normal
            Vector2f un = Normalize(new Vector2f(collider2.GetPosition().X - GetPosition().X, collider2.GetPosition().Y - GetPosition().Y));
            //unit tanges
            Vector2f ut = new Vector2f(-un.Y, un.X);
            //dots
            float v1n = Dot(GetVelocity(), un);
            float v2n = Dot(collider2.GetVelocity(), un);
            float v1t = Dot(GetVelocity(), ut);
            float v2t = Dot(collider2.GetVelocity(), ut);

            //after dots
            float v1nAfter = v2n;
            float v2nAfter = v1n;

            //return to arrow
            Vector2f v1nAfterVec = new Vector2f();
            v1nAfterVec.X = v1nAfter * un.X;
            v1nAfterVec.Y = v1nAfter * un.Y;
            Vector2f v2nAfterVec = new Vector2f();
            v2nAfterVec.X = v2nAfter * un.X;
            v2nAfterVec.Y = v2nAfter * un.Y;

            //tanges vector
            Vector2f v1tAfter = new Vector2f();
            v1tAfter.X = v1t * ut.X;
            v1tAfter.Y = v1t * ut.Y;
            Vector2f v2tAfter = new Vector2f();
            v2tAfter.X = v1t * ut.X;
            v2tAfter.Y = v1t * ut.Y;

            Vector2f newVelocity1 = v1nAfterVec + v1tAfter;
            Vector2f newVelocity2 = v2nAfterVec + v2tAfter;
            SetVelocity(newVelocity1);
            collider2.SetVelocity(newVelocity2);
            CalcFriction(newVelocity1);
            collider2.CalcFriction(newVelocity2);
        }

        public override void CalcFriction(Vector2f vel)
        {
            friction = Normalize(vel);
            friction.X *= -1;
            friction.Y *= -1;
            friction.X *= constant;
            friction.Y *= constant;
        }

        public float Dot(Vector2f vel, Vector2f nort)
        {
            float result = (vel.X * nort.X) + (vel.Y * nort.Y);
            return result;
        }

        public override bool GetShoot()
        {
            return shoot;
        }

        public override void SetShoot(bool canshoot)
        {
            shoot = canshoot;
        }
    }
}
