using Aliyun.OSS;
using huqiang;
using huqiang.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HotFix
{
    [Serializable]
    public class OssToken
    {
        public string endPoint;
        public string securityToken;
        public string path;
        public string accessKeyId;
        public string accessKeySecret;
        public string type;
        //public string 
    }
    public class OssInfo
    {
        public string type;
        public OssClient client;
        public int time;
        public string folder;
    }
    public class ObjectInfo
    {
        /// <summary>
        /// 存储桶
        /// </summary>
        public string bucket;
        /// <summary>
        /// 先对路径
        /// </summary>
        public string dic;
        /// <summary>
        /// 类型
        /// </summary>
        public string type;
        /// <summary>
        /// 文件名
        /// </summary>
        public string name;
    }
    public class AliyunOss
    {
        static List<OssInfo> osses;
        static void AddOssClient(OssInfo oss)
        {
            for (int i = 0; i < osses.Count; i++)
            {
                if (oss.type == osses[i].type)
                {
                    osses[i] = oss;
                    return;
                }
            }
            osses.Add(oss);
        }
        public static void CreateOssClient(OssToken token)
        {
            OssInfo oss = new OssInfo();
            oss.client = new OssClient(token.endPoint, token.accessKeyId, token.accessKeySecret, token.securityToken);
            var folder = token.path;
            oss.folder = folder.Replace("*", "");
            oss.time =  (int)App.AllTime;
            oss.type = token.type;
            AddOssClient(oss);
        }
        static OssInfo GetOssClient(string type)
        {
            for (int i = 0; i < osses.Count; i++)
            {
                if (osses[i].type == type)
                    return osses[i];
            }
            return null;
        }
        public static bool CheckOssAccess(string type, int id = 0)
        {
            for (int i = 0; i < osses.Count; i++)
            {
                var oss = osses[i];
                if (oss.type == type)
                {
                    if (oss.time + 3500 < App.AllTime)
                    {
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }

        public static async void PutObject(ObjectInfo info, Stream data, Action<OssFileProgress> start, Action<OssFileProgress> done)
        {
            var oss = GetOssClient(info.type);
            OssFileProgress progress = new OssFileProgress(data);
            progress.Info = info;
            if (start != null)
                start(progress);
            string key = info.dic + "/" + info.type + "/" + info.name;
            var result = await Task.Run<PutObjectResult>(() => {
                try
                {
                    return oss.client.PutObject("weark", key, data);
                }catch (Exception ex)
                {
                    Debug.Log(ex.StackTrace);
                    return null;
                }
            });
            progress.result = result;
            if (done != null)
                done(progress);
            progress.Dispose();
        }
        public static async void GetObject(ObjectInfo obj, Action<OssFileProgress> start, Action<OssFileProgress> done)
        {
            var info = GetOssClient(obj.type);
            var client = info.client;
             string key =obj.dic + "/" + obj.type + "/" + obj.name;
             OssFileProgress oss = null;
             await Task.Run(()=>{
                string bp = GetDownLoadPath(obj.bucket, obj.name);
                var request = new GetObjectRequest(obj.bucket, key);
                 try
                 {
                     var meta = client.GetObjectMetadata(obj.bucket, key);
                     if (File.Exists(bp))
                         File.Delete(bp);
                     var fs = File.Create(bp);
                     oss = new OssFileProgress(fs);
                     oss.length = meta.ContentLength;
                     oss.Info = obj;
                 }
                 catch (Exception ex)
                 {
                     Debug.Log(ex.StackTrace);
                 }
            });
            if (oss != null)
            {
                if (start != null)
                    start(oss);
            }
            else return;   
            await Task.Run(()=> {
                try
                {
                    var result = client.GetObject(obj.bucket, key);
                    oss.ossObject = result;
                }catch (Exception ex)
                {
                    Debug.Log(ex.StackTrace);
                }
            });
            if (done != null)
                done(oss);
            oss.Dispose();
        }
        /// <summary>
        /// 获取一个本地可写入的路径
        /// </summary>
        /// <param name="bucket"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        static string GetDownLoadPath(string bucket,string name)
        {
            var dic = LocalFileManager.persistentDataPath + "/oss";
            if (!Directory.Exists(dic))
                Directory.CreateDirectory(dic);
            dic += "/download";
            if (!Directory.Exists(dic))
                Directory.CreateDirectory(dic);
            dic += "/"+bucket;
            if (!Directory.Exists(dic))
                Directory.CreateDirectory(dic);
            dic += "/" + name;
            return dic;
        }
    }
}
