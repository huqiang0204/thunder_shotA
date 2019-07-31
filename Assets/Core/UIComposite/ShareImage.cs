using huqiang.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGUI;
using UnityEngine;

namespace huqiang.UIComposite
{
    public class ShareComponent:UITransform
    {
        public ShareComponent(ShareImage image)
        {
            Parent = image;
            image.buff.Add(this);
        }
        public ShareImage Parent { get; private set; }
        public Vector2 Pivot = new Vector2(0.5f, 0.5f);
        public Vector2 mSize=new Vector2(100,100);
        public Vector3 mLocalPosition;
        public Vector2 mLocalScale = Vector2.one;
        public Quaternion rotate = Quaternion.identity;
        Vector3 mPostion;
        Vector3 mScale;
        Quaternion mRotate;
        void GetGlobaInfo()
        {
            var coor = ModelElement.GetGlobaInfo(Parent.Model);
            mPostion.x = mLocalPosition.x * coor.Scale.x;
            mPostion.y = mLocalPosition.y * coor.Scale.y;
            mPostion.z = mLocalPosition.z * coor.Scale.z;
            mPostion += coor.Postion;
            mScale.x = coor.Scale.x * mLocalScale.x;
            mScale.y = coor.Scale.y * mLocalScale.y;
            mRotate = coor.quaternion * rotate;
        }
        public Vector3 Angle { set { rotate = Quaternion.Euler(value); } }
        public Quaternion LocalRotate { get => rotate; set { rotate = value; Changed = true; } }
        public Vector2 SizeDelta { get => mSize; set { mSize = value; Changed = true; } }
        public Vector3 LocalPosition { get => mLocalPosition; set { mLocalPosition = value; Changed = true; } }
        public Vector2 LocalScale { get => mLocalScale; set { mLocalScale = value; Changed = true; } }
        public Vector3 GlobalPosition { get {
                if (Changed)
                    GetGlobaInfo();
                return mPostion;
            }
        }
        public Vector3 GlobalScale { get {
                if (Changed)
                    GetGlobaInfo();
                return mScale;
            } }
        public Quaternion GlobalRotate { get {
                if (Changed)
                    GetGlobaInfo();
                return mRotate;
            } }
        public Color color = Color.white;
        UIVertex[] buff = new UIVertex[4];
        public void SetSpriteUV(Vector2[] uv)
        {
            if (uv == null)
                return;
            buff[0].uv0 = uv[3];
            buff[1].uv0 = uv[0];
            buff[2].uv0 = uv[2];
            buff[3].uv0 = uv[1];
        }
        public void SetUV(Vector2[] uv)
        {
            if (uv == null)
                return;
            buff[0].uv0 = uv[0];
            buff[1].uv0 = uv[1];
            buff[2].uv0 = uv[2];
            buff[3].uv0 = uv[3];
        }
        static void ReCalcul(ShareComponent image)
        {
            float w = image.mLocalScale.x * image.mSize.x;
            float h = image.mLocalScale.y * image.mSize.y;
            var Pivot = image.Pivot;
            var pos = image.mLocalPosition;
            float left = -Pivot.x * w;
            float right = (1 - Pivot.x) * w;
            float down =  - Pivot.y * h;
            float top = (1 - Pivot.y) * h;
            var buff = image.buff;
            var color = image.color;
            buff[0].color = color;
            buff[1].color = color;
            buff[2].color = color;
            buff[3].color = color;
            var q = image.rotate;
            buff[0].position = q * new Vector3(left, down) + pos;
            buff[1].position = q * new Vector3(left, top) + pos;
            buff[2].position = q * new Vector3(right, top) + pos;
            buff[3].position = q * new Vector3(right, down) + pos;
        }
        public bool Changed;
        public UIVertex[] GetUVInfo()
        {
            if (Changed)
            {
                ReCalcul(this);
                Changed = false;
            }
            return buff;
        }
        public void Dispose()
        {
            Parent.buff.Remove(this);
        }
        public huqiang.Math.Collider2D collider { get; set; }
    
    }
    public class ShareImage: ModelInital
    {
        public CustomImageElement rawImage { private set; get; }
        public List<ShareComponent> buff = new List<ShareComponent>();
        List<UIVertex> vertices=new List<UIVertex>();
        List<int> tri = new List<int>();
        public override void Initial(ModelElement mod)
        {
            Model = mod;
            rawImage = mod.GetComponent<CustomImageElement>();
        }
        public void Refresh()
        {
            vertices.Clear();
            tri.Clear();
            int s = 0;
            for (int i = 0; i < buff.Count; i++)
            {
                vertices.AddRange(buff[i].GetUVInfo());
                tri.Add(s);
                tri.Add(s + 1);
                tri.Add(s + 2);
                tri.Add(s + 2);
                tri.Add(s + 3);
                tri.Add(s);
                s += 4;
            }
            if (rawImage != null)
                rawImage.UpdateVert(vertices,tri);
        }
    }
}
