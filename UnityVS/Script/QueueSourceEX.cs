using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.UnityVS.Script
{   

    class QueueSourceEX
    {
        public const float layer = 10;
        public static Point2[] angle_table=SP.a_t_s_c_360;
        public static Font def_font;//=Resources.Load("Fonts/STXINGKA") as Font;
        public static Transform main_canvas;
        public static Vector3 origion_location = new Vector3(0, 0, 10);//pervent multi new instance
        protected static Vector3 origion_scale = new Vector3(1, 1, 0);

        public static Material Mat_Blood;// = Resources.Load("Shader/blood") as Material;
        public static Material Mat_fan;// = Resources.Load("Shader/fan_per") as Material;
        public static Material Mat_def;// = Resources.Load("Shader/Default") as Material;

        protected static Point2[] six_angle_button = new Point2[] {new Point2(-0.3772548f, 0.224755f),
        new Point2(0,0.4465373f),new Point2(0.3772548f, 0.224755f),new Point2(0.3772548f, -0.224755f),
        new Point2(0,-0.4465373f),new Point2(-0.3772548f, -0.224755f) };

        protected static Point2 screen;// = new Point2(Screen.width,Screen.height);
        protected static ImageBase[] buff_img = new ImageBase[256];
        protected static ImageBaseEx[] buff_img_ex = new ImageBaseEx[128];
        public static void LoadBase()
        {
            def_font = Resources.Load("Fonts/STXINGKA") as Font;
            Mat_Blood = Resources.Load("Shader/blood") as Material;
            Mat_fan = Resources.Load("Shader/fan_per") as Material;
            Mat_def = Resources.Load("Shader/def_vert") as Material;
            screen = new Point2(Screen.width, Screen.height);
        }

        #region sound control
        //static GameObject[] buff_sound=new GameObject[3];
        //static AudioClip AC= Resources.Load("Sound/ding") as AudioClip;
        //static AudioSource[] AS=new AudioSource[3];
       // public static bool asopen { get; set; }

        public static void PlaySound()//i can't make music 不会制作音乐太鬼畜
        {
            //for(int i=0;i<3;i++)
            //{
            //    if(buff_sound[i]==null)
            //    {
            //        buff_sound[i] = new GameObject();
            //        AS[i] = buff_sound[i].AddComponent<AudioSource>();
            //        AS[i].clip = AC;                   
            //        AS[i].Play();
            //        break;
            //    }
            //    if (AS[i].isPlaying == false)
            //    {
            //        AS[i].Play();
            //        break;
            //    }                   
            //}            
        }
        #endregion

        #region collion check
        public static Point2[] GetPointsOffset(Vector3 location,ref Point2[] offsest)
        {
            Point2[] temp = new Point2[offsest.Length];
            for(int i=0;i<temp.Length;i++)
            {
                temp[i].x = location.x + offsest[i].x;
                temp[i].y = location.y + offsest[i].y;
            }
            return temp;
        }
        public static bool DotToPolygon(Point2 origion, Point2[] A, Point2 B)//offset
        {
            int count = 0;
            for (int i = 0; i < A.Length; i++)
            {
                Point2 p1 = A[i];
                p1.x += origion.x;
                p1.y += origion.y;
                Point2 p2 = i == A.Length - 1 ? A[0] : A[i + 1];
                p2.x += origion.x;
                p2.y += origion.y;
                if (B.y >= p1.y & B.y <= p2.y | B.y >= p2.y & B.y <= p1.y)
                {
                    float t = (B.y - p1.y) / (p2.y - p1.y);
                    float xt = p1.x + t * (p2.x - p1.x);
                    if (B.x == xt)
                        return true;
                    if (B.x < xt)
                        count++;
                }
            }
            return count % 2 > 0 ? true : false;
        }
        public static bool DotToPolygon(Point2[] A, Point2 B)//rotate
        {
            int count = 0;
            for (int i = 0; i < A.Length; i++)
            {
                Point2 p1 = A[i];
                Point2 p2 = i == A.Length - 1 ? A[0] : A[i + 1];
                if (B.y >= p1.y & B.y <= p2.y | B.y >= p2.y & B.y <= p1.y)
                {
                    float t = (B.y - p1.y) / (p2.y - p1.y);
                    float xt = p1.x + t * (p2.x - p1.x);
                    if (B.x == xt)
                        return true;
                    if (B.x < xt)
                        count++;
                }
            }
            return count % 2 > 0 ? true : false;
        }
        public static bool CircleToCircle(Vector2 A, Vector2 B, float radiusA, float radiusB)
        {
            return radiusA + radiusB > Mathf.Sqrt((A.x - B.x) * (A.x - B.x) + (A.y - B.y) * (A.y - B.y));
        }
        public static Point2 RotatePoint2(ref Point2 p,ref Point2 location,float angle)//a=绝对角度 d=直径
        {
            float a = p.x + angle;
            if (a < 0)
                a += 360;
            if (a > 360)
                a -= 360;
            a*= 0.0174533f;//change angle to radin
            float d = p.y ;
            Point2 temp = new Point2();
            temp.x = location.x - Mathf.Sin(a) * d;
            temp.y = location.y + Mathf.Cos(a) * d;
            return temp;
        }
        public static Vector3 RotateVector3(Point2 p,ref Vector3 location, float angle)//a=绝对角度 d=直径
        {
            int a = (int)(p.x + angle);
            if (a < 0)
                a += 360;
            if (a > 360)
                a -= 360;
            float d = p.y;
            Vector3 temp = location;           
            temp.x = location.x +angle_table[a].x * d;
            temp.y = location.y + angle_table[a].y * d;
            return temp;
        }
        public static void RotatePoint2(ref Point2 p, ref Point2 location, float angle, ref Vector3 o)//a=绝对角度 d=直径
        {
            int a = (int)(p.x + angle);
            if (a < 0)
                a += 360;
            if (a > 360)
                a -= 360;
            float d = p.y;
            o.x = location.x + angle_table[a].x * d;
            o.y = location.y + angle_table[a].y * d;
        }
        public static Point2[] RotatePoint2(ref Point2[] P, Point2 location, float angle)//p[].x=绝对角度 p[].y=直径
        {           
            Point2[] temp = new Point2[P.Length]; 
            for(int i=0;i<P.Length;i++)
            {
                int a =(int)(P[i].x+angle);//change angle to radin
                if (a < 0)
                    a += 360;
                if (a >= 360)
                    a -= 360;
                temp[i].x = location.x + angle_table[a].x * P[i].y;
                temp[i].y = location.y + angle_table[a].y * P[i].y;
            }                     
            return temp;
        }
        public static Point3 RotatePoint(Point3 P, Point3 A, float rad, float r, bool isClockwise)//弧度只能表示180°所以用正反转表示
        {
            //点Temp1
            Point3 Temp1 = new Point3();
            Temp1.x = P.x - A.x;
            Temp1.y = P.x - A.x;
            //∠T1OX弧度
            float angT1OX = radPOX(Temp1.x, Temp1.y);
            //∠T2OX弧度（T2为T1以O为圆心旋转弧度rad）
            float angT2OX = angT1OX - (isClockwise ? 1 : -1) * rad;
            //点Temp2
            Point3 Temp2 = new Point3();
            Temp2.x = r * Mathf.Cos(angT2OX) + A.x;
            Temp2.y = r * Mathf.Sin(angT2OX) + A.y;
            //点Q
            return Temp2;
        }
        public static Point3[] RotatePoints(ref Point3[] P, Point3 origion, float angle)//弧度只能表示180°所以用正反转表示
        {
            if (angle > 180)
                angle += -360;
            angle /= 57.29577951f;
            for (int i = 0; i < P.Length; i++)
            {
                //点Temp1
                Point3 Temp1 = new Point3();
                Temp1.x = P[i].x - origion.x;
                Temp1.y = P[i].x - origion.x;
                //∠T1OX弧度
                float angT1OX = radPOX(Temp1.x, Temp1.y);
                //∠T2OX弧度（T2为T1以O为圆心旋转弧度rad）
                float angT2OX = angT1OX - angle;
                //点Temp2

                P[i].x = P[i].z * Mathf.Cos(angT2OX) + origion.x;
                P[i].y = P[i].z * Mathf.Sin(angT2OX) + origion.y;
                //点Q
            }
            return P;
        }
        public static float radPOX(float x, float y)
        {
            //P在(0,0)的情况
            if (x == 0 && y == 0) return 0;

            //P在四个坐标轴上的情况：x正、x负、y正、y负
            if (y == 0 && x > 0) return 0;
            if (y == 0 && x < 0) return Mathf.PI;
            if (x == 0 && y > 0) return Mathf.PI / 2;
            if (x == 0 && y < 0) return Mathf.PI / 2 * 3;

            //点在第一、二、三、四象限时的情况
            if (x > 0 && y > 0) return Mathf.Atan(y / x);
            if (x < 0 && y > 0) return Mathf.PI - Mathf.Atan(y / -x);
            if (x < 0 && y < 0) return Mathf.PI + Mathf.Atan(-y / -x);
            if (x > 0 && y < 0) return Mathf.PI * 2 - Mathf.Atan(-y / x);

            return 0;
        }
        public static bool PToP2(Point2[] A, Point2[] B)
        {
            //Cos A=(b²+c²-a²)/2bc
            float min1 = 0, max1 = 0, min2 = 0, max2 = 0;
            int second = 0;
            Point2 a, b;
        label1:
            for (int i = 0; i < A.Length; i++)
            {
                int id;
                a = A[i];
                if (i == A.Length - 1)
                {
                    b = A[0];
                    id = 1;
                }
                else
                {
                    b = A[i + 1];
                    id = i + 2;
                }
                float x = a.x - b.x;
                float y = a.y - b.y;//向量
                a.x = y;
                a.y = -x;//法线点a
                b.x = -y;
                b.y = x;//法线点b
                        // float ab = (x + x) * (x + x) + (y + y) * (y + y);//b 平方
                        //x = c.x - a.x;
                        //y = c.y - a.y;
                float ac;// = x * x + y * y;//c 平方
                //x = b.x - c.x;
                //y = b.y - c.y;
                float bc;// = x * x + y * y;//a 平方
                //float d = Mathf.Sqrt(bc) + Mathf.Sqrt(ac) - Mathf.Sqrt(ab);
                float d;// = ac - bc;
                //min1 = d;
                //max1 = d;
                for (int o = 0; o < A.Length; o++)
                {
                    float x1 = A[o].x - a.x;
                    x1 *= x1;
                    float y1 = A[o].y - a.y;
                    ac = x1 + y1 * y1;//ac
                    float x2 = b.x - A[o].x;
                    x2 *= x2;
                    float y2 = b.y - A[o].y;
                    bc = x2 + y2 * y2;//bc
                    d = ac - bc;//ab+ac-bc
                    if (o == 0)
                    {
                        min1 = max1 = d;
                    }
                    else
                    {
                        if (d < min1)
                            min1 = d;
                        else if (d > max1)
                            max1 = d;
                    }
                }
                for (int o = 0; o < B.Length; o++)
                {
                    float x1 = B[o].x - a.x;
                    x1 *= x1;
                    float y1 = B[o].y - a.y;
                    ac = x1 + y1 * y1;//ac
                    float x2 = b.x - B[o].x;
                    x2 *= x2;
                    float y2 = b.y - B[o].y;
                    bc = x2 + y2 * y2;//bc
                    d = ac - bc;//ab+ac-bc
                    if (o == 0)
                        max2 = min2 = d;
                    else
                    {
                        if (d < min2)
                            min2 = d;
                        else if (d > max2)
                            max2 = d;
                    }
                }
                if (min2 > max1 | min1 > max2)
                    return false;
            }
            second++;
            if (second < 2)
            {
                Point2[] temp = A;
                A = B;
                B = temp;
                goto label1;
            }
            return true;
        }
        public static bool PToP2A(Point2[] A, Point2[] B, ref Vector3 location)
        {
            //formule
            //A.x+x1*V1.x=B.x+x2*V2.x
            //x2*V2.x=A.x+x1*V1.x-B.x
            //x2=(A.x+x1*V1.x-B.x)/V2.x
            //A.y+x1*V1.y=B.y+x2*V2.y
            //A.y+x1*V1.y=B.y+(A.x+x1*V1.x-B.x)/V2.x*V2.y
            //x1*V1.y=B.y+(A.x-B.x)/V2.x*V2.y-A.y+x1*V1.x/V2.x*V2.y
            //x1*V1.y-x1*V1.x/V2.x*V2.y=B.y+(A.x-B.x)/V2.x*V2.y-A.y
            //x1*(V1.y-V1.x/V2.x*V2.y)=B.y+(A.x-B.x)/V2.x*V2.y-A.y
            //x1=(B.y-A.y+(A.x-B.x)/V2.x*V2.y)/(V1.y-V1.x/V2.x*V2.y)
            //改除为乘防止除0溢出
            //if((V1.y*V2.x-V1.x*V2.y)==0) 平行
            //x1=((B.y-A.y)*V2.x+(A.x-B.x)*V2.y)/(V1.y*V2.x-V1.x*V2.y)
            //x2=(A.x+x1*V1.x-B.x)/V2.x
            //x2=(A.y+x1*V1.y-B.y)/V2.y
            //if(x1>=0&x1<=1 &x2>=0 &x2<=1) cross =true
            //location.x=A.x+x1*V1.x
            //location.y=A.x+x1*V1.y
            Point2[] VB = new Point2[B.Length];
            for (int i = 0; i < B.Length; i++)
            {
                if (i == B.Length - 1)
                {
                    VB[i].x = B[0].x - B[i].x;
                    VB[i].y = B[0].y - B[i].y;
                }
                else
                {
                    VB[i].x = B[i + 1].x - B[i].x;
                    VB[i].y = B[i + 1].y - B[i].y;
                }
            }
            for (int i = 0; i < A.Length; i++)
            {
                Point2 VA = new Point2();
                if (i == A.Length - 1)
                {
                    VA.x = A[0].x - A[i].x;
                    VA.y = A[0].y - A[i].y;
                }
                else
                {
                    VA.x = A[i + 1].x - A[i].x;
                    VA.y = A[i + 1].y - A[i].y;
                }
                for (int c = 0; c < B.Length; c++)
                {
                    //(V1.y*V2.x-V1.x*V2.y)
                    float y = VA.y * VB[c].x - VA.x * VB[c].y;
                    if (y == 0)
                        break;
                    //((B.y-A.y)*V2.x+(A.x-B.x)*V2.y)
                    float x = (B[c].y - A[i].y) * VB[c].x + (A[i].x - B[c].x) * VB[c].y;
                    float d = x / y;
                    if (d >= 0 & d <= 1)
                    {
                        if (VB[c].x == 0)
                        {
                            //x2=(A.y+x1*V1.y-B.y)/V2.y
                            y = (A[i].y - B[c].y + d * VA.y) / VB[c].y;
                        }
                        else
                        {
                            //x2=(A.x+x1*V1.x-B.x)/V2.x
                            y = (A[i].x - B[c].x + d * VA.x) / VB[c].x;
                        }
                        //location.x=A.x+x1*V1.x
                        //location.y=A.x+x1*V1.y
                        if (y >= 0 & y <= 1)
                        {
                            location.x = A[i].x + d * VA.x;
                            location.y = A[i].y + d * VA.y;
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static bool PToP2A(Point2[] A, Point2[] B, ref Vector3 la,ref Vector3 lb)
        {
            //formule
            //A.x+x1*V1.x=B.x+x2*V2.x
            //x2*V2.x=A.x+x1*V1.x-B.x
            //x2=(A.x+x1*V1.x-B.x)/V2.x
            //A.y+x1*V1.y=B.y+x2*V2.y
            //A.y+x1*V1.y=B.y+(A.x+x1*V1.x-B.x)/V2.x*V2.y
            //x1*V1.y=B.y+(A.x-B.x)/V2.x*V2.y-A.y+x1*V1.x/V2.x*V2.y
            //x1*V1.y-x1*V1.x/V2.x*V2.y=B.y+(A.x-B.x)/V2.x*V2.y-A.y
            //x1*(V1.y-V1.x/V2.x*V2.y)=B.y+(A.x-B.x)/V2.x*V2.y-A.y
            //x1=(B.y-A.y+(A.x-B.x)/V2.x*V2.y)/(V1.y-V1.x/V2.x*V2.y)
            //改除为乘防止除0溢出
            //if((V1.y*V2.x-V1.x*V2.y)==0) 平行
            //x1=((B.y-A.y)*V2.x+(A.x-B.x)*V2.y)/(V1.y*V2.x-V1.x*V2.y)
            //x2=(A.x+x1*V1.x-B.x)/V2.x
            //x2=(A.y+x1*V1.y-B.y)/V2.y
            //if(x1>=0&x1<=1 &x2>=0 &x2<=1) cross =true
            //location.x=A.x+x1*V1.x
            //location.y=A.x+x1*V1.y
            bool re = false;
            Point2[] VB = new Point2[B.Length];
            for (int i = 0; i < B.Length; i++)
            {
                if (i == B.Length - 1)
                {
                    VB[i].x = B[0].x - B[i].x;
                    VB[i].y = B[0].y - B[i].y;
                }
                else
                {
                    VB[i].x = B[i + 1].x - B[i].x;
                    VB[i].y = B[i + 1].y - B[i].y;
                }
            }
            for (int i = 0; i < A.Length; i++)
            {
                Point2 VA = new Point2();
                if (i == A.Length - 1)
                {
                    VA.x = A[0].x - A[i].x;
                    VA.y = A[0].y - A[i].y;
                }
                else
                {
                    VA.x = A[i + 1].x - A[i].x;
                    VA.y = A[i + 1].y - A[i].y;
                }
                for (int c = 0; c < B.Length; c++)
                {
                    //(V1.y*V2.x-V1.x*V2.y)
                    float y = VA.y * VB[c].x - VA.x * VB[c].y;
                    if (y == 0)
                        break;
                    //((B.y-A.y)*V2.x+(A.x-B.x)*V2.y)
                    float x = (B[c].y - A[i].y) * VB[c].x + (A[i].x - B[c].x) * VB[c].y;
                    float d = x / y;
                    if (d >= 0 & d <= 1)
                    {
                        if (VB[c].x == 0)
                        {
                            //x2=(A.y+x1*V1.y-B.y)/V2.y
                            y = (A[i].y - B[c].y + d * VA.y) / VB[c].y;
                        }
                        else
                        {
                            //x2=(A.x+x1*V1.x-B.x)/V2.x
                            y = (A[i].x - B[c].x + d * VA.x) / VB[c].x;
                        }
                        //location.x=A.x+x1*V1.x
                        //location.y=A.x+x1*V1.y
                        if (y >= 0 & y <= 1)
                        {
                            if(re)
                            {
                                lb.x = A[i].x + d * VA.x;
                                lb.y = A[i].y + d * VA.y;
                                return true;
                            }else
                            {
                                la.x = A[i].x + d * VA.x;
                                la.y = A[i].y + d * VA.y;
                                re = true;
                            }                           
                        }
                    }
                }
            }
            return re;
        }
        public static bool PToP3(Point3[] A, Point3[] B)
        {
            //Cos A=(b²+c²-a²)/2bc
            float min1 = 0, max1 = 0, min2 = 0, max2 = 0;
            int second = 0;
            Point3 a, b;
        label1:
            for (int i = 0; i < A.Length; i++)
            {
                int id;
                a = A[i];
                if (i == A.Length - 1)
                {
                    b = A[0];
                    id = 1;
                }
                else
                {
                    b = A[i + 1];
                    id = i + 2;
                }
                float x = a.x - b.x;
                float y = a.y - b.y;//向量
                a.x = y;
                a.y = -x;//法线点a
                b.x = -y;
                b.y = x;//法线点b
                        // float ab = (x + x) * (x + x) + (y + y) * (y + y);//b 平方
                        //x = c.x - a.x;
                        //y = c.y - a.y;
                float ac;// = x * x + y * y;//c 平方
                //x = b.x - c.x;
                //y = b.y - c.y;
                float bc;// = x * x + y * y;//a 平方
                //float d = Mathf.Sqrt(bc) + Mathf.Sqrt(ac) - Mathf.Sqrt(ab);
                float d;// = ac - bc;
                //min1 = d;
                //max1 = d;
                for (int o = 0; o < A.Length; o++)
                {
                    float x1 = A[o].x - a.x;
                    x1 *= x1;
                    float y1 = A[o].y - a.y;
                    ac = x1 + y1 * y1;//ac
                    float x2 = b.x - A[o].x;
                    x2 *= x2;
                    float y2 = b.y - A[o].y;
                    bc = x2 + y2 * y2;//bc
                    d = ac - bc;//ab+ac-bc
                    if (o == 0)
                    {
                        min1 = max1 = d;
                    }
                    else
                    {
                        if (d < min1)
                            min1 = d;
                        else if (d > max1)
                            max1 = d;
                    }
                }
                for (int o = 0; o < B.Length; o++)
                {
                    float x1 = B[o].x - a.x;
                    x1 *= x1;
                    float y1 = B[o].y - a.y;
                    ac = x1 + y1 * y1;//ac
                    float x2 = b.x - B[o].x;
                    x2 *= x2;
                    float y2 = b.y - B[o].y;
                    bc = x2 + y2 * y2;//bc
                    d = ac - bc;//ab+ac-bc
                    if (o == 0)
                        max2 = min2 = d;
                    else
                    {
                        if (d < min2)
                            min2 = d;
                        else if (d > max2)
                            max2 = d;
                    }
                }
                if (min2 > max1 | min1 > max2)
                    return false;
            }
            second++;
            if (second < 2)
            {
                Point3[] temp = A;
                A = B;
                B = temp;
                goto label1;
            }
            return true;
        }
        public static bool TriangleToPolygon(Point3[] A, Point3[] B)
        {
            Point3[] a = new Point3[3]
            {
            new Point3(A[1].x - A[0].x, A[1].y - A[0].y,0),
            new Point3(A[2].x - A[1].x, A[2].y - A[1].y,0),
            new Point3(A[0].x - A[2].x, A[0].y - A[2].y,0)
            };
            int again = 0;
        label1:
            for (int i = 0; i < a.Length; i++)
            {
                float min1 = 1000, min2 = 1000, max1 = 0, max2 = 0;
                float sxy = a[i].x * a[i].x + a[i].y * a[i].y;
                for (int l = 0; l < 3; l++)
                {
                    float dxy = A[l].x * a[i].x + A[l].y * a[i].y;
                    float x = dxy / sxy * a[i].x;
                    if (x < 0)
                        x = 0 - x;
                    float y = dxy / sxy * a[i].y;
                    if (y < 0)
                        y = 0 - y;
                    x = x + y;
                    if (x > max1)
                        max1 = x;
                    if (x < min1)
                        min1 = x;
                }
                for (int l = 0; l < B.Length; l++)
                {
                    float dxy = B[l].x * a[i].x + B[l].y * a[i].y;
                    float x = dxy / sxy * a[i].x;
                    if (x < 0)
                        x = 0 - x;
                    float y = dxy / sxy * a[i].y;
                    if (y < 0)
                        y = 0 - y;
                    x = x + y;
                    if (x > max2)
                        max2 = x;
                    if (x < min2)
                        min2 = x;
                }
                if (min1 > max2 | min2 > max1)
                {
                    return false;
                }
            }
            if (again > 0)
                return true;
            a = new Point3[B.Length];
            for (int i = 0; i < B.Length - 1; i++)
            {
                a[i].x = B[i + 1].x - B[i].x;
                a[i].y = B[i + 1].y - B[i].y;
            }
            a[a.Length - 1].x = B[0].x - B[a.Length - 1].x;
            a[a.Length - 1].y = B[0].y - B[a.Length - 1].y;
            again++;
            goto label1;
        }
        public static bool CircleToPolygon(Vector2 C, float r, Point2[] P)
        {
            Point2 A = new Point2();
            Point2 B = new Point2();
            float z = 10, r2 = r * r, x = 0, y = 0;
            float[] d = new float[P.Length];
            int id = 0;
            for (int i = 0; i < P.Length; i++)
            {
                x = C.x - P[i].x;
                y = C.y - P[i].y;
                x = x * x + y * y;
                if (x <= r2)
                    return true;
                d[i] = x;
                if (x < z)
                {
                    z = x;
                    id = i;
                }
            }
            int p1 = id - 1;
            if (p1 < 0)
                p1 = P.Length - 1;
            float a, b, c;
            c = d[p1];
            a = d[id];
            B = P[id];
            A = P[p1];
            x = B.x - A.x;
            x *= x;
            y = B.y - A.y;
            y *= y;
            b = x + y;
            x = c - a;
            if (x < 0)
                x = -x;
            if (x <= b)
            {
                y = b + c - a;
                y = y * y / 4 / b;
                if (c - y <= r2)
                    return true;
            }
            else
            {
                p1 = id + 1;
                if (p1 == P.Length)
                    p1 = 0;
                c = d[p1];
                A = P[p1];
                x = B.x - A.x;
                x *= x;
                y = B.y - A.y;
                y *= y;
                b = x + y;
                x = c - a;
                if (x < 0)
                    x = -x;
                if (x <= b)
                {
                    y = b + c - a;
                    y = y * y / 4 / b;
                    if (c - y <= r2)
                        return true;
                }
            }
            return DotToPolygon(P, new Point2(C.x,C.y));//circle inside polygon
        }
        public static bool CircleToPolygon(Point2 C, float r, Point2[] P)
        {
            Point2 A = new Point2();
            Point2 B = new Point2();
            float z = 10, r2 = r * r, x = 0, y = 0;
            float[] d = new float[P.Length];
            int id = 0;
            for (int i = 0; i < P.Length; i++)
            {
                x = C.x - P[i].x;
                y = C.y - P[i].y;
                x = x * x + y * y;
                if (x <= r2)
                    return true;
                d[i] = x;
                if (x < z)
                {
                    z = x;
                    id = i;
                }
            }
            int p1 = id - 1;
            if (p1 < 0)
                p1 = P.Length - 1;
            float a, b, c;
            c = d[p1];
            a = d[id];
            B = P[id];
            A = P[p1];
            x = B.x - A.x;
            x *= x;
            y = B.y - A.y;
            y *= y;
            b = x + y;
            x = c - a;
            if (x < 0)
                x = -x;
            if (x <= b)
            {
                y = b + c - a;
                y = y * y / 4 / b;
                if (c - y <= r2)
                    return true;
            }
            else
            {
                p1 = id + 1;
                if (p1 == P.Length)
                    p1 = 0;
                c = d[p1];
                A = P[p1];
                x = B.x - A.x;
                x *= x;
                y = B.y - A.y;
                y *= y;
                b = x + y;
                x = c - a;
                if (x < 0)
                    x = -x;
                if (x <= b)
                {
                    y = b + c - a;
                    y = y * y / 4 / b;
                    if (c - y <= r2)
                        return true;
                }
            }
            return DotToPolygon(P, C);//circle inside polygon
        }
        public static bool CircleToLine(Vector2 C, float r, Point2 A, Point2 B)
        {
            float vx1 = C.x - A.x;
            float vy1 = C.y - A.y;
            float vx2 = B.x - A.x;
            float vy2 = B.y - A.y;
            float len = Mathf.Sqrt(vx2 * vx2 + vy2 * vy2);
            vx2 /= len;
            vy2 /= len;
            float u = vx1 * vx2 + vy1 * vy2;
            float x0 = 0f;
            float y0 = 0f;
            if (u <= 0)
            {
                x0 = A.x;
                y0 = A.y;
            }
            else if (u >= len)
            {
                x0 = B.x;
                y0 = B.y;
            }
            else
            {
                x0 = A.x + vx2 * u;
                y0 = A.y + vy2 * u;
            }
            return (C.x - x0) * (C.x - x0) + (C.y - y0) * (C.y - y0) <= r * r;
        }
        public static bool CircleToLine(Point2 C, float r, Point2 A, Point2 B)
        {
            r *= r;
            float x = C.x - B.x;
            x *= x;
            float y = C.y - B.y;
            y *= y;
            float a = x + y;
            if (a <= r)
                return true;
            x = A.x - C.x;
            x *= x;
            y = A.y - C.y;
            y *= y;
            float c = x + y;
            if (c <= r)
                return true;
            x = B.x - A.x;
            x *= x;
            y = B.y - A.y;
            y *= y;
            float b = x + y;
            x = c - a;
            if (x < 0)
                x = -x;
            if (x > b)
                return false;
            y = b + c - a;
            y *= y / 4 / b;
            if (c - y <= r)
                return true;
            return false;        
    }
        #endregion

        #region button and mouse control
        protected static bool mousedown;
        protected static Vector3 mouse_position;
        protected static int cur_bid;
        public static Vector3 PixToCameraOffset(Vector3 pix)
        {
            pix.x -= screen.x / 2;
            pix.y -= screen.y / 2;
            pix.x = pix.x * 10 / screen.y;
            pix.y = pix.y * 10 / screen.y;
            return pix;
        }
        //static void ChangeColora(float a, ButtonEvent id)
        //{
        //    Color hh = buff_img[id.imageid].spriterender.color;
        //    hh.a = hh.a + a;
        //    buff_img[id.imageid].spriterender.color = hh;
        //    if (id.textid > -1)
        //    {
        //        hh = buff_text[id.textid].textmesh.color;
        //        hh.a = hh.a + a;
        //        buff_text[id.textid].textmesh.color = hh;
        //    }
        //}
        public static Vector3 Mouse_Position { get { return mouse_position; } }
        static int CheckClick(Vector3 s_dot)
        {
            Vector3 w_dot = PixToCameraOffset(s_dot);
            for (int i = 15; i > -1; i--)
            {
                if (buff_circlebutton[i].active & buff_circlebutton[i].r > 0)
                {
                    Vector2 t = buff_circlebutton[i].transform.localPosition;
                    if (buff_circlebutton[i].ui)
                    {
                        t.x += screen.x / 2;
                        t.y += screen.y / 2;
                        if (Vector2.Distance(s_dot, t) < buff_circlebutton[i].r)
                            return i;
                    }
                    else
                    {
                        if (Vector2.Distance(w_dot, t) < buff_circlebutton[i].r)
                            return i;
                    }
                }
            }
            for (int i = 15; i > -1; i--)
            {
                if (buff_edgebutton[i].active &buff_edgebutton[i].points != null)
                {
                    Point2 origion = new Point2(buff_edgebutton[i].transform.localPosition.x, buff_edgebutton[i].transform.localPosition.y);
                    if (buff_edgebutton[i].ui)
                    {
                        origion.x += screen.x / 2;
                        origion.y += screen.y / 2;
                        if (DotToPolygon(origion, buff_edgebutton[i].points, new Point2(s_dot.x, s_dot.y)))
                            return i + 256;
                    }
                    else
                    {
                        if (DotToPolygon(origion, buff_edgebutton[i].points, new Point2(w_dot.x, w_dot.y)))
                            return i + 256;
                    }
                }
            }
            return -1;
        }       
        public static void Mouse_Click(Vector3 dot)//
        {
            mouse_position = dot;
            cur_bid = CheckClick(dot);
            if(cur_bid!=-1)
            {
                if (cur_bid > 255)
                {
                    if (buff_edgebutton[cur_bid - 256].click != null)
                        buff_edgebutton[cur_bid - 256].click();
                }                   
                else if(buff_circlebutton[cur_bid].click!=null)
                    buff_circlebutton[cur_bid].click();
            } 
        }
        public static void Mouse_Down(Vector3 dot)
        {
            mousedown = true;
            mouse_position = dot;
            cur_bid= CheckClick(dot);                
        }
        public static void Mouse_Up(Vector3 dot)
        {
            mousedown = false;
            //if (CheckClick(Camera.main.ScreenToWorldPoint(dot), ref cur_bid))
            //    ChangeColora(0.2f, cur_bid);
        }

        protected static Sliding mouse_move;
        public static void Mouse_Move(Vector3 dot)
        {
            if (mouse_move != null)
                mouse_move(dot);
            if (mousedown)
                if (cur_bid != -1)
                {
                    Vector3 temp = dot - mouse_position;
                    mouse_position = dot;
                    if (cur_bid > 255)
                    {
                        if (buff_edgebutton[cur_bid - 256].sliding != null)
                            buff_edgebutton[cur_bid - 256].sliding(temp);
                    }
                    else
                        if (buff_circlebutton[cur_bid].sliding != null)
                        buff_circlebutton[cur_bid].sliding(temp);
                }
        }
        
        static CircleButtonBase[] buff_circlebutton = new CircleButtonBase[16];
        static EdgeButtonBase[] buff_edgebutton = new EdgeButtonBase[16];
        static int cb_id = 0, eb_id = 0;        
        public static void ResetCircleButton(CircleButtonBase cb, int id)
        {
            buff_circlebutton[id].r = cb.r;
            buff_circlebutton[id].click = cb.click;
            buff_circlebutton[id].sliding = cb.sliding;
        }
        public static int RegCircleButton(CircleButtonBase cb)
        {
            while (buff_circlebutton[cb_id].r > 0)
                cb_id++;
            buff_circlebutton[cb_id] = cb;
            buff_circlebutton[cb_id].active = true;
            return cb_id;
        }
        public static void UnRegCircleButton(int id)
        {
            buff_circlebutton[id].r = 0;
            buff_circlebutton[id].active = false;
            if (id < cb_id)
                cb_id = id;
        }
        public static CircleButtonBase GetCircleButton(int id)
        { return buff_circlebutton[id]; }

        public static void ResetEdgeButton(EdgeButtonBase eb, int id)
        {         
            buff_edgebutton[id].click = eb.click;
            buff_edgebutton[id].sliding = eb.sliding;
            buff_edgebutton[id].points = eb.points;
        }
        public static int RegEdgeButton(EdgeButtonBase eb)
        {
            while (buff_edgebutton[eb_id].points != null)
                eb_id++;
            buff_edgebutton[eb_id] = eb;
            buff_edgebutton[eb_id].active = true;
            return eb_id;
        }
        public static void UnRegEdgeButton(int id)
        {
            buff_edgebutton[id].points = null;
            buff_edgebutton[id].active = false;
            if (id < eb_id)
                eb_id = id;
        }
        public static EdgeButtonBase GetEdgeButton(int id)
        { return buff_edgebutton[id]; }

        public static void ClearButton()
        {
            for (int i = 0; i < 16; i++)
                buff_circlebutton[i].r = 0;
            for (int i = 0; i < 16; i++)
                buff_edgebutton[i].points = null;
        }

        public static int CreateCircleButton(Transform parent, CirclePropertyEx target)
        {
            int id= target.property.imageid = CreateImage(parent, target.imagebase);
            target.property.transform = buff_img[id].transform;
            if (target.text.text != null)
                target.property.textid = CreateText(buff_img[id].transform, target.text);
            else
                target.property.textid = -1;
            return RegCircleButton(target.property);
        }
        public static void DeleteCircleButton(int id)
        {
            RecycleImage(buff_circlebutton[id].imageid);
            if (buff_circlebutton[id].textid != -1)
                RecycleText(buff_circlebutton[id].textid);
            UnRegCircleButton(id);
        }
        public static void ResetCircleButton(Transform parent, CirclePropertyEx target, int id)
        {
            ResetImage(parent, target.imagebase, buff_circlebutton[id].imageid);
            if( buff_circlebutton[id].textid!=-1)
            ResetText(buff_img[buff_circlebutton[id].imageid].transform, target.text, buff_circlebutton[id].textid);
            target.property.transform = buff_img[buff_circlebutton[id].imageid].transform;
            ResetCircleButton(target.property, id);
        }
        public static void HideCircleButton(int id)
        {
            buff_circlebutton[id].active = false;
            buff_img[buff_circlebutton[id].imageid].gameobject.SetActive(false);
            if (buff_circlebutton[id].textid > -1)
                buff_text[buff_circlebutton[id].textid].gameobject.SetActive(false);
        }
        public static void ShowCircleButton(int id)
        {
            buff_circlebutton[id].active = true;
            buff_img[buff_circlebutton[id].imageid].gameobject.SetActive(true);
            if (buff_circlebutton[id].textid> -1)
                buff_text[buff_circlebutton[id].textid].gameobject.SetActive(true);
        }
        public static void ShowCircleButton(int id, Vector3 location)
        {
            buff_circlebutton[id].active = true;
            buff_img[buff_circlebutton[id].imageid].gameobject.SetActive(true);
            buff_img[buff_circlebutton[id].imageid].transform.localPosition = location;
            if (buff_circlebutton[id].textid > -1)
                buff_text[buff_circlebutton[id].textid].gameobject.SetActive(true);
        }

        public static int CreateEdgeButton(Transform parent, EdgePropertyEx target)
        {
            int id= target.property.imageid= CreateImage(parent, target.imagebase);
            target.property.transform = buff_img[id].transform;
            if (target.text.text != null)
                target.property.textid = CreateText(buff_img[id].transform, target.text);
            else
                target.property.textid = -1;
            return RegEdgeButton(target.property);
        }
        public static void DeleteEdgeButton(int id)
        {
            RecycleImage(buff_edgebutton[id].imageid);
            if (buff_edgebutton[id].textid != -1)
                RecycleText(buff_edgebutton[id].textid);
            UnRegEdgeButton(id);
        }
        public static void ResetEdgeButton(Transform parent, EdgePropertyEx target, int id)
        {
            ResetImage(parent, target.imagebase, buff_edgebutton[id].imageid);
            ResetText(buff_img[buff_edgebutton[id].imageid].transform, target.text, buff_edgebutton[id].textid);
            ResetEdgeButton(target.property, id);           
        }

        public static void HideEdgeButton(int id)
        {
            buff_edgebutton[id].active = false;
            buff_img[buff_edgebutton[id].imageid].gameobject.SetActive(false);
            if (buff_edgebutton[id].textid > -1)
                buff_text[buff_edgebutton[id].textid].gameobject.SetActive(false);
        }
        public static void ShowEdgeButton(int id)
        {
            buff_edgebutton[id].active = true;
            buff_img[buff_edgebutton[id].imageid].gameobject.SetActive(true);
            if (buff_edgebutton[id].textid > -1)
                buff_text[buff_edgebutton[id].textid].gameobject.SetActive(true);
        }
        public static void ShowEdgeButton(int id, Vector3 location)
        {
            buff_edgebutton[id].active = true;
            buff_img[buff_edgebutton[id].imageid].gameobject.SetActive(true);
            buff_img[buff_edgebutton[id].imageid].transform.localPosition = location;
            if (buff_edgebutton[id].textid > -1)
                buff_text[buff_edgebutton[id].textid].gameobject.SetActive(true);
        }
        #endregion

        #region image control
        protected static int imageid = 0,imgcycle=192;
        public static int CreateImageNull(Transform parent)
        {
            while (buff_img[imageid].reg)
                imageid++;
            int id = imageid;           
            if (imgcycle > 192)
            {
                imgcycle--;
                buff_img[id] = buff_img[imgcycle];
                buff_img[id].gameobject.SetActive(true);
            }
            else
            {
                GameObject temp = new GameObject();
                buff_img[id].gameobject = temp;
                buff_img[id].transform = temp.transform;
                buff_img[id].spriterender = temp.AddComponent<SpriteRenderer>();
                buff_img[id].spriterender.material = Mat_def;
            }
            buff_img[id].transform.SetParent(parent);
            buff_img[id].reg = true;
            return id;
        }
        public static int CreateImage(Transform parent, ImageProperty target)
        {
            int id = CreateImageNull(parent);
            buff_img[id].transform.localScale = target.scale;
            buff_img[id].transform.localPosition = target.location;
            buff_img[id].transform.localEulerAngles = target.angle;
            buff_img[id].spriterender.sortingOrder = target.sorting;
            //buff_img[id].spriterender.material = Mat_def;
            if (target.imagepath != null)
                buff_img[id].spriteid = CreateSprite(ref buff_img[id].spriterender, target.imagepath);
            return id;
        }
        public static int CreateImageA(Transform parent, ImageProperty target, int spt_id)
        {
            int id = CreateImageNull(parent);
            buff_img[id].transform.localScale = target.scale;
            buff_img[id].transform.localPosition = target.location;
            buff_img[id].transform.localEulerAngles = target.angle;
            buff_img[id].spriterender.sortingOrder = target.sorting;
            if (target.imagepath != null)
            {
                if (buff_spriteex[spt_id].sprites == null)
                    CreateSpriteGA(spt_id, target.grid);
            }
            buff_img[id].spriterender.sprite = buff_spriteex[spt_id].sprites[0];
            return id;
        }
        public static void ResetImage(Transform parent, ImageProperty target, int id)
        {
            buff_img[id].transform.SetParent(parent);
            buff_img[id].transform.localScale = target.scale;
            buff_img[id].transform.localPosition = target.location;
            if (target.angle.z != 0)
                buff_img[id].transform.localEulerAngles = target.angle;
            buff_img[id].spriterender.sortingOrder = target.sorting;
            buff_img[id].spriteid = CreateSprite(ref buff_img[id].spriterender, target.imagepath);
        }
        public static void RecycleImage(int id)
        {
            buff_img[id].reg = false;
            if (id < imageid)
                imageid = id;
            if (buff_img[id].gameobject==null)
                return;
            if (imgcycle >= 255)
            {
                GameObject.Destroy(buff_img[id].gameobject);
            }
            else
            {
                buff_img[id].gameobject.SetActive(false);
                buff_img[imgcycle] = buff_img[id];
                buff_img[id].gameobject = null;
                imgcycle++;
            }           
        }
        public static void ClearImage(int id)
        {
            buff_img[id].reg = false;
            GameObject.Destroy(buff_img[id].gameobject);
            if (id < imageid)
                imageid = id;
        }
        public static void ClearImageRecycle()
        {
            while (imgcycle >= 256)
            {
                imgcycle--;
                if (buff_img[imgcycle].gameobject != null)
                    GameObject.Destroy(buff_img[imgcycle].gameobject, 0);
            }
        }

        public static ImageBase GetImageBase(int id)
        {
            return buff_img[id];
        }
        protected static int img_ex_top;
        protected static int CreateImgNullEx(IMGupdate update,int extra)
        {
            int id ;
            for(id=0;id<128;id++)
            {
                if(!buff_img_ex[id].reg)
                {
                    goto label1;
                }else if(buff_img_ex[id].restore)
                {
                    buff_img_ex[id].gameobject.SetActive(true);
                    buff_img_ex[id].restore = false;
                    goto label2;
                }
            }
            label1:
            buff_img_ex[id].reg = true;
            GameObject temp = new GameObject();
            buff_img_ex[id].gameobject = temp;
            Transform tf = temp.transform;
            buff_img_ex[id].transform = tf;
            tf.localPosition = new Vector3(0,0,layer);
            buff_img_ex[id].mr= temp.AddComponent<MeshRenderer>();
            MeshFilter mf = temp.AddComponent<MeshFilter>();
            mf.mesh = new Mesh();
            buff_img_ex[id].mesh = mf.mesh;
            label2:          
            buff_img_ex[id].update = update;
            buff_img_ex[id].extra = extra;
            if (id > img_ex_top)
                img_ex_top = id;
            return id;
        }
        protected static void UpdateImgEx()
        {
            for (int i = 0; i <= img_ex_top; i++)
            {
                if (buff_img_ex[i].reg)
                {
                    if (!buff_img_ex[i].restore)
                    {
                        if (buff_img_ex[i].update != null)
                            buff_img_ex[i].update(ref buff_img_ex[i]);
                        else buff_img_ex[i].restore = true;
                    }
                }
            }
        }
        protected static void ClearImgEx()
        {
            for (int i = 0; i < 128; i++)
            {
                if (buff_img_ex[i].reg)
                {
                    buff_img_ex[i].reg = false;
                    buff_img_ex[i].restore = true;
                    GameObject.Destroy(buff_img_ex[i].gameobject);
                }
            }
        }
        protected static void RecycleImgEx(int id)
        {
             buff_img_ex[id].restore = true;
             buff_img_ex[id].update = null;
             buff_img_ex[id].gameobject.SetActive(false);
        }
#endregion

        #region sprite
        static Vector2 spt_center = new Vector2(0.5f, 0.5f);
        protected static SpriteBaseEx[] buff_spriteex = new SpriteBaseEx[256];
        static int spt_exid, spt_exmax;
        public static int RegSprite(string path)
        {
            for (int i = 0; i <= spt_exmax; i++)
            {
                if (path == buff_spriteex[i].path)
                {
                    buff_spriteex[i].count++;
                    return i;
                }
            }
            while (buff_spriteex[spt_exid].path != null)
                spt_exid++;
            if (spt_exid > spt_exmax)
                spt_exmax = spt_exid;
            buff_spriteex[spt_exid].count = 1;
            buff_spriteex[spt_exid].path = path;
            return spt_exid;
        }
        protected static void RegSpriteA(string path, ref int id)//u
        {
            if (path == null)
                return;
            id = RegSprite(path);
            if (buff_spriteex[id].count < 2)
                buff_spriteex[id].rr = Resources.LoadAsync(path);
        }
        protected static Sprite CreateSpriteP(int spt_id, Grid g)//pc
        {
            byte[] temp = FileManage.GetFileData(buff_spriteex[spt_id].dataid);
            int w = 0, h = 0;
            w = temp[16] << 24 | temp[17] << 16 | temp[18] << 8 | temp[19];
            h = temp[20] << 24 | temp[21] << 16 | temp[22] << 8 | temp[23];
            buff_spriteex[spt_id].texture = new Texture2D(w, h);
            buff_spriteex[spt_id].texture.LoadImage(temp);
            if (g.x == 0)
            {
                Rect rect = new Rect(0, 0, w, h);
                buff_spriteex[spt_id].sprites = new Sprite[1];
                buff_spriteex[spt_id].sprites[0] = Sprite.Create(buff_spriteex[spt_id].texture, rect, spt_center);
            }
            else
            {
                float x = buff_spriteex[spt_id].texture.width / g.x;
                float y = buff_spriteex[spt_id].texture.height / g.y;
                int s = 0;
                buff_spriteex[spt_id].sprites = new Sprite[g.x * g.y];
                Rect rect = new Rect(0, 0, x, y);
                for (int i = 0; i < g.y; i++)
                    for (int c = 0; c < g.x; c++)
                    {
                        rect.x = c * x;
                        rect.y = i * y;
                        buff_spriteex[spt_id].sprites[s] = Sprite.Create(buff_spriteex[spt_id].texture, rect, spt_center);
                        s++;
                    }
            }
            return buff_spriteex[spt_id].sprites[0];
        }

        public static int CreateSprite(string path)
        {
            int id = RegSprite(path);
            if (buff_spriteex[id].sprites == null)
            {
                Texture2D temptexture = Resources.Load(path) as Texture2D;
                buff_spriteex[id].texture = temptexture;               
                Rect rect = new Rect(0, 0, temptexture.width, temptexture.height);
                buff_spriteex[id].sprites = new Sprite[1];
                buff_spriteex[id].sprites[0] = Sprite.Create(temptexture, rect, spt_center);               
            }
            return id;
        }
        public static Sprite CreateSprite(string path,ref int spt_id)
        {
            int id =spt_id= RegSprite(path);
            if (buff_spriteex[id].sprites == null)
            {
                Texture2D temptexture = Resources.Load(path) as Texture2D;
                buff_spriteex[id].texture = temptexture;
                Rect rect = new Rect(0, 0, temptexture.width, temptexture.height);
                buff_spriteex[id].sprites = new Sprite[1];
                buff_spriteex[id].sprites[0] = Sprite.Create(temptexture, rect, spt_center);
            }
            return buff_spriteex[id].sprites[0];
        }
        public static int CreateSpriteG(string path, Grid g)
        {
            int id = RegSprite(path);
            if (buff_spriteex[id].texture == null)
            {
                Texture2D temptexture = Resources.Load(path) as Texture2D;
                buff_spriteex[id].texture = temptexture;
                if (g.x==0)
                {
                    Rect rect = new Rect(0, 0, temptexture.width, temptexture.height);
                    buff_spriteex[id].sprites = new Sprite[1];
                    buff_spriteex[id].sprites[0] = Sprite.Create(temptexture, rect, spt_center);
                }
                else
                {
                    float x = buff_spriteex[id].texture.width / g.x;
                    float y = buff_spriteex[id].texture.height / g.y;
                    int s = 0;
                    buff_spriteex[id].sprites = new Sprite[g.x * g.y];
                    Rect temp = new Rect(0, 0, x, y);
                    for (int i = 0; i < g.y; i++)
                        for (int c = 0; c < g.x; c++)
                        {
                            temp.x = c * x;
                            temp.y = i * y;
                            buff_spriteex[id].sprites[s] = Sprite.Create(buff_spriteex[id].texture, temp, spt_center);
                            s++;
                        }
                }
            }
            return id;
        }
        protected static Sprite CreateSpriteA(int id, Rect[] e)
        {
            buff_spriteex[id].texture = buff_spriteex[id].rr.asset as Texture2D;
            if (e == null)
            {
                Rect rect = new Rect(0, 0, buff_spriteex[id].texture.width, buff_spriteex[id].texture.height);
                buff_spriteex[id].sprites = new Sprite[1];
                return buff_spriteex[id].sprites[0] = Sprite.Create(buff_spriteex[id].texture, rect, spt_center);
            }
            else
            {
                buff_spriteex[id].sprites = new Sprite[e.Length];
                for (int c = 0; c < e.Length; c++)
                    buff_spriteex[id].sprites[c] = Sprite.Create(buff_spriteex[id].texture, e[c], spt_center);
            }
            return buff_spriteex[id].sprites[0];
        }
        public static int CreateSprite(ref SpriteRenderer container, string path)
        {
            int id = CreateSprite(path);
            container.sprite = buff_spriteex[id].sprites[0];
            return id;
        }
        public static void DeleteSprite(int id)
        {
            buff_spriteex[id].count--;
            if (buff_spriteex[id].count < 1)
            {
                if(buff_spriteex[id].sprites!=null)
                for (int i = 0; i < buff_spriteex[id].sprites.Length; i++)
                    Sprite.Destroy(buff_spriteex[id].sprites[i], 0);
                Resources.UnloadAsset(buff_spriteex[id].texture);
                buff_spriteex[id].path = null;
                buff_spriteex[id].texture = null;
                buff_spriteex[id].sprites = null;
            }
            if (id < spt_exid)
                spt_exid = id;
            if (id == spt_exmax)
                spt_exmax--;
        }

        protected static Sprite CreateSpriteGA(int id,Grid g)
        {
            buff_spriteex[id].texture = buff_spriteex[id].rr.asset as Texture2D;
            if(g.x==0)
            {
                Rect temp = new Rect(0, 0, buff_spriteex[id].texture.width, buff_spriteex[id].texture.height);
                buff_spriteex[id].sprites = new Sprite[1];
                buff_spriteex[id].sprites[0] = Sprite.Create(buff_spriteex[id].texture, temp, spt_center);
            }
            else
            {
                float x = buff_spriteex[id].texture.width / g.x;
                float y = buff_spriteex[id].texture.height / g.y;
                int s = 0;
                buff_spriteex[id].sprites = new Sprite[g.x * g.y];
                Rect temp = new Rect(0, 0, x, y);
                for (int i = 0; i < g.y; i++)
                    for (int c = 0; c < g.x; c++)
                    {
                        temp.x = c * x;
                        temp.y = i * y;
                        buff_spriteex[id].sprites[s] = Sprite.Create(buff_spriteex[id].texture, temp, spt_center);
                        s++;
                    }
            }            
            return buff_spriteex[id].sprites[0];
        }
        protected static int CreateSpriteS(string path, SpriteInfo[] s)
        {
            int id = RegSprite(path);
            if (buff_spriteex[id].texture != null)
                return id;
            buff_spriteex[id].texture = Resources.Load(path) as Texture2D;           
            if (s == null)
            {
                Rect rect = new Rect(0, 0, buff_spriteex[id].texture.width, buff_spriteex[id].texture.height);
                buff_spriteex[id].sprites = new Sprite[1];
                buff_spriteex[id].sprites[0] = Sprite.Create(buff_spriteex[id].texture, rect, spt_center);
            }
            else
            {
                buff_spriteex[id].sprites = new Sprite[s.Length];
                for (int i = 0; i < s.Length; i++)
                    buff_spriteex[id].sprites[i] = Sprite.Create(buff_spriteex[id].texture, s[i].rect, s[i].pivot);
            }                
            return id;
        }
        protected static void CreateSpriteS(int id, SpriteInfo[] s)
        {
            buff_spriteex[id].texture = buff_spriteex[id].rr.asset as Texture2D;
            if (s==null)
            {
                Rect rect = new Rect(0, 0, buff_spriteex[id].texture.width, buff_spriteex[id].texture.height);
                buff_spriteex[id].sprites = new Sprite[1];
                buff_spriteex[id].sprites[0] = Sprite.Create(buff_spriteex[id].texture, rect, spt_center);
            }
            else
            {
                buff_spriteex[id].sprites = new Sprite[s.Length];
                for (int i = 0; i < s.Length; i++)
                    buff_spriteex[id].sprites[i] = Sprite.Create(buff_spriteex[id].texture, s[i].rect, s[i].pivot);
            }            
        }
#endregion

        #region text control
        protected static TextBase[] buff_text = new TextBase[32];
        static int  textcycle = 16;
        public static int CreateText(Transform parent, TextProperty target)
        {
            int id = -1;
            for (int i=0;i<16;i++)
            {
                if(buff_text[i].gameobject == null)
                {
                    id = i;
                    break;
                }
            }
            if (textcycle > 16)
            {
                textcycle--;
                while (buff_text[textcycle].gameobject==null)
                {                   
                    if (textcycle == 16)                                       
                        goto label1;                    
                    textcycle--;
                }
                if (buff_text[textcycle].gameobject != null)
                {
                    buff_text[id] = buff_text[textcycle];
                    buff_text[id].gameobject.SetActive(true);
                }
                else
                {
                    GameObject temp1 = new GameObject();
                    buff_text[id].gameobject = temp1;
                    buff_text[id].transform = temp1.transform;
                    buff_text[id].meshrender = temp1.AddComponent<MeshRenderer>();
                    buff_text[id].textmesh = temp1.AddComponent<TextMesh>();
                }
                goto label2;          
            }
            label1:             
                GameObject temp = new GameObject();
                buff_text[id].gameobject = temp;
                buff_text[id].transform = temp.transform;
                buff_text[id].meshrender = temp.AddComponent<MeshRenderer>();
                buff_text[id].textmesh = temp.AddComponent<TextMesh>();
            label2:
            ResetText(parent, target, id);
            return id;
        }
        public static void RecycleText(int id)
        {
            if (buff_text[id].gameobject == null)
                return;
            buff_text[id].gameobject.SetActive(false);
            buff_text[textcycle] = buff_text[id];
            buff_text[id].gameobject = null;
            textcycle++;
        }
        public static void ResetText(Transform parent, TextProperty target, int id)
        {
            GameObject tempobject = buff_text[id].gameobject;
            tempobject.transform.SetParent(parent);
            tempobject.transform.localPosition = target.location;
            tempobject.transform.localScale = target.scale;
            tempobject.transform.localEulerAngles = Vector3.zero;
            if (target.angle.z != 0)
                tempobject.transform.localEulerAngles = target.angle;
            buff_text[id].meshrender.sortingOrder = 6;//ui layer
            buff_text[id].meshrender.material = def_font.material;
            buff_text[id].textmesh.anchor = TextAnchor.MiddleCenter;
            if (target.fontsize > 0)
                buff_text[id].textmesh.fontSize = target.fontsize;
            else
                buff_text[id].textmesh.fontSize = 33;//default
            if (target.color.a > 0)
                buff_text[id].textmesh.color = target.color;
            buff_text[id].textmesh.font = def_font;
            buff_text[id].textmesh.text = target.text;
        }
        public static TextBase GetTextBase(int id)
        {
            return buff_text[id];
        }
#endregion

        #region effect manage 
        public static float CalculateCurve(ref Point2[] P,float timeratio)
        {
            int index=0;
            if (timeratio > 1)
            {
                timeratio = 1;
                index = P.Length - 2;
            }               
            else
            {
                for (int i = 0; i < P.Length; i++)
                {
                    index = i;
                    if (P[i + 1].x >= timeratio)
                        break;
                }
                if (index == P.Length - 1)
                    index--;
            }                    
            float d = timeratio - P[index].x;
            float x = P[index + 1].x - P[index].x;
            float y = P[index + 1].y - P[index].y;
            float h = P[index].y;            
            return d * y / x + h;             
        }
        public static Color HSVAToRGBA(Color hsv)//h==r s==g v==b a==a
        {
            Color rgb = hsv;
            if(hsv.g==0)
            {
                rgb.r = rgb.g = rgb.b = hsv.b;//V
                return rgb;
            }
            if (hsv.r >= 1)
                hsv.r -= 1;
            float f = hsv.r * 6;
            int i =(int)f;//H
            f -= i;
            float a, b, c;
            a = hsv.b * (1 - hsv.g);//V*(1-S) p
            b = hsv.b * (1 - hsv.g*f);//V*(1-S*f) q
            c = hsv.b * (1 - hsv.g * (1-f));//V*(1-S*(1-f)) t
            switch(i)
            {
                case 0:
                    rgb.r = hsv.b;
                    rgb.g = c;
                    rgb.b = a;
                    break;
                case 1:
                    rgb.r = b;
                    rgb.g = hsv.b;
                    rgb.b = a;
                    break;
                case 2:
                    rgb.r = a;
                    rgb.g = hsv.b;
                    rgb.b = c;
                    break;
                case 3:
                    rgb.r = a;
                    rgb.g = b;
                    rgb.b = hsv.b;
                    break;
                case 4:
                    rgb.r = c;
                    rgb.g = a;
                    rgb.b = hsv.b;
                    break;
                case 5:
                    rgb.r = hsv.b;
                    rgb.g = a;
                    rgb.b = b;
                    break;
            }
            return rgb;
        }
        #endregion

        #region UI image control
        protected static UIImageBase[] buff_ui_img = new UIImageBase[512];
        static int ui_img_top = 0;
        public static int CreateUIimage(Transform parent,UIImageProperty target)
        {
            int id = 0;
            for(int i=ui_img_top;i<512;i++)
            {
                if (buff_ui_img[i].gameobject == null)
                {
                    id = i;
                    break;
                }
            }
            GameObject temp = new GameObject();
            Image img = temp.AddComponent<Image>();            
            buff_ui_img[id].gameobject = temp;

            if(target.imagepath!=null)
            {
                int spt_id = CreateSpriteG(target.imagepath, target.grid);
                buff_ui_img[id].spriteid = spt_id;
                img.sprite = buff_spriteex[spt_id].sprites[0];
            }
            
            buff_ui_img[id].transform = img.rectTransform;
            if(target.size.x==0)
                img.rectTransform.sizeDelta = new Vector2(img.sprite.rect.width,img.sprite.rect.height);
            else
            {
                img.rectTransform.sizeDelta = target.size;
            }                
            buff_ui_img[id].transform.SetParent(parent);
            buff_ui_img[id].transform.anchoredPosition = target.location;
            buff_ui_img[id].transform.localScale = target.scale;
            
            buff_ui_img[id].image = img;
            
            ui_img_top = id;
            return id;
        }
        public static void DeleteUIimage(int id)
        {
            if (buff_ui_img[id].gameobject!=null)
               GameObject.Destroy(buff_ui_img[id].gameobject,0);
            if (id < ui_img_top)
                ui_img_top = id;
        }
        public static void ClearUIimage()
        {
            for(int i=0;i<256;i++)
            {
                if (buff_ui_img[i].gameobject != null)
                    GameObject.Destroy(buff_ui_img[i].gameobject);
            }
            ui_img_top = 0;
        }
#endregion

        #region UI text control
        protected static UITextBase[] buff_ui_txt = new UITextBase[256];
        static int ui_txt_top = 0;
        public static int CreateUItext(Transform parent,UITextProperty target)
        {
            int id = 0;
            for (int i = 0; i < 256; i++)
            {
                if (buff_ui_txt[i].gameobject == null)
                {
                    id = i;
                    break;
                }
            }
            GameObject temp = new GameObject();
            Text txt = temp.AddComponent<Text>();
            buff_ui_txt[id].gameobject = temp;
            buff_ui_txt[id].transform = txt.rectTransform;
            buff_ui_txt[id].transform.SetParent(parent);
            buff_ui_txt[id].transform.localPosition = target.location;
            buff_ui_txt[id].transform.sizeDelta = target.size;
            buff_ui_txt[id].transform.localScale = target.scale;            
            txt.font = def_font;
            buff_ui_txt[id].text = txt;
            txt.text = target.text;
            if (target.color.a == 0)
                txt.color = Color.white;
            else
                txt.color = target.color;
            txt.fontSize = target.fontsize;
            txt.resizeTextForBestFit = true;
            ui_txt_top = id;
            return id;
        }
        public static void DeleteUItext(int id)
        {
            if (buff_ui_txt[id].gameobject != null)
                GameObject.Destroy(buff_ui_txt[id].gameobject, 0);
            if (id < ui_txt_top)
                ui_txt_top = id;
        }
        public static void ClearUItext()
        {
            for (int i = 0; i < 256; i++)
                if (buff_ui_txt[i].gameobject != null)
                    GameObject.Destroy(buff_ui_txt[i].gameobject);
            ui_txt_top = 0;
        }
#endregion

        #region UI Listbox
        protected static ListBox[] buff_lbox = new ListBox[8];
        static int  GetList_Id()
        {
            for (int i = 0; i < 8; i++)
            {
                if (buff_lbox[i].reg == false)
                {
                    return i;
                }
            }
            return 7;
        }
        static Transform CreateList_BKG(int id)
        {
            if (buff_lbox[id].bk_ground.imagepath != null)
            {
                int bkid = buff_lbox[id].bk_id = CreateUIimage(main_canvas, buff_lbox[id].bk_ground);
                RectTransform p = buff_ui_img[bkid].transform;
                buff_lbox[id].vp_id = CreateUIimage(p, buff_lbox[id].vp_window);
            }
            else
            {
                buff_lbox[id].vp_id = CreateUIimage(main_canvas, buff_lbox[id].vp_window);
            }
            int vpid = buff_lbox[id].vp_id;
            buff_ui_img[vpid].gameobject.AddComponent<Mask>();//view port
            return buff_ui_img[vpid].transform;
        }
        static void CreateUIListboxItem(RectTransform parent,ref ListboxItemID li_id, ref ListBoxItemMod mod,ItemBindData data)
        {
            if(mod.img!=null)
            for (int i=0;i<mod.img.Length;i++)
            {               
                li_id.img_id[i] = CreateUIimage(parent,mod.img[i]);
                if (data.imgpath != null)
                    if (i < data.imgpath.Length)
                        {
                            int a=0;
                            buff_ui_img[li_id.img_id[i]].image.sprite = CreateSprite(data.imgpath[i],ref a);                            
                        }                        
           }
            if(mod.text!=null)
            for (int i = 0; i < mod.text.Length; i++)
            {
                if(data.text!=null)
                if (i < data.text.Length)
                    mod.text[i].text = data.text[i];
                li_id.txt_id[i] = CreateUItext(parent, mod.text[i]);
            }
        }
        public static int CreateUIlistbox(ListBox target)//use to small data
        {
            int id = GetList_Id();
            buff_lbox[id] = target;
            buff_lbox[id].reg = true;
            Transform vp = target.edgebutton.transform = CreateList_BKG(id);
            target.edgebutton.ui = true;
            target.edgebutton.sliding = ListboxSliding;
            target.edgebutton.click = ListBoxClick;
            buff_lbox[id].event_id = RegEdgeButton(target.edgebutton);
            int needCtreate= target.data.Count;

            buff_lbox[id].full_item = needCtreate;
            buff_lbox[id].it_id = new int[needCtreate];
            buff_lbox[id].item_son_id = new ListboxItemID[needCtreate];

            ListBoxItemMod temp = target.item_mod;
            int img_len = 0, txt_len = 0;
            if (temp.img != null)
                img_len = temp.img.Length;
            if (temp.text != null)
                txt_len = temp.text.Length;
            float v, u = target.per_len;
            Vector2 uv = Vector2.zero;
            if (target.landscape)
            {
                buff_lbox[id].start = -target.len / 2;
                buff_lbox[id].over = buff_lbox[id].start + target.per_len * target.data.Count;
                v = -target.len / 2;
                uv.x = v - u / 2;
            }
            else
            {
                buff_lbox[id].start = target.len / 2;
                buff_lbox[id].over = buff_lbox[id].start - target.per_len * target.data.Count;
                v = target.len / 2;
                uv.y = v + u / 2;
            }
            for (int i = 0; i < needCtreate; i++)
            {
                int it_iid = buff_lbox[id].it_id[i] = CreateUIimage(vp, buff_lbox[id].item_bkg);
                RectTransform itp = buff_ui_img[it_iid].transform;
                buff_lbox[id].item_son_id[i].img_id = new int[img_len];
                buff_lbox[id].item_son_id[i].txt_id = new int[txt_len];
                CreateUIListboxItem(itp, ref buff_lbox[id].item_son_id[i],ref target.item_mod, target.data[i]);

                if (target.landscape)
                    uv.x += u;
                else
                    uv.y -= u;
                itp.anchoredPosition = uv;
            }
            return id;
        }
        public static int CreateUIlistboxA(ListBox target)//use to big data
        {
            int id = GetList_Id();
            buff_lbox[id] = target;
            buff_lbox[id].reg = true;
            Transform vp= target.edgebutton.transform = CreateList_BKG(id);
            target.edgebutton.ui = true;
            target.edgebutton.sliding = ListboxSlidingA;
            target.edgebutton.click = ListBoxClickA;
            buff_lbox[id].event_id = RegEdgeButton(target.edgebutton);

            int needCtreate;           
            buff_lbox[id].full_item= needCtreate = (int)(target.len / target.per_len + 1);
            buff_lbox[id].it_id = new int[needCtreate];
            buff_lbox[id].item_son_id = new ListboxItemID[needCtreate];
            if (needCtreate > target.data.Count)
                needCtreate = target.data.Count;
            ListBoxItemMod temp = target.item_mod;

            int img_len=0, txt_len=0;
            if (temp.img != null)
                img_len = temp.img.Length;
            if (temp.text != null)
                txt_len = temp.text.Length;
            float v,u=target.per_len;
            Vector2 uv = Vector2.zero;
            if (target.landscape)
            {
                buff_lbox[id].start = -target.len / 2;
                buff_lbox[id].over = buff_lbox[id].start + target.per_len * target.data.Count;
                v = -target.len / 2;
                uv.x = v - u / 2;
            }               
            else
            {
                buff_lbox[id].start = target.len / 2;
                buff_lbox[id].over = buff_lbox[id].start - target.per_len * target.data.Count;
                v = target.len / 2;                
                uv.y = v + u / 2;
            }
                
            for (int i = 0; i < needCtreate; i++)
            {
                int it_iid= buff_lbox[id].it_id[i] = CreateUIimage(vp, buff_lbox[id].item_bkg);
                RectTransform itp = buff_ui_img[it_iid].transform;
                buff_lbox[id].item_son_id[i].img_id = new int[img_len];
                buff_lbox[id].item_son_id[i].txt_id = new int[txt_len];
                CreateUIListboxItem(itp,ref buff_lbox[id].item_son_id[i],ref target.item_mod,target.data[i]);
               
                if(target.landscape)               
                    uv.x += u;                
                else                
                    uv.y -= u;   
                itp.anchoredPosition = uv;
            }
            buff_lbox[id].current_item = needCtreate;
            return id;
        }
        public static void AddListBoxItem(int id,ItemBindData target)
        {
            buff_lbox[id].data.Add(target);
            if(buff_lbox[id].current_item<buff_lbox[id].full_item)
            {
                ListBoxItemMod temp = buff_lbox[id].item_mod;

                int img_len = 0, txt_len = 0;
                if (temp.img != null)
                    img_len = temp.img.Length;
                if (temp.text != null)
                    txt_len = temp.text.Length;
                int i = buff_lbox[id].current_item;
                buff_lbox[id].current_item++;
                buff_lbox[id].item_son_id[i].img_id = new int[img_len];
                RectTransform vp = buff_ui_img[buff_lbox[id].vp_id].transform;
                int it_iid = buff_lbox[id].it_id[i] = CreateUIimage(vp, buff_lbox[id].item_bkg);
                RectTransform itp = buff_ui_img[it_iid].transform;
                for (int c = 0; c < img_len; c++)
                {
                    int ic = buff_lbox[id].item_son_id[i].img_id[c] = CreateUIimage(itp, temp.img[c]);
                    int spt_id = CreateSprite(target.imgpath[c]);
                    buff_ui_img[ic].image.sprite = buff_spriteex[spt_id].sprites[0];
                }
                buff_lbox[id].item_son_id[i].txt_id = new int[txt_len];
                for (int c = 0; c < txt_len; c++)
                {
                    int tc = buff_lbox[id].item_son_id[i].txt_id[c] = CreateUItext(itp, temp.text[c]);
                    buff_ui_txt[tc].text.text = target.text[c];
                }
            }
        }
        public static void DeleteListBoxItem(int id,int index)
        {
            buff_lbox[id].data.RemoveAt(index);
        }
        public static void DeleteListBox(int id)
        {
            buff_lbox[id].reg = false;
            DeleteUIimage(buff_lbox[id].vp_id);
            if (buff_lbox[id].bk_ground.imagepath != null)
                DeleteUIimage(buff_lbox[id].bk_id);
            UnRegEdgeButton(buff_lbox[id].event_id);           
        }
        public static void ClearListBox()
        {
            for(int i=0;i<8;i++)
            {
                if(buff_lbox[i].reg)
                {
                    buff_lbox[i].reg = false;
                    DeleteUIimage(buff_lbox[i].vp_id);
                    if (buff_lbox[i].bk_ground.imagepath != null)
                        DeleteUIimage(buff_lbox[i].bk_id);
                    UnRegEdgeButton(buff_lbox[i].event_id);
                }
            }
        }
        public static void HideListBox(int id)
        {
           if( buff_lbox[id].bk_ground.imagepath!=null)
            {
                 buff_ui_img[buff_lbox[id].bk_id].gameobject.SetActive(false);
            }
            else
            {
                buff_ui_img[buff_lbox[id].vp_id].gameobject.SetActive(false);
            }
            int eid = buff_lbox[id].event_id;
            buff_edgebutton[eid].active = false;
        }
        public static void ShowListBox(int id)
        {
            if (buff_lbox[id].bk_ground.imagepath != null)
            {
                buff_ui_img[buff_lbox[id].bk_id].gameobject.SetActive(true);
            }
            else
            {
                buff_ui_img[buff_lbox[id].vp_id].gameobject.SetActive(true);
            }
            int eid = buff_lbox[id].event_id;
            buff_edgebutton[eid].active = true;
        }
        public static void ChangeItem(int id, int index, ItemBindData target)
        {
            int len=0;
            if (target.imgpath!=null)
            {
                len = target.imgpath.Length;
                for (int i = 0; i < len; i++)
                {
                    int c = buff_lbox[id].item_son_id[index].img_id[i];
                    int spt_id = CreateSprite(target.imgpath[i]);
                    buff_ui_img[c].image.sprite = buff_spriteex[spt_id].sprites[0];
                }
            }                
            if(target.text!=null)
            {
                len = target.text.Length;
                for (int i = 0; i < len; i++)
                {
                    int c = buff_lbox[id].item_son_id[index].txt_id[i];
                    buff_ui_txt[c].text.text = target.text[i];
                }
            }
            buff_lbox[id].data[index] = target;
        }
        public static void ChangeItemA(int id, int index, ItemBindData target)
        {
            buff_lbox[id].data[index] = target;
            RefreshListBoxA(id);
        }
        static void ListboxSliding(Vector3 offset)
        {
            int id = 0,eid=cur_bid-256;
            for(int i=0;i<8;i++)
            {
                if(buff_lbox[i].event_id==eid)
                {
                    id = i;
                    break;
                }
            }
            if(buff_lbox[id].full_item*buff_lbox[id].per_len>buff_lbox[id].len)
                ListboxSliding(id,offset);
        }
        static void ListboxSliding(int id, Vector3 offset)
        {
            if (buff_lbox[id].landscape)
            {
                float p = buff_lbox[id].start - offset.x;
                if (p < -buff_lbox[id].len / 2 | p + buff_lbox[id].len > buff_lbox[id].over)
                    return;
                else
                    buff_lbox[id].start = p;
                for (int c = 0; c < buff_lbox[id].full_item; c++)
                {
                    Transform t = buff_ui_img[buff_lbox[id].it_id[c]].transform;
                    Vector3 v = t.localPosition;
                    v.x += offset.x;
                    t.localPosition = v;
                }
            }
            else
            {
                float p = buff_lbox[id].start - offset.y;
                if (p > buff_lbox[id].len / 2 | p - buff_lbox[id].len < buff_lbox[id].over)
                    return;
                else
                    buff_lbox[id].start = p;
                for (int c = 0; c < buff_lbox[id].full_item; c++)
                {
                    Transform t = buff_ui_img[buff_lbox[id].it_id[c]].transform;
                    Vector3 v = t.localPosition;
                    v.y += offset.y;
                    t.localPosition = v;
                }
            }
        }
        static void ListboxSlidingA(Vector3 offset)
        {
            int id = 0, eid = cur_bid - 256;
            for (int i = 0; i < 8; i++)
            {
                if (buff_lbox[i].event_id == eid)
                {
                    id = i;
                    break;
                }
            }
            if (buff_lbox[id].current_item < buff_lbox[id].full_item)
                return;
            ListboxSlidingA(id, offset);
        }
        static void ListboxSlidingA(int id, Vector3 offset)
        {
            bool fresh=false;
            if (buff_lbox[id].landscape)
            {
                float p = buff_lbox[id].start - offset.x;
                if (p < -buff_lbox[id].len / 2 | p + buff_lbox[id].len > buff_lbox[id].over)
                    return;
                else
                    buff_lbox[id].start = p;
                float right = buff_lbox[id].len / 2 + buff_lbox[id].per_len / 2;
                float left = -right;
                for (int c = 0; c < buff_lbox[id].full_item; c++)
                {
                    Transform t = buff_ui_img[buff_lbox[id].it_id[c]].transform;
                    Vector3 v = t.localPosition;
                    v.x += offset.x;
                    if (v.x > right)
                    {
                        v.x -= buff_lbox[id].full_item * buff_lbox[id].per_len;
                        fresh = true;
                    }
                        
                    else if (v.x < left)
                    {
                        v.x += buff_lbox[id].full_item * buff_lbox[id].per_len;
                        fresh = true;
                    }
                    t.localPosition = v;
                }
            }
            else
            {
                float p = buff_lbox[id].start-offset.y;
                if (p >buff_lbox[id].len/2 | p - buff_lbox[id].len < buff_lbox[id].over)
                    return;
                else
                    buff_lbox[id].start = p;
                float top = buff_lbox[id].len / 2 + buff_lbox[id].per_len / 2;
                float bottom = -top;
                for (int c = 0; c < buff_lbox[id].full_item; c++)
                {
                    Transform t = buff_ui_img[buff_lbox[id].it_id[c]].transform;
                    Vector3 v = t.localPosition;
                    v.y+= offset.y;
                    if (v.y > top)
                    {
                        v.y -= buff_lbox[id].full_item * buff_lbox[id].per_len;
                        fresh = true;
                    }                      
                    else if (v.y < bottom)
                    {
                        v.y += buff_lbox[id].full_item * buff_lbox[id].per_len;
                        fresh = true;
                    }                       
                    t.localPosition = v;
                }
            }
            if (fresh)
                RefreshListBoxA(id);
        }
        static void RefreshListBoxA(int id)
        {
            int img_len = buff_lbox[id].data[0].imgpath.Length;
            int txt_len = buff_lbox[id].data[0].text.Length;
            int a = buff_lbox[id].data.Count;
            int b = buff_lbox[id].full_item;
            if (a<b)
            {
                int l = buff_lbox[id].current_item;
                if (l > a)//sub
                {                    
                    for(int i=a;i<l;i++)
                    {
                        DeleteUIimage(buff_lbox[id].it_id[i]);
                    }
                    l = a;
                }
                else if(l<a)
                {
                    float p = (l+0.5f )* buff_lbox[id].per_len;
                    if (buff_lbox[id].landscape)                    
                        buff_lbox[id].item_bkg.location.x = p;                   
                      else
                        buff_lbox[id].item_bkg.location.y = -p;                      
                    RectTransform vp = buff_ui_img[ buff_lbox[id].vp_id].transform;
                    for (int i = l; i < a; i++)//add new
                    {                       
                        buff_lbox[id].it_id[i] = CreateUIimage(vp,buff_lbox[id].item_bkg);
                        RectTransform tp = buff_ui_img[buff_lbox[id].it_id[i]].transform;
                        CreateUIListboxItem(tp,ref buff_lbox[id].item_son_id[i],ref buff_lbox[id].item_mod,buff_lbox[id].data[i]);
                        if (buff_lbox[id].landscape)
                            buff_lbox[id].item_bkg.location.x += buff_lbox[id].per_len;
                        else
                            buff_lbox[id].item_bkg.location.y -= buff_lbox[id].per_len;
                    }
                }                    
                for(int i=0;i< l;i++)
                {
                    for (int c = 0; c < img_len; c++)
                    {
                        int ic = buff_lbox[id].item_son_id[i].img_id[c];
                        int spt_id = CreateSprite(buff_lbox[id].data[i].imgpath[c]);
                        buff_ui_img[ic].image.sprite = buff_spriteex[spt_id].sprites[0];
                    }
                    buff_lbox[id].item_son_id[i].txt_id = new int[txt_len];
                    for (int c = 0; c < txt_len; c++)
                    {
                        int tc = buff_lbox[id].item_son_id[i].txt_id[c];
                        buff_ui_txt[tc].text.text = buff_lbox[id].data[i].text[c];
                    }
                } 
            }
            else
            {
                int s = 0;
                if (buff_lbox[id].landscape)
                {
                    float ab = (buff_lbox[id].start + buff_lbox[id].len / 2) / buff_lbox[id].per_len;
                    s = (int)ab;
                }
                else
                {
                    float ab = (buff_lbox[id].start - buff_lbox[id].len / 2) / buff_lbox[id].per_len;
                    s = (int)-ab;
                }              
                int l = buff_lbox[id].full_item;
                int d = s % l;
                s = s - d;
                int il = buff_lbox[id].data[0].imgpath.Length;
                int tl = buff_lbox[id].data[0].text.Length;
                for (int i=0;i<l;i++)
                {
                    int f = s + i;
                    if (i < d)
                        f += l;
                    if (f >= buff_lbox[id].data.Count)
                        break;
                    if(buff_lbox[id].data[f].imgpath!=null)
                    {
                        for (int c = 0; c < il; c++)
                        {
                            int i_id = buff_lbox[id].item_son_id[i].img_id[c];
                            Image img = buff_ui_img[i_id].image;
                            img.sprite = CreateSprite(buff_lbox[id].data[f].imgpath[c],ref i_id);
                        }
                    }                                        
                    else
                    {
                        for (int c = 0; c < il; c++)
                        {
                            int i_id = buff_lbox[id].item_son_id[i].img_id[c];
                            Image img = buff_ui_img[i_id].image;
                            img.sprite= CreateSprite(buff_lbox[id].item_mod.img[c].imagepath,ref i_id);
                        }
                    }
                    if (buff_lbox[id].data[f].text != null)
                    {
                        for (int c = 0; c < tl; c++)
                        {
                            int i_id = buff_lbox[id].item_son_id[i].txt_id[c];
                            buff_ui_txt[i_id].text.text = buff_lbox[id].data[f].text[c];
                        }
                    }                      
                    else
                    {
                        for (int c = 0; c < tl; c++)
                        {
                            int i_id = buff_lbox[id].item_son_id[i].txt_id[c];
                            buff_ui_txt[i_id].text.text = buff_lbox[id].item_mod.text[c].text;
                        }
                    }
                }
            }
        }
        static void ListBoxClick()
        {
            int id = 0, eid = cur_bid - 256;
            for (int i = 0; i < 8; i++)
            {
                if (buff_lbox[i].event_id == eid)
                {
                    id = i;
                    break;
                }
            }
            float ab = (buff_lbox[id].start + buff_lbox[id].len / 2) / buff_lbox[id].per_len;
            //int l = buff_lbox[id].full_item;
            float r = buff_lbox[id].per_len / 2;
            int s = 0;
            if (buff_lbox[id].landscape)
            {
                //float so= (buff_lbox[id].start + buff_lbox[id].len / 2) / buff_lbox[id].per_len;
                int ss = (int)ab;
                s = buff_lbox[id].full_item - 1;
                for (int c= ss;c< buff_lbox[id].full_item;c++)
                {
                    if (buff_ui_img[buff_lbox[id].it_id[c]].transform.position.x - r > mouse_position.x)
                    {
                        s = c - 1;
                        break;
                    }
                }                
            }
            else
            {
                //float so = (buff_lbox[id].start - buff_lbox[id].len / 2) / buff_lbox[id].per_len;
                int ss = (int)-ab;
                if (ss < 0)
                    ss = 0;
                s = buff_lbox[id].full_item - 1;
                for (int c = ss; c < buff_lbox[id].full_item; c++)
                {
                   if( buff_ui_img[buff_lbox[id].it_id[c]].transform.position.y+r<mouse_position.y)
                    {
                        s = c - 1;
                        break;
                    }
                }                
            }
            if (buff_lbox[id].click!=null)
                buff_lbox[id].click(s);
        }
        static void ListBoxClickA()
        {
            int id = 0, eid = cur_bid - 256;
            for (int i = 0; i < 8; i++)
            {
                if (buff_lbox[i].event_id == eid)
                {
                    id = i;
                    break;
                }
            }           
            float r = buff_lbox[id].per_len / 2;
            int t = 0;
            int s = 0;
            if (buff_lbox[id].landscape)
            {
                for (int c = 0; c < buff_lbox[id].full_item; c++)
                {
                    float x = buff_ui_img[buff_lbox[id].it_id[c]].transform.position.x;
                    if ( x- r < mouse_position.x & x + r > mouse_position.x)
                    {
                        t = c;
                        break;
                    }
                }
                float ab = (buff_lbox[id].start + buff_lbox[id].len / 2) / buff_lbox[id].per_len;
                s = (int)ab;
            }
            else
            {                
                for (int c = 0; c < buff_lbox[id].full_item; c++)
                {
                    float y = buff_ui_img[buff_lbox[id].it_id[c]].transform.position.x;
                    if (y + r > mouse_position.y & y-r < mouse_position.y)
                    {
                        t = c;
                        break;
                    }
                }
                float ab = (buff_lbox[id].start - buff_lbox[id].len / 2) / buff_lbox[id].per_len;
                s = (int)-ab;
            }
            int l = buff_lbox[id].full_item;
            int d = s % l;
            s -= d;
            if (t < d)
                t += l;
            s += t;
            if (buff_lbox[id].click != null)
                buff_lbox[id].click(s);
        }
        #endregion

        #region material control
        protected static MaterialBase[] buff_mat = new MaterialBase[128];
        public static int RegMat(string path)
        {
            for(int i=0;i<128;i++)
            {
                if (buff_mat[i].path == path)
                {
                    return i;
                }
                else if (buff_mat[i].path == null)
                {
                    buff_mat[i].path = path;
                    return i;
                }
            }
            return -1;
        }
        public static void RegMatA(string path, ref int id)//main thread
        {
            for (int i = 0; i < 128; i++)
            {
                if (buff_mat[i].path == path)
                {
                    id = i;
                    if (buff_mat[i].rr == null)
                        buff_mat[i].rr = Resources.LoadAsync(path);
                    return;
                }
                else if (buff_mat[i].path == null)
                {
                    id = i;
                    buff_mat[i].path = path;
                    buff_mat[i].rr = Resources.LoadAsync(path);
                    return;
                }
            }
        }
        protected static void LoadMatAscyncAll()//main thread
        {
            for(int i=0;i<128;i++)
            {
                if (buff_mat[i].path != null & buff_mat[i].rr==null)
                    buff_mat[i].rr = Resources.LoadAsync(buff_mat[i].path);
            }
        }
        protected static Material CreateMat(int id)
        {
            if (buff_mat[id].rr == null)
            {
                //if(buff_mat[id].path!=null)
                //    buff_mat[id].rr = Resources.LoadAsync(buff_mat[id].path);
                return null;
            }
            if (buff_mat[id].mat != null)
                return buff_mat[id].mat;
            buff_mat[id].mat = buff_mat[id].rr.asset as Material;
            return buff_mat[id].mat;
        }
        protected static Material CreateMat(string path)
        {
            int i= RegMat(path);
            if (buff_mat[i].mat != null)
                return buff_mat[i].mat;
            Material mat= Resources.Load(path) as Material;
            buff_mat[i].path = path;
            buff_mat[i].mat = mat;
            return mat;
        }
        protected static void ClearMat(int id)
        {
            buff_mat[id].rr = null;
            buff_mat[id].path = null;
            Resources.UnloadAsset(buff_mat[id].mat);
            buff_mat[id].mat = null;
        }
        protected static void ClearMatAll()
        {
            for(int i=0;i<128;i++)
            {
                buff_mat[i].rr = null;
                buff_mat[i].mat = null;
                buff_mat[i].path = null;
            }
            Resources.UnloadUnusedAssets();
        }
        #endregion


    }
}
