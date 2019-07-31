using UnityEngine;

namespace Assets.UnityVS.Script
{
    class Ani_Motion : GameControl
    {
        #region moth
        public static void Moth_stage0(ref AnimatEx[] ae)
        {
            ae[0].scale = 0.5f;
            ae[0].pivot_p.y = 0.25f;
            ae[1].scale = 0.5f;
            ae[1].pivot_p.y = 0.25f;
            ae[2].pivot_p.y = 0.72f;
            ae[3].pivot_p.y = 0.72f;
            ae[5].angle = 90;
            ae[6].angle = 330;
            ae[7].angle = 350;
            ae[8].angle = 270;
            ae[9].angle = 30;
            ae[10].angle = 10;
            ae[11].angle = 120;
            ae[12].angle = 20;
            ae[13].angle = 20;
            ae[14].angle = 240;
            ae[15].angle = 340;
            ae[16].angle = 340;
            ae[17].angle = 60;
            ae[19].angle = 300;
            ae[21].angle = 120;
            ae[22].angle = 240;
            ae[23].scale = 1;
            ae[24].scale = 1;
            ae[23].pivot_p.y = 0.33f;
            ae[24].pivot_p.y = 0.33f;
        }
        public static bool Moth_stageA(ref AnimatBaseEx abe, ref AnimatEx[] ae, float ta)//0-24 ta=time ratio
        {
            if (ae.Length < 25)
                return true;
            if (ta > 1500)
                return true;
            ta *= 0.000625f;
            if (ta > 0.5f)
            {
                float t = ta - 0.5f;
                ae[0].scale = ta;
                ae[0].pivot_p.y = 0.25f - t * 0.5f;
                ae[1].scale = ta;
                ae[1].pivot_p.y = 0.25f - t * 0.5f;
                float tt = 0.72f - t * 1.44f;
                ae[2].pivot_p.y = tt;
                ae[3].pivot_p.y = tt;
                tt = t * 180;
                ae[5].angle = 90 - tt;
                ae[8].angle = 270 + tt;
                tt = t * 60;
                ae[6].angle = 330 + tt;
                ae[9].angle = 30 - tt;
                tt = 20 * t;
                ae[7].angle = 350 + tt;
                ae[10].angle = 10 - tt;
                float a120 = 120 - 240f * t;
                ae[11].angle = a120;
                float a20 = 20 - 40f * t;
                ae[12].angle = a20;
                ae[13].angle = a20;
                float a240 = 240 + 240f * t;
                ae[14].angle = a240;
                float a340 = 340 + 40f * t;
                ae[15].angle = a340;
                ae[16].angle = a340;
                tt = t * 120;
                ae[17].angle = 60 - tt;
                ae[19].angle = 300 + tt;
                ae[21].angle = a120;
                ae[22].angle = a240;
            }
            if (ta < 0.8f)
            {
                float d = 0.35f + ta * 10;
                ae[23].pivot_p.y = d;
                ae[24].pivot_p.y = d;
            }
            else
            {
                ae[23].scale = 0;
                ae[24].scale = 0;
            }
            return false;
        }
        #endregion

