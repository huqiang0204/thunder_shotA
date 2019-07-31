using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Game
{
    public class WaveInfo
    {
        /// <summary>
        /// 敌机编码
        /// </summary>
        public int EnemyCode;
        /// <summary>
        /// 敌机的初始化位置
        /// </summary>
        public Vector3 StartPos;
        /// <summary>
        /// 敌机的等级
        /// </summary>
        public int level;
        /// <summary>
        /// 敌机的运动轨迹
        /// </summary>
        public Vector3[] motion;
        /// <summary>
        /// 移动方式
        /// </summary>
        public int motionType;
    }
    public class WaveInfos
    {
        public WaveInfo[] infos;
        /// <summary>
        /// 持续时间
        /// </summary>
        public int Duration = -1;
        /// <summary>
        /// 结束方式
        /// </summary>
        public int endType;
    }
    public class EnemyWave
    {
        public void Create()
        {

        }
        public void Update(float time)
        {

        }
        public void Dispose()
        {

        }
    }
}
