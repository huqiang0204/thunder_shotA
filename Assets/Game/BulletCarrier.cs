using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Game
{
    public class BulletCarrier
    {
        public int Code;
        Func<Bullet> Func;
        public BulletCarrier(int code,Func<Bullet> func)
        {
            Code = code;
            Func = func;
        }
        List<Bullet> buffer=new List<Bullet>();
        public Bullet CreateBullet()
        {
            var t = Func();
            t.carrier = this;
            buffer.Add(t);
            return t;
        }
        public void ReleaseBullet(Bullet bullet)
        {
            buffer.Remove(bullet);
        }
        public void Update()
        {
            int c = buffer.Count - 1;
            for (; c >= 0; c--)
                buffer[c].Update();
        }
        /// <summary>
        /// 合成网格
        /// </summary>
        public void MeshComplete()
        {

        }
        /// <summary>
        /// 应用网格
        /// </summary>
        public void Apply()
        {

        }
    }
}
