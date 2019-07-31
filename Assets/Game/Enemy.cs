using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game
{
    public class StateOfShot
    {
        /// <summary>
        /// 动画状态
        /// </summary>
        public string State;
        /// <summary>
        /// 当前的动画可发射的子弹
        /// </summary>
        public int[] BulletCodes;
    }
    public class Enemy
    {
        public int[] BulletCodes;
        public string assetName;
        public string textureName;
        public string spriteName;
        public string aniName;
        public int endType;
        public int moveType;
        public void Update(float time)
        {
        }
    }
}
