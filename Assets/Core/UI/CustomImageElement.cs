﻿using System;
using System.Collections.Generic;
using huqiang.Data;
using UGUI;
using UnityEngine;

namespace huqiang.UI
{
    public class CustomImageElement:RawImageElement
    {
        public CustomRawImage custom;
        protected bool vertChanged;
        protected List<UIVertex> vertex;
        protected List<int> tris;
        public override void LoadToObject(Component game)
        {
            base.LoadToObject(game);
            custom = Context as CustomRawImage;
        }
        public void UpdateVert(List<UIVertex> vertices,List<int> tri)
        {
            vertex = vertices;
            tris = tri;
            vertChanged = true;
        }
        public override void Apply()
        {
            base.Apply();
            if(vertChanged)
            {
                custom.uIVertices = vertex;
                custom.triangle = tris;
                custom.SetVerticesDirty();
                vertChanged = false;
            }
        }
    }
    public class ShareImageElement : CustomImageElement
    {
        public unsafe override void Load(FakeStruct fake)
        {
            base.Load(fake);
            var array = fake.buffer.GetData(data.ex) as FakeStructArray;
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
                    var name = fake.GetData(dp->spriteName) as string;
                    if (name != null)
                        dat.SetUV(ElementAsset.FindSpriteUV(textureName, name, ref dat.data.pivot));
                    dat.SetParent(model);
                }
            }
        }
        public bool needCalcul;
        public override void VertexCalculation()
        {
            if(needCalcul)
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
