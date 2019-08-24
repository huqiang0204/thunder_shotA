using System;
using System.Collections.Generic;
using huqiang.Data;
using huqiang.UI;
using UGUI;
using UnityEngine;

[RequireComponent(typeof(ShareImage))]
public class ShareImageHelper : UICompositeHelp
{
    public ShareRender shareRender;
    void VertexCalculation(CustomRawImage raw)
    {
        var vert = new List<UIVertex>();
        var tri = new List<int>();
        for (int i = 0; i < transform.childCount; i++)
        {
            var c= transform.GetChild(i);
            var help = c.GetComponent<ShareChild>();
            if (help != null)
                help.GetUVInfo(vert,tri,Vector3.zero,Quaternion.identity,Vector3.one);
        }
        raw.uIVertices = vert;
        raw.triangle = tri;
        raw.SetVerticesDirty();
        if(shareRender!=null)
        {
            shareRender.Vertex.Clear();
            shareRender.UV.Clear();
            shareRender.Colors.Clear();
            shareRender.Tri.Clear();
            for (int i = 0; i < transform.childCount; i++)
            {
                var c = transform.GetChild(i);
                var help = c.GetComponent<ShareChild>();
                if (help != null)
                    help.GetUVInfo(shareRender.Vertex,shareRender.UV,shareRender.Colors,shareRender.Tri, Vector3.zero, Quaternion.identity, Vector3.one);
            }
            shareRender.Aplly();
        }
    }
    public void Refresh()
    {
        var raw = GetComponent<CustomRawImage>();
        if (raw != null)
            VertexCalculation(raw);
    }
}
