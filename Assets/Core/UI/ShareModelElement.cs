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
            float right = (1 - Pivot.x) * w;
            float down = -Pivot.y * h;
            float top = (1 - Pivot.y) * h;
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
        public void SetUV(Vector2[] uv)
        {
            if (uv == null)
                return;
            buff[0].uv0 = uv[0];
            buff[1].uv0 = uv[1];
            buff[2].uv0 = uv[2];
            buff[3].uv0 = uv[3];
        }
        Color _color;
        public override Color color { get => _color;set { _color = value;Changed(); } }
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
