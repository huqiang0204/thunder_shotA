using huqiang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game
{
    public class MoveManager
    {
        public static void MoveBullet(Bullet bullet,float time)
        {
            switch (bullet.ballistic)
            {
                case BallisticType.None:
                    var v = time * bullet.Speed * MathH.Tan2(bullet.shotAngle.z) * 0.001f;
                    bullet.render.data.localPosition.x += v.x;
                    bullet.render.data.localPosition.y += v.y;
                    break;
            }
        }
    }
}
