using Aliyun.OSS;
using huqiang;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">上传的文件类型</param>
        /// <param name="name">上传的文件名</param>
        /// <param name="data">要上传的数据</param>
        public static async void UpdateOssData(string type,string name,Stream data,Action<int> callback)
        {
            var oss = GetOssClient(type);
            if (oss== null)
                return;
            try
            {
                string key = oss.folder + name;
                PutObjectResult result = await PutObject(type,"",name,data);
            }
            catch (Exception ex)
            {
               
            }
        }
        static async Task<PutObjectResult> PutObject(string type, string bu, string key, Stream data)
        {
            var oss = GetOssClient(type);
            return await Task.Run<PutObjectResult>(() => {
                return oss.client.PutObject("weark", key, data);
            });
        }
    }
}