        #region jifeng
        public static void jifeng_stage0(ref AnimatEx[] ae)
        {
            ae[0].angle = 290;
            ae[0].scale = 0;
            ae[1].angle = 70;
            ae[1].scale = 0;
            ae[2].angle = 290;
            ae[2].scale = 0;
            ae[3].angle = 70;
            ae[3].scale = 0;
        }
        public static bool jifeng_stage2(ref AnimatBaseEx abe, ref AnimatEx[] ae, float ta)
        {
            if (ae.Length < 4)
                return true;
            if (ta > 1000)
                return true;
            ta *= 0.001f;
            if (ta > 0.6f)
            {
                ae[0].scale = 1;
                ae[1].scale = 1;
                ae[2].scale = 1;
                ae[3].scale = 1;
                float a = (ta - 0.6f) * 100;
                ae[2].angle = 290 - a;
                ae[3].angle = 70 + a;
            }
            else if (ta < 0.3f)
            {
                float a = ta * 3.3333f;
                ae[0].scale = a;
                ae[1].scale = a;
                ae[2].scale = a;
                ae[3].scale = a;
            }
            return false;
        }
        public static bool jifeng_stage3(ref AnimatBaseEx abe, ref AnimatEx[] ae, float ta)
        {
            if (ae.Length < 4)
                return true;
            if (ta > 1000)
                return true;
            ta *= 0.001f;
            if (ta < 0.4f)
            {
                ae[0].scale = 1;
                ae[1].scale = 1;
                ae[2].scale = 1;
                ae[3].scale = 1;
                float a = ta * 100;
                ae[2].angle = 250 + a;
                ae[3].angle = 110 - a;
            }
            else if (ta > 0.7f)
            {
                float a = (1 - ta) * 3.3333f;
                ae[0].scale = a;
                ae[1].scale = a;
                ae[2].scale = a;
                ae[3].scale = a;
            }
            return false;
        }
        #endregion

        #region nouhuo
        private const float nh_s = 0.02f;
        public static void nh_stage0(ref AnimatEx[] ae)
        {
            for (int i = 0; i < 10; i++)
            {
                ae[i].scale = 0;
                ae[i].free = false;
                if (i < 5)
                {
                    ae[i].angle = 45;
                }
                else {
                    ae[i].angle = 315;
                }
            }
        }
        public static bool nh_stage1(ref AnimatBaseEx abe, ref AnimatEx[] ae, float ta)
        {
            if (ae.Length < 10)
                return true;
            if (ta > 1000)
                return true;
            ta *= 0.001f;
            if (ta < 0.2f)
            {
                float s = ta * 4f;
                ae[0].scale = s;
                ae[5].scale = s;
            }
            else if (ta < 0.4f)
            {
                ae[0].scale = 0.8f;
                ae[5].scale = 0.8f;
                float t = ta - 0.2f;
                float s = 0.8f + t;
                ae[1].scale = s;
                ae[6].scale = s;
                s = t * 165;
                ae[1].angle = 45 + s;
                ae[6].angle = 315 - s;
            }
            else if (ta < 0.6f)
            {
                float t = ta - 0.4f;
                float s = t * 165;
                ae[2].angle = 80 + s;
                ae[7].angle = 280 - s;
                ae[1].scale = 1;
                ae[6].scale = 1;
                ae[2].scale = 1;
                ae[7].scale = 1;
            }
            else if (ta < 0.8f)
            {
                float t = ta - 0.6f;
                float s = 1 - t;
                ae[3].scale = s;
                ae[8].scale = s;
                s = t * 165;
                ae[3].angle = 114 + s;
                ae[8].angle = 246 - s;
            }
            else
            {
                float t = ta - 0.8f;
                float s;
                ae[4].scale = 0.8f;
                ae[9].scale = 0.8f;
                s = t * 165;
                ae[4].angle = 147 + s;
                ae[9].angle = 213 - s;
            }
            return false;
        }
        public static bool nh_stage2(ref AnimatBaseEx abe, ref AnimatEx[] ae, float ta)
        {
            if (ae.Length < 10)
                return true;
            if (ta > 1020)
            {
                nh_stage0(ref ae);
                return true;
            }
            ta *= 0.001f;
            for (int i = 0; i < 10; i++)
            {
                ae[i].free = true;
            }
            if (ta > 0.8f)
            {
                float t3 = 1 - ta;
                ae[1].scale = t3;
                ae[2].scale = t3;
                ae[6].scale = t3;
                ae[7].scale = t3;
                ae[3].scale = 0;
                ae[8].scale = 0;
                ae[0].scale = 0;
                ae[5].scale = 0;
                ae[4].scale = 0;
                ae[9].scale = 0;
                goto label2;

            }
            else//0.5
            {
                float t1 = 0.8f - ta;
                float t3 = 1 - ta;
                ae[0].scale = t1;
                ae[5].scale = t1;
                ae[4].scale = t1;
                ae[9].scale = t1;
                ae[1].scale = t3;
                ae[2].scale = t3;
                ae[6].scale = t3;
                ae[7].scale = t3;
                ae[3].scale = t1;
                ae[8].scale = t1;
            }
            ae[4].location.x += angle_table[180].x * nh_s;
            ae[4].location.y += angle_table[180].y * nh_s;
            ae[9].location.x += angle_table[180].x * nh_s;
            ae[9].location.y += angle_table[180].y * nh_s;

            ae[0].location.x += angle_table[45].x * nh_s;
            ae[0].location.y += angle_table[45].y * nh_s;
            ae[5].location.x += angle_table[315].x * nh_s;
            ae[5].location.y += angle_table[315].y * nh_s;
            label2:;
            ae[1].location.x += angle_table[78].x * nh_s;
            ae[1].location.y += angle_table[78].y * nh_s;
            ae[2].location.x += angle_table[113].x * nh_s;
            ae[2].location.y += angle_table[113].y * nh_s;
            ae[3].location.x += angle_table[147].x * nh_s;
            ae[3].location.y += angle_table[147].y * nh_s;
            ae[6].location.x += angle_table[282].x * nh_s;
            ae[6].location.y += angle_table[282].y * nh_s;
            ae[7].location.x += angle_table[247].x * nh_s;
            ae[7].location.y += angle_table[247].y * nh_s;
            ae[8].location.x += angle_table[213].x * nh_s;
            ae[8].location.y += angle_table[213].y * nh_s;
            return false;
        }
        #endregion

