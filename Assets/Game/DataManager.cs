using huqiang.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Game
{
    //public unsafe struct BulletData
    //{
    //    public int Code;
    //    /// <summary>
    //    /// 发射此子弹飞机是否需要静止
    //    /// </summary>
    //    public bool FixShot;
    //    /// <summary>
    //    /// 发射此子弹所需时间,例如激光
    //    /// </summary>
    //    public float ShotTime;
    //    public int assetName;
    //    public int txtName;
    //    public int spName;
    //    public float Angle;
    //    public float Speed;
    //    public int vertex;
    //    public int uv;
    //    public int MoveType;
    //    public static int Size = sizeof(BulletData);
    //    public static int ElementSize = Size / 4;
    //}
    //public unsafe struct EnemyData
    //{
    //    public int Code;
    //    public int prefabName;
    //    /// <summary>
    //    /// 发射此子弹飞机是否需要静止
    //    /// </summary>
    //    public bool FixShot;
    //    /// <summary>
    //    /// 发射此子弹所需时间,例如激光
    //    /// </summary>
    //    public float ShotTime;
    //    public Vector3 shotPos;
    //    public Vector3 shotAngle;
    //    public Vector2 Position;
    //    public float Angle;
    //    public float Speed;
    //    public int vertex;
    //    public int uv;
    //    public int MoveType;
    //    public static int Size = sizeof(EnemyData);
    //    public static int ElementSize = Size / 4;
    //}
    //public unsafe struct AllData
    //{
    //    public int Level;
    //    public int Enemy;
    //    public int Bullet;
    //    public static int Size = sizeof(BulletData);
    //    public static int ElementSize = Size / 4;
    //}
    public class DataManager
    {
        static DataBuffer buffer;
        public static void Initial(byte[] data)
        {
            buffer = new DataBuffer(data);
        }
        public void LoadLevel(int index)
        {

        }
        public void LoadWave(int level,int wave)
        {

        }
        //public unsafe bool LoadEnemy(int code,ref EnemyData data)
        //{
        //    AllData* ap = (AllData*)buffer.fakeStruct.ip;
        //    var fs = buffer.fakeStruct.GetData<FakeStructArray>(ap->Enemy);
        //    if(fs!=null)
        //    {
        //        for(int i=0;i<fs.Length;i++)
        //        {
        //            int c = ((EnemyData*)fs[i])->Code;
        //            if(code==c)
        //            {
        //                data = *(EnemyData*)fs[i];
        //                return true;
        //            }
        //        }
        //    }
        //    return false;
        //}
        //public unsafe T LoadBullet<T>(int code)where T:Bullet,new ()
        //{
        //    AllData* ap = (AllData*)buffer.fakeStruct.ip;
        //    var fs = buffer.fakeStruct.GetData<FakeStructArray>(ap->Bullet);
        //    if (fs != null)
        //    {
        //        for (int i = 0; i < fs.Length; i++)
        //        {
        //            BulletData* bp= (BulletData*)fs[i];
        //            int c = bp->Code;
        //            if (code == c)
        //            {
        //                var t = new T();
        //                t.Code = code;
        //                t.MoveType = bp->MoveType;
        //                //t.assetName =buffer.GetData(bp->assetName)as string ;
        //                //t.txtName = buffer.GetData(bp->txtName)as string;
        //                //t.spName = buffer.GetData(bp->spName) as string;
        //                t.vertex = buffer.GetArray<Vector3>(bp->vertex);
        //                t.uv = buffer.GetArray<Vector2>(bp->uv);
        //                return t;
        //            }
        //        }
        //    }
        //    return null;
        //}
    }
}
