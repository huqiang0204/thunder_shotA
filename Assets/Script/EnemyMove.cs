using System;
using UnityEngine;

namespace Assets.UnityVS.Script
{
    class EnemyMove:GameControl
    {
        public static void Player_0_3(ref EnemyBaseEX ebe)
        {
            ebe.extra_a++;
            if (ebe.extra_a >= 40)
                ebe.extra_a = 0;
            int index = ebe.extra_a;
            if (index % 10 == 0)
            {
                ebe.update_spt = true;
                //ebe.spt_index = index / 10;               
            }
        }
        public static void Player_4_7(ref EnemyBaseEX ebe)
        {
            ebe.extra_a++;
            if (ebe.extra_a >= 40)
                ebe.extra_a = 0;
            int index = ebe.extra_a;
            if (index % 10 == 0)
            {
                ebe.update_spt = true;
                //ebe.spt_index =4+ index / 10;
            }
        }
        public static void Player_0_5(ref EnemyBaseEX ebe)
        {
            ebe.extra_a++;
            if (ebe.extra_a >= 50)
                ebe.extra_a = 0;
            int index = ebe.extra_a;
            if (index % 10 == 0)
            {
                ebe.update_spt = true;
                //ebe.spt_index = index / 10;              
            }
        }
        public static void Player_0_11(ref EnemyBaseEX ebe)
        {
            ebe.extra_a++;
            if (ebe.extra_a >= 110)
                ebe.extra_a = 0;
            int index = ebe.extra_a;
            if (index % 10 == 0)
            {
                ebe.update_spt = true;
                //ebe.spt_index = index / 10;               
            }
        }
        public static void Player_11_0(ref EnemyBaseEX ebe)
        {
            ebe.extra_a++;
            if (ebe.extra_a>10)
            {
                ebe.update_spt = true;
                //ebe.spt_index --;
                //if (ebe.spt_index < 0)
                //    ebe.spt_index = 11;
               ebe.extra_a = 0;
            }
        }
        public static void Player_12_23(ref EnemyBaseEX ebe)
        {
            ebe.extra_a++;
            int index = ebe.extra_a;
            if (index % 10 == 0)
            {
                ebe.update_spt = true;
                //ebe.spt_index = index / 10 + 11;
                if (ebe.extra_a >= 50)
                    ebe.extra_a = 0;
            }
        }
        public static bool M_LeftToRightA(ref EnemyBaseEX ebe)
        {
            if (ebe.location.x > 3)
            {
                ebe.c_blood = 0;
                return false;
            }
            if (ebe.extra_b > ebe.shotfrequency)
            {
                ebe.extra_b = 0;
                if (ebe.location.x < 2.5f)
                {
                    int bid = ebe.bulletid[0];
                    ebe.shot(ref buff_b_ex[bid], ref ebe.location,ref ebe.extra_b);
                }
            }
            ebe.extra_b+=ts;
            ebe.location.x+=0.0067f*ts;
            return true;
        }
        public static bool M_LeftToRightB(ref EnemyBaseEX ebe)
        {
            if (ebe.location.x > 3)
            {
                ebe.c_blood = 0;
                return false;
            }
            if (ebe.extra_b > ebe.shotfrequency)
            {
                ebe.extra_b = 0;
                if (ebe.location.x < 2.5f)
                {
                    int bid = ebe.bulletid[0];
                    ebe.shot(ref buff_b_ex[bid], ref ebe.location,ref ebe.extra_b);
                }
            }
            ebe.extra_b+=ts;
            ebe.location.x += 0.0067f*ts;
            ebe.location.y -= 0.0003f*ts;
            return true;
        }
        public static bool M_LeftToRightC(ref EnemyBaseEX ebe)
        {
            if (ebe.location.x > 3)
            {
                ebe.c_blood = 0;
                return false;
            }
            if (ebe.extra_b > ebe.shotfrequency)
            {
                ebe.extra_b = 0;
                if (ebe.location.x < 2.5f)
                {
                    int bid = ebe.bulletid[0];
                    ebe.shot(ref buff_b_ex[bid], ref ebe.location,ref ebe.extra_b);
                }
            }
            ebe.extra_b+=ts;
            if(ebe.location.x<0)
                ebe.location.y -= 0.0003f*ts;
            else ebe.location.y += 0.0003f*ts;
            ebe.location.x += 0.0067f*ts;
            return true;
        }
        public static bool M_RightToLeftA(ref EnemyBaseEX ebe)
        {
            if (ebe.location.x <-3)
            {
                ebe.c_blood = 0;
                return false;
            }
            if (ebe.extra_b > ebe.shotfrequency)
            {
                ebe.extra_b = 0;
                if (ebe.location.x > -2.5f)
                {
                    int bid = ebe.bulletid[0];
                    ebe.shot(ref buff_b_ex[bid], ref ebe.location,ref ebe.extra_b);
                }
            }
            ebe.extra_b+=ts;
            ebe.location.x -= 0.0067f*ts;
            return true;
        }
        public static bool M_RightToLeftB(ref EnemyBaseEX ebe)
        {
            if (ebe.location.x <-3)
            {
                ebe.c_blood= 0;
                return false;
            }
            if (ebe.extra_b > ebe.shotfrequency)
            {
                ebe.extra_b = 0;
                if (ebe.location.x >- 2.5f)
                {
                    int bid = ebe.bulletid[0];
                    ebe.shot(ref buff_b_ex[bid], ref ebe.location,ref ebe.extra_b);
                }
            }
            ebe.extra_b+=ts;
            ebe.location.x -= 0.0067f*ts;
            ebe.location.y -= 0.0003f*ts;
            return true;
        }
        public static bool M_RightToLeftC(ref EnemyBaseEX ebe)
        {
            if (ebe.location.x <-3)
            {
                ebe.c_blood = 0;
                return false;
            }
            if (ebe.extra_b > ebe.shotfrequency)
            {
                ebe.extra_b = 0;
                if (ebe.location.x >- 2.5f)
                {
                    int bid = ebe.bulletid[0];
                    ebe.shot(ref buff_b_ex[bid], ref ebe.location,ref ebe.extra_b);
                }
            }
            ebe.extra_b+=ts;
            if (ebe.location.x > 0)
                ebe.location.y -= 0.0003f*ts;
            else ebe.location.y += 0.0003f*ts;
            ebe.location.x -= 0.0067f*ts;
            return true;
        }
        public static bool M_Meteor(ref EnemyBaseEX ebe)
        {
            if (ebe.location.y < -6f)
            {
                ebe.c_blood = 0;
                return false;
            }
            ebe.location.y -= 0.0033f*ts;
            return true;
        }
        public static bool M_FixedTo_200(ref EnemyBaseEX ebe)
        {
            if (ebe.extra_m < 200)
            {
                ebe.extra_m++;
                ebe.location.y -= 0.005f*ts;
                return true;
            }
            if (ebe.extra_b > ebe.shotfrequency)
            {
                ebe.extra_b = 0;
                int bid = ebe.bulletid[0];
                ebe.shot(ref buff_b_ex[bid], ref ebe.location,ref ebe.extra_b);
            }
            ebe.extra_b+=ts;
            return true;
        }
        public static bool M_Downward_Def(ref EnemyBaseEX ebe)
        {
            Vector3 a = ebe.location;
            if (a.y < -5.5)
            {
                ebe.c_blood = 0;
                return false;
            }
            ebe.location.y -= 0.005f*ts;
            if (ebe.extra_b > ebe.shotfrequency)
            {
                ebe.extra_b = 0;
                int bid = ebe.bulletid[0];
                ebe.shot(ref buff_b_ex[bid], ref ebe.location,ref ebe.extra_b);
            }
            ebe.extra_b+=ts;
            return true;
        }
        public static bool M_Downward_01(ref EnemyBaseEX ebe)
        {
            if (ebe.location.y < -5.5f)
            {
                ebe.c_blood = 0;
                return false;
            }
            ebe.location.y -= 0.0044f*ts;
            if(ebe.extra_b>ebe.shotfrequency)
            {
                ebe.extra_b = 0;
                int bid = ebe.bulletid[0];
                ebe.shot(ref buff_b_ex[bid],ref ebe.location,ref ebe.extra_b);
            }
            ebe.extra_b+=ts;
            return true;
        }
        public static bool M_Downward_NoStop(ref EnemyBaseEX ebe)
        {
            Vector3 a = ebe.location;
            if (a.y < -5.5)
            {
                ebe.c_blood = 0;
                return false;
            }
            ebe.location.y -= 0.001f*ts;
            if (ebe.shot != null)
            {
                if(ebe.extra_b>ebe.shotfrequency)
                {
                    ebe.extra_b = 0;
                    int bid = ebe.bulletid[0];
                    ebe.shot(ref buff_b_ex[bid], ref ebe.location,ref ebe.extra_b);
                }                    
                ebe.extra_b+=ts;
            }                
            return true;
        }
        public static bool M_Down_Slow(ref EnemyBaseEX ebe)
        {
            Vector3 a = ebe.location;
            if (a.y < -5.5)
            {
                ebe.c_blood = 0;
                return false;
            }
            if (ebe.extra_b > ebe.shotfrequency)
            {
                ebe.extra_b = 0;
                if (ebe.location.y < 5f)
                {
                    int bid = ebe.bulletid[0];
                    ebe.shot(ref buff_b_ex[bid],ref ebe.location,ref ebe.extra_b);
                }
            }
            ebe.extra_b+=ts;
            ebe.location.y -= 0.0033f*ts;
            return true;
        }
        public static bool M_Down_FastToSlow(ref EnemyBaseEX ebe)
        {
            Vector3 a = ebe.location;
            if (a.y < -5.5f)
            {
                ebe.c_blood = 0;
                return false;
            }
            if (ebe.extra_m < 40)
            {
                ebe.extra_m++;
                ebe.location.y -= 0.003f*ts;
            }
            else
            {
                if (ebe.extra_b > ebe.shotfrequency)
                {
                    ebe.extra_b = 0;
                    if (ebe.location.y < 5f)
                    {
                        int bid = ebe.bulletid[0];
                        ebe.shot(ref buff_b_ex[bid],ref ebe.location,ref ebe.extra_b);
                    }
                }
                ebe.extra_b+=ts;
            }
            return true;
        }
        public static bool M_Forward(ref EnemyBaseEX ebe)//正向
        {
            Vector3 a = ebe.location;
            if (a.y < -5.5f)
            {
                ebe.c_blood = 0;
                return false;
            }
            else
            {
                int z = (int)ebe.angle.z;
                ebe.location.x += angle_table[z].x * 0.001f*ts;
                ebe.location.y -= angle_table[z].y * 0.001f*ts;
                if(ebe.shotfrequency<ebe.extra_b)
                {
                    ebe.extra_b = 0;
                    int bid = ebe.bulletid[0];
                    ebe.shot(ref buff_b_ex[bid], ref ebe.location,ref ebe.extra_b);
                }               
                ebe.extra_b+=ts;
            }
            return true;
        }
        public static bool M_RightArc(ref EnemyBaseEX ebe)
        {
            int z = (int)ebe.angle.z;
            z++;
            if (z > 359)
                z = 0;
            if (z == 60)
            {
                ebe.c_blood = 0;
                return false;
            }
            ebe.angle.z = z;
            ebe.location.x -= angle_table[z].x * 0.004f*ts;
            ebe.location.y -= angle_table[z].y * 0.004f*ts;
            if (ebe.shot != null)
            {
                if (ebe.extra_b > ebe.shotfrequency)
                {
                    ebe.extra_b = 0;
                    int bid = ebe.bulletid[0];
                    ebe.shot(ref buff_b_ex[bid], ref ebe.location,ref ebe.extra_b);
                }
                ebe.extra_b+=ts;
            }
            return true;
        }
        public static bool M_LeftArc(ref EnemyBaseEX ebe)
        {
            int z = (int)ebe.angle.z;
            z--;
            if (z <= 0)
                z = 359;
            if (z == 300)
            {
                ebe.c_blood = 0;
                return false;
            }
            ebe.angle.z = z;
            ebe.location.x -= angle_table[z].x * 0.004f*ts;
            ebe.location.y -= angle_table[z].y * 0.004f*ts;
            if (ebe.shot != null)
            {
                if (ebe.extra_b > ebe.shotfrequency)
                {
                    ebe.extra_b = 0;
                    int bid = ebe.bulletid[0];
                    ebe.shot(ref buff_b_ex[bid], ref ebe.location,ref ebe.extra_b);
                }
                ebe.extra_b+=ts;
            }
            return true;
        }
        public static bool M_Dock_180(ref EnemyBaseEX ebe)
        {
            ebe.extra_m++;
            if (ebe.extra_m < 80 | ebe.extra_m > 280)
            {
                ebe.location.y -= 0.002f*ts;
            }
            else
            {
                if (ebe.extra_b > ebe.shotfrequency)
                {
                    ebe.extra_b = 0;
                    int bid = ebe.bulletid[0];
                    ebe.shot(ref buff_b_ex[bid], ref ebe.location,ref ebe.extra_b);
                }
                ebe.extra_b+=ts;
            }
            if (ebe.location.y < -5.5f)
            {
                ebe.c_blood = 0;
                return false;
            }
            return true;
        }
        public static bool M_Dock_200(ref EnemyBaseEX ebe)
        {
            ebe.extra_m++;
            if (ebe.extra_m < 100 | ebe.extra_m > 300)
            {
                ebe.location.y -= 0.002f*ts;
            }
            else if(ebe.extra_b > ebe.shotfrequency)
            {
                ebe.extra_b = 0;
                int bid = ebe.bulletid[0];
                ebe.shot(ref buff_b_ex[bid], ref ebe.location,ref ebe.extra_b);
            }
            ebe.extra_b+=ts;  
            if (ebe.location.y < -5.5f)
            {
                ebe.c_blood = 0;
                return false;
            }
            return true;
        }
        public static bool M_Dwon_Back(ref EnemyBaseEX ebe)
        {
            ebe.extra_m++;
            if (ebe.extra_m < 100)
            {
                ebe.location.y -= 0.0001f*ts;
                return true;
            }
            else
                if (ebe.extra_m == 100)
            {
                buff_b_ex[ebe.bulletid[0]].s_count = 1;
                float x = ebe.location.x;
                float y = ebe.location.y;
                float z = Aim(ref ebe.location, ref core_location);
                int bid = ebe.bulletid[0];
                buff_b_ex[bid].s_count = 1;
                buff_b_ex[bid].shotpoint = new Point3[] { new Point3(x,y,z)};
                return true;
            }
            if (ebe.extra_m < 120)
            {
                if (ebe.location.x <= 0)
                {
                    if (ebe.angle.z == 0)
                        ebe.angle.z = 360;
                    ebe.angle.z -= 9;
                }
                else
                {
                    ebe.angle.z += 9;
                }
                return true;
            }
            if (ebe.extra_m < 220)
            {
                ebe.location.y += 0.001f*ts;
                return true;
            }
            ebe.extra_m = 0;
            ebe.c_blood = 0;
            return false;
        }
        public static bool M_AimLeft(ref EnemyBaseEX ebe)
        {
            if(ebe.location.x>3| ebe.location.y<-5.5f)
            {
                ebe.extra_m = 0;
                ebe.c_blood= 0;
                return false;
            }
            if(ebe.extra_m==0)
            {
                Aim1(ref ebe.location,ref core_location,0.03f,ref ebe.olt);
                ebe.extra_m++;
            }
            if(ebe.extra_b>ebe.shotfrequency)
            {
                ebe.extra_b = 0;
                if (ebe.location.x > -2.5f)
                {
                    int bid = ebe.bulletid[0];
                    ebe.shot(ref buff_b_ex[bid], ref ebe.location,ref ebe.extra_b);
                }
            }
            ebe.extra_b+=ts;
            ebe.location += ebe.olt*ts;
            return true;
        }
        public static bool M_AimRight(ref EnemyBaseEX ebe)
        {
            if (ebe.location.x <-3 | ebe.location.y < -5.5f)
            {
                ebe.extra_m = 0;
                ebe.c_blood = 0;
                return false;
            }
            if (ebe.extra_m == 0)
            {
                Aim1(ref ebe.location, ref core_location, 0.03f, ref ebe.olt);
                ebe.extra_m++;
            }
            if (ebe.extra_b > ebe.shotfrequency)
            {
                ebe.extra_b = 0;
                if (ebe.location.x <2.5f)
                {
                    int bid = ebe.bulletid[0];
                    ebe.shot(ref buff_b_ex[bid], ref ebe.location,ref ebe.extra_b);
                }
            }
            ebe.extra_b+=ts;
            ebe.location += ebe.olt*ts;
            return true;
        }
        public static bool M_AimTop(ref EnemyBaseEX ebe)
        {
            if ( ebe.location.y < -5.5f)
            {
                ebe.extra_m = 0;
                ebe.c_blood = 0;
                return false;
            }
            if (ebe.extra_m == 0)
            {
                Aim1(ref ebe.location, ref core_location, 0.03f, ref ebe.olt);
                ebe.extra_m++;
            }
            if (ebe.extra_b > ebe.shotfrequency)
            {
                ebe.extra_b = 0;
                if (ebe.location.y < 5f)
                {
                    int bid = ebe.bulletid[0];
                    ebe.shot(ref buff_b_ex[bid], ref ebe.location,ref ebe.extra_b);
                }
            }
            ebe.extra_b+=ts;
            ebe.location += ebe.olt*ts;
            return true;
        }
    }
}