        #region zhihui
        public static void zhh_stage0(ref AnimatEx[] ae)
        {
            ae[18].angle = 0;//20
            ae[19].angle = 0;//40
            ae[20].angle = 0;//60
            ae[21].angle = 40;//100
            ae[22].angle = 0;
            ae[23].angle = 0;
            ae[24].angle = 0;
            ae[25].angle = 320;
            ae[0].pivot_p.y = 0.1f;
            ae[1].pivot_p.y = 0.15f;
            ae[2].pivot_p.y = 0.4f;
            ae[3].pivot_p.y = 0.3f;
            ae[4].pivot_p.y = 0.4f;
            ae[5].pivot_p.y = 0.4f;
            ae[6].pivot_p.y = 0.4f;
            ae[7].pivot_p.y = 0.4f;
            ae[8].pivot_p.y = 0.1f;
            ae[9].pivot_p.y = 0.15f;
            ae[10].pivot_p.y = 0.4f;
            ae[11].pivot_p.y = 0.3f;
            ae[12].pivot_p.y = 0.4f;
            ae[13].pivot_p.y = 0.4f;
            ae[14].pivot_p.y = 0.4f;
            ae[15].pivot_p.y = 0.4f;
            ae[16].pivot_p.y = 0.4f;
            for (int i = 0; i < 17; i++)
            {
                ae[i].free = false;
                ae[i].scale = 0;
            }
            ae[26].scale = 0;
            ae[27].scale = 0;
            ae[28].scale = 0;
            ae[29].scale = 0;
        }
        public static bool zhh_stage1(ref AnimatBaseEx abe, ref AnimatEx[] ae, float ta)
        {
            if (ae.Length < 30)
                return true;
            if (ta < 33)
            {
                ae[0].pivot_p.y = 0.1f;
                ae[1].pivot_p.y = 0.15f;
                ae[2].pivot_p.y = 0.4f;
                ae[3].pivot_p.y = 0.3f;
                ae[4].pivot_p.y = 0.4f;
                ae[5].pivot_p.y = 0.4f;
                ae[6].pivot_p.y = 0.4f;
                ae[7].pivot_p.y = 0.4f;
                ae[8].pivot_p.y = 0.1f;
                ae[9].pivot_p.y = 0.15f;
                ae[10].pivot_p.y = 0.4f;
                ae[11].pivot_p.y = 0.3f;
                ae[12].pivot_p.y = 0.4f;
                ae[13].pivot_p.y = 0.4f;
                ae[14].pivot_p.y = 0.4f;
                ae[15].pivot_p.y = 0.4f;
                ae[16].pivot_p.y = 0.4f;
                for (int i = 0; i < 17; i++)
                {
                    ae[i].free = false;
                    ae[i].scale = 0;
                }
            }
            ta *= 0.001f;
            if (ta > 0.5f)
            {
                ta -= 0.5f;
                ta *= 2;
                int c = (int)ta;
                ta -= c;
                float l = ta * 1.5f;
                float x = angle_table[60].x * l;
                float y = angle_table[60].y * l;
                ae[26].location.x = x;
                ae[26].location.y = y;
                ae[27].location.x = -x;
                ae[27].location.y = y;
                ae[28].location.x = x;
                ae[28].location.y = -y;
                ae[29].location.x = -x;
                ae[29].location.y = -y;
                if (ta > 0.5f)
                    ta = 1 - ta;
                for (int i = 26; i < 30; i++)
                {
                    ae[i].scale = ta * 3;
                    if (ae[i].angle >= 355)
                        ae[i].angle = 0;
                    else ae[i].angle += 20;
                }
            }
            else
            if (ta > 0.2f)
            {
                ae[18].angle = 20;//20
                ae[19].angle = 40;//40
                ae[20].angle = 60;//60
                ae[21].angle = 100;//100
                ae[22].angle = 340;
                ae[23].angle = 320;
                ae[24].angle = 300;
                ae[25].angle = 260;
                float t = (ta - 0.2f) * 3.33f;
                for (int i = 0; i < 17; i++)
                {
                    ae[i].scale = t;
                }
                ae[26].scale = t;
                ae[27].scale = t;
                ae[28].scale = t;
                ae[29].scale = t;
            }
            else
            {
                float t = ta * 100;
                ae[18].angle = t;
                ae[22].angle = 360 - t;
                float t1 = t * 2;
                ae[19].angle = t1;
                ae[23].angle = 360 - t1;
                t1 = t * 3;
                ae[20].angle = t1;
                ae[24].angle = 360 - t1;
                ae[21].angle = 40 + t1;
                ae[25].angle = 320 - t;
            }
            return false;
        }
        public static bool zhh_stage2(ref AnimatBaseEx abe, ref AnimatEx[] ae, float ta)
        {
            if (ae.Length < 30)
                return true;
            ta *= 0.0006f;
            if (ta > 0.5f)
            {
                zhh_stage0(ref ae);
                return true;
            }
            else if (ta > 0.3f)
            {
                ae[26].scale = 0;
                ae[27].scale = 0;
                ae[28].scale = 0;
                ae[29].scale = 0;
                ta = 0.5f - ta;
                float t = ta * 100;
                ae[18].angle = t;
                ae[22].angle = 360 - t;
                float t1 = t * 2;
                ae[19].angle = t1;
                ae[23].angle = 360 - t1;
                t1 = t * 3;
                ae[20].angle = t1;
                ae[24].angle = 360 - t1;
                ae[21].angle = 40 + t1;
                ae[25].angle = 320 - t;
            }
            else
            {
                ta *= 3.33f;
                float t = 1 - ta;
                for (int i = 0; i < 17; i++)
                {
                    int a = (int)ae[i].pivot_p.x;
                    ae[i].location.x += angle_table[a].x * 0.1f;
                    ae[i].location.y += angle_table[a].y * 0.1f;
                    ae[i].free = true;
                    ae[i].scale = t;
                }
            }
            return false;
        }
        #endregion

