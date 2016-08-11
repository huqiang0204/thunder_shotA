using System;
using UnityEngine;

namespace Assets.UnityVS.Script
{
    class ShotBullet:GameControl
    {
        #region bullet shot style  bullet id and enemyid
        public static void Angle6_Rotate(ref BulletPropertyEx bpe,ref EnemyBaseEX epe)
        {
            bpe.shotpoint = SP.GetSixAngle(bpe.extra,epe.location);
            bpe.extra += 5;
            if (bpe.extra > 60)
            {
                bpe.extra = 0;
                epe.extra_b = -300;
            }
            bpe.s_count = 6;
        }
        public static void Angle6_RotateA(ref BulletPropertyEx bpe, ref EnemyBaseEX epe)
        {
            Point3 temp = new Point3();
            temp.x = epe.location.x;
            temp.y = epe.location.y - 0.5f;
            temp.z = bpe.extra;
            bpe.shotpoint = new Point3[6];
            for (int i = 0; i < 6; i++)
            {
                bpe.shotpoint[i] = temp;
                temp.z += 60;
            }
            bpe.s_count = 6;
            if (bpe.extra < 60)
            {
                bpe.extra += 5;
                if (bpe.extra >= 60)
                {
                    epe.extra_b = -150;
                }
            }
            else
            {
                bpe.extra -= 5;
                if (bpe.extra <= 0)
                {
                    epe.extra_b = -300;
                    bpe.extra = 0;
                    return;
                }
            }
        }
        public static void Down_Arc(ref BulletPropertyEx bpe, ref EnemyBaseEX epe)
        {
            float x = epe.location.x;
            float y = epe.location.y-0.3f;
            bpe.shotpoint = new Point3[7];
            for (int i = 0; i < 7; i++)
                bpe.shotpoint[i] = new Point3(x, y, i * 10 + 150);
            bpe.s_count = 7;
        }
        public static void Down_Arc3(ref BulletPropertyEx bpe, ref EnemyBaseEX epe)
        {
            if (bpe.extra < 3)
            {
                float x = epe.location.x;
                float y = epe.location.y- 0.3f;
                bpe.shotpoint = new Point3[7];
                for (int i = 0; i < 7; i++)
                    bpe.shotpoint[i] =  new Point3(x, y, i * 10 + 150);
                bpe.s_count = 7;
                bpe.extra++;
            }
            else
            {
                bpe.extra = 0;
                epe.extra_b = -3000;
            }
        }
        public static void Three_Circle12(ref BulletPropertyEx bpe, ref EnemyBaseEX epe)
        {
            float x = epe.location.x;
            float y = epe.location.y-0.3f;
            bpe.shotpoint = new Point3[12];
            float angle = 0;
            if (bpe.extra == 1)
                angle = 10;
            else if (bpe.extra == 2)
            {
                angle = 20;
                bpe.extra = -1;
                epe.extra_b = -3000;
            }
            bpe.extra++;
            for (int i = 0; i < 12; i++)
                bpe.shotpoint[i] = new Point3(x, y, i * 30+angle);
            bpe.s_count = 12;
        }
        public static void Three_Circle36(ref BulletPropertyEx bpe, ref EnemyBaseEX epe)
        {
            float x = epe.location.x;
            float y = epe.location.y - 0.3f;
            bpe.shotpoint = new Point3[36];
            float angle = 0;
            if (bpe.extra == 1)
                angle = 3;
            else if (bpe.extra == 2)
            {
                angle = 6;
                bpe.extra = -1;
                epe.extra_b = -6000;
            }
            bpe.extra++;
            for (int i = 0; i < 36; i++)
                bpe.shotpoint[i] =  new Point3(x, y, i * 10+angle);
            bpe.s_count = 36;
        }
        public static void Circle36A(ref BulletPropertyEx bpe, ref EnemyBaseEX epe)
        {
            float x = epe.location.x;
            float y = epe.location.y - 0.3f;
            bpe.shotpoint = new Point3[36];
            float z = Aim(ref epe.location, ref core_location);
            z -= 15;
            if (z < 0)
                z += 360;
            int s = 0;
            for (int i = 0; i < 6; i++)
            {
                for (int c = 0; c < 6; c++)
                {
                    bpe.shotpoint[s] =  new Point3(x, y, z);
                    z += 5;
                    if (z > 360)
                        z -= 360;
                    s++;
                }
                z += 30;
            }
            bpe.s_count = 36;
            bpe.extra++;
            if(bpe.extra>3)
            {
                bpe.extra = 0;
                epe.extra_b = -3000;
            }
        }

