using huqiang.Data;
using huqiang.UI;
using huqiang.UIComposite;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game
{
    public class BulletCarrier
    {
        public int Code;
        Func<Bullet> Func;
        public ModelElement model;
        public string txtName;
        public string spName;
        public BulletCarrier(ModelElement parent, int code,Func<Bullet> func)
        {
            Code = code;
            Func = func;
            var mod = ModelElement.CreateNew(code.ToString());
            mod.SetParent(parent);
            mod.data.sizeDelta = new Vector2(400, 400);
            var img = mod.AddComponent<ShareImageElement>();
            img.ChangeTexture("enemy", "base.unity3d");

        }
        List<Bullet> buffer=new List<Bullet>();
        public Bullet CreateBullet()
        {
            var t = Func();
            t.container = this;
            buffer.Add(t);
            t.render = new ModelElement();
            var se = t.render.AddComponent<ShareChildElement>();
            ElementAsset.FindSpriteUV(txtName, spName, ref se.data.rect, ref se.data.txtSize, ref se.data.pivot);
            return t;
        }
        public void ReleaseBullet(Bullet bullet)
        {
            buffer.Remove(bullet);
            bullet.render.SetParent(null);
        }
        public void Update(float time)
        {
            int c = buffer.Count - 1;
            for (; c >= 0; c--)
                buffer[c].Update(time);
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
