using huqiang.UI;
using huqiang.UIComposite;
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
        public ModelElement model;
        public BulletCarrier(int code,Func<Bullet> func)
        {
            Code = code;
            Func = func;
            var mod = ModelElement.CreateNew(code.ToString());
            mod.data.sizeDelta = new Vector2(400, 400);
            var img = mod.AddComponent<ShareImageElement>();
            img.ChangeTexture("enemy", "base.unity3d");

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
            model.VertexCalculation();
        }
        /// <summary>
        /// 应用网格
        /// </summary>
        public void Apply()
        {

        }
    }
}
