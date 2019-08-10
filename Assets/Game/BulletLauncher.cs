using System;
using UnityEngine;

namespace Assets.Game
{
    public struct ShotPoint
    {
        public Vector3 Offset;
        public float angle;
    }
    public class BulletLauncher
    {
        public BulletLauncher(Carrier car)
        {
            carrier = car;
        }
        /// <summary>
        /// 发射位置
        /// </summary>
        public Vector3 localPos;
        /// <summary>
        /// 发射间隔
        /// </summary>
        public float Interval;
        /// <summary>
        /// 子弹编码
        /// </summary>
        public int BulletCode;
        /// <summary>
        /// 载体
        /// </summary>
        public Carrier carrier;
        /// <summary>
        /// 子弹发射点
        /// </summary>
        public ShotPoint[] shots;

        public float cd;
        public virtual void Update(float time)
        {
            cd += time;
            if (cd > Interval)
            {
                cd -= Interval;
                if (shots != null)
                {
                    ShotPoint[] points = new ShotPoint[shots.Length];
                    for (int i = 0; i < shots.Length; i++)
                    {
                        points[i] = shots[i];
                        points[i].Offset += localPos + carrier.Position;
                    }
                    BulletManager.Shot(carrier, points, BulletCode);
                }
            }
        }
    }
}
