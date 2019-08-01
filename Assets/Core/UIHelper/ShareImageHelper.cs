using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using huqiang.Data;
using UGUI;
using UnityEngine;

public class ShareImageHelper : UICompositeHelp
{
    public class TransData
    {
        public Vector3 localPosition;
        public Vector3 localScale=Vector3.one;
        public Vector3 Angle;
        public Vector2 sizeDelta=new Vector2(100,100);
        public Vector2 pivot=new Vector2(0.5f,0.5f);
        public Color color = Color.white;
        UIVertex[] buff = new UIVertex[4];
        public Sprite sprite;
        public void SetSprite(Sprite sp)
        {
            if (sp == null)
                return;
            sprite = sp;
            float tx = sprite.texture.width;
            float ty = sprite.texture.height;
            float x = sprite.rect.x / tx;
            float y = sprite.rect.y / ty;
            float w = sprite.rect.width;
            float h = sprite.rect.height;
            float r = x + w / tx;
            float t = y + h / ty;
            Vector2 p = sprite.pivot;
            buff[0].uv0.x = x;
            buff[0].uv0.y = y;
            buff[1].uv0.x = x;
            buff[1].uv0.y = t;
            buff[2].uv0.x = r;
            buff[2].uv0.y = t;
            buff[3].uv0.x = r;
            buff[3].uv0.y = y;
        }
        public UIVertex[] GetUVInfo()
        {
            float w = localScale.x * sizeDelta.x;
            float h = localScale.y * sizeDelta.y;
            var pos = localPosition;
            float left = -pivot.x * w;
            float right = (1 - pivot.x) * w;
            float down = -pivot.y * h;
            float top = (1 - pivot.y) * h;
            buff[0].color = color;
            buff[1].color = color;
            buff[2].color = color;
            buff[3].color = color;
            var q = Quaternion.Euler(Angle);
            buff[0].position = q * new Vector3(left, down) + pos;
            buff[1].position = q * new Vector3(left, top) + pos;
            buff[2].position = q * new Vector3(right, top) + pos;
            buff[3].position = q * new Vector3(right, down) + pos;
            return buff;
        }
        
    }
    public List<TransData> datas=new List<TransData>();
    public override FakeStruct ToFakeStruct(DataBuffer data)
    {
        return base.ToFakeStruct(data);
    }
    void VertexCalculation(CustomRawImage raw)
    {
        var vert = new List<UIVertex>();
        var tri = new List<int>();
        int s = 0;
        for (int i = 0; i < datas.Count; i++)
        {
            var son =datas[i];
            if (son != null)
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
       
        raw.uIVertices = vert;
        raw.triangle = tri;
        raw.SetVerticesDirty();
    }
    public void Refresh()
    {
        var raw = GetComponent<CustomRawImage>();
        if (raw != null)
            VertexCalculation(raw);
    }
    public void AddSon()
    {
        TransData trans = new TransData();
        datas.Add(trans);
    }
}