        public static void Pentagram(ref BulletPropertyEx bpe, ref EnemyBaseEX epe)
        {
            bpe.shotpoint = new Point3[1];
            float x = epe.location.x;
            float y = epe.location.y;
            bpe.shotpoint[0] = new Point3(x,y,18);
            bpe.s_count = 1;
            bpe.extra++;
            if (bpe.extra> 48)
            {
                bpe.extra = 0;
                epe.extra_b = -3000;
            }
        }
        public static void Aim2(ref BulletPropertyEx bpe, ref EnemyBaseEX epe)
        {
            float x = epe.location.x;
            float y = epe.location.y;
            float z = Aim(ref epe.location, ref core_location);
            bpe.shotpoint = new Point3[] { new Point3(x, y, z), new Point3(x, y, z) };
            bpe.s_count = 2;
            bpe.extra++;
            if (bpe.extra > 12)
            {
                bpe.extra = 0;
                epe.extra_b = -3600;
            }
        }
        public static void Aim_3(ref BulletPropertyEx bpe, ref EnemyBaseEX epe)
        {
            float x = epe.location.x;
            float y = epe.location.y;
            float z = Aim(ref epe.location, ref core_location);
            bpe.shotpoint = new Point3[] { new Point3(x, y, z)};
            bpe.s_count = 1;
            bpe.extra++;
            if (bpe.extra > 3)
            {
                bpe.extra = 0;
                epe.extra_b = -2400;
            }
        }
        public static void Aim_12(ref BulletPropertyEx bpe, ref EnemyBaseEX epe)
        {
            float x = epe.location.x;
            float y = epe.location.y;
            float z = Aim(ref epe.location, ref core_location);
            bpe.shotpoint = new Point3[] { new Point3(x, y, z) };
            bpe.s_count = 1;
            bpe.extra++;
            if (bpe.extra > 12)
            {
                bpe.extra = 0;
                epe.extra_b = -2400;
            }
        }
        public static void Aim_Arc3(ref BulletPropertyEx bpe, ref EnemyBaseEX epe)
        {
            float x = epe.location.x;
            float y = epe.location.y;
            float z = Aim(ref epe.location, ref core_location);
            z -= 10;
            if (z < 0)
                z += 360;
            Point3[] temp = new Point3[3];
            for (int i = 0; i < 3; i++)
            {
                temp[i] = new Point3(x,y,z);
                z += 10;
                if (z > 360)
                    z -= 360;
            }
            bpe.shotpoint = temp;
            bpe.s_count = 3;
            bpe.extra++;
            if (bpe.extra > 12)
            {
                bpe.extra = 0;
                epe.extra_b = -3000;
            }
        }
        public static void Aim_Arc6(ref BulletPropertyEx bpe, ref EnemyBaseEX epe)
        {
            float x = epe.location.x;
            float y = epe.location.y;
            float z = Aim(ref epe.location,ref core_location);
            z -= 30;
            if (z < 0)
                z += 360;
            Point3[] temp = new Point3[6];
            for (int i = 0; i < 6; i++)
            {
                temp[i] = new Point3(x,y,z);
                z += 10;
                if (z > 360)
                    z -= 360;
            }
            bpe.shotpoint = temp;
            bpe.s_count = 6;
            bpe.extra++;
            if (bpe.extra > 8)
            {
                bpe.extra = 0;
                epe.extra_b = -3000;
            }
        }
        public static void Aim_Arc18(ref BulletPropertyEx bpe, ref EnemyBaseEX epe)
        {
            float x = epe.location.x;
            float y = epe.location.y;
            float z = Aim(ref epe.location, ref core_location);
            z -= 60;
            if (z < 0)
                z += 360;
            Point3[] temp = new Point3[18];
            int s = 0;
            for (int i = 0; i < 3; i++)
            {
                for(int c=0;c<6;c++)
                {
                    temp[s] = new Point3(x,y,z);
                    z += 5;
                    if (z > 360)
                        z -= 360;
                    s++;
                }
                z += 15;
            }
            bpe.shotpoint = temp;
            bpe.s_count = 18;
            bpe.extra++;
            if (bpe.extra > 4)
            {
                bpe.extra = 0;
                epe.extra_b = -3000;
            }
        }
        public static void Diamond(ref BulletPropertyEx bpe, ref EnemyBaseEX epe)
        {
            Point3 p = new Point3(epe.location.x,epe.location.y,0);
            Point3[] temp = new Point3[12];
            for (int i = 0; i < 12; i++)
                temp[i] = p;
            bpe.shotpoint = temp;
            bpe.s_count = 12;
            bpe.extra++;
            if(bpe.extra>1)
            {
                bpe.extra = 0;
                epe.extra_b = -3000;
            }            
        }
        public static void ThreePoint(ref BulletPropertyEx bpe, ref EnemyBaseEX epe)
        {
            float x = epe.location.x;
            float y = epe.location.y;
            float z = epe.angle.z;
            bpe.shotpoint = new Point3[] { new Point3(x,y,z),new Point3(x,y,z-30),new Point3(x,y,z+30)};
            bpe.s_count = 3;
            bpe.extra++;
            if(bpe.extra>5)
            {
                bpe.extra = 0;
                epe.extra_b = -1500;
            }
        }
        public static void ThreeBeline10(ref BulletPropertyEx bpe, ref EnemyBaseEX epe)
        {
            float x = epe.location.x;
            float y = epe.location.y;
            bpe.shotpoint = new Point3[] { new Point3(x, y, 150), new Point3(x, y, 180), new Point3(x, y, 210) };
            bpe.s_count = 3;
            bpe.extra++;
            if (bpe.extra > 10)
            {
                bpe.extra = 0;
                epe.extra_b = -1500;
            }
        }
        public static void ThreeBeline20(ref BulletPropertyEx bpe, ref EnemyBaseEX epe)
        {
            float x = epe.location.x;
            float y = epe.location.y;
            bpe.shotpoint = new Point3[] { new Point3(x, y, 150), new Point3(x, y, 180), new Point3(x, y, 210) };
            bpe.s_count = 3;
            bpe.extra++;
            if (bpe.extra > 20)
            {
                bpe.extra = 0;
                epe.extra_b = -1500;
            }
        }
        public static void Downflowers(ref BulletPropertyEx bpe, ref EnemyBaseEX epe)
        {
            int angle = bpe.extra;
            float x = epe.location.x;
            float y = epe.location.y;
            bpe.shotpoint = new Point3[] { new Point3(x, y, 160 - angle),new Point3(x, y, 120 - angle) ,
            new Point3(x, y, 240 + angle) ,new Point3(x, y, 220 - angle)};
            bpe.s_count = 4;
            bpe.extra += 5;
            if(bpe.extra>=60)
            {
                bpe.extra = 0;
                epe.extra_b = -3000;
            }
        }
        public static void Parabola(ref BulletPropertyEx bpe,ref EnemyBaseEX epe)
        {
            int a = bpe.extra>>3;
            if((a&1)==0)
            {
                bpe.shotpoint =new Point3[] { new Point3(epe.location.x, epe.location.y, 10) };
            }
            else
            {
                bpe.shotpoint = new Point3[] { new Point3(epe.location.x, epe.location.y, 350) };
            }
            bpe.s_count = 1;
            bpe.extra++;
            if (bpe.extra > 48)
            {
                bpe.extra = 0;
                epe.extra_b = -2000;
            }
        }
        public static void Sharp_V(ref BulletPropertyEx bpe,ref EnemyBaseEX ebe)
        {
            float x = ebe.location.x;
            float y = ebe.location.y - 0.25f;
            if (bpe.extra==0)
            {
                Point3[] pt = new Point3[6];
                float a = 155;
                for(int i=0;i<6;i++)
                {
                    pt[i].x = x;
                    pt[i].y = y;
                    pt[i].z = a;
                    a += 10;
                }
                bpe.shotpoint = pt;
                bpe.s_count = 6;
            }
            else
            {
                Point3[] pt = new Point3[12];
                float a = 155-bpe.extra;
                for (int i = 0; i < 6; i++)
                {
                    pt[i].x = x;
                    pt[i].y = y;
                    pt[i].z = a;
                    a += 10;
                }
                a = 155 + bpe.extra;
                for (int i = 6; i < 12; i++)
                {
                    pt[i].x = x;
                    pt[i].y = y;
                    pt[i].z = a;
                    a += 10;
                }
                bpe.shotpoint = pt;
                bpe.s_count = 12;
            }
            bpe.extra++;
            if(bpe.extra>3)
            {
                bpe.extra = 0;
                ebe.extra_b = -2000;
            }
        }
        public static void Sharp_O(ref BulletPropertyEx bpe, ref EnemyBaseEX ebe)
        {
            float x = ebe.location.x;
            float y = ebe.location.y - 0.25f;
            if (bpe.extra == 0|bpe.extra==7)
            {
                Point3[] pt = new Point3[6];
                float a = 155;
                for (int i = 0; i < 6; i++)
                {
                    pt[i].x = x;
                    pt[i].y = y;
                    pt[i].z = a;
                    a += 10;
                }
                bpe.shotpoint = pt;
                bpe.s_count = 6;
            }
            else
            {
                Point3[] pt = new Point3[12];
                float c=bpe.extra>3?7-bpe.extra:bpe.extra;
                float a = 155 - c;
                for (int i = 0; i < 6; i++)
                {
                    pt[i].x = x;
                    pt[i].y = y;
                    pt[i].z = a;
                    a += 10;
                }
                a = 155 + c;
                for (int i = 6; i < 12; i++)
                {
                    pt[i].x = x;
                    pt[i].y = y;
                    pt[i].z = a;
                    a += 10;
                }
                bpe.shotpoint = pt;
                bpe.s_count = 12;
            }
            bpe.extra++;
            if (bpe.extra > 7)
            {
                bpe.extra = 0;
                ebe.extra_b = -3000;
            }
        }
        public static void Random(ref BulletPropertyEx bpe,ref EnemyBaseEX ebe)
        {
            float f = (float)lucky.NextDouble();
            float x =  f* 5-2.5f;
            int c = (int)(f * 4)+1;
            float y = ebe.location.y + f;
            x -= 2.5f;
            Point3[] pt = new Point3[c];
            for(int i=0;i< c;i++)
            {
                pt[i].x = x;
                pt[i].y = y;
                pt[i].z = 180;
                x += c;
                if (x > 2.5f)
                    x -= 5;
                f += f;
                if (f > 1)
                    f--;
                y = ebe.location.y + f;
            }
            bpe.shotpoint = pt;
            bpe.s_count = c;
            bpe.extra++;
            if(bpe.extra>15)
            {
                bpe.extra = 0;
                ebe.extra_b = -3000;
            }
        }
        public static void Rotate_left(ref BulletPropertyEx bpe, ref EnemyBaseEX ebe)
        {
            float x = ebe.location.x;
            float y = ebe.location.y - 0.25f;
            int c = bpe.extra;
            Point3[] pt = new Point3[6];
            for (int i = 0; i < 6; i++)
            {
                int a = c + 90;
                if (a >= 360)
                    a -= 360;
                pt[i].x = x + angle_table[a].x * 0.5f;
                pt[i].y = y + angle_table[a].y * 0.5f;
                if (c >= 360)
                    c -= 360;
                pt[i].z = c;
                c += 60;
            }
            bpe.shotpoint = pt;
            bpe.s_count = 6;
            bpe.extra += 4;
            if (bpe.extra >= 60)
            {
                bpe.extra = 0;
                ebe.extra_b = -2000;
            }
        }
        public static void Rotate_right(ref BulletPropertyEx bpe, ref EnemyBaseEX ebe)
        {
            float x = ebe.location.x;
            float y = ebe.location.y - 0.25f;
            int c = bpe.extra;
            if (c < 0)
                c += 60;
            Point3[] pt = new Point3[6];
            for(int i=0;i<6;i++)
            {
                int a = c - 90;
                if (a < 0)
                    a += 360;
                pt[i].x = x + angle_table[a].x * 0.5f;
                pt[i].y = y + angle_table[a].y * 0.5f;
                pt[i].z = c;
                c += 60;
            }
            bpe.shotpoint = pt;
            bpe.s_count = 6;
            bpe.extra -= 4;
            if (bpe.extra <= -60)
            {
                bpe.extra = 0;
                ebe.extra_b = -2000;
            }
        }
        public static void MultiBeline(ref BulletPropertyEx bpe, ref EnemyBaseEX ebe)
        {
            float x = ebe.location.x+0.5f;
            float y = ebe.location.y;
            Point3[] pt = new Point3[12];
            float a1 = 155;
            float a2 = 205;
            for (int i = 0; i < 4; i += 2)
            {
                pt[i].x = x;
                pt[i].y = y;
                pt[i].z = 160;
                pt[i + 1].x = x;
                pt[i + 1].y = y;
                pt[i + 1].z = 200;
                x -= 1f;
            }
            x -= 0.3f;
            y -= 0.2f;
            for (int i=4;i<8;i+=2)
            {
                pt[i].x = x;
                pt[i].y = y;
                pt[i].z = a1;
                pt[i + 1].x = x;
                pt[i + 1].y = y;
                pt[i + 1].z = a2;
                x += 0.4f;
                a1 += 15;
                a2 -= 15;
            }
            for (int i = 8; i < 12; i+=2)
            {
                a1 -= 15;
                a2 += 15;
                pt[i].x = x;
                pt[i].y = y;
                pt[i].z = a1;
                pt[i + 1].x = x;
                pt[i + 1].y = y;
                pt[i + 1].z = a2;
                x += 0.4f;
            }
            bpe.shotpoint = pt;
            bpe.s_count = 12;
            bpe.extra++;
            if (bpe.extra > 20)
            {
                bpe.extra = 0;
                ebe.extra_b = -3000;
            }
        }
        #endregion

