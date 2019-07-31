#define PC
#define UWP
//#undef PC
#undef UWP

#if PC
using System.Threading;
using System.Security.Cryptography;
#endif
#if UWP
using System.Threading;
using System.Threading.Tasks;
using System.IO.IsolatedStorage;
using Windows.Security.Cryptography.Core;
using Windows.Security.Cryptography;
using Windows.Storage.Streams;
#endif

using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;

namespace Assets.UnityVS.Script
{
    class FileManage
    {
        #region const
        public static string datapath;
        static byte[] data_buff;
        static int data_len;
        static int data_count;
        public static Vector2[] def_4x4 { get; set; }
        static void LoadData()
        {
            string path = datapath + "/data";
            FileStream tempstream;
            if (File.Exists(path))
            {
                tempstream = File.Open(path, FileMode.Open, FileAccess.Read);
                data_buff = new byte[tempstream.Length];
                tempstream.Read(data_buff, 0, data_buff.Length);
                tempstream.Dispose();
            }
        }
        public static void InitialData()
        {
            LoadData();
            if (data_buff == null)
                return;
#if PC || UWP
            unsafe
            {
                fixed(byte* b=&data_buff[0])
                {
                    int* ip = (int*)b;
                    data_len = *ip;
                }
            }
#endif
            data_count = data_len / 64;
            LoadConst();
        }
        static void LoadConst()//name
        {
            //def_4x4 = GetVector2(new byte[] { 100, 101, 102, 95, 52, 120, 52, 32 });// 86, 101, 99, 116, 111, 114, 50, 91, 93});
            QueueSourceEX.angle_table = GetPoint2(new byte[] {(byte)'a', (byte)'_', (byte)'t', (byte)'_', (byte)'s', (byte)'_', (byte)'c',
            (byte)'_',(byte)'3',(byte)'6',(byte)'0'});
        }
        static void LoadConstA()//ID
        {
            QueueSourceEX.angle_table = GetPoint2A(0);
        }
        static int FindAddress(byte[] name)
        {
            int s = 12;
            int len = name.Length;
            for(int i=0;i<data_count;i++)
            {
                for (int c = 0; c < len; c++)
                {
                    if (data_buff[s + c] != name[c])
                        goto label1;
                }
                goto label2;
                label1:;
            }
            return -1;
            label2:;
            return s - 8;
        }
        static Vector2[] GetVector2(byte[] name)
        {
            int address = FindAddress(name);
            if (address < 0)
                return null;
            return GetVector2(address);
        }
        static Vector2[] GetVector2A(int id)
        {
            if (id > data_count)
                return null;
            int address = id * 64 + 4;
            return GetVector2(address);
        }
        static Vector2[] GetVector2(int address)
        {
#if PC || UWP
            Vector2[] temp;
            unsafe
            {
                fixed (byte* b = &data_buff[address])
                {
                    int* ip = (int*)b;
                    int offset = *ip;
                    ip++;
                    int len = *ip;
                    len /= 2;
                    temp = new Vector2[len];
                    offset += (int)ip + data_len-address;
                    float* fp = (float*)offset;

                    for (int i = 0; i < len; i++)
                    {
                        temp[i].x = *fp;
                        fp++;
                        temp[i].y = *fp;
                        fp++;
                    }
                }
            }
            return temp;
#endif
            return new Vector2[0];
        }
        static float[] Getfloat(byte[] name)
        {
            int address = FindAddress(name);
            if (address < 0)
                return null;
            return Getfloat(address);
        }
        static float[] GetfloatA(int id)
        {
            if (id > data_count)
                return null;
            int address = id * 64 + 4;
            return Getfloat(address);
        }
        static float[] Getfloat(int address)
        {
#if PC || UWP
            float[] temp;
            unsafe
            {
                fixed (byte* b = &data_buff[address])
                {
                    int* ip = (int*)b;
                    int offset = *ip;
                    ip++;
                    int len = *ip;
                    len /= 4;
                    temp = new float[len];
                    offset += (int)ip + data_len-address;
                    float* fp = (float*)offset;
                    for (int i = 0; i < len; i++)
                    {
                        temp[i] = *fp;
                        fp++;
                    }
                }
            }
            return temp;
#endif
            return new float[0];
        }
        static Point2[] GetPoint2(byte[] name)
        {
            int address = FindAddress(name);
            if (address < 0)
                return null;
            return GetPoint2(address);
        }
        static Point2[] GetPoint2A(int id)
        {
            if (id > data_count)
                return null;
            int address = id * 64 + 4;
            return GetPoint2(address);
        }
        static Point2[] GetPoint2(int address)
        {
#if PC || UWP
            Point2[] temp;
            unsafe
            {
                fixed (byte* b = &data_buff[address])
                {
                    int* ip = (int*)b;
                    int offset = *ip;
                    ip++;
                    int len = *ip;
                    len /= 2;
                    temp = new Point2[len];
                    offset += (int)ip + data_len-address-4;
                    float* fp = (float*)offset;
                    for (int i = 0; i < len; i++)
                    {
                        temp[i].x = *fp;
                        fp++;
                        temp[i].y = *fp;
                        fp++;
                    }
                }
            }
            return temp;
#endif
            return new Point2[0];
        }
        static Point3[] GetPoint3(byte[] name)
        {
            int address = FindAddress(name);
            if (address < 0)
                return null;
            return GetPoint3(address);
        }
        static Point3[] GetPoint3A(int id)
        {
            if (id > data_count)
                return null;
            int address = id * 64 + 4;
            return GetPoint3(address);
        }
        static Point3[] GetPoint3(int address)
        {
#if PC || UWP
            Point3[] temp;
            unsafe
            {
                fixed (byte* b = &data_buff[address])
                {
                    int* ip = (int*)b;
                    int offset = *ip;
                    ip++;
                    int len = *ip;
                    len /= 12;
                    temp = new Point3[len];
                    offset += (int)ip + data_len;
                    float* fp = (float*)offset;
                    for (int i = 0; i < len; i++)
                    {
                        temp[i].x = *fp;
                        fp++;
                        temp[i].y = *fp;
                        fp++;
                        temp[i].z = *fp;
                        fp++;
                    }
                }
            }
            return temp;
#endif
            return new Point3[0];
        }
        #endregion

