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
        public float Progress { get { return ((float)data.Position / (float)length) * 100; } }
        internal long length;
        public Stream data;
        public OssFileProgress(Stream stream)
        {
            data = stream;
            length = data.Length;
        }
        public PutObjectResult result;
        public void Dispose()
        {
            if (data != null)
            {
                data.Dispose();
                data = null;
            }
        }
        ~OssFileProgress()
        {
            if (data != null)
            {
                data.Dispose();
                data = null;
            }
        }
    }
}
