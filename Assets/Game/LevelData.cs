using huqiang.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Game
{
    public class BulletData
    {
        public bool FixShot;//发射时是否需要飞机停止运动
        public Vector3 ShotPos;//发射地址
        public float ShotTime;//发射需要蓄力时间
        public float cd;//冷却时间
        public float Speed;//子弹速度
        public int count;//单次发射数量
        public string AniCode;//运动轨迹编码
        public string BulletCode;//子弹编码
    }
    public class EnemyData
    {
        public List<BulletData> bullets=new List<BulletData>();
        public Vector3 StartPos;//出生位置
        public string AniCode;//运动轨迹编码
        public string EnemyCode;//敌机编码
        public int score;//死亡后奖励分数
        public int crystal;//死亡后掉落水晶数
        public float propRate;//死亡后道具掉落比率
    }
    public class WaveData
    {
        public List<EnemyData> enemies = new List<EnemyData>();
        public float time;//持续时间

    }
    public class LevelData
    {
        static DataBuffer buffer;
        public static void LoadData(byte[] data)
        {
            buffer = new DataBuffer(data);
        }
        public static FakeStructArray LoadLevel()
        {
            return null;
        }
        public List<WaveData> waves = new List<WaveData>();
    }
}
