using huqiang.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Game
{
    public class Bullet
    {
        public int Code;
        /// <summary>
        /// 发射此子弹飞机是否需要静止
        /// </summary>
        public bool FixShot;
        /// <summary>
        /// 发射此子弹所需时间,例如激光
        /// </summary>
        public float ShotTime;
        public Vector3 shotPos;
        public Vector3 shotAngle;
        public Vector2 Position;
        public float Angle;
        public float Speed;
        public Vector3[] vertex;
        public Vector2[] uv;
        public int MoveType;
        public Enemy enemy;
        public BulletCarrier carrier;
        public virtual void Update() { }
    }
    public class CircleBullet : Bullet
    {
        public float Radius;
       
    }
    public class PolygonBullet : Bullet
    {
        public Vector2[] points;
    }
}
