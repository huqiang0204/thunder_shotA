using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace huqiang.Data
{
    public class SpriteData
    {
        class SpriteCategory
        {
            public string txtName;
            public List<Sprite> sprites = new List<Sprite>();
        }
        public unsafe struct SpriteDataS
        {
            public Int32 name;
            public Int32 uv;
            public Vector2 pivot;
            public static int Size = sizeof(SpriteDataS);
            public static int ElementSize = Size / 4;
        }
        List<SpriteCategory> lsc = new List<SpriteCategory>();
        public void AddSprite(Sprite sprite)
        {
            if (sprite == null)
                return;
            string tname = sprite.texture.name;
            for (int i = 0; i < lsc.Count; i++)
            {
                if (tname == lsc[i].txtName)
                {
                    lsc[i].sprites.Add(sprite);
                    return;
                }
            }
            SpriteCategory category = new SpriteCategory();
            category.txtName = tname;
            category.sprites.Add(sprite);
            lsc.Add(category);
        }
        FakeStructArray SaveCategory(DataBuffer buffer)
        {
            FakeStructArray array = new FakeStructArray(buffer, 2, lsc.Count);
            for (int i=0;i<lsc.Count;i++)
            {
                array.SetData(i,0,lsc[i].txtName);
                array.SetData(i,1,SaveSprites(buffer,lsc[i].sprites));
            }
            return array;
        }
        FakeStructArray SaveSprites(DataBuffer buffer,List<Sprite> sprites)
        {
            FakeStructArray array = new FakeStructArray(buffer, SpriteDataS.ElementSize, sprites.Count);
            float tx = sprites[0].texture.width;
            float ty = sprites[0].texture.height;
            for (int i = 0; i < sprites.Count; i++)
            {
                var sprite = sprites[i];
                string name = sprite.name;
                Vector2[] tmp = new Vector2[4];
                float x = sprite.rect.x/tx;
                float y = sprite.rect.y/ty;
                float w = sprite.rect.width;
                float h = sprite.rect.height;
                float r = x + w / tx;
                float t = y + h / ty;
                Vector2 p = sprite.pivot;
                tmp[0].x = x;
                tmp[0].y = y;
                tmp[1].x = x;
                tmp[1].y = t;
                tmp[2].x = r;
                tmp[2].y = t;
                tmp[3].x = r;
                tmp[3].y = y;
                array.SetData(i, 0, name);
                array[i, 1] = buffer.AddArray<Vector2>(tmp);
                array.SetFloat(i, 2, p.x / w);
                array.SetFloat(i, 3, p.y / h);
            }
            return array;
        }
        public void Save(string name,string path)
        {
            DataBuffer buffer = new DataBuffer(4096);
            var fs = buffer.fakeStruct = new FakeStruct(buffer, 2);
            fs.SetData(0, name);
            fs.SetData(1, SaveCategory(buffer));
            byte[] dat = buffer.ToBytes();
            File.WriteAllBytes(path,dat);
        }
        public void Clear()
        {
            lsc.Clear();
        }
        FakeStruct fakeStruct;
        public void LoadSpriteData(byte[] data)
        {
            fakeStruct = new DataBuffer(data).fakeStruct;
        }
        public Vector2[] FindSpriteUV(string tName, string sName)
        {
            Vector2 p = Vector2.zero;
            return FindSpriteUV(tName, sName, ref p);
        }
        public Vector2[] FindSpriteUV(string tName,string sName,ref Vector2 pivot)
        {
            if (fakeStruct == null)
                return null;
            var fsa = fakeStruct.GetData<FakeStructArray>(1);
            if(fsa!=null)
            {
                for(int i=0;i<fsa.Length;i++)
                {
                    if(fsa.GetData(i,0) as string==tName)
                    {
                        fsa = fsa.GetData(i,1) as FakeStructArray;
                        if (fsa != null)
                        {
                            for (int j = 0; j < fsa.Length; j++)
                            {
                                if (fsa.GetData(j, 0) as string == sName)
                                {
                                    var v = fsa.buffer.GetArray<Vector2>(fsa[j,1]);
                                    pivot.x = fsa.GetFloat(j, 2);
                                    pivot.y = fsa.GetFloat(j, 3);
                                    return v;
                                }
                            }
                        }
                        break;
                    }
                }
            }
            return null;
        }
    }
}
