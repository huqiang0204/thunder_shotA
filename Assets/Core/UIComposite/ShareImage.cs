using huqiang.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGUI;
using UnityEngine;

namespace huqiang.UIComposite
{
    public class ShareComponent
    {
        public ShareComponent(ShareImage image)
        {
            Parent = image;
            image.buff.Add(this);
        }
        public ShareImage Parent { get; private set; }
        public Vector2 Pivot = new Vector2(0.5f, 0.5f);
        public Vector2 SizeDelta=new Vector2(100,100);
        public Vector3 LocalPosition;
        public Vector2 LocalScale = Vector2.one;
        public Vector3 Angle { set { LocalQuaternion = Quaternion.Euler(value); } }
        public Quaternion LocalQuaternion = Quaternion.identity;
        public Color color = Color.white;
        UIVertex[] buff = new UIVertex[4];
        public void SetSpriteUV(Vector2[] uv)
        {
            if (uv == null)
                return;
            buff[0].uv0 = uv[3];
            buff[1].uv0 = uv[0];
            buff[2].uv0 = uv[2];
            buff[3].uv0 = uv[1];
        }
        public void SetUV(Vector2[] uv)
        {
            if (uv == null)
                return;
            buff[0].uv0 = uv[0];
            buff[1].uv0 = uv[1];
            buff[2].uv0 = uv[2];
            buff[3].uv0 = uv[3];
        }
        static void ReCalcul(ShareComponent image)
        {
            float w = image.LocalScale.x * image.SizeDelta.x;
            float h = image.LocalScale.y * image.SizeDelta.y;
            var Pivot = image.Pivot;
            var pos = image.LocalPosition;
            float left = -Pivot.x * w;
            float right = (1 - Pivot.x) * w;
            float down =  - Pivot.y * h;
            float top = (1 - Pivot.y) * h;
            var buff = image.buff;
            var color = image.color;
            buff[0].color = color;
            buff[1].color = color;
            buff[2].color = color;
            buff[3].color = color;
            var q = image.LocalQuaternion;
            buff[0].position = q * new Vector3(left, down) + pos;
            buff[1].position = q * new Vector3(left, top) + pos;
            buff[2].position = q * new Vector3(right, top) + pos;
            buff[3].position = q * new Vector3(right, down) + pos;
        }
        public bool Changed;
        public UIVertex[] GetUVInfo()
        {
            if (Changed)
            {
                ReCalcul(this);
                Changed = false;
            }
            return buff;
        }
        public void Dispose()
        {
            Parent.buff.Remove(this);
        }
    }
    public class ShareImage: ModelInital
    {
        public CustomImageElement rawImage { private set; get; }
        public List<ShareComponent> buff = new List<ShareComponent>();
        List<UIVertex> vertices=new List<UIVertex>();
        List<int> tri = new List<int>();
        public override void Initial(ModelElement mod)
        {
            Model = mod;
            rawImage = mod.GetComponent<CustomImageElement>();
        }
        public void Refresh()
        {
            vertices.Clear();
            tri.Clear();
            int s = 0;
            for (int i = 0; i < buff.Count; i++)
            {
                vertices.AddRange(buff[i].GetUVInfo());
                tri.Add(s);
                tri.Add(s + 1);
                tri.Add(s + 2);
                tri.Add(s + 2);
                tri.Add(s + 3);
                tri.Add(s);
                s += 4;
            }
            if (rawImage != null)
                rawImage.UpdateVert(vertices,tri);
        }
    }
}