        #region bigboom
        public static bool bb_stage1(ref AnimatBaseEx abe, ref AnimatEx[] ae, float ta)
        {
            if (ta > 3000)
            {
                for (int i = 0; i < 8; i++)
                {
                    ae[i].scale = 0;
                }
                return true;
            }
            ta *= 0.001f;
            if (ta < 0.2f)
            {
                float t = ta * 15;
                for (int i = 0; i < 8; i++)
                    ae[i].scale = t;
                abe.col.a = 1;
                abe.col.r = 1 + t;
                abe.col.g = 1 + t;
                abe.col.b = 0.5f + t;
            }
            else if (ta < 2.6f)
            {
                float t = ta * 66;
                ae[0].angle = t;
                ae[1].angle = 180 - t;
                ae[2].angle = 180 + t;
                ae[3].angle = 360 - t;
                t = ta * 0.6f;
                t = 2 - t;
                abe.col.r = t;
                abe.col.g = t;
                abe.col.b = t - 0.5f;
                abe.col.a = 1 - ta * 0.3f;
            }
            else
            {
                float t = 3 - ta;
                t *= 0.4f;
                abe.col.a = t;
            }
            return false;
        }
        public static bool sh_stage1(ref AnimatBaseEx abe, ref AnimatEx[] ae, float ta)
        {
            ae[0].angle += 1f;
            if (ae[0].angle >= 360)
                ae[0].angle -= 360;
            return false;
        }
        #endregion

