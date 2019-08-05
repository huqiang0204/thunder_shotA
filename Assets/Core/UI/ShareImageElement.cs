using huqiang.Data;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace huqiang.UI
{
    public class ShareImageElement : CustomImageElement
    {
        public unsafe override void Load(FakeStruct fake)
        {
            base.Load(fake);
            var array = model.GetExtand() as FakeStructArray;
            if (array != null)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    var dat = new ShareModelElement();
                    ShareElementData* dp = (ShareElementData*)array[i];
                    dat.data.localPosition = dp->localPosition;
                    dat.data.localScale = dp->localScale;
                    dat.data.localRotation = dp->loaclRotate;
                    dat.data.sizeDelta = dp->sizeDelta;
                    dat.data.localScale = dp->localScale;
                    dat.data.pivot = dp->pivot;
                    dat.color = dp->color;
                    var name = fake.buffer.GetData(dp->spriteName) as string;
                    if (name != null)
                        dat.SetUV(ElementAsset.FindSpriteUV(textureName, name, ref dat.data.pivot));
                    dat.SetParent(model);
                }
                needCalcul = true;
            }
        }
        public bool needCalcul;
        public override void VertexCalculation()
        {
            if (needCalcul)
            {
                var vert = new List<UIVertex>();
                var tri = new List<int>();
                for (int i = 0; i < model.child.Count; i++)
                {
                    var c = model.child[i];
                    var help = c.GetComponent<ShareChildElement>();
                    if (help != null)
                        help.GetUVInfo(vert, tri, Vector3.zero, Quaternion.identity, Vector3.one);
                }
                vertex = vert;
                tris = tri;
                vertChanged = true;
            }
        }
    }
}
