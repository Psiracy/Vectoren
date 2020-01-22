using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class Hole : Circle
    {
        Level lvl;
        Audio explosion = new Audio("BIG_Explosion_Sound_Effect[Mp3Converter.net].mp3");
        public Hole(Level level,Vector2f ballpos, float straal) : base(ballpos, straal)
        {
            lvl = level;
            SetStraal(straal-4);
        }

        public void HolePaint()
        {
            engine.SetColor(Color.Black);
            engine.FillEllipse(GetPosition().X, GetPosition().Y, straal+4, straal+4);
        }

        public override void OnCollisionEnter(Circle collider2)
        {
            engine.PlayAudio(explosion);
            collider2.SetPos(new Vector2f(1000, 1000));
            lvl.DeleteBall(collider2);
        }
    }
}
