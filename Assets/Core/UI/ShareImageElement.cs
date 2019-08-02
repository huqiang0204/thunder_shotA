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
                int s = 0;
                var child = model.child;
                for (int i = 0; i < child.Count; i++)
                {
                    var son = child[i] as ShareModelElement;
                    if (son != null)
                    {
                        if (son.activeSelf)
                        {
                            var uv = son.GetUVInfo();
                            vert.AddRange(uv);
                            tri.Add(s);
                            tri.Add(s + 1);
                            tri.Add(s + 2);
                            tri.Add(s + 2);
                            tri.Add(s + 3);
                            tri.Add(s);
                            s += 4;
                        }
                    }
                }
                vertex = vert;
                tris = tri;
                vertChanged = true;
            }
        }
    }
}
