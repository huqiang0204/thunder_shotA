﻿using System;
using System.Collections.Generic;
using huqiang.Data;
using huqiang.UI;
using UGUI;
using UnityEngine;

[RequireComponent(typeof(ShareImage))]
public class ShareImageHelper : UICompositeHelp
{
    public class TransData
    {
        public Vector3 localPosition;
        public Vector3 localScale=Vector3.one;
        public Vector3 Angle;
        public Vector2 sizeDelta=new Vector2(100,100);
        public Vector2 pivot =new Vector2(0.5f,0.5f);
        public Color color = Color.white;
        public float fillAmount=1;
        UIVertex[] buff = new UIVertex[4];
        public Sprite sprite;
        Vector2[] uvs = new Vector2[4];
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
            uvs[0].x = x;
            uvs[0].y = y;
            uvs[1].x = x;
            uvs[1].y = t;
            uvs[2].x = r;
            uvs[2].y = t;
            uvs[3].x = r;
            uvs[3].y = y;
        }
        public UIVertex[] GetUVInfo()
        {
            float w = localScale.x * sizeDelta.x;
            float h = localScale.y * sizeDelta.y;
            var pos = localPosition;
            float left = -pivot.x * w;
            float right = left+w * fillAmount;
            float down = -pivot.y * h;
            float top = down+h;
            buff[0].color = color;
            buff[1].color = color;
            buff[2].color = color;
            buff[3].color = color;
            var q = Quaternion.Euler(Angle);
            buff[0].position = q * new Vector3(left, down) + pos;
            buff[1].position = q * new Vector3(left, top) + pos;
            buff[2].position = q * new Vector3(right, top) + pos;
            buff[3].position = q * new Vector3(right, down) + pos;
            float uw = uvs[2].x - uvs[1].x;
            float ur = uvs[1].x + uw * fillAmount;
            buff[0].uv0 = uvs[0];
            buff[1].uv0 = uvs[1];
            buff[2].uv0 = uvs[2];
            buff[2].uv0.x = ur;
            buff[3].uv0 = uvs[3];
            buff[3].uv0.x = ur;
            return buff;
        }
        public bool foldout;
    }
    public List<TransData> datas = new List<TransData>();
    public unsafe override object ToBufferData(DataBuffer data)
    {
        ForbidChild = true;
        datas.Clear();
        ReadData();
        return SaveData(data);
    }
    unsafe FakeStructArray SaveData(DataBuffer data)
    {
        FakeStructArray array = new FakeStructArray(data, ShareElementData.ElementSize, datas.Count);
        for (int i = 0; i < datas.Count; i++)
        {
            var dat = datas[i];
            ShareElementData* dp = (ShareElementData*)array[i];
            dp->localPosition = dat.localPosition;
            dp->localScale = dat.localScale;
            dp->loaclRotate = Quaternion.Euler(dat.Angle);
            dp->sizeDelta = dat.sizeDelta;
            dp->localScale = dat.localScale;
            dp->pivot = dat.pivot;
            dp->color = dat.color;
            if (dat.sprite != null)
                dp->spriteName = data.AddData(dat.sprite.name);
        }
        return array;
    }
    unsafe void ReadData()
    {
        var raw = GetComponent<CustomRawImage>();
        if (raw == null)
            return;
        var db = new DataBuffer(buff);
        var array = db.fakeStruct.GetData<FakeStructArray>(0);
        if(array!=null)
        {
            for(int i=0;i<array.Length;i++)
            {
                var dat = new TransData();
                ShareElementData* dp = (ShareElementData*)array[i];
                dat.localPosition = dp->localPosition;
                dat.localScale = dp->localScale;
                dat.Angle = dp->loaclRotate.eulerAngles;
                dat.sizeDelta = dp->sizeDelta;
                dat.localScale = dp->localScale;
                dat.pivot = dp->pivot;
                dat.color = dp->color;
                var name = db.GetData(dp->spriteName) as string;
                if(name!=null)
                {
#if UNITY_EDITOR
                   var sp= EditorModelManager.FindSprite(raw.texture.name,name);
                    dat.SetSprite(sp);
#endif
                }
                datas.Add(dat);
            }
        }
    }
    void VertexCalculation(CustomRawImage raw)
    {
        var vert = new List<UIVertex>();
        var tri = new List<int>();
        //int s = 0;
        //for (int i = 0; i < datas.Count; i++)
        //{
        //    var son =datas[i];
        //    if (son != null)
        //    {
        //        var uv = son.GetUVInfo();
        //        vert.AddRange(uv);
        //        tri.Add(s);
        //        tri.Add(s + 1);
        //        tri.Add(s + 2);
        //        tri.Add(s + 2);
        //        tri.Add(s + 3);
        //        tri.Add(s);
        //        s += 4;
        //    }
        //}
        for (int i = 0; i < transform.childCount; i++)
        {
            var c= transform.GetChild(i);
            var help = c.GetComponent<ShareElementHelper>();
            if (help != null)
                help.GetUVInfo(vert,tri,Vector3.zero,Quaternion.identity,Vector3.one);
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
        DataBuffer db = new DataBuffer(32);
        db.fakeStruct = new FakeStruct(db, 1);
        db.fakeStruct.SetData(0,SaveData(db));
        buff = db.ToBytes();
    }
    public void AddSon()
    {
        TransData trans = new TransData();
        datas.Add(trans);
    }
    [HideInInspector]
    public byte[] buff;
    public void ReLoad()
    {
        //if(buff!=null)
        //{
        //    datas.Clear();
        //    ReadData();
        //    var raw = GetComponent<CustomRawImage>();
        //    if (raw != null)
        //        VertexCalculation(raw);
        //}
    }
}
