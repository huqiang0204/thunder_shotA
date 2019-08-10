﻿using huqiang;
using huqiang.Data;
using huqiang.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Game
{
    public enum BallisticType
    {
        None, Line, Bezier, Lock, Aim
    }
    public enum TargetType
    {
        Enemy, Fight
    }
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
        public Vector2 direction;
        public float Angle;
        public float Speed;
        public Vector3[] vertex;
        public Vector2[] uv;
        public int MoveType;
        public BallisticType ballistic;
        public Carrier carrier;
        public BulletCarrier container;
        public ModelElement render;
        public virtual void Update(float time)
        {
            MoveManager.MoveBullet(this,time);
        }
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