        #region war plane
        public static void Scatter_level2(ref BulletPropertyEx bpe)//12 hit
        {
            float x = core_location.x;
            float y = core_location.y;
            int state = bpe.extra;
            if (state ==0)
            {
                bpe.t_uv = SP.uv_zhihui[1];
                bpe.uv_rect = SP.p_zhihui[1];
                bpe.shotpoint = new Point3[] { new Point3(x,y,8),new Point3(x,y, 16),
                      new Point3(x,y, 24),new Point3(x,y, 352), new Point3(x,y, 344),new Point3(x,y,336)};
                bpe.s_count = 6;
            }
            else
                if (state == 1)
            {
                bpe.shotpoint =
                     new Point3[] { new Point3(x,y,6),new Point3(x,y, 12),
                      new Point3(x,y, 18),new Point3(x,y, 354), new Point3(x,y, 348),new Point3(x,y,342)};
                bpe.s_count = 6;
            }
            else
            {
                bpe.extra = 0;
                bpe.shotpoint = new Point3[] { new Point3(x,y,3),new Point3(x,y, 10),
                      new Point3(x,y, 15),new Point3(x,y, 357), new Point3(x,y, 350),new Point3(x,y,345)};
                bpe.s_count = 6;
                return;
            }
            bpe.extra++;
        }
        public static void Scatter_level3(ref BulletPropertyEx bpe)//16 hit
        {
            float x = core_location.x;
            float y = core_location.y;
            int state = bpe.extra;
            if (state == 0)
            {
                bpe.shotpoint = new Point3[] {new Point3(x,y,4),new Point3(x,y,8),
                    new Point3(x,y, 16),new Point3(x,y, 24),new Point3(x,y, 356),
                      new Point3(x,y, 352) ,new Point3(x,y, 344) ,new Point3(x,y,336)};
                bpe.s_count = 8;
            }
            else
                if (state == 1)
            {
                bpe.t_uv = SP.uv_zhihui[0];
                bpe.uv_rect = SP.p_zhihui[0];
                bpe.shotpoint = new Point3[] {new Point3(x,y,2),new Point3(x,y,6),
                    new Point3(x,y, 12),new Point3(x,y, 18),new Point3(x,y, 358),
                      new Point3(x,y, 354) ,new Point3(x,y, 348) ,new Point3(x,y,342)};
                bpe.s_count = 8;
            }
            else
            {
                bpe.t_uv = SP.uv_zhihui[1];
                bpe.uv_rect = SP.p_zhihui[1];
                bpe.extra=0;
                Vector3 site = core_location;
                bpe.shotpoint= new Point3[] {new Point3(x,y,3),new Point3(x,y,10),
                    new Point3(x,y, 15),new Point3(x,y, 20),new Point3(x,y, 340),
                      new Point3(x,y, 357) ,new Point3(x,y, 350) ,new Point3(x,y,345)};
                bpe.s_count = 8;
                return;
            }
            bpe.extra++;
        }
        public static void Scatter_level4(ref BulletPropertyEx bpe)//super hit 20!!!
        {
            float x = core_location.x;
            float y = core_location.y;
            int state = bpe.extra;
            if (state ==0)
            {
                bpe.shotpoint = new Point3[] {new Point3(x,y,4),new Point3(x,y,8),
                    new Point3(x,y, 16) ,new Point3(x,y, 24),new Point3(x,y, 356) ,
                      new Point3(x,y, 352) ,new Point3(x,y, 344) ,new Point3(x,y,336)};
                bpe.s_count = 8;
            }
            else
               if (state == 1)
            {
                bpe.t_uv = SP.uv_zhihui[0];
                bpe.uv_rect = SP.p_zhihui[0];
                bpe.shotpoint = new Point3[] {new Point3(x,y,2),new Point3(x,y,6),
                    new Point3(x,y, 12) ,new Point3(x,y, 18),new Point3(x,y, 358) ,
                      new Point3(x,y, 354) ,new Point3(x,y, 348) ,new Point3(x,y,342)};
                bpe.s_count = 8;
            }
            else
            {
                bpe.t_uv = SP.uv_zhihui[1];
                bpe.uv_rect = SP.p_zhihui[1];
                bpe.shotpoint = new Point3[] {new Point3(x,y,3),new Point3(x,y,10),
                    new Point3(x,y, 15) ,new Point3(x,y, 20),new Point3(x,y, 340) ,
                      new Point3(x,y, 357) ,new Point3(x,y, 350) ,new Point3(x,y,345)};
                bpe.s_count = 8;
                bpe.extra = 0;
                return;
            }
            bpe.extra++;
        }
        public static void Thunder_level1(ref BulletPropertyEx bpe)
        {
            float x = core_location.x;
            float y = core_location.y;
            bpe.shotpoint = new Point3[] {new Point3(x-0.3f,y,60),new Point3(x+0.3f,y,300) };
            bpe.s_count = 2;
        }
        public static void Thunder_level2(ref BulletPropertyEx bpe)
        {
            float x = core_location.x;
            float y = core_location.y;
            bpe.shotpoint = new Point3[] {new Point3(x,y,0), new Point3(x - 0.3f, y, 60), new Point3(x + 0.3f, y, 300) };
            bpe.s_count = 3;
        }
        public static void Thunder_level3(ref BulletPropertyEx bpe)
        {
            float x = core_location.x;
            float y = core_location.y;
            if (bpe.extra == 0)
            {
                bpe.extra = 1;
                current.B_second.extra_b = 500;
                bpe.shotpoint = new Point3[] { new Point3(x - 0.3f, y, 20), new Point3(x + 0.3f, y, 340) };
                bpe.s_count = 2;
            }
            else
            {
                bpe.extra = 0;
                bpe.shotpoint = new Point3[] { new Point3(x - 0.3f, y, 60), new Point3(x + 0.3f, y, 300) };
                bpe.s_count = 2;
            }
        }
        public static void Thunder_level4(ref BulletPropertyEx bpe)
        {
            float x = core_location.x;
            float y = core_location.y;
            if (bpe.extra == 0)
            {
                bpe.extra = 1;
                current.B_second.extra_b = 500;
                bpe.shotpoint = new Point3[] { new Point3(x - 0.3f, y, 20), new Point3(x + 0.3f, y, 340) };
                bpe.s_count = 2;
            }
            else
            {
                bpe.extra = 0;
                bpe.shotpoint = new Point3[] {new Point3(x,y,0), new Point3(x - 0.3f, y, 60), new Point3(x + 0.3f, y, 300) };
                bpe.s_count = 3;
            }
        }
        public static void Laser_level1(ref BulletPropertyEx bpe)
        {
            if (current.level ==3)
            {
                if(!bpe.b_s[0].active)
                {
                    bpe.b_s[0].active = true;
                    bpe.b_s[1].active = true;
                    bpe.play = BulletMoveEx.Play_7_4;
                    bpe.b_s[0].extra = 0;
                    bpe.b_s[1].extra = 0;
                }
                return;
            }
            float x = wing_location.x;
            float y = wing_location.y;
            bpe.max = 2;
            bpe.play = BulletMoveEx.Play_7_1;
            bpe.uv[0] = bpe.t_uv[0];
            bpe.uv[1] = bpe.t_uv[1];
            bpe.uv[2] = bpe.t_uv[2];
            bpe.uv[3] = bpe.t_uv[3];
            bpe.uv[4] = bpe.t_uv[0];
            bpe.uv[5] = bpe.t_uv[1];
            bpe.uv[6] = bpe.t_uv[2];
            bpe.uv[7] = bpe.t_uv[3];
            bpe.b_s[0].id = 0;
            bpe.b_s[0].extra = 0;
            bpe.b_s[0].location.x = x-1;
            bpe.b_s[0].location.y = y;
            bpe.b_s[0].active = true;
            bpe.b_s[0].uv_rect = bpe.uv_rect;
            bpe.b_s[1].id = 1;
            bpe.b_s[1].extra = 0;
            bpe.b_s[1].location.x = x + 1;
            bpe.b_s[1].location.y = y;
            bpe.b_s[1].active = true;
            bpe.b_s[1].uv_rect = bpe.uv_rect;
        }
        public static void Shot_zhuji(ref BulletPropertyEx bpe)
        {
            float x = core_location.x;
            float y = core_location.y;
            int state = bpe.extra;
            if(state==0)
            {
                bpe.extra = 1;
                int t = 5;
                for (int i = 0; i < 256; i++)
                {
                    if(!bpe.b_s[i].active)
                    {
                        bpe.b_s[i].angle = 0;
                        int p = i * 4;
                        if (t>4)
                        {
                            bpe.b_s[i].uv_rect = SP.p_zhuji[5];
                            bpe.uv[p] = SP.uv_zhuji[5][0];
                            p++;
                            bpe.uv[p] = SP.uv_zhuji[5][1];
                            p++;
                            bpe.uv[p] = SP.uv_zhuji[5][2];
                            p++;
                            bpe.uv[p] = SP.uv_zhuji[5][3];
                            bpe.b_s[i].location.x = x;
                            bpe.b_s[i].location.y = y + 0.3f;
                        }
                        else if(t>2)
                        {
                            bpe.b_s[i].uv_rect = SP.p_zhuji[4];
                            bpe.uv[p] = SP.uv_zhuji[4][0];
                            p++;
                            bpe.uv[p] = SP.uv_zhuji[4][1];
                            p++;
                            bpe.uv[p] = SP.uv_zhuji[4][2];
                            p++;
                            bpe.uv[p] = SP.uv_zhuji[4][3];
                            bpe.b_s[i].location.y = y+0.1f;
                            if(t==3)
                                bpe.b_s[i].location.x = x + 0.26f;
                            else bpe.b_s[i].location.x = x - 0.26f;
                        }
                        else
                        {
                            bpe.b_s[i].uv_rect = SP.p_zhuji[0];
                            bpe.uv[p] = SP.uv_zhuji[0][0];
                            p++;
                            bpe.uv[p] = SP.uv_zhuji[0][1];
                            p++;
                            bpe.uv[p] = SP.uv_zhuji[0][2];
                            p++;
                            bpe.uv[p] = SP.uv_zhuji[0][3];
                            bpe.b_s[i].location.y = y-0.1f;
                            if (t == 1)
                                bpe.b_s[i].location.x = x + 0.51f;
                            else bpe.b_s[i].location.x = x - 0.51f;
                        }
                        bpe.b_s[i].extra = 0;
                        bpe.b_s[i].active = true;
                        t--;
                        if(t==0)
                        {
                            bpe.a_count = 5;
                            if (i >= bpe.max)
                            {
                                bpe.max = i + 1;
                            }
                            return;
                        }
                    }
                }
            }
            else
            {
                bpe.extra = 0;
                int t = 7;
                for (int i = 0; i < 256; i++)
                {
                    if (!bpe.b_s[i].active)
                    {
                        bpe.b_s[i].angle = 0;
                        int p = i * 4;
                        if (t > 6)
                        {
                            bpe.b_s[i].uv_rect = SP.p_zhuji[5];
                            bpe.uv[p] = SP.uv_zhuji[5][0];
                            p++;
                            bpe.uv[p] = SP.uv_zhuji[5][1];
                            p++;
                            bpe.uv[p] = SP.uv_zhuji[5][2];
                            p++;
                            bpe.uv[p] = SP.uv_zhuji[5][3];
                            bpe.b_s[i].location.x = x;
                            bpe.b_s[i].location.y = y + 0.3f;
                        }
                        else if (t > 4)
                        {
                            bpe.b_s[i].uv_rect = SP.p_zhuji[4];
                            bpe.uv[p] = SP.uv_zhuji[4][0];
                            p++;
                            bpe.uv[p] = SP.uv_zhuji[4][1];
                            p++;
                            bpe.uv[p] = SP.uv_zhuji[4][2];
                            p++;
                            bpe.uv[p] = SP.uv_zhuji[4][3];
                            bpe.b_s[i].location.y = y + 0.1f;
                            if (t == 5)
                                bpe.b_s[i].location.x = x + 0.26f;
                            else bpe.b_s[i].location.x = x - 0.26f;
                        }
                        else if(t>2)
                        {
                            bpe.b_s[i].uv_rect = SP.p_zhuji[3];
                            bpe.uv[p] = SP.uv_zhuji[3][0];
                            p++;
                            bpe.uv[p] = SP.uv_zhuji[3][1];
                            p++;
                            bpe.uv[p] = SP.uv_zhuji[3][2];
                            p++;
                            bpe.uv[p] = SP.uv_zhuji[3][3];
                            bpe.b_s[i].location.y = y-0.1f;
                            if (t == 3)
                                bpe.b_s[i].location.x = x + 0.51f;
                            else bpe.b_s[i].location.x = x - 0.51f;
                        }
                        else
                        {
                            bpe.b_s[i].uv_rect = SP.p_zhuji[1];
                            bpe.uv[p] = SP.uv_zhuji[1][0];
                            p++;
                            bpe.uv[p] = SP.uv_zhuji[1][1];
                            p++;
                            bpe.uv[p] = SP.uv_zhuji[1][2];
                            p++;
                            bpe.uv[p] = SP.uv_zhuji[1][3];
                            bpe.b_s[i].location.y = y-0.3f;
                            if (t == 1)
                                bpe.b_s[i].location.x = x + 0.2f;
                            else bpe.b_s[i].location.x = x - 0.2f;
                        }
                        bpe.b_s[i].extra = 0;
                        bpe.b_s[i].active = true;
                        t--;
                        if (t == 0)
                        {
                            bpe.a_count = 7;
                            if (i >= bpe.max)
                            {
                                bpe.max = i + 1;
                            }
                            return;
                        }
                    }
                }
            }
        }
        #endregion

        #region eastproject
        public static void Shot_lingmeng(ref BulletPropertyEx bpe)
        {
            float x = core_location.x;
            float y = core_location.y;
            bpe.shotpoint = new Point3[] { new Point3(x,y+0.2f,2),new Point3(x,y+0.2f,358),new Point3(x,y,6),new Point3(x,y,354)};
            bpe.s_count = 4;
        }
        public static void Shot_lingmengS(ref BulletPropertyEx bpe)
        {
            float x = core_location.x;
            float y = core_location.y;
            bpe.shotpoint = new Point3[] { new Point3(x-0.3f,y,30),new Point3(x+0.3f,y,330)};
            bpe.s_count = 2;
        }
        #endregion
    }
}
