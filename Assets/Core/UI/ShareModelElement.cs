using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace huqiang.UI
{
    public unsafe struct ShareElementData
    {
        public Vector3 localPosition;
        public Vector3 localScale;
        public Quaternion loaclRotate;
        public Vector2 sizeDelta;
        public Vector2 pivot;
        public Color color;
        public int spriteName;
        public static int Size = sizeof(ShareElementData);
        public static int ElementSize = Size / 4;
    }
    public class ShareModelElement:ModelElement
    {
        static void ReCalcul(ShareModelElement mod)
        {
            float w = mod.data.localScale.x * mod.data.sizeDelta.x;
            float h = mod.data.localScale.y * mod.data.sizeDelta.y;
            var Pivot = mod.data.pivot;
            var pos = mod.data.localPosition;
            float left = -Pivot.x * w;
            float right = left + w * mod._fill;
            float down = -Pivot.y * h;
            float top = h + down;
            var buff = mod.buff;
            var color = mod._color;
            buff[0].color = color;
            buff[1].color = color;
            buff[2].color = color;
            buff[3].color = color;
            var q = mod.data.localRotation;
            buff[0].position = q * new Vector3(left, down) + pos;
            buff[1].position = q * new Vector3(left, top) + pos;
            buff[2].position = q * new Vector3(right, top) + pos;
            buff[3].position = q * new Vector3(right, down) + pos;
            float uw = mod.uvs[2].x - mod.uvs[1].x;
            float ur = mod.uvs[1].x + uw * mod._fill;
            buff[0].uv0 = mod.uvs[0];
            buff[1].uv0 = mod.uvs[1];
            buff[2].uv0 = mod.uvs[2];
            buff[2].uv0.x = ur;
            buff[3].uv0 = mod.uvs[3];
            buff[3].uv0.x = ur;
        }
        UIVertex[] buff = new UIVertex[4];
        public void Changed()
        {
            IsChanged= true;
            if (parent != null)
            {
               var share = parent.GetComponent<ShareImageElement>();
                if (share != null)
                    share.needCalcul = true;
            }
        }
        Vector2[] uvs=new Vector2[4];
        public void SetUV(Vector2[] uv)
        {
            if (uv == null)
                return;
            uvs[0] = uv[0];
            uvs[1] = uv[1];
            uvs[2] = uv[2];
            uvs[3] = uv[3];
        }
        Color _color = Color.white;
        public override Color color { get => _color;set { _color = value;Changed(); } }
        float _fill = 1;
        public float FillAmount { get { return _fill; } set {
                if (value < 0)
                    value = 0;
                else if (value > 1)
                    value = 1;
                _fill = value;
                Changed();
            } }

        public UIVertex[] GetUVInfo()
        {
            if (IsChanged)
            {
                ReCalcul(this);
                IsChanged = false;
            }
            return buff;
        }
        public override void Apply()
        {
        }
    }
}
