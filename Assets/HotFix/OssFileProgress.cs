using Aliyun.OSS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotFix
{
    public class OssFileProgress
    {
        public ObjectInfo Info;
        public float Progress { get { return ((float)data.Position / (float)length) * 100; } }
        internal long length;
        public Stream data;
        public OssFileProgress(Stream stream)
        {
            data = stream;
            length = data.Length;
            progresses.Add(this);
        }
        public PutObjectResult result;
        public OssObject ossObject;
        public void Dispose()
        {
            if (data != null)
            {
                data.Dispose();
                data = null;
            }
            ossObject = null;
            progresses.Remove(this);
        }
        ~OssFileProgress()
        {
            if (data != null)
            {
                data.Dispose();
                data = null;
            }
        }
        public static List<OssFileProgress> progresses = new List<OssFileProgress>();
    }
}
