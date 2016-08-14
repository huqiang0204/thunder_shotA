using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.UnityVS.Script
{
    class BulletMoveEx:GameControl
    {
        public static int LockEnemy(Vector3 location)
        {
            float x = location.x;
            float y = location.y;
            float d = 100;
            int index = -1;
            for (int l = 0; l < 20; l++)
            {
                if (buff_enemy[l].move != null)
                {
                    float x1 = buff_enemy[l].location.x - x;
                    float y1 = buff_enemy[l].location.y - y;
                    float d1 = x1 * x1 + y1 * y1;
                    if (d > d1)
                    {
                        d = d1;
                        index = l;
                    }
                }
            }
            return index;
        }
        public static void Play_6_1(ref BulletPropertyEx bpe, ref BulletStateEx state)
        {
            if (state.extra_p % 6 == 0)
            {
                int y = state.extra_p / 6;
                int id = state.id * 4;
                bpe.uv[id] = SP.uv_def_3x2[y][0];
                id++;
                bpe.uv[id] = SP.uv_def_3x2[y][1];
                id++;
                bpe.uv[id] = SP.uv_def_3x2[y][2];
                id++;
                bpe.uv[id] = SP.uv_def_3x2[y][3];
            }
            state.extra_p++;
            if (state.extra_p > 35)
            {
                state.extra_p = 0;
                state.angle = lucky.Next(0,360);
            }
        }
        public static void Play_7_1(ref BulletPropertyEx bpe, ref BulletStateEx state)
        {
            if (state.extra_p % 6 == 0)// 1/7=0.1428571
            {
                float x = (float)state.extra_p;
                x*= 0.023809f;
                Vector2[] uv = bpe.uv;
                int id = state.id * 4;
                uv[id].x = x;
                uv[id+1].x = x;
                x += 0.14328751f;
                uv[id+2].x = x;
                uv[id+3].x = x;
            }
            state.extra_p++;
            if (state.extra_p > 36)
                state.extra_p = 0;
        }
        public static void Play_7_4(ref BulletPropertyEx bpe, ref BulletStateEx state)
        {
            if (state.extra_p % 3 == 0)
            {
                float uv = ((float)state.extra_p) / 0.8571426f;
                int id = state.id * 4;
                bpe.uv[id].x = uv;
                bpe.uv[id + 1].x = uv;
                uv += 0.1428751f;
                bpe.uv[id + 2].x = uv;
                bpe.uv[id + 3].x = uv;
            }
            if (state.extra_p > 12)
                state.extra_p = 6;
            state.extra_p++;
        }
        public static void Play_Def16(ref BulletPropertyEx bpe, ref BulletStateEx state)
        {
            if (state.extra_p > 15)
                state.extra_p = 0;
            int y = state.extra_p;
            int id = state.id * 4;
            bpe.uv[id] = SP.uv_def_4x4[y][0];
            bpe.uv[id + 1] = SP.uv_def_4x4[y][1];
            bpe.uv[id + 2] = SP.uv_def_4x4[y][2];
            bpe.uv[id + 3] = SP.uv_def_4x4[y][3];
            state.angle += 3;
            if (state.angle > 360)
                state.angle = 0;
            state.extra_p++;
        }
        public static void B_Aim(ref BulletPropertyEx bpe,ref BulletStateEx state)
        {
            if (state.extra == 0)
            {
                float s = bpe.speed;
                int z = state.angle=(int) Aim(ref state.location, ref core_location);
                state.movexyz.x = angle_table[z].x * s;
                state.movexyz.y = angle_table[z].y * s;
            }
            state.extra++;
            float x = state.movexyz.x*ts;
            float y = state.movexyz.y*ts;
            state.location.x += x;
            x = state.location.x;
            state.location.y += y;
            y = state.location.y;
            if (y > 5.5f | y < -5.5f | x > 3f | x < -3f)
            {
                state.extra = 0;
                state.active = false;
            }
        }
        public static void B_ArcTrace(ref BulletPropertyEx bpe, ref BulletStateEx state)
        {
            if (state.extra == 0)
            {
                state.extra++;
                state.movexyz.z = state.angle;
                int z = state.angle;
                state.movexyz.x = angle_table[z].x * bpe.speed;
                state.movexyz.y = angle_table[z].y * bpe.speed;
                int t = -1;
                float d = 100;
                for (int i = 0; i < 20; i++)
                {
                    float tx = state.location.x;
                    float ty = state.location.y;
                    if (buff_enemy[i].move != null)
                    {
                        float x1 = buff_enemy[i].location.x - tx;
                        float y1 = buff_enemy[i].location.y - ty;
                        float d1 = x1 * x1 + y1 * y1;
                        if (d1 < d)
                        {
                            d = d1;
                            t = i;
                        }
                    }
                }
                state.extra2 = t;//save the enemy id
                return;
            }
            float x = state.location.x;
            float y = state.location.y;
            if (y > 5.5f | y < -5.5f | x > 3f | x < -3f)
            {
                state.active = false;
                state.extra = 0;
                state.extra2 = 0;
                return;
            }
            if (state.extra2 >= 0)
            {
                if (buff_enemy[state.extra2].c_blood>0)
                {
                    float a = Aim(ref state.location, ref buff_enemy[state.extra2].location);
                    float z = state.movexyz.z;
                    if (a > z)//顺时针
                    {
                        float b = a - z;//顺时针
                        float c = 360 - a + z;
                        if (b > c)
                        {
                            z -= 5;
                        }
                        else
                        {
                            z += 5;
                        }
                    }
                    else//逆时针
                    {
                        float b = z - a;//逆时针
                        float c = 360 - z + a;
                        if (b > c)
                        {
                            z += 5;
                        }
                        else
                        {
                            z -= 5;
                        }
                    }
                    if (z > 359)
                        z = 0;
                    if (z < 0)
                        z = 359;
                    state.movexyz.z = z;
                    state.movexyz.x = angle_table[(int)z].x * bpe.speed;
                    state.movexyz.y = angle_table[(int)z].y * bpe.speed;
                }
                else
                    state.extra2 = -1;
            }
            x = state.movexyz.x * ts;
            y = state.movexyz.y * ts;
            state.location.x += x;
            state.location.y += x;
            if ((state.id & 1) == 0)
            {
                state.angle -= 5;
                if (state.angle < 0)
                    state.angle = 359;
            }
            else
            {
                state.angle += 5;
                if (state.angle > 359)
                    state.angle = 0;
            }
        }
        public static void B_RotateWithParentA(ref BulletPropertyEx bpe, ref BulletStateEx state)
        {
            if (state.extra == 0)
            {
                int z = state.angle;
                state.movexyz.z = z;
                state.movexyz.x = angle_table[z].x * 0.0015f;
                state.movexyz.y = angle_table[z].y * 0.0015f;
            }
            state.extra++;
            float x, y;
            if (state.extra < 30)
            {
                x = state.movexyz.x * ts;
                y = state.movexyz.y * ts;
                state.location.x += x;
                state.location.y += y;
                return;
            }
            state.movexyz.z++;
            if (state.movexyz.z > 360)
                state.movexyz.z -= 360;
            int a = (int)state.movexyz.z;
            int eid = bpe.parentid;
            x = angle_table[a].x * 0.05f * ts;
            y = angle_table[a].y * 0.05f * ts;
            state.location.x = buff_enemy[eid].location.x + x;
            state.location.y = buff_enemy[eid].location.y + y;
            if (state.extra > 300)
            {
                state.active = false;
                state.extra = 0;
            }
        }
        public static void B_RotateWithParentB(ref BulletPropertyEx bpe, ref BulletStateEx state)
        {
            if (state.extra == 0)
            {
                int z = state.angle;
                state.movexyz.z = z;
                state.movexyz.x = angle_table[z].x * 0.0015f;
                state.movexyz.y = angle_table[z].y * 0.0015f;
            }
            state.extra++;
            float x, y;
            if (state.extra < 30)
            {
                x = state.movexyz.x * ts;
                y = state.movexyz.y * ts;
                state.location.x += x;
                state.location.y += y;
                return;
            }
            state.movexyz.z--;
            if (state.movexyz.z < 0)
                state.movexyz.z += 360;
            int a = (int)state.movexyz.z;
            int eid = bpe.parentid;
            x = angle_table[a].x * 0.05f * ts;
            y = angle_table[a].y * 0.05f * ts;
            state.location.x = buff_enemy[eid].location.x + x;
            state.location.y = buff_enemy[eid].location.y + y;
            if (state.extra > 300)
            {
                state.active = false;
                state.extra = 0;
            }
        }
        public static void B_CiecleDisappear(ref BulletPropertyEx bpe, ref BulletStateEx state)
        {
            state.extra++;
            if (state.extra < 20)
            {
                state.location.y -= 0.02f*ts;
                return;
            }
            if (state.extra == 20)
            {
                int z = state.angle;
                state.movexyz.x = angle_table[z].x * 0.00062f;
                state.movexyz.y = angle_table[z].y * 0.00062f;
                return;
            }
            if (state.extra > 200)
            {
                state.active = false;
                state.extra = 0;
                return;
            }
            else
            {
                float x = state.movexyz.x * ts;
                float y = state.movexyz.y * ts;
                state.location.x += x;
                state.location.y += y;
            }
        }
        public static void B_CiecleExpolde(ref BulletPropertyEx bpe, ref BulletStateEx state)
        {
            if (state.location.x < -3 | state.location.x > 3 | state.location.y < -5.5f | state.location.x > 5.5f)
            {
                state.active = false;
                state.extra = 0;
                return;
            }
            state.extra++;
            if (state.extra < 80)
            {
                state.location.y -= 0.00112f*ts;
                return;
            }
            if (state.extra == 80)
            {
                int z = state.angle;
                state.movexyz.x = angle_table[z].x * 0.00062f;
                state.movexyz.y = angle_table[z].y * 0.00062f;
                return;
            }
            else
            {
                float x = state.movexyz.x * ts;
                float y = state.movexyz.y * ts;
                state.location.x += x;
                state.location.y += y;
            }
        }
        public static void B_ForwardToDown(ref BulletPropertyEx bpe, ref BulletStateEx state)
        {
            if (state.location.x < -3 | state.location.x > 3 | state.location.y < -5.5f | state.location.x > 5.5f)
            {
                state.active = false;
                state.extra = 0;
                return;
            }
            if (state.extra == 0)
            {
                int z = state.angle;
                state.movexyz.x = -angle_table[z].x * bpe.speed;
                state.movexyz.y = angle_table[z].y * bpe.speed;
            }
            if (state.extra == 60)
            {
                if (state.angle < 180)
                    state.movexyz.x = -0.0003f;
                else state.movexyz.x = 0.0003f;
                state.movexyz.y = -0.02f;
            }
            float x = state.movexyz.x * ts;
            float y = state.movexyz.y * ts;
            state.location.x += x;
            state.location.y += y;
            state.extra++;
        }
        static Point3[] diamond_increment = new Point3[12] { new Point3(0,-0.1f,180),new Point3(0.033f,0.038f,200),new Point3(0.0165f,0.076f,200),
            new Point3(0.05f,0,180),new Point3(-0.0165f,0.076f,160),new Point3(-0.033f,0.038f,160),new Point3(0,0.1f,180),new Point3(-0.033f,-0.038f,200),
            new Point3(-0.0165f,-0.076f,200),new Point3(-0.05f,0,180),new Point3(0.0165f,-0.076f,160),new Point3(0.033f,-0.038f,160)};
        public static void B_Diamond(ref BulletPropertyEx bpe, ref BulletStateEx state)//frist parament is bullet id
        {
            if (state.extra == 0)
            {
                state.extra++;
                int s = state.id % 12;
                state.angle = (int)diamond_increment[s].z;
                state.extra2 = s;
            }
            if (state.extra < 10)
            {
                state.location.x += diamond_increment[state.extra2].x;
                state.location.y += diamond_increment[state.extra2].y;
                state.extra++;
            }
            else
                state.location.y -= 0.05f;
            if (state.location.y < -5.5f)
            {
                state.active = false;
                state.extra = 0;
                state.extra2 = 0;
            }
        }
        public static void B_LockEnemy(ref BulletPropertyEx bpe, ref BulletStateEx state)
        {
            if (state.extra == 0)
            {
                state.movexyz.z = state.angle;
                int z = state.angle;
                state.movexyz.x = angle_table[z].x * 0.005f;
                state.movexyz.y = angle_table[z].y * 0.005f;
            }
            state.extra++;
            float x = state.location.x;
            float y = state.location.y;
            if (y > 5.5f | y < -5.5f | x > 3f | x < -3f)
            {
                state.active = false;
                state.extra = 0;
                state.extra2 = 0;
                return;
            }
            if (state.extra < 15)
            {
                x = state.movexyz.x * ts;
                y = state.movexyz.y * ts;
                state.location.x += x;
                state.location.y += y;
                return;
            }
            if (state.extra == 15)
            {
                int t = -1;
                float d = 100;
                for (int i = 0; i < 20; i++)
                {
                    if (buff_enemy[i].c_blood >0)
                    {
                        float x1 = buff_enemy[i].location.x - x;
                        float y1 = buff_enemy[i].location.y - y;
                        float d1 = x1 * x1 + y1 * y1;
                        if (d1 < d)
                        {
                            d = d1;
                            t = i;
                        }
                    }
                }
                state.extra2 = t;//save the enemy id
                return;
            }
            if (state.extra2 > -1)
            {
                if (buff_enemy[state.extra2].c_blood >0)
                {
                    Aim1(ref state.location, ref buff_enemy[state.extra2].location, bpe.speed, ref state.movexyz);
                }
                else
                    state.extra2 = -1;
            }
            x = state.movexyz.x * ts;
            y = state.movexyz.y * ts;
            state.location.x += x;
            state.location.y += y;
        }
        public static void B_LockCore(ref BulletPropertyEx bpe, ref BulletStateEx state)
        {
            //Effect_Def16(ref state);
            state.extra++;
            if (state.extra > 400)
            {
                state.active = false;
                state.extra = 0;
                state.extra2 = 0;
                return;
            }
            Aim1(ref state.location, ref core_location, bpe.speed*ts);
        }
        public static void B_DownWord(ref BulletPropertyEx bpe, ref BulletStateEx state)
        {
            state.location.y -= bpe.speed*ts;
            if (state.location.y < -5.5f)
            {
                state.active = false;
            }
        }
        public static void B_DownWordEX(ref BulletPropertyEx bpe, ref BulletStateEx state)
        {
            if (state.extra < 10)
            {
                state.extra++;
                int z = state.angle;
                state.location.x += angle_table[z].x * bpe.speed*ts;
                state.location.y += angle_table[z].y * bpe.speed*ts;
                return;
            }
            state.location.y -= 0.0017f*ts;
            if (state.location.y < -5.5f)
            {
                state.active = false;
                state.extra = 0;
                state.extra2 = 0;
            }
        }
        public static void B_Laser_level1(ref BulletPropertyEx bpe, ref BulletStateEx state)
        {
            state.extra++;
            if (state.extra > 36 &current.level<3)
            {
                state.extra = 0;
                state.active = false;
            }
            if ((state.id & 1) == 0)
                state.location.x = wing_location.x-1;
            else
                state.location.x = wing_location.x + 1f;
            state.location.y = wing_location.y;
        }
        public static void B_Ripple(ref BulletPropertyEx bpe, ref BulletStateEx state)
        {
            if (state.id % 2 == 0)//left
            {
                if (state.extra < 6)//left
                {
                    state.angle -= 5;
                }
                else//right
                {
                    state.angle += 5;
                }
            }
            else//right
            {
                if (state.extra < 6)//rgiht
                {
                    state.angle += 5;
                }
                else//left
                {
                    state.angle -= 5;
                }
            }
            int z = (int)state.angle;
            if (z < 0)
                z += 360;
            if (z > 360)
                z -= 360;
            state.location.x += angle_table[z].x * 0.0017f*ts;
            state.location.y += angle_table[z].y * 0.0017f*ts;
            state.extra++;
            if (state.extra > 17)
                state.extra = -6;
            if (state.location.y < -5.5f | state.location.x < -3 | state.location.x > 3 | state.location.y > 5.5f)
            {
                state.active = false;
                state.extra = 0;
            }
        }
        public static void B_Pentagram(ref BulletPropertyEx bpe, ref BulletStateEx state)
        {
            if (state.extra % 50 == 0)
            {
                state.angle += 144;
                if (state.angle > 360)
                    state.angle -= 360;
                int z = state.angle;
                state.movexyz.x = angle_table[z].x * 0.0056f;
                state.movexyz.y = angle_table[z].y * 0.0056f;
            }
            state.location.x += state.movexyz.x*ts;
            state.location.y += state.movexyz.y*ts;
            state.extra++;
            if (state.extra > 250)
            {
                state.active = false;
                state.extra = 0;
            }
        }
        public static void B_AngleToDwon(ref BulletPropertyEx bpe, ref BulletStateEx state)
        {
            if (state.extra == 0)
            {
                int z = (int)state.angle;
                state.movexyz.x = angle_table[z].x * 0.003f;
                state.movexyz.y = angle_table[z].y * 0.003f;
            }
            if (state.extra < 30)
            {
                state.location.x += state.movexyz.x*ts;
                state.location.y += state.movexyz.y*ts;
            }
            else
                state.location.y -= 0.001f*ts;
            if (state.location.y < -5.5f)
            {
                state.active = false;
                state.extra = 0;
                return;
            }
            state.extra++;
        }
        internal static void B_DownToCross(ref BulletPropertyEx bpe, ref BulletStateEx state)
        {
            state.extra++;
            if (state.extra < 100)
            {
                state.location.y -= 0.01f;
            }
            else
            {
                int c = state.extra % 4;
                switch (c)
                {
                    case 0:
                        {
                            state.location.y -= 0.0003f*ts;
                            break;
                        }
                    case 1:
                        {
                            state.location.y += 0.0003f*ts;
                            state.angle = 180;
                            break;
                        }
                    case 2:
                        {
                            state.location.x -= 0.0003f*ts;
                            state.angle = 270;
                            break;
                        }
                    case 3:
                        {
                            state.location.x += 0.0003f*ts;
                            state.angle = 90;
                            break;
                        }
                }
                if (state.extra > 150)
                {
                    state.active = false;
                    state.extra = 0;
                }
            }
        }
        public static void B_Boss_Tick(ref BulletPropertyEx bpe, ref BulletStateEx state)
        {
            if (state.location.y < -5.5f)
            {
                state.active = false;
                state.extra = 0;
                return;
            }
            if (state.extra == 0)
            {
                int z = state.angle;
                state.movexyz.x = angle_table[z].x * 0.0056f;
                state.movexyz.y = angle_table[z].y * 0.0056f;
            }
            if (state.location.x < -2.5f)
            {
                state.angle = 240;
                state.movexyz.x = angle_table[240].x * 0.0056f;
                state.movexyz.y = angle_table[240].y * 0.0056f;
            }
            else if (state.location.x > 2.5f)
            {
                state.angle = 120;
                state.movexyz.x = angle_table[120].x * 0.0056f;
                state.movexyz.y = angle_table[120].y * 0.0056f;
            }
            state.location.x += state.movexyz.x*ts;
            state.location.y += state.movexyz.y*ts;
            state.extra++;
        }
        public static void Parabola(ref BulletPropertyEx bpe,ref BulletStateEx bse)
        {
            if (bse.location.y < -5.5f)
            {
                bse.active = false;
                bse.extra = 0;
                return;
            }
            if(bse.extra<1)
            {
                bse.movexyz=bse.location;
                if (bse.angle < 180)
                    bse.movexyz.z = -1;
                else bse.movexyz.z = 1;
            }
            float c ,x;
            c = bse.extra - 8;
            x = 0.02f * c;
            if (x<=0.1f | x >= 0.1f)
                bse.angle = 180;
            //y=ax²+bx+c
            float y = -4f * x * x + 4f * x + 0.5f;
            if (bse.movexyz.z < 0)
                x = bse.movexyz.x - x -0.25f;
            else x += bse.movexyz.x +0.25f;
            y += bse.movexyz.y;
            bse.location.x = x;
            bse.location.y = y;
            bse.extra++;
        }
        public static void Missile(ref BulletPropertyEx bpe,ref BulletStateEx bse)
        {
            if (bse.location.y < -5.5f)
            {
                bse.active = false;
            }
            bse.location.y -= ts * 0.01f;
        }
    }
}