        #region ra2l wing
        public static bool ra2l_stage1(ref AnimatBaseEx abe, ref AnimatEx[] ae, float ta)
        {
            float x = wing_location.x - 1;
            float y = wing_location.y;
            float x1 = wing_location.x + 1;
            float d1 = 100, d2 = 100;
            int c1 = -1, c2 = -1;
            for (int i = 0; i < 20; i++)
            {
                if (buff_enemy[i].c_blood > 0)
                {
                    float xx = buff_enemy[i].location.x - x;
                    float yy = buff_enemy[i].location.y - y;
                    float dd = xx * xx + yy * yy;
                    if (d1 > dd)
                    {
                        d1 = dd;
                        c1 = i;
                    }
                    xx = buff_enemy[i].location.x - x1;
                    yy = buff_enemy[i].location.y - y;
                    dd = xx * xx + yy * yy;
                    if (d2 > dd)
                    {
                        d2 = dd;
                        c2 = i;
                    }
                }
            }
            Vector2 v = new Vector2(x, y);
            if (c1 >= 0)
            {
                ae[0].angle = Aim(ref v, ref buff_enemy[c1].location);
            }
            if (c2 >= 0)
            {
                v.x = x1;
                ae[1].angle = Aim(ref v, ref buff_enemy[c2].location);
            }
            return false;
        }
        #endregion

        #region huijin
        public static void huijin_stage0(ref AnimatEx[] ae)
        {
            ae[2].angle = 45;
            ae[5].angle = 315;
            ae[15].location.x = 0.42f;
            ae[15].location.y = 0.25f;
            ae[20].location.x = -0.42f;
            ae[20].location.y = 0.25f;
            ae[18].pivot_p.y = 0.2470529f;
            ae[23].pivot_p.y = 0.2470529f;
        }
        public static bool huijin_stage1(ref AnimatBaseEx abe, ref AnimatEx[] ae, float ta)
        {
            if (ta > 250)
                return true;
            ta *=0.0025f;
            if (ta < 0.5f)
            {
                float a = ta * 90;
                ae[2].angle = 45 - a;
                ae[5].angle = 315 + a;
                float x = ta * 2.5f + 1;
                ta *= 0.4f;
                ae[15].location.x = 0.42f * x;
                ae[15].location.y = 0.25f - ta;
                ae[20].location.x = -0.42f * x;
                ae[20].location.y = 0.25f - ta;
            }
            else
            {
                ae[2].angle = 0;
                ae[5].angle = 0;
                ae[15].location.x = 0.945f;
                ae[15].location.y = 0.03f;
                ae[20].location.x = -0.945f;
                ae[20].location.y = 0.03f;
            }
            return false;
        }
        public static bool huijin_stage2(ref AnimatBaseEx abe, ref AnimatEx[] ae, float ta)
        {
            ae[18].pivot_p.y = 0.32f;
            ae[23].pivot_p.y = 0.32f;
            return true;
        }
        public static bool huijin_stage3(ref AnimatBaseEx abe, ref AnimatEx[] ae, float ta)
        {
            ae[18].pivot_p.y = 0.2470529f;
            ae[23].pivot_p.y = 0.2470529f;
            return true;
        }
        #endregion
    }
}