        #region file 
        struct FileData
        {
            public string path;
            public byte[] data;
        }
        static FileData[] buff_data = new FileData[256];
        static Goods[] buff_goods = new Goods[200];
        static int sum = 0,wait=0;
        static int[] waitid = new int[200];
        readonly static byte[] cypher = System.Text.Encoding.UTF8.GetBytes("huqiang@1990outlook.com");
        static  void LoadResource(int id)
        {
            FileStream tempstream = File.Open(buff_data[id].path, FileMode.Open, FileAccess.Read);
            buff_data[id].data = new byte[tempstream.Length];
            tempstream.Read(buff_data[id].data, 0, buff_data[id].data.Length);
            tempstream.Dispose();            
        }
        public static int LoadFileToBuff(string path)
        {
            int id = -1,c=sum;
            if (c > 0)
                for (int i = 0; i < 200; i++)
                {
                    if (buff_data[i].path == null)
                    {
                        if (id < 0)
                            id = i;
                    }
                    else
                    {
                        if (buff_data[i].path == path)
                            return i;
                        c--;
                        if (c < 0)
                        {
                            if (id < 0)
                                id = i;
                            break;
                        }
                    }
                }
            else id = 0;
            buff_data[id].path = path;
            waitid[wait] = id;
            sum++;
            wait++;
            return id;
        }
        public static byte[] GetFileData(int id)
        {
            return buff_data[id].data;
        }
        public static void Run()//need repair
        {
            if(wait>0)
            {                
                for(int i=0;i<wait;i++)
                {
                    LoadResource(waitid[i]);
                }
                wait = 0;
            }
        } 
        public static void DeleteFileData(int id)
        {
            buff_data[id].path = null;
            buff_data[id].data = null;
            sum--; 
        } 
        public static void ClearFileData()
        {
            for (int i = 0; i < 200; i++)
            {
                if (buff_data[i].path != null)
                {
                    buff_data[i].path = null;
                    buff_data[i].data = null;
                    sum--;
                    if (sum < 1)
                        break;
                } 
            }
        }
        
