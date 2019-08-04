using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using huqiang.Data;
using UnityEngine;

namespace huqiang.UI
{
    public unsafe struct ShareChildData
    {
        public Color color;
        public Vector2 txtSize;
        public Rect rect;
        public Vector2 spritePivot;
        public float fillAmountX;
        public float fillAmountY;
        public int spriteName;
        public static int Size = sizeof(ShareChildData);
        public static int ElementSize = Size / 4;
    }
    public class ShareChildElement:DataConversion
    {
        public ShareChildData data;
        public string spriteName;
        public override unsafe void Load(FakeStruct fake)
        {
            data = *(ShareChildData*)fake.ip;
            model.color = data.color;
            spriteName= fake.buffer.GetData(data.spriteName) as string;
        }
    }
}
