﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Game
{
    public class BulletManager
    {
        static List<BulletCarrier> carriers;
        public static void Shot(Enemy enemy, Vector3 position,float angle,int code)
        {
            BulletCarrier carrier;
            if (carriers == null)
            {
                carriers = new List<BulletCarrier>();
                carrier = CreateCarrier(code);
                goto label;
            }
            else
            {
                for (int i = 0; i < carriers.Count; i++)
                {
                    if (carriers[i].Code == code)
                    {
                        carrier = carriers[i];
                        goto label;
                    }
                }
            }
            carrier = CreateCarrier(code);
        label:;
            var bullet = carrier.CreateBullet();
            bullet.shotPos = position;
            bullet.shotAngle.z = angle;
        }
        static BulletCarrier CreateCarrier(int code)
        {
            BulletCarrier carrier = new BulletCarrier(code,FindFunc(code));
            carriers.Add(carrier);
            return carrier;
        }
        static Func<Bullet> FindFunc(int code)
        {
            code >>= 16;
            switch(code)
            {
                case 1:
                    return () => { return new PolygonBullet(); };
                case 2:
                    return () => { return new CircleBullet(); };
                default:
                    return () => { return new Bullet(); };
            }
        }
    }
}