        static void ReadGood(byte[] fs)
        {
#if PC || UWP
            unsafe
            {
                fixed (byte* b = &fs[0])
                {
                    int* t = (int*)b;
                    for (int i = 0; i < 200; i++)
                    {
                        buff_goods[i].id = *t;
                        t ++;
                        buff_goods[i].level = *t;
                        t ++;
                        buff_goods[i].exp = *t;
                        t ++;
                    }
                }
            }
#endif
        }
        static void GoodsToByte(ref byte[] fs)
        {
#if PC || UWP
            unsafe
            {
                fixed(byte* b=&fs[0])
                {
                    int* t = (int*)b;
                    for (int i = 0; i < 200; i++)
                    {
                        *t= buff_goods[i].id;
                        t ++;
                        *t= buff_goods[i].level;
                        t ++;
                        *t= buff_goods[i].exp;
                        t ++;
                    }
                }
            }
#endif
        }
        public static byte[] AES_Encrypt(byte[] input, byte[] pass)
        {
#if UWP
            SymmetricKeyAlgorithmProvider SAP = SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithmNames.AesEcbPkcs7);
            CryptographicKey AES;
            HashAlgorithmProvider HAP = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Md5);
            CryptographicHash Hash_AES = HAP.CreateHash();

            //string encrypted = "";
            //try
            //{
                byte[] hash = new byte[32];
                Hash_AES.Append(CryptographicBuffer.CreateFromByteArray(pass));
                byte[] temp;
                CryptographicBuffer.CopyToByteArray(Hash_AES.GetValueAndReset(), out temp);

                Array.Copy(temp, 0, hash, 0, 16);//key1
                Array.Copy(temp, 0, hash, 15, 16);//key2

                AES = SAP.CreateSymmetricKey(CryptographicBuffer.CreateFromByteArray(hash));

                //IBuffer Buffer = CryptographicBuffer.CreateFromByteArray(System.Text.Encoding.UTF8.GetBytes(input));
                //encrypted = CryptographicBuffer.EncodeToBase64String(CryptographicEngine.Encrypt(AES, Buffer, null));
                IBuffer Buffer = CryptographicBuffer.CreateFromByteArray(input);
                byte[] Encrypted;
                CryptographicBuffer.CopyToByteArray(CryptographicEngine.Encrypt(AES, Buffer, null), out Encrypted);
                return Encrypted;
            //}
            //catch (Exception ex)
            //{
            //    return null;
            //}
#elif PC
            DES des = DES.Create();
            byte[] k = new byte[8];
            byte[] iv = new byte[8];
            Array.Copy(pass, 0, k, 0, 8);
            Array.Copy(pass, 7, iv, 0, 8);
            des.Key = k;
            des.IV = iv;
            ICryptoTransform ict = des.CreateEncryptor();
            k = ict.TransformFinalBlock(input, 0, input.Length);
            return k;
#endif
            return null;
        }
        public static byte[] AES_Decrypt(byte[] input, byte[] pass)
        {
#if UWP
            SymmetricKeyAlgorithmProvider SAP = SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithmNames.AesEcbPkcs7);
            CryptographicKey AES;
            HashAlgorithmProvider HAP = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Md5);
            CryptographicHash Hash_AES = HAP.CreateHash();

            //string decrypted = "";
            //try
            //{
                byte[] hash = new byte[32];
                Hash_AES.Append(CryptographicBuffer.CreateFromByteArray(pass));
                byte[] temp;
                CryptographicBuffer.CopyToByteArray(Hash_AES.GetValueAndReset(), out temp);

                Array.Copy(temp, 0, hash, 0, 16);//key1
                Array.Copy(temp, 0, hash, 15, 16);//key2

                AES = SAP.CreateSymmetricKey(CryptographicBuffer.CreateFromByteArray(hash));
                //IBuffer Buffer = CryptographicBuffer.DecodeFromBase64String(input);
                IBuffer Buffer = CryptographicBuffer.CreateFromByteArray(input);
                byte[] Decrypted;
                CryptographicBuffer.CopyToByteArray(CryptographicEngine.Decrypt(AES, Buffer, null), out Decrypted);
                //decrypted = System.Text.Encoding.UTF8.GetString(Decrypted, 0, Decrypted.Length);

                return Decrypted;
            //}
            //catch (Exception ex)
            //{                
            //    return null;
            //}
#elif PC
            DES des = DES.Create();
            byte[] k=new byte[8];
            byte[] iv = new byte[8];
            Array.Copy(pass,0,k,0,8);
            Array.Copy(pass,7,iv,0,8);
            des.Key = k;
            des.IV = iv;
            ICryptoTransform ict= des.CreateDecryptor();
            k = ict.TransformFinalBlock(input,0,input.Length);
            return k;
