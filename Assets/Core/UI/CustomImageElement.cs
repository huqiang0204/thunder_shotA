using System.Collections.Generic;
using UGUI;
using UnityEngine;

namespace huqiang.UI
{
    public class CustomImageElement:RawImageElement
    {
        public CustomRawImage custom;
        bool vertChanged;
        List<UIVertex> vertex;
        List<int> tris;
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
        public bool needCalcul;
        List<UIVertex> vertices = new List<UIVertex>();
        List<int> tri = new List<int>();
        public override void VertexCalculation()
        {
            vertices.Clear();
            tri.Clear();
            int s = 0;
            var child = model.child;
            for (int i = 0; i <child.Count; i++)
            {
                var son = child[i] as SonModelElement;
                if(son!=null)
                {
                    if(son.activeSelf)
                    {
                        vertices.AddRange(son.GetUVInfo());
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
            UpdateVert(vertices, tri);
        }
    }
}
