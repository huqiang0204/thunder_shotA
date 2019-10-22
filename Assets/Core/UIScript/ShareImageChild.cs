using System;
using System.Collections.Generic;
using UnityEngine;
using huqiang.UI;
using huqiang.Data;

public class ShareImageChild : MonoBehaviour,DataStorage
{
    public float fillAmountX = 1;
    public float fillAmountY = 1;
    public Color color = Color.white;
    public UIVertex[] buff = new UIVertex[4];
    public Sprite sprite;
    public Vector2[] uvs = new Vector2[4];
    public void SetSprite(Sprite sp)
    {
        sprite = sp;
        if (sp == null)
        {
            return;
        }
        float tx = sprite.texture.width;
        float ty = sprite.texture.height;
        float x = sprite.rect.x / tx;
        float y = sprite.rect.y / ty;
        float w = sprite.rect.width;
        float h = sprite.rect.height;
        float r = x + w / tx;
        float t = y + h / ty;
        uvs[0].x = x;
        uvs[0].y = y;
        uvs[1].x = x;
        uvs[1].y = t;
        uvs[2].x = r;
        uvs[2].y = t;
        uvs[3].x = r;
        uvs[3].y = y;
    }
    public void SetNactiveSize()
    {
        if (sprite != null)
        {
            float w = sprite.rect.width;
            float h = sprite.rect.height;
            (transform as RectTransform).sizeDelta = new Vector2(w, h);
        }
    }
    public void SetSpritePivot()
    {
        if (sprite != null)
        {
            (transform as RectTransform).pivot = new Vector2(sprite.pivot.x / sprite.rect.width, sprite.pivot.y / sprite.rect.height);
        }
    }
    public unsafe FakeStruct ToBufferData(DataBuffer data)
    {
        FakeStruct fake = new FakeStruct(data, ShareImageChildData.ElementSize);
        ShareImageChildData* sp = (ShareImageChildData*)fake.ip;
        sp->color = color;
        sp->fillAmountX = fillAmountX;
        sp->fillAmountY = fillAmountY;
        if (sprite != null)
        {
            sp->rect = sprite.rect;
            sp->txtSize.x = sprite.texture.width;
            sp->txtSize.y = sprite.texture.height;
            sp->pivot = sprite.pivot;
            sp->spriteName = data.AddData(sprite.name);
        }
        return fake;
    }
}