#endif
            return null;
        }
        public static void ReplaceWeapon(int id, Goods g)
        {
            int top = g.level >> 16;
            Goods a = buff_goods[id];
            buff_goods[id] = g;
            a.level &= 0xffff;
            a.level |= top << 16;
            buff_goods[top] = a;
        }
        public static void DeleteGood(int id)
        {
            buff_goods[id].exp = 0;
            buff_goods[id].id = 0;
            buff_goods[id].level = 0;
        }
        public static void AddGood(int type, int id)
        {
            for(int i=10;i<200;i++)
            {
                if(buff_goods[i].level==0)
                {
                    buff_goods[i].id = (type<<16)+id;
                    buff_goods[i].level = i<<16 | 1;
                    break;
                }
            }
        }
        public static void ResetGood(int id, Goods g)
        {
            buff_goods[id] = g;
        }
        public static CurrentDispose GetCurrentSet()
        {
            CurrentDispose cd = new CurrentDispose();
            cd.warplane = ThunderData.Plane_all[buff_goods[0].id & 0xffff];
            cd.B_second = ThunderData.SB_all[buff_goods[1].id & 0xffff];
            cd.wing = ThunderData.Wing_all[buff_goods[2].id & 0xffff];
            cd.shiled = ThunderData.Shiled_all[buff_goods[3].id & 0xffff];
            cd.skill = ThunderData.all_skill[buff_goods[4].id & 0xffff]; //9=gold 8=pass level
            cd.bs_back= ThunderData.SB_all[buff_goods[5].id & 0xffff];
            cd.w_back= ThunderData.Wing_all[buff_goods[6].id & 0xffff];
            return cd;
        }
        public static void LoadDisposeFile()
        {
#if PC
            FileStream tempstream;
            string direction = datapath + @"\vs";
            if (File.Exists(direction))
            {
                tempstream = File.Open(direction, FileMode.Open, FileAccess.Read);
                byte[] temp = new byte[tempstream.Length];
                tempstream.Read(temp, 0, temp.Length);
                ReadGood(AES_Decrypt(temp,cypher));
            }else
            {
                buff_goods[0] = new Goods() { level = 1 };//mainplane
                buff_goods[1] = new Goods() { id = 0x10000, level = 1 };//second weapon
                buff_goods[2] = new Goods() { id = 0x20000, level = 1 };//wing weapon
                buff_goods[3] = new Goods() { id = 0x30000, level = 1 };//shiled 
                buff_goods[4] = new Goods() { id = 0x40000, level = 1 };//enegy weapon
                buff_goods[5] = new Goods() { id = 0x10001, level = 1 };//second weapon change
                buff_goods[6] = new Goods() { id = 0x20001, level = 1 };//wing weapon change
                //buff_goods[8] = new Goods() { level = 1 };//pass level
                buff_goods[9] = new Goods() { level = 1 };//gold                            
                byte[] b = new byte[2400];
                GoodsToByte(ref b);
                b = AES_Encrypt(b, cypher);
                tempstream = File.Create(direction);
                tempstream.Write(b,0,b.Length);
            }
            tempstream.Dispose();
#elif UWP
            IsolatedStorageFile temp = IsolatedStorageFile.GetUserStoreForApplication();
            IsolatedStorageFileStream fs;
            if (temp.FileExists("vs"))
            {
                fs = temp.OpenFile("vs", FileMode.Open);
                byte[] b = new byte[fs.Length];
                fs.Read(b,0,b.Length);
                ReadGood(AES_Decrypt(b,cypher));
            }                
            else
            {
                buff_goods[0] = new Goods() { level = 1 };//mainplane
                buff_goods[1] = new Goods() { id = 0x10000, level = 1 };// second weapon
                buff_goods[2] = new Goods() { id = 0x20000, level = 1 };//wing weapon
                buff_goods[3] = new Goods() { id = 0x30000, level = 1 };//shiled 
                buff_goods[4] = new Goods() { id = 0x40000, level = 1 };//enegy weapon   
                buff_goods[5] = new Goods() { id = 0x10001, level = 1 };//second weapon change
                buff_goods[6] = new Goods() { id = 0x20001, level = 1 };//wing weapon change                            
                byte[] b = new byte[2400];
                GoodsToByte(ref b);
                b= AES_Encrypt(b,cypher);
                fs = temp.CreateFile("vs");
                fs.Write(b,0,b.Length);               
            } 
            fs.Dispose();               
            temp.Dispose();
#endif
        }
        public static void SaveDisposeFile()
        {
#if PC
            FileStream tempstream;
            string direction = datapath+ @"\vs";
            if (File.Exists(direction))            
                tempstream = File.Open(direction, FileMode.Open, FileAccess.Write);                           
            else            
                tempstream = File.Create(direction);
            byte[] b = new byte[2400];
            GoodsToByte(ref b);
            b = AES_Encrypt(b, cypher);
            tempstream.Write(b, 0, b.Length);
            tempstream.Dispose();
            return;
#elif UWP
            IsolatedStorageFile temp = IsolatedStorageFile.GetUserStoreForApplication();
            IsolatedStorageFileStream fs;
            if (temp.FileExists("vs"))            
                fs= temp.OpenFile("vs", FileMode.OpenOrCreate);                
            else
                fs= temp.CreateFile("vs");
            byte[] b = new byte[2400];
            GoodsToByte(ref b);
            b = AES_Encrypt(b, cypher);
            fs.Write(b,0,b.Length);
            fs.Dispose();
            temp.Dispose();
#endif
        }
        public static Goods GetGood(int id)
        {
             return buff_goods[id];      
        }
        public static List<Goods> GetGoods(int type)
        {
            List<Goods> temp = new List<Goods>();
            if (type < 10)
            {
                for (int i = 10; i < 100; i++)
                {
                    if (buff_goods[i].id >> 16 == type & buff_goods[i].level > 0)//
                        temp.Add(buff_goods[i]);
                }
            }
            else
            {
                for (int i = 100; i < 200; i++)
                {
                    if (buff_goods[i].id >> 16 == type)
                        temp.Add(buff_goods[i]);
                }
            } 
            return temp;
        }
        #endregion

    }

    class AsyncManage
    {
#if PC||UWP
        struct ThreadInfo
        {
            public AutoResetEvent are;
            public bool run;
        }
        static ThreadInfo[] pool = new ThreadInfo[3];
#endif
#if PC
        static Thread[] t = new Thread[] { new Thread(() => { AsyncExcute(0); }),
        new Thread(() => { AsyncExcute(1); }),new Thread(() => { AsyncExcute(2); })};
#endif

        static bool stop;
        static Action[] buff_async = new Action[9];

        static int waittask=0;
        public static void Inital()//pc
        {
            stop = false;
#if PC
            for(int i=0;i<3;i++)
            {
                pool[i].are = new AutoResetEvent(false);
                if(t[i].ThreadState==ThreadState.Unstarted)
                t[i].Start();
            }
#elif UWP
            for (int i = 0; i < 3; i++)
            {
                pool[i].are = new AutoResetEvent(false);
            }
            Task.Run(() => { AsyncExcute(0); });
            Task.Run(() => { AsyncExcute(1); });
            Task.Run(() => { AsyncExcute(2); });
#endif
        }

        public static void AsyncDelegate(Action a)
        {
#if PC || UWP
            for (int i = 0; i < 9; i++)
            {
                if (a == buff_async[i])
                    return;
            }
            if (waittask >= 9)//pc
                waittask = 0;
            buff_async[waittask] = a;
            int id = waittask % 3;
            if (!pool[id].run)
                pool[id].are.Set();
            waittask++;
#endif
            //Task.Run(a);
        }
        static void AsyncExcute(int s)
        {
#if PC|| UWP
            try
            {
                while (true)
                {
                    pool[s].are.WaitOne();
                    if(stop)
            return;
                    pool[s].run = true;
                    for (int i=s;i<buff_async.Length;i+=3)
                    {
                        if (buff_async[i] != null)
                        {
                            buff_async[i]();
                            buff_async[i] = null;
                        }
                    }
                    pool[s].run = false;
                }
                // ...
                throw null;    // 异常会在下面被捕获
                               // ...
            }
            catch (Exception ex)
            {
                // 一般会记录异常， 和/或通知其它线程我们遇到问题了
                // ...
                Debug.Log(ex);
                
            }
#endif
        }

        public static void Stop()
        {
            stop = true;
#if PC || UWP
            pool[0].are.Set();
            pool[1].are.Set();
            pool[2].are.Set();
#endif
        }
    }
}
