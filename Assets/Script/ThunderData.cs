#define pc
//#undef pc
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.UnityVS.Script
{
    class ThunderData : SP
    {
        #region string resouce
#if pc
        static string mat_nouhuo = "Mat_PC/w_nh";
        static string mat_jifeng = "Mat_PC/w_jifeng";
        static string mat_zhihui = "Mat_PC/w_zhh";
        static string mat_w_02a = "Mat_PC/w_02a";
        static string mat_w_jf = "Mat_PC/w_jianfeng";
        static string mat_b_chain = "Mat_PC/b_b03";
        static string mat_b_tb = "Mat_PC/B_thunderboll";
        static string mat_b_ls01 = "Mat_PC/b_laser01";
        static string mat_b_ls02 = "Mat_PC/b_laser02";
        static string mat_b_ls03 = "Mat_PC/b_laser03";
        static string mat_b_ls04 = "Mat_PC/b_laser04";
        static string mat_b_ls05 = "Mat_PC/b_laser05";
        static string mat_b_zhihui = "Mat_PC/b_zhihui";
        static string mat_b_zhuji = "Mat_PC/b_zhuji";
        static string mat_b_a03 = "Mat_PC/b_a03";
        static string mat_b_b02 = "Mat_PC/b_b02";
        static string mat_b_b04 = "Mat_PC/b_b04";
        static string mat_b_tb01 = "Mat_PC/b_tb01";
        static string mat_e_moth = "Mat_PC/e_moth";
        static string mat_e_hj = "Mat_PC/e_huijin";
        static string mat_e_a00 = "Mat_PC/t_e_a00";        
        static string mat_e_met = "Mat_PC/t_e_met";
        static string mat_e_b00 = "Mat_PC/t_e_b00";
        static string mat_s_s = "Mat_PC/s_shield";
#else
        static string mat_nouhuo = "Mat_Phone/w_nh";
        static string mat_jifeng = "Mat_Phone/w_jifeng";
        static string mat_zhihui = "Mat_Phone/w_zhh";
        static string mat_w_02a = "Mat_Phone/w_02a";
        static string mat_w_jf = "Mat_Phone/w_jianfeng";
        static string mat_b_chain= "Mat_Phone/b_b03";
        static string mat_b_tb = "Mat_Phone/B_thunderboll";
        static string mat_b_ls01 = "Mat_Phone/b_laser01";
        static string mat_b_ls02 = "Mat_Phone/b_laser02";
        static string mat_b_ls03 = "Mat_Phone/b_laser03";
        static string mat_b_ls05 = "Mat_Phone/b_laser05";
        static string mat_b_zhihui = "Mat_Phone/b_zhihui";
        static string mat_b_zhuji = "Mat_Phone/b_zhuji";
        static string mat_b_a03 = "Mat_Phone/b_a03";
        static string mat_b_b02 = "Mat_Phone/b_b02";
        static string mat_b_b04 = "Mat_Phone/b_b04";
        static string mat_b_tb01 = "Mat_Phone/b_tb01";
        static string mat_e_moth = "Mat_Phone/e_moth";
        static string mat_e_a00 = "Mat_Phone/t_e_a00";
        static string mat_e_a10 = "Mat_Phone/e-a10";
        static string mat_e_met = "Mat_Phone/t_e_met";
        static string mat_e_b00 = "Mat_Phone/t_e_b00";
        static string mat_s_s = "Mat_Phone/s_shield";
#endif
        static string mat_e_a10 = "Mat_PC/e-a10";
        static string mat_e_bee = "Mat_PC/e-bee";
        static string mat_hit = "Mat_PC/hit";
        static string mat_missile = "Mat_PC/b_missile";
        static string mat_missile01 = "Mat_PC/b_missile01";
        static string img_zhihui = "Picture/p-06d";
        static string img_nouhuo = "Picture/p-03c";
        static string img_jifeng = "Picture/p-05d";
        static string img_thunderboll = "Picture/m-04a";
        static string img_mijia = "Picture/w-02a";
        static string img_p02b = "Picture/p-02b";
        static string img_p04b = "Picture/p-b04";
        static string img_circle = "Picture/magic_shiled";
#endregion

#region edge points
        static readonly Point2[] points_meteor = new Point2[] { new Point2(-0.0234375f, -0.6171875f), new Point2(-0.1328125f, -0.609375f), new Point2(-0.40625f, -0.2421875f), new Point2(-0.0390625f, 0.625f), new Point2(0.390625f, -0.2265625f) };
#endregion

#region goods image plane

        public static string[] img_all_plane = new string[] { img_nouhuo, img_jifeng, img_zhihui };
#endregion

#region goods image second ewapon

        public static string[] img_all_second = new string[] { img_thunderboll, img_p04b };
#endregion

#region goods iamge wing
        public static string[] img_all_wing = new string[] { img_mijia, img_p02b };
#endregion

#region goods image skill        
        public static string[] img_all_skill = new string[] { img_circle };
#endregion

#region skill resource
        public static AnimatBaseEx shield = new AnimatBaseEx() { stage = new AniRun[] { Ani_Motion.sh_stage1 }, ae = new AnimatEx[] { new AnimatEx { scale = 2, uv2 = uv_def_1x1, free = true, rect = uv_128x128 } }
        };
        static Skill skill_shiled = new Skill() { update = ThunderMod.sh_up, abe = shield, mat_name = mat_s_s, gold = 10000, force_clear = true, follow = true, r = 1f, energy_ec = 4, energy_max = 1000, energy_re = 1f };
        public static Skill[] all_skill = new Skill[] { skill_shiled };
#endregion

#region power dispose
        public readonly static Power[] allpower = new Power[]
        {
            new Power() {energy=100 }
        };
        #endregion

        #region bullet
        public static BulletPropertyEx b_missile = new BulletPropertyEx()
        {
            edgepoints = new Point2[] { new Point2(-0.109375f, 0.75f),
            new Point2(-0.1171875f, -0.2265625f),
            new Point2(0.1171875f, -0.2265625f),
            new Point2(0.109375f, 0.75f) },
            uv_rect = new Point2[] { new Point2(-0.25f, -1f),
            new Point2(-0.25f, 1f),
            new Point2(0.25f, 1f),
            new Point2(0.25f, -1f) },
            t_uv = uv_def_1x1,
            offset = true, penetrate = true,
            mat_name = mat_missile,
            attack = 1000,
            move = BulletMoveEx.Missile,
            collision = GameControl.CollisionCore,
            maxrange = 2f,minrange=0.02f
        
        };
        public static BulletPropertyEx b_missile01 = new BulletPropertyEx()
        {
            edgepoints = p_b_missile01,
            uv_rect = p_b_missile01,
            t_uv = uv_def_1x1,
            mat_name = mat_missile01,
            attack = 25,
            move = BulletMoveEx.B_DownWord,
            collision = GameControl.CollisionCore,
            maxrange = 1f,
            minrange = 0.02f,
            speed = 0.008f
        };
        public static BulletPropertyEx b_laser2 = new BulletPropertyEx()
        {
            calcul = ThunderMod.CaculLaser02,
            up_img = ThunderMod.Laser02_update,
            mat_name = mat_b_ls02,
            t_uv = t_uv_laser02,
            attack = 100,
        };
        public static BulletPropertyEx b_laser4 = new BulletPropertyEx()
        {
            calcul = ThunderMod.CaculLaser04,
            up_img = ThunderMod.Laser04_update,
            mat_name = mat_b_ls04,
            attack = 100,
        };
        public static BulletPropertyEx b_def_b3 = new BulletPropertyEx()
        {
            mat_name = mat_b_b02,
            t_uv = uv_def_4x2[0], uv_rect = uv_64x64,
            collision = ThunderMod.Collision,
            radius = 0.094f,
            maxrange = 0.017f,
            minrange = 0.017f,
            attack = 30,
            speed = 0.001f
        };
        public static BulletPropertyEx b_def_b03b = new BulletPropertyEx()
        {
            mat_name = mat_b_a03,
            collision = ThunderMod.Collision,
            t_uv = uv_def_1x1,
            uv_rect = p_r_b03,
            maxrange = 0.222f,
            minrange = 0.022f,
            attack = 32,
            edgepoints = p_e_b03,
            speed = 0.0015f
        };
        public static BulletPropertyEx b_def_b04 = new BulletPropertyEx()
        {
            mat_name = mat_b_b04,
            collision = ThunderMod.Collision,
            maxrange = 0.0835f,
            minrange = 0.03f,
            attack = 33,
            uv_rect = p_r_b04,
            t_uv = uv_def_3x1[0],
            edgepoints = p_e_b04,
            speed = 0.006f
        };
        public static BulletPropertyEx b_bigblueboll = new BulletPropertyEx()
        {
            penetrate = true,
            collision = GameControl.CollisionCore,
            radius = 0.5f, play = BulletMoveEx.Play_6_1, uv_rect = uv_128x128, t_uv = uv_def_3x2[0],
            maxrange = 0.2581f,
            minrange = 0.2581f,
            attack = 100,
            speed = 0.002f,
            mat_name = mat_b_tb01
        };
        #endregion

        #region plane bullet
        public static BulletPropertyEx b_hit = new BulletPropertyEx()
        {
            mat_name=mat_hit,
            uv_rect=uv_64x64,calcul=ThunderMod.CalculCollision
        };
        public static BulletPropertyEx b_chain = new BulletPropertyEx()
        {
            mat_name = mat_b_chain,
            t_uv = uv_def_1x1, calcul = ThunderMod.Chain_Calcul, inital = ThunderMod.Chain_Initial,
            uv_rect = new Point2[] { new Point2(154f, 0.5799828f), new Point2(26f, 0.5799828f), new Point2(334f, 0.5799828f), new Point2(206f, 0.5799828f) },
            attack = 30,
            speed = 0.01f
        };
        public static BulletPropertyEx b_thunder = new BulletPropertyEx()
        {
            collision = GameControl.CollisionEnemy,
            mat_name = mat_b_tb,
            uv_rect = uv_128x128,
            t_uv = uv_def_4x4[0],
            play = BulletMoveEx.Play_Def16,
            radius = 0.3f,
            maxrange = 1.2f,
            minrange = 0.1f,
            attack = 300,
            speed = 0.015f,
            move = BulletMoveEx.B_LockEnemy
        };
        static Point2[] pbl = new Point2[]{
               new Point2(-0.390625f,0f), new Point2(-0.390625f,10f),
               new Point2(0.390625f,10f), new Point2(0.390625f,0f) };
        public static BulletPropertyEx b_laser = new BulletPropertyEx()
        {
            mat_name = mat_b_ls05,
            collision = GameControl.CollisionEnemy,
            play = BulletMoveEx.Play_7_1, offset = true,
            uv_rect = pbl,
            t_uv = new Vector2[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(0.14285f, 1), new Vector2(0.14285f, 0) },
            edgepoints = pbl,
            maxrange = 20f,
            minrange = 0.8f,
            attack = 20, penetrate = true,
            move = BulletMoveEx.B_Laser_level1
        };
        public static BulletPropertyEx b_z_zhzd = new BulletPropertyEx()
        {
            attack = 20,
            collision = GameControl.CollisionEnemy,
            mat_name = mat_b_zhihui,
            edgepoints = e_w_zhihui,
            t_uv = uv_zhihui[1],
            uv_rect = p_zhihui[1],
            maxrange = 5,
            minrange = 0.5f,
            speed = 0.013f
        };
        public static BulletPropertyEx b_laser_r = new BulletPropertyEx()
        {
            mat_name = mat_b_ls01,
            t_uv = new Vector2[] { new Vector2(0.248f, 0.02472528f),
            new Vector2(0.248f, 0.9917582f),
            new Vector2(0.404f, 0.9917582f),
            new Vector2(0.404f, 0.02472528f) },
            edgepoints = new Point2[]{
               new Point2(-0.44f,0f), new Point2(-0.44f,10f),
               new Point2(0.44f,10f), new Point2(0.44f,0f) },
            calcul = ThunderMod.Laser_Calculate, inital = ThunderMod.Laser_Initial, dispose = ThunderMod.Laser_Dispose,
            up_img = ThunderMod.Laser_Update,
            maxrange = 1.6f,
            attack = 30,
        };
        public static BulletPropertyEx b_laser_w = new BulletPropertyEx()
        {
            //calcul=ThunderMod.Laser_Calculate,
            calcul = ThunderMod.ra2l_calcul, inital = ThunderMod.ra2l_Initial,
            up_img = ThunderMod.Updatera2l,
            attack = 200,
            mat_name = mat_b_ls03
        };

        public static BulletPropertyEx b_zhuji = new BulletPropertyEx()
        {
            collision = GameControl.CollisionEnemy,
            mat_name = mat_b_zhuji,
            edgepoints = new Point2[] { new Point2(0, 0.8277818f), new Point2(348, 0.57f), new Point2(180, 0.707f), new Point2(12, 0.57f) },
            maxrange = 5f,
            minrange = 0.5f,
            attack = 20,
            speed = 0.01f
        };
#endregion

#region warplane dispose
        static void lc_nuhuo(ref WarPlane wp, ref BulletPropertyEx bpe, int level)
        {
            if (level == 0)
            {
                wp.shotfrequency = 140;
                bpe.speed = 0.013f;

            } else if (level == 1)
            {
                wp.shotfrequency = 120;
                bpe.speed = 0.015f;
            } else if (level == 2)
            {
                wp.shotfrequency = 100;
                bpe.speed = 0.02f;
            }
            else
            {
                wp.shotfrequency = 60;
                bpe.speed = 0.03f;
            }
        }
        public static WarPlane plane_nuhuo = new WarPlane()
        {
            gold = 100,
            blood = 1000,
            currentblood = 1000,
            bpe = b_zhuji, shotfrequency = 140,
            //t_uv=uv_def_1x1,
            mat_name = mat_nouhuo,
            shot = ShotBullet.Shot_zhuji, animat = true,
            lc = lc_nuhuo, abe = Ani.nh
        };
        static void lc_zhihui(ref WarPlane wp, ref BulletPropertyEx bpe, int level)
        {
            switch (level)
            {
                case 1:
                    wp.shot = ShotBullet.Scatter_level2;
                    wp.shotfrequency = 110;
                    bpe.speed = 0.018f;
                    break;
                case 2:
                    wp.shot = ShotBullet.Scatter_level3;
                    wp.shotfrequency = 100;
                    bpe.speed = 0.02f;
                    break;
                case 3:
                    wp.shot = ShotBullet.Scatter_level4;
                    wp.shotfrequency = 60;
                    bpe.speed = 0.025f;
                    break;
                default:
                    wp.shot = ShotBullet.Scatter_level2;
                    wp.shotfrequency = 120;
                    bpe.speed = 0.016f;
                    break;
            }
        }
        public static WarPlane plane_zhihui = new WarPlane()
        {
            gold = 100, lc = lc_zhihui,
            blood = 1000, currentblood = 1000, bpe = b_z_zhzd, mat_name = mat_zhihui,
            animat = true, abe = Ani.zhh,
            shot = ShotBullet.Scatter_level2, shotfrequency = 140
        };
        static void lc_jifeng(ref WarPlane wp, ref BulletPropertyEx bpe, int level)
        {
            if (level == 3)
            {
                bpe.edgepoints[0].x = -0.64f;
                bpe.edgepoints[1].x = -0.64f;
                bpe.edgepoints[2].x = 0.64f;
                bpe.edgepoints[3].x = 0.64f;
                bpe.attack = 60;
            }
            else
            {
                bpe.edgepoints[0].x = -0.44f;
                bpe.edgepoints[1].x = -0.44f;
                bpe.edgepoints[2].x = 0.44f;
                bpe.edgepoints[3].x = 0.44f;
                bpe.attack = 30;
            }
        }
        public static WarPlane plane_jifeng = new WarPlane()
        {
            gold = 100,
            blood = 1000,
            currentblood = 1000,
            bpe = b_laser_r, shot = ThunderMod.Laser_shot,
            mat_name = mat_jifeng, animat = true,
            abe = Ani.jf, lc = lc_jifeng
        };
        public static WarPlane[] Plane_all = new WarPlane[] { plane_nuhuo, plane_jifeng, plane_zhihui };
#endregion

#region  second weapon dispose
        static void lc_chain(ref SecondBullet sb, ref BulletPropertyEx bpe, int level)
        {
            switch (level)
            {
                case 1:
                    sb.shotfrequency = 150;
                    bpe.speed = 0.012f;
                    break;
                case 2:
                    sb.shotfrequency = 120;
                    bpe.speed = 0.013f;
                    break;
                case 3:
                    sb.shotfrequency = 100;
                    bpe.speed = 0.015f;
                    break;
                default:
                    sb.shotfrequency = 180;
                    bpe.speed = 0.01f;
                    break;
            }
        }
        public static SecondBullet SB_Chain = new SecondBullet()
        {
            lc = lc_chain,
            gold = 100,
            shotfrequency = 180,
            shot = ThunderMod.Chain_Shot,
            bpe = b_chain
        };
        static void lc_thuder(ref SecondBullet sb, ref BulletPropertyEx bpe, int level)
        {
            switch (level)
            {
                case 1:
                    sb.shot = ShotBullet.Thunder_level2;
                    sb.shotfrequency = 800;
                    bpe.speed = 0.018f;
                    break;
                case 2:
                    sb.shot = ShotBullet.Thunder_level3;
                    sb.shotfrequency = 600;
                    bpe.speed = 0.02f;
                    break;
                case 3:
                    sb.shot = ShotBullet.Thunder_level4;
                    sb.shotfrequency = 400;
                    bpe.speed = 0.023f;
                    break;
                default:
                    sb.shot = ShotBullet.Thunder_level1;
                    sb.shotfrequency = 1000;
                    bpe.speed = 0.015f;
                    break;
            }
        }
        public static SecondBullet SB_Thunder = new SecondBullet()
        {
            lc = lc_thuder,
            gold = 100, shotfrequency = 800,
            shot = ShotBullet.Thunder_level1,
            bpe = b_thunder
        };
        public static SecondBullet[] SB_all = new SecondBullet[] { SB_Thunder, SB_Chain, };
#endregion

#region wing dispose
        public static Wing W_laser = new Wing()
        { gold = 100,
            mat_name = mat_w_02a,
            shot = ShotBullet.Laser_level1, bpe = b_laser, shotfrequency = 3000, abe = Ani.w_gc
        };
        public static Wing W_laserra2 = new Wing()
        {
            gold = 100, shotfrequency = 3000, shot = ThunderMod.ra2l_shot,
            animat = true, abe = Ani.w_ra2l, mat_name = mat_w_jf,
            bpe = b_laser_w, update = ThunderMod.wing_up2
        };
        public readonly static Wing[] Wing_all = new Wing[] { W_laser, W_laserra2, };
#endregion

#region shiled dispose
        static Shiled S_d = new Shiled { gold = 1000, max = 100, defence = 5, resume = 0.3f, imgpath = "Picture/d" };
        static Shiled S_c = new Shiled { gold = 2000, max = 110, defence = 6, resume = 0.32f, imgpath = "Picture/c" };
        static Shiled S_b = new Shiled { gold = 3000, max = 120, defence = 7, resume = 0.34f, imgpath = "Picture/b" };
        static Shiled S_a = new Shiled { gold = 4000, max = 130, defence = 8, resume = 0.36f, imgpath = "Picture/a" };
        static Shiled S_s = new Shiled { gold = 5000, max = 150, defence = 10, resume = 0.4f, imgpath = "Picture/s" };
        public readonly static Shiled[] Shiled_all = new Shiled[] { S_d, S_c, S_b, S_a, S_s };
        #endregion

        #region enemy_a dispose
        public static EnemyPropertyEX Boss_Huijin = new EnemyPropertyEX()
        {
            enemy = new EnemyBaseEX()
            {
                score = 300,
                boss = true,
                f_blood = 60000,
                defance = 10,
                minrange = 1f,
                maxrange = 3,points_style=1,
                points = p_hjA,
                animat = true,
                abe = Ani.huijin,
                mat_name = mat_e_hj,
                move=ThunderMod.M_huijin
            }
        };
        public static EnemyPropertyEX Boss_Moth = new EnemyPropertyEX()
        {
            enemy = new EnemyBaseEX()
            {
                move=ThunderMod.M_Moth,
                score=300,
                boss = true,
                f_blood = 60000,
                defance = 10,
                minrange = 1f,
                maxrange = 3,
                points = p_mothA,
                animat = true,
                abe = Ani.moth,
                mat_name = mat_e_moth
            }
        };
        public static EnemyPropertyEX e_a10 = new EnemyPropertyEX()
        {
            //image = new ImageProperty() { scale = def_scale, imagepath = enemy_a10 },
            enemy = new EnemyBaseEX()
            {
                score=100,
                mat_name = mat_e_a10,
                vertexs = new Vector3[] { new Vector3(-1.3f, -1.3f), new Vector3(-1.3f, 1.3f), new Vector3(1.3f, 1.3f), new Vector3(1.3f, -1.3f) },
                uv = uv_def_1x1,
                triangle = tri_def,
                f_blood = 40000,
                boss = true,
                defance = 9,
                minrange = 1f,
                maxrange = 3,
                points = p_a10,
                move= ThunderMod.M_a10
            }
        };
        public static EnemyPropertyEX e_bee = new EnemyPropertyEX()
        {
            //image = new ImageProperty() { scale = def_scale, imagepath = enemy_a10 },
            enemy = new EnemyBaseEX()
            {
                score = 100,
                mat_name = mat_e_bee,
                vertexs = new Vector3[] { new Vector3(-1.3f, -1.3f), new Vector3(-1.3f, 1.3f), new Vector3(1.3f, 1.3f), new Vector3(1.3f, -1.3f) },
                uv = uv_def_1x1,
                triangle = tri_def,
                f_blood = 40000,
                boss = true,
                defance = 9,
                minrange = 1f,
                maxrange = 3,
                points = p_a10,
                move= ThunderMod.M_bee
            }
        };
        public static EnemyPropertyEX e_def_a00 = new EnemyPropertyEX()
        {
            enemy = new EnemyBaseEX()
            {
                score=4,
                mat_name = mat_e_a00,
                uv = uv_def_4x2[0],
                triangle = tri_def,
                vertexs = new Vector3[] { new Vector3(-1, -1), new Vector3(-1, 1), new Vector3(1, 1), new Vector3(1, -1) },
                points = e_a_edge[0],
                f_blood = 1500, show_blood = true,
                defance = 5,
                minrange = 0.3f,
                maxrange = 2,
            }
        };
        public static EnemyPropertyEX e_meteor = new EnemyPropertyEX()
        {
            //image = new ImageProperty() { scale = def_scale, imagepath = "Picture/meteor" },
            enemy = new EnemyBaseEX()
            {
                score = 5,
                mat_name = mat_e_met,
                uv = uv_def_1x1,
                triangle = tri_def,
                vertexs = new Vector3[] { new Vector3(-0.453125f,-0.71875f),new Vector3(-0.453125f,0.71875f),
                    new Vector3(0.453125f,0.71875f),new Vector3(0.453125f,-0.71875f) },
                f_blood = 3000, show_blood = true,
                defance = 10,
                minrange = 0.3f,
                maxrange = 2, points_style = 1,
                points = points_meteor,
                move=EnemyMove.M_Downward_NoStop
            }
        };
#endregion

#region enemy_b dispose
        public static EnemyPropertyEX e_def_b00 = new EnemyPropertyEX()
        {
            //image = new ImageProperty() { scale = def_scale, imagepath = enemy_b, grid = def_4x3 },
            bpe = new BulletPropertyEx[] { b_def_b03b },
            enemy = new EnemyBaseEX()
            {
                score=3,
                mat_name = mat_e_b00,
                uv = uv_def_4x3[0],
                vertexs = new Vector3[] {new Vector3(-0.666992f,-0.598958f),new Vector3(-0.666992f,0.598958f),
                    new Vector3(0.666992f,0.598958f),new Vector3(0.666992f,-0.598958f) },
                triangle = tri_def,
                f_blood = 1000,
                show_blood = true,
                defance = 5,
                minrange = 0.3f,
                maxrange = 2,
                points = e_b_edge[0]
            }
        };
#endregion

#region Battelfiled
        static Action[] SetLevelModMain = new Action[] { SL_M_1 , SL_M_2 , SL_M_3 , SL_M_4 , SL_M_5,SL_M_6 ,SL_M_7, SL_M_8 };
        static SetBattelField[] SetLevelModSub = new SetBattelField[] { SetLevel1, SetLevel2, SetLevel3, SetLevel4, SetLevel5, SetLevel6, SetLevel7,
        SetLevel8,SetLevel9,SetLevel10,};
        static int index_s;
        public static void GetLevel(int index)
        {
            index_s = index;
            SetLevelModMain[index]();
            AsyncManage.AsyncDelegate(() => {
                GameControl.SetLevel(SetLevelModSub[index_s]);
            });
        }
        static void SL_M_1()//set level main 01
        {
            QueueSourceEX.RegMatA(e_def_b00.enemy.mat_name, ref e_def_b00.enemy.mat_id);
            QueueSourceEX.RegMatA(b_def_b03b.mat_name, ref b_def_b03b.mat_id);
        }
        static void SetLevel1(ref BattelField bf)
        {
            BulletPropertyEx[] bp1 = new BulletPropertyEx[] { b_def_b03b };
            BulletPropertyEx[] bp2 = new BulletPropertyEx[] { b_def_b03b };
            bp2[0].speed = 0.003f;
            BulletPropertyEx[] bp_diamond = new BulletPropertyEx[] { b_def_b03b };
            bp_diamond[0].move = BulletMoveEx.B_Diamond;
            EnemyPropertyEX e1 = e_def_b00;
            EnemyPropertyEX e2 = e_meteor;
            bf.wave.Clear();
            bf.level = 1;
            EnemyWave ew = new EnemyWave();
            ew.enemyppt = e1;
            ew.enemyppt.enemy.move = EnemyMove.M_Dock_200;
            ew.enemyppt.bpe = bp_diamond;
            ew.enemyppt.enemy.shot = ShotBullet.Diamond;
            ew.enemyppt.enemy.shotfrequency = 500;//500
            ew.enemyppt.bpe[0].move = BulletMoveEx.B_Diamond;
            ew.start = S_Dwon_2;
            ew.sum = 2;
            ew.staytime = 50;
            bf.wave.Add(ew);
            ew.enemyppt.bpe = bp1;
            ew.enemyppt.enemy.move = EnemyMove.M_Dock_180;
            ew.enemyppt.enemy.shot = ShotBullet.ThreeBeline10;
            ew.enemyppt.enemy.shotfrequency = 150;
            ew.start = S_Up_3;
            ew.sum = 1;
            ew.staytime = 200;
            bf.wave.Add(ew);
            ew.enemyppt.enemy.move = EnemyMove.M_Dock_200;
            ew.enemyppt.enemy.shot = ShotBullet.Down_Arc3;
            ew.enemyppt.enemy.shotfrequency = 600;
            ew.enemyppt.bpe = bp2;
            bf.wave.Add(ew);
            ew = bf.wave[0];
            bf.wave.Add(ew);
            ew.enemyppt.enemy.uv = uv_def_4x3[2];
            ew.enemyppt.enemy.points = e_b_edge[1];
            ew.enemyppt.enemy.shot = ShotBullet.Down_Arc3;
            ew.enemyppt.bpe = bp1;
            ew.start = S_Dwon_3;
            ew.sum = 3;
            ew.staytime = 500;
            bf.wave.Add(ew);
            ew.enemyppt.bpe = bp2;
            ew.enemyppt.enemy.shot = ShotBullet.Aim_12;
            ew.enemyppt.enemy.move = EnemyMove.M_Downward_NoStop;
            ew.enemyppt.enemy.shotfrequency = 600;
            ew.staytime = 500;
            bf.wave.Add(ew);
            ew.enemyppt = e2;
            ew.enemyppt.enemy.move = EnemyMove.M_Downward_NoStop;
            ew.start = S_Up_3;
            ew.sum = 1;
            ew.staytime = 0;
            bf.wave.Add(ew);
            ew = bf.wave[2];
            ew.enemyppt.enemy.move = EnemyMove.M_Downward_NoStop;
            ew.enemyppt.enemy.shot = ShotBullet.Down_Arc3;
            ew.enemyppt.bpe = bp2;
            ew.start = S_RandomDown_1();
            ew.sum = 1;
            ew.staytime = 50;
            bf.wave.Add(ew);
            ew.start = S_RandomDown_1();
            bf.wave.Add(ew);
            ew.start = S_RandomDown_1();
            bf.wave.Add(ew);
            ew.start = S_RandomDown_1();
            bf.wave.Add(ew);
            ew.enemyppt.enemy.move = EnemyMove.M_LeftArc;
            ew.enemyppt.enemy.shot = ShotBullet.Aim_12;
            ew.start = S_Left_1;
            ew.sum = 1;
            ew.staytime = 50;
            bf.wave.Add(ew);
            ew.enemyppt.enemy.move = EnemyMove.M_RightArc;
            ew.enemyppt.enemy.shot = ShotBullet.Aim_12;
            ew.start = S_Right_1;
            ew.sum = 1;
            ew.staytime = 50;
            bf.wave.Add(ew);
            ew.enemyppt = e2;
            ew.enemyppt.enemy.move = EnemyMove.M_Downward_NoStop;
            ew.start = S_Dwon_3;
            ew.sum = 3;
            ew.staytime = 0;
            bf.wave.Add(ew);
            ew = bf.wave[1];
            ew.enemyppt.bpe = bp2;
            ew.enemyppt.enemy.move = EnemyMove.M_Dock_180;
            ew.enemyppt.enemy.shot = ShotBullet.Down_Arc3;
            ew.start = S_Up_3;
            ew.sum = 1;
            ew.staytime = 200;
            bf.wave.Add(ew);
            ew.enemyppt = e2;
            ew.enemyppt.enemy.move = EnemyMove.M_Downward_NoStop;
            ew.start = S_Up_1;
            ew.sum = 1;
            ew.staytime = 300;
            bf.wave.Add(ew);
            bf.wave.Add(bf.wave[0]);
            bf.wave.Add(bf.wave[1]);
            bf.wave.Add(bf.wave[3]);
            bf.wave.Add(bf.wave[5]);
            bf.wave.Add(bf.wave[11]);
            bf.wave.Add(bf.wave[9]);
            bf.wave.Add(bf.wave[2]);
            bf.wave.Add(bf.wave[12]);
            bf.wave.Add(bf.wave[7]);
            bf.wave.Add(bf.wave[8]);
            bf.wave.Add(bf.wave[4]);
            bf.wave.Add(bf.wave[11]);
            bf.wave.Add(bf.wave[14]);
            bf.wave.Add(bf.wave[3]);
            bf.wave.Add(bf.wave[7]);
            bf.wave.Add(bf.wave[8]);
            bf.wave.Add(bf.wave[9]);
            bf.wave.Add(bf.wave[10]);
            bf.wave.Add(bf.wave[2]);
            bf.wave.Add(bf.wave[12]);
            bf.wave.Add(bf.wave[6]);
            ew.staytime = 2000;
            bf.wave.Add(ew);
        }
        static void SL_M_2()
        {
            QueueSourceEX.RegMatA(e_def_b00.enemy.mat_name, ref e_def_b00.enemy.mat_id);
            QueueSourceEX.RegMatA(b_def_b03b.mat_name, ref b_def_b03b.mat_id);
            QueueSourceEX.RegMatA(e_a10.enemy.mat_name, ref e_a10.enemy.mat_id);
            QueueSourceEX.RegMatA(b_def_b04.mat_name, ref b_def_b04.mat_id);
            QueueSourceEX.RegMatA(b_bigblueboll.mat_name, ref b_bigblueboll.mat_id);
        }
        static void SetLevel2(ref BattelField bf)
        {
            BulletPropertyEx[] bp1 = new BulletPropertyEx[] { b_def_b03b };
            BulletPropertyEx[] bp2 = new BulletPropertyEx[] { b_def_b03b };
            BulletPropertyEx[] bp_diamond = new BulletPropertyEx[] { b_def_b03b };
            bp_diamond[0].move = BulletMoveEx.B_Diamond;
            BulletPropertyEx[] bboss = new BulletPropertyEx[] { b_def_b03b, b_def_b03b, b_bigblueboll, b_def_b04 };
            bboss[0].speed = 0.003f;
            bboss[1].speed = 0.003f;
            bp2[0].speed = 0.002f;

            EnemyPropertyEX e1 =  e_def_b00;
            EnemyPropertyEX e2 =  e_meteor;
            EnemyPropertyEX e3 =  e_a10;
            bf.wave.Clear();
            bf.level = 2;
            EnemyWave ew = new EnemyWave();
            ew.enemyppt = e1;
            ew.enemyppt.bpe = bp1;
            ew.enemyppt.enemy.move = EnemyMove.M_Dock_180;
            ew.enemyppt.enemy.shot = ShotBullet.ThreeBeline10;
            ew.enemyppt.enemy.shotfrequency = 150;
            ew.start = S_Up_3;
            ew.sum = 1;
            ew.staytime = 200;
            bf.wave.Add(ew);
            ew.enemyppt.enemy.move = EnemyMove.M_Dock_200;
            ew.enemyppt.enemy.shot = ShotBullet.Down_Arc3;
            ew.enemyppt.enemy.shotfrequency = 600;
            ew.enemyppt.bpe = bp2;
            bf.wave.Add(ew);
            ew = bf.wave[0];
            bf.wave.Add(ew);
            ew.enemyppt.enemy.uv = uv_def_4x3[2];
            ew.enemyppt.enemy.points = e_b_edge[1];
            ew.enemyppt.enemy.shot = ShotBullet.Down_Arc3;
            ew.enemyppt.bpe = bp1;
            ew.start = S_Dwon_3;
            ew.sum = 3;
            ew.staytime = 500;
            bf.wave.Add(ew);
            ew.enemyppt.bpe = bp2;
            ew.enemyppt.enemy.shot = ShotBullet.Aim_12;
            ew.enemyppt.enemy.move = EnemyMove.M_Downward_NoStop;
            ew.enemyppt.enemy.shotfrequency = 600;
            ew.staytime = 500;
            bf.wave.Add(ew);
            ew.enemyppt = e2;
            ew.enemyppt.enemy.move = EnemyMove.M_Downward_NoStop;
            ew.start = S_Up_3;
            ew.sum = 1;
            ew.staytime = 0;
            bf.wave.Add(ew);
            ew = bf.wave[2];
            ew.enemyppt.enemy.move = EnemyMove.M_Downward_NoStop;
            ew.enemyppt.enemy.shot = ShotBullet.Down_Arc3;
            ew.enemyppt.bpe = bp2;
            ew.start = S_RandomDown_1();
            ew.sum = 1;
            ew.staytime = 50;
            bf.wave.Add(ew);
            ew.start = S_RandomDown_1();
            bf.wave.Add(ew);
            ew.start = S_RandomDown_1();
            bf.wave.Add(ew);
            ew.start = S_RandomDown_1();
            bf.wave.Add(ew);
            ew.enemyppt.enemy.move = EnemyMove.M_LeftArc;
            ew.enemyppt.enemy.shot = ShotBullet.Aim_12;
            ew.start = S_Left_1;
            ew.sum = 1;
            ew.staytime = 50;
            bf.wave.Add(ew);
            ew.enemyppt.enemy.move = EnemyMove.M_RightArc;
            ew.enemyppt.enemy.shot = ShotBullet.Aim_12;
            ew.start = S_Right_1;
            ew.sum = 1;
            ew.staytime = 50;
            bf.wave.Add(ew);
            ew.enemyppt = e2;
            ew.enemyppt.enemy.move = EnemyMove.M_Downward_NoStop;
            ew.start = S_Dwon_3;
            ew.sum = 3;
            ew.staytime = 0;
            bf.wave.Add(ew);
            ew = bf.wave[1];
            ew.enemyppt.bpe = bp2;
            ew.enemyppt.enemy.move = EnemyMove.M_Dock_180;
            ew.enemyppt.enemy.shot = ShotBullet.Down_Arc3;
            ew.start = S_Up_3;
            ew.sum = 1;
            ew.staytime = 200;
            bf.wave.Add(ew);
            ew.enemyppt = e2;
            ew.enemyppt.enemy.move = EnemyMove.M_Downward_NoStop;
            ew.start = S_Up_1;
            ew.sum = 1;
            ew.staytime = 300;
            bf.wave.Add(ew);
            bf.wave.Add(bf.wave[8]);
            bf.wave.Add(bf.wave[4]);
            bf.wave.Add(bf.wave[11]);
            bf.wave.Add(bf.wave[14]);
            bf.wave.Add(bf.wave[3]);
            bf.wave.Add(bf.wave[7]);
            bf.wave.Add(bf.wave[9]);
            bf.wave.Add(bf.wave[2]);
            bf.wave.Add(bf.wave[12]);
            bf.wave.Add(bf.wave[7]);
            bf.wave.Add(bf.wave[8]);
            bf.wave.Add(bf.wave[9]);
            bf.wave.Add(bf.wave[10]);
            bf.wave.Add(bf.wave[0]);
            bf.wave.Add(bf.wave[1]);
            bf.wave.Add(bf.wave[3]);
            bf.wave.Add(bf.wave[5]);
            bf.wave.Add(bf.wave[11]);
            bf.wave.Add(bf.wave[2]);
            bf.wave.Add(bf.wave[12]);
            bf.wave.Add(bf.wave[6]);
            ew.staytime = 200;
            bf.wave.Add(ew);
            ew.enemyppt = e3;
            ew.enemyppt.bpe = bboss;
            ew.start = S_Up_3;
            ew.sum = 1;
            ew.staytime = 50;
            bf.wave.Add(ew);

        }
        static void SL_M_3()
        {
            QueueSourceEX.RegMatA(e_def_b00.enemy.mat_name, ref e_def_b00.enemy.mat_id);
            QueueSourceEX.RegMatA(b_def_b03b.mat_name, ref b_def_b03b.mat_id);
        }
        static void SetLevel3(ref BattelField bf)
        {
            //bf.bk_groud = new BackGround[] { new BackGround() { dur_wave = 999999, imgpath="Picture/cosmos" } };
            //b_def_b03b, b_def_b04y, b_def_reddiamond 注册需要的资源让主线程去加载
            //e_meteor.enemy.mat_id = QueueSourceEX.RegMat(e_meteor.enemy.mat_name);
            //e_def_b00.enemy.mat_id = QueueSourceEX.RegMat(e_def_b00.enemy.mat_name);
            //b_def_b03b.mat_id = QueueSourceEX.RegMat(b_def_b03b.mat_name);

            //
            BulletPropertyEx[] bp1 = new BulletPropertyEx[] { b_def_b03b };
            BulletPropertyEx[] bp2 = new BulletPropertyEx[] { b_def_b03b };
            bp2[0].speed = 0.003f;
            BulletPropertyEx[] bp_diamond = new BulletPropertyEx[] { b_def_b03b };
            bp_diamond[0].move = BulletMoveEx.B_Diamond;
            EnemyPropertyEX e1 = e_def_b00;
            EnemyPropertyEX e2 = e_meteor;
            bf.wave.Clear();
            bf.level = 3;
            EnemyWave ew = new EnemyWave();
            ew.enemyppt = e1;
            ew.enemyppt.enemy.uv = uv_def_4x3[4];
            ew.enemyppt.enemy.points = e_b_edge[2];
            ew.enemyppt.enemy.move = EnemyMove.M_Dock_200;
            ew.enemyppt.bpe = bp_diamond;
            ew.enemyppt.enemy.shot = ShotBullet.Diamond;
            ew.enemyppt.enemy.shotfrequency = 400;
            ew.enemyppt.bpe[0].move = BulletMoveEx.B_Diamond;
            ew.start = S_Dwon_2;
            ew.sum = 2;
            ew.staytime = 50;
            bf.wave.Add(ew);
            ew.enemyppt.bpe = bp1;
            ew.enemyppt.enemy.move = EnemyMove.M_Dock_180;
            ew.enemyppt.enemy.shot = ShotBullet.ThreeBeline10;
            ew.enemyppt.enemy.shotfrequency = 100;
            ew.start = S_Up_3;
            ew.sum = 1;
            ew.staytime = 200;
            bf.wave.Add(ew);
            ew.enemyppt.enemy.move = EnemyMove.M_Dock_200;
            ew.enemyppt.enemy.shot = ShotBullet.Down_Arc3;
            ew.enemyppt.enemy.shotfrequency = 400;
            ew.enemyppt.bpe = bp2;
            bf.wave.Add(ew);
            ew = bf.wave[0];
            bf.wave.Add(ew);
            ew.enemyppt.enemy.uv = uv_def_4x3[5];
            ew.enemyppt.enemy.points = e_b_edge[2];
            ew.enemyppt.enemy.shot = ShotBullet.Circle36A;
            ew.enemyppt.enemy.shotfrequency = 1200;
            ew.enemyppt.bpe = bp1;
            ew.start = S_Dwon_3;
            ew.sum = 3;
            ew.staytime = 500;
            bf.wave.Add(ew);
            ew.enemyppt.bpe = bp2;
            ew.enemyppt.enemy.shot = ShotBullet.Aim_12;
            ew.enemyppt.enemy.move = EnemyMove.M_Downward_NoStop;
            ew.enemyppt.enemy.shotfrequency = 400;
            ew.staytime = 500;
            bf.wave.Add(ew);
            ew.enemyppt = e2;
            ew.enemyppt.enemy.move = EnemyMove.M_Downward_NoStop;
            ew.start = S_Up_3;
            ew.sum = 1;
            ew.staytime = 0;
            bf.wave.Add(ew);
            ew = bf.wave[2];
            ew.enemyppt.enemy.move = EnemyMove.M_Downward_NoStop;
            ew.enemyppt.enemy.shot = ShotBullet.Downflowers;
            ew.enemyppt.bpe = bp2;
            ew.start = S_RandomDown_1();
            ew.sum = 1;
            ew.staytime = 50;
            bf.wave.Add(ew);
            ew.start = S_RandomDown_1();
            bf.wave.Add(ew);
            ew.start = S_RandomDown_1();
            bf.wave.Add(ew);
            ew.start = S_RandomDown_1();
            bf.wave.Add(ew);
            ew.enemyppt.enemy.uv = uv_def_4x3[6];
            ew.enemyppt.enemy.points = e_b_edge[3];
            ew.enemyppt.enemy.move = EnemyMove.M_LeftArc;
            ew.start = S_Left_1;
            ew.sum = 1;
            ew.staytime = 50;
            bf.wave.Add(ew);
            ew.enemyppt.enemy.move = EnemyMove.M_RightArc;
            ew.start = S_Right_1;
            ew.sum = 1;
            ew.staytime = 50;
            bf.wave.Add(ew);
            ew.enemyppt = e2;
            ew.enemyppt.enemy.move = EnemyMove.M_Downward_NoStop;
            ew.start = S_Dwon_3;
            ew.sum = 3;
            ew.staytime = 0;
            bf.wave.Add(ew);
            ew = bf.wave[1];
            ew.enemyppt.bpe = bp2;
            ew.enemyppt.enemy.uv = uv_def_4x3[7];
            ew.enemyppt.enemy.points = e_b_edge[3];
            ew.enemyppt.enemy.move = EnemyMove.M_Dock_180;
            ew.enemyppt.enemy.shot = ShotBullet.Down_Arc3;
            ew.start = S_Up_3;
            ew.sum = 1;
            ew.staytime = 200;
            bf.wave.Add(ew);
            ew.enemyppt = e2;
            ew.enemyppt.enemy.move = EnemyMove.M_Downward_NoStop;
            ew.start = S_Up_1;
            ew.sum = 1;
            ew.staytime = 300;
            bf.wave.Add(ew);
            bf.wave.Add(bf.wave[7]);
            bf.wave.Add(bf.wave[8]);
            bf.wave.Add(bf.wave[4]);
            bf.wave.Add(bf.wave[11]);
            bf.wave.Add(bf.wave[14]);
            bf.wave.Add(bf.wave[3]);
            bf.wave.Add(bf.wave[7]);
            bf.wave.Add(bf.wave[8]);
            bf.wave.Add(bf.wave[9]);
            bf.wave.Add(bf.wave[10]);
            bf.wave.Add(bf.wave[0]);
            bf.wave.Add(bf.wave[1]);
            bf.wave.Add(bf.wave[3]);
            bf.wave.Add(bf.wave[5]);
            bf.wave.Add(bf.wave[11]);
            bf.wave.Add(bf.wave[9]);
            bf.wave.Add(bf.wave[2]);
            bf.wave.Add(bf.wave[12]);
            bf.wave.Add(bf.wave[2]);
            bf.wave.Add(bf.wave[12]);
            bf.wave.Add(bf.wave[6]);
            ew.staytime = 2000;
            bf.wave.Add(ew);
        }
        static void SL_M_4()
        {
            QueueSourceEX.RegMatA(e_def_a00.enemy.mat_name,ref e_def_a00.enemy.mat_id);
            QueueSourceEX.RegMatA(e_def_b00.enemy.mat_name,ref e_def_b00.enemy.mat_id);
            QueueSourceEX.RegMatA(Boss_Moth.enemy.mat_name,ref Boss_Moth.enemy.mat_id);
            QueueSourceEX.RegMatA(b_def_b03b.mat_name,ref b_def_b03b.mat_id);
            QueueSourceEX.RegMatA(b_def_b04.mat_name,ref b_def_b04.mat_id);
            QueueSourceEX.RegMatA(b_def_b3.mat_name,ref b_def_b3.mat_id);
            QueueSourceEX.RegMatA(b_laser2.mat_name,ref b_laser2.mat_id);
        }
        static void SetLevel4(ref BattelField bf)
        {
            //bf.bk_groud = new BackGround[] { new BackGround() { dur_wave = 999999, imgpath="Picture/cosmos" } };
            //b_def_b03b, b_def_b04y, b_def_reddiamond, b_def_redlaser 注册需要的资源让主线程去加载
            //
            EnemyPropertyEX e1 =  e_def_a00;
            EnemyPropertyEX e2 =  e_meteor;
            EnemyPropertyEX e3 =  e_def_b00;
            e3.enemy.uv = uv_def_4x3[7];
            e3.enemy.points = e_b_edge[3];
            EnemyPropertyEX e4 =  Boss_Moth;
            BulletPropertyEx[] bp1 = new BulletPropertyEx[] { b_def_b03b };
            BulletPropertyEx[] bp2 = new BulletPropertyEx[] { b_def_b03b };
            bp2[0].speed = 0.003f;
            bf.wave.Clear();
            bf.level = 4;
            EnemyWave ew = new EnemyWave();

            ew.enemyppt = e1;
            ew.enemyppt.bpe= new BulletPropertyEx[] { b_def_b03b };
            ew.enemyppt.enemy.move = EnemyMove.M_Dock_200;
            ew.enemyppt.enemy.shot = ShotBullet.Diamond;
            ew.enemyppt.bpe[0].move = BulletMoveEx.B_Diamond;
            ew.enemyppt.enemy.shotfrequency = 400;
            ew.start = S_Dwon_2;
            ew.sum = 2;
            ew.staytime = 50;
            bf.wave.Add(ew);
            ew.enemyppt.bpe = bp1;
            ew.enemyppt.enemy.move = EnemyMove.M_Dock_180;
            ew.enemyppt.enemy.shot = ShotBullet.ThreeBeline10;
            ew.enemyppt.enemy.shotfrequency = 100;
            ew.start = S_Up_3;
            ew.sum = 1;
            ew.staytime = 200;
            bf.wave.Add(ew);
            ew.enemyppt.enemy.move = EnemyMove.M_Dock_200;
            ew.enemyppt.enemy.shot = ShotBullet.Down_Arc3;
            ew.enemyppt.bpe = bp2;
            ew.enemyppt.enemy.shotfrequency = 100;
            bf.wave.Add(ew);
            ew = bf.wave[1];
            bf.wave.Add(ew);
            ew = bf.wave[2];
            ew.enemyppt.enemy.move = EnemyMove.M_Dock_200;
            ew.enemyppt.enemy.shot = ShotBullet.Down_Arc3;
            ew.start = S_Dwon_3;
            ew.sum = 3;
            ew.staytime = 500;
            bf.wave.Add(ew);
            ew.enemyppt.enemy.move = EnemyMove.M_Downward_NoStop;
            ew.staytime = 500;
            bf.wave.Add(ew);
            ew.enemyppt=e2;
            ew.enemyppt.enemy.move = EnemyMove.M_Downward_NoStop;
            ew.start = S_Up_3;
            ew.sum = 1;
            ew.staytime = 50;
            bf.wave.Add(ew);
            ew.enemyppt = e1;
            ew.enemyppt.bpe = bp1;
            ew.enemyppt.enemy.move = EnemyMove.M_Downward_NoStop;
            ew.enemyppt.enemy.shot = ShotBullet.Angle6_Rotate;
            ew.enemyppt.enemy.shotfrequency = 100;
            ew.start = S_RandomDown_1();
            ew.sum = 1;
            ew.staytime = 50;
            bf.wave.Add(ew);
            ew.start = S_RandomDown_1();
            bf.wave.Add(ew);
            ew.start = S_RandomDown_1();
            bf.wave.Add(ew);
            ew.start = S_RandomDown_1();
            bf.wave.Add(ew);
            ew.enemyppt=e3;
            ew.enemyppt.bpe = bp2;
            ew.enemyppt.enemy.move = EnemyMove.M_LeftArc;
            ew.enemyppt.enemy.shot = ShotBullet.Aim_12;
            ew.enemyppt.enemy.shotfrequency = 300;
            ew.start = S_Left_1;
            ew.sum = 1;
            ew.staytime = 50;
            bf.wave.Add(ew);
            ew.enemyppt.enemy.move = EnemyMove.M_RightArc;
            ew.enemyppt.enemy.shot = ShotBullet.Aim_12;
            ew.start = S_Right_1;
            ew.sum = 1;
            ew.staytime = 50;
            bf.wave.Add(ew);
            ew.enemyppt=e2;
            ew.enemyppt.enemy.move = EnemyMove.M_Downward_NoStop;
            ew.start = S_Dwon_3;
            ew.sum = 3;
            ew.staytime = 0;
            bf.wave.Add(ew);
            ew.enemyppt=e1;
            ew.enemyppt.bpe = bp2;
            ew.enemyppt.enemy.move = EnemyMove.M_Dock_180;
            ew.enemyppt.enemy.shot = ShotBullet.Down_Arc3;
            ew.enemyppt.enemy.shotfrequency = 100;
            ew.start = S_Up_3;
            ew.sum = 1;
            ew.staytime = 200;
            bf.wave.Add(ew);
            ew.enemyppt=e2;
            ew.enemyppt.enemy.move = EnemyMove.M_Downward_NoStop;
            ew.start = S_Up_1;
            ew.sum = 1;
            ew.staytime = 300;
            bf.wave.Add(ew);
            bf.wave.Add(bf.wave[0]);
            bf.wave.Add(bf.wave[1]);
            bf.wave.Add(bf.wave[3]);
            bf.wave.Add(bf.wave[5]);
            bf.wave.Add(bf.wave[11]);
            bf.wave.Add(bf.wave[9]);
            bf.wave.Add(bf.wave[2]);
            bf.wave.Add(bf.wave[12]);
            bf.wave.Add(bf.wave[7]);
            bf.wave.Add(bf.wave[8]);
            bf.wave.Add(bf.wave[4]);
            bf.wave.Add(bf.wave[11]);
            bf.wave.Add(bf.wave[14]);
            bf.wave.Add(bf.wave[3]);
            bf.wave.Add(bf.wave[7]);
            bf.wave.Add(bf.wave[8]);
            bf.wave.Add(bf.wave[9]);
            bf.wave.Add(bf.wave[10]);
            bf.wave.Add(bf.wave[2]);
            bf.wave.Add(bf.wave[12]);
            bf.wave.Add(bf.wave[6]);
            ew.staytime = 500;
            bf.wave.Add(ew);
            ew.enemyppt=e4;//
            ew.enemyppt.bpe = new BulletPropertyEx[] { b_def_b03b, b_def_b03b, b_def_b04, b_def_b04, b_def_b3, b_laser2 };
            ew.enemyppt.bpe[0].speed = 0.003f;
            ew.start = S_Up_3;
            ew.sum = 1;
            ew.staytime = 20000;
            bf.wave.Add(ew);
        }
        static void SL_M_5()
        {
            QueueSourceEX.RegMatA(e_def_b00.enemy.mat_name, ref e_def_b00.enemy.mat_id);
            QueueSourceEX.RegMatA(b_def_b03b.mat_name, ref b_def_b03b.mat_id);
        }
        static void SetLevel5(ref BattelField bf)
        {
            BulletPropertyEx[] bp1 = new BulletPropertyEx[] { b_def_b03b };
            BulletPropertyEx[] bp2 = new BulletPropertyEx[] { b_def_b03b };
            bp2[0].speed = 0.003f;
            BulletPropertyEx[] bp_diamond = new BulletPropertyEx[] { b_def_b03b };
            bp_diamond[0].move = BulletMoveEx.B_Diamond;
            EnemyPropertyEX e1 = e_def_b00;
            EnemyPropertyEX e2 =  e_meteor;
            bf.wave.Clear();
            bf.level = 5;
            EnemyWave ew = new EnemyWave();
            ew.enemyppt = e1;
            ew.enemyppt.enemy.uv = uv_def_4x3[4];
            ew.enemyppt.enemy.points = e_b_edge[2];
            ew.enemyppt.enemy.move = EnemyMove.M_Dock_200;
            ew.enemyppt.bpe = bp_diamond;
            ew.enemyppt.enemy.shot = ShotBullet.Diamond;
            ew.enemyppt.enemy.shotfrequency = 400;
            ew.enemyppt.bpe[0].move = BulletMoveEx.B_Diamond;
            ew.start = S_Dwon_2;
            ew.sum = 2;
            ew.staytime = 50;
            bf.wave.Add(ew);
            ew.enemyppt.bpe = bp1;
            ew.enemyppt.enemy.move = EnemyMove.M_Dock_180;
            ew.enemyppt.enemy.shot = ShotBullet.ThreeBeline10;
            ew.enemyppt.enemy.shotfrequency = 100;
            ew.start = S_Up_3;
            ew.sum = 1;
            ew.staytime = 200;
            bf.wave.Add(ew);
            ew.enemyppt.enemy.move = EnemyMove.M_Dock_200;
            ew.enemyppt.enemy.shot = ShotBullet.Down_Arc3;
            ew.enemyppt.enemy.shotfrequency = 400;
            ew.enemyppt.bpe = bp2;
            bf.wave.Add(ew);
            ew = bf.wave[0];
            bf.wave.Add(ew);
            ew.enemyppt.enemy.uv = uv_def_4x3[5];
            ew.enemyppt.enemy.points = e_b_edge[2];
            ew.enemyppt.enemy.shot = ShotBullet.Circle36A;
            ew.enemyppt.enemy.shotfrequency = 1200;
            ew.enemyppt.bpe = bp1;
            ew.start = S_Dwon_3;
            ew.sum = 3;
            ew.staytime = 500;
            bf.wave.Add(ew);
            ew.enemyppt.bpe = bp2;
            ew.enemyppt.enemy.shot = ShotBullet.Aim_12;
            ew.enemyppt.enemy.move = EnemyMove.M_Downward_NoStop;
            ew.enemyppt.enemy.shotfrequency = 400;
            ew.staytime = 500;
            bf.wave.Add(ew);
            ew.enemyppt = e2;
            ew.enemyppt.enemy.move = EnemyMove.M_Downward_NoStop;
            ew.start = S_Up_3;
            ew.sum = 1;
            ew.staytime = 0;
            bf.wave.Add(ew);
            ew = bf.wave[2];
            ew.enemyppt.enemy.move = EnemyMove.M_Downward_NoStop;
            ew.enemyppt.enemy.shot = ShotBullet.Downflowers;
            ew.enemyppt.bpe = bp2;
            ew.start = S_RandomDown_1();
            ew.sum = 1;
            ew.staytime = 50;
            bf.wave.Add(ew);
            ew.start = S_RandomDown_1();
            bf.wave.Add(ew);
            ew.start = S_RandomDown_1();
            bf.wave.Add(ew);
            ew.start = S_RandomDown_1();
            bf.wave.Add(ew);
            ew.enemyppt.enemy.uv = uv_def_4x3[6];
            ew.enemyppt.enemy.points = e_b_edge[3];
            ew.enemyppt.enemy.move = EnemyMove.M_LeftArc;
            ew.start = S_Left_1;
            ew.sum = 1;
            ew.staytime = 50;
            bf.wave.Add(ew);
            ew.enemyppt.enemy.move = EnemyMove.M_RightArc;
            ew.start = S_Right_1;
            ew.sum = 1;
            ew.staytime = 50;
            bf.wave.Add(ew);
            ew.enemyppt = e2;
            ew.enemyppt.enemy.move = EnemyMove.M_Downward_NoStop;
            ew.start = S_Dwon_3;
            ew.sum = 3;
            ew.staytime = 0;
            bf.wave.Add(ew);
            ew = bf.wave[1];
            ew.enemyppt.bpe = bp2;
            ew.enemyppt.enemy.uv = uv_def_4x3[7];
            ew.enemyppt.enemy.points = e_b_edge[3];
            ew.enemyppt.enemy.move = EnemyMove.M_Dock_180;
            ew.enemyppt.enemy.shot = ShotBullet.Down_Arc3;
            ew.start = S_Up_3;
            ew.sum = 1;
            ew.staytime = 200;
            bf.wave.Add(ew);
            ew.enemyppt = e2;
            ew.enemyppt.enemy.move = EnemyMove.M_Downward_NoStop;
            ew.start = S_Up_1;
            ew.sum = 1;
            ew.staytime = 300;
            bf.wave.Add(ew);
            bf.wave.Add(bf.wave[7]);
            bf.wave.Add(bf.wave[8]);
            bf.wave.Add(bf.wave[4]);
            bf.wave.Add(bf.wave[11]);
            bf.wave.Add(bf.wave[14]);
            bf.wave.Add(bf.wave[3]);
            bf.wave.Add(bf.wave[7]);
            bf.wave.Add(bf.wave[8]);
            bf.wave.Add(bf.wave[9]);
            bf.wave.Add(bf.wave[10]);
            bf.wave.Add(bf.wave[0]);
            bf.wave.Add(bf.wave[1]);
            bf.wave.Add(bf.wave[3]);
            bf.wave.Add(bf.wave[5]);
            bf.wave.Add(bf.wave[11]);
            bf.wave.Add(bf.wave[9]);
            bf.wave.Add(bf.wave[2]);
            bf.wave.Add(bf.wave[12]);
            bf.wave.Add(bf.wave[2]);
            bf.wave.Add(bf.wave[12]);
            bf.wave.Add(bf.wave[6]);
            ew.staytime = 2000;
            bf.wave.Add(ew);
        }
        static void SL_M_6()
        {
            QueueSourceEX.RegMatA(e_def_a00.enemy.mat_name, ref e_def_a00.enemy.mat_id);
            QueueSourceEX.RegMatA(e_def_b00.enemy.mat_name, ref e_def_b00.enemy.mat_id);
            QueueSourceEX.RegMatA(b_def_b3.mat_name, ref b_def_b3.mat_id);
            QueueSourceEX.RegMatA(b_def_b03b.mat_name, ref b_def_b03b.mat_id);
            QueueSourceEX.RegMatA(b_def_b04.mat_name, ref b_def_b04.mat_id);
            QueueSourceEX.RegMatA(b_bigblueboll.mat_name, ref b_bigblueboll.mat_id);
            QueueSourceEX.RegMatA(e_bee.enemy.mat_name, ref e_bee.enemy.mat_id);

        }
        static void SetLevel6(ref BattelField bf)
        {
            EnemyPropertyEX e1 = e_def_a00;
            EnemyPropertyEX e2 = e_meteor;
            EnemyPropertyEX e3 = e_def_b00;
            e3.enemy.uv = uv_def_4x3[7];
            e3.enemy.points = e_b_edge[3];
            EnemyPropertyEX e4 = Boss_Moth;
            BulletPropertyEx[] bp1 = new BulletPropertyEx[] { b_def_b03b };
            BulletPropertyEx[] bp2 = new BulletPropertyEx[] { b_def_b03b };
            bp2[0].speed = 0.003f;
            bf.wave.Clear();
            bf.level = 6;
            EnemyWave ew = new EnemyWave();

            ew.enemyppt = e1;
            ew.enemyppt.bpe = new BulletPropertyEx[] { b_def_b03b };
            ew.enemyppt.enemy.move = EnemyMove.M_Dock_200;
            ew.enemyppt.enemy.shot = ShotBullet.Diamond;
            ew.enemyppt.bpe[0].move = BulletMoveEx.B_Diamond;
            ew.enemyppt.enemy.shotfrequency = 400;
            ew.start = S_Dwon_2;
            ew.sum = 2;
            ew.staytime = 50;
            bf.wave.Add(ew);
            ew.enemyppt.bpe = bp1;
            ew.enemyppt.enemy.move = EnemyMove.M_Dock_180;
            ew.enemyppt.enemy.shot = ShotBullet.ThreeBeline10;
            ew.enemyppt.enemy.shotfrequency = 100;
            ew.start = S_Up_3;
            ew.sum = 1;
            ew.staytime = 200;
            bf.wave.Add(ew);
            ew.enemyppt.enemy.move = EnemyMove.M_Dock_200;
            ew.enemyppt.enemy.shot = ShotBullet.Down_Arc3;
            ew.enemyppt.bpe = bp2;
            ew.enemyppt.enemy.shotfrequency = 100;
            bf.wave.Add(ew);
            ew = bf.wave[1];
            bf.wave.Add(ew);
            ew = bf.wave[2];
            ew.enemyppt.enemy.move = EnemyMove.M_Dock_200;
            ew.enemyppt.enemy.shot = ShotBullet.Down_Arc3;
            ew.start = S_Dwon_3;
            ew.sum = 3;
            ew.staytime = 500;
            bf.wave.Add(ew);
            ew.enemyppt.enemy.move = EnemyMove.M_Downward_NoStop;
            ew.staytime = 500;
            bf.wave.Add(ew);
            ew.enemyppt = e2;
            ew.enemyppt.enemy.move = EnemyMove.M_Downward_NoStop;
            ew.start = S_Up_3;
            ew.sum = 1;
            ew.staytime = 50;
            bf.wave.Add(ew);
            ew.enemyppt = e1;
            ew.enemyppt.bpe = bp1;
            ew.enemyppt.enemy.move = EnemyMove.M_Downward_NoStop;
            ew.enemyppt.enemy.shot = ShotBullet.Angle6_Rotate;
            ew.enemyppt.enemy.shotfrequency = 100;
            ew.start = S_RandomDown_1();
            ew.sum = 1;
            ew.staytime = 50;
            bf.wave.Add(ew);
            ew.start = S_RandomDown_1();
            bf.wave.Add(ew);
            ew.start = S_RandomDown_1();
            bf.wave.Add(ew);
            ew.start = S_RandomDown_1();
            bf.wave.Add(ew);
            ew.enemyppt = e3;
            ew.enemyppt.bpe = bp2;
            ew.enemyppt.enemy.move = EnemyMove.M_LeftArc;
            ew.enemyppt.enemy.shot = ShotBullet.Aim_12;
            ew.enemyppt.enemy.shotfrequency = 300;
            ew.start = S_Left_1;
            ew.sum = 1;
            ew.staytime = 50;
            bf.wave.Add(ew);
            ew.enemyppt.enemy.move = EnemyMove.M_RightArc;
            ew.enemyppt.enemy.shot = ShotBullet.Aim_12;
            ew.start = S_Right_1;
            ew.sum = 1;
            ew.staytime = 50;
            bf.wave.Add(ew);
            ew.enemyppt = e2;
            ew.enemyppt.enemy.move = EnemyMove.M_Downward_NoStop;
            ew.start = S_Dwon_3;
            ew.sum = 3;
            ew.staytime = 0;
            bf.wave.Add(ew);
            ew.enemyppt = e1;
            ew.enemyppt.bpe = bp2;
            ew.enemyppt.enemy.move = EnemyMove.M_Dock_180;
            ew.enemyppt.enemy.shot = ShotBullet.Down_Arc3;
            ew.enemyppt.enemy.shotfrequency = 100;
            ew.start = S_Up_3;
            ew.sum = 1;
            ew.staytime = 200;
            bf.wave.Add(ew);
            ew.enemyppt = e2;
            ew.enemyppt.enemy.move = EnemyMove.M_Downward_NoStop;
            ew.start = S_Up_1;
            ew.sum = 1;
            ew.staytime = 300;
            bf.wave.Add(ew);
            bf.wave.Add(bf.wave[0]);
            bf.wave.Add(bf.wave[1]);
            bf.wave.Add(bf.wave[3]);
            bf.wave.Add(bf.wave[5]);
            bf.wave.Add(bf.wave[11]);
            bf.wave.Add(bf.wave[9]);
            bf.wave.Add(bf.wave[2]);
            bf.wave.Add(bf.wave[12]);
            bf.wave.Add(bf.wave[7]);
            bf.wave.Add(bf.wave[8]);
            bf.wave.Add(bf.wave[4]);
            bf.wave.Add(bf.wave[11]);
            bf.wave.Add(bf.wave[14]);
            bf.wave.Add(bf.wave[3]);
            bf.wave.Add(bf.wave[7]);
            bf.wave.Add(bf.wave[8]);
            bf.wave.Add(bf.wave[9]);
            bf.wave.Add(bf.wave[10]);
            bf.wave.Add(bf.wave[2]);
            bf.wave.Add(bf.wave[12]);
            bf.wave.Add(bf.wave[6]);
            ew.staytime = 500;

            ew.enemyppt = e_bee;
            BulletPropertyEx[] tp= new BulletPropertyEx[] { b_def_b3, b_def_b03b, b_bigblueboll, b_def_b3 };
            tp[0].speed = 0.002f;
            tp[1].speed = 0.003f;
            tp[3].t_uv = SP.uv_def_4x2[6];
            tp[3].attack = 40;
            ew.enemyppt.bpe = tp;
            ew.start = S_Up_3;
            ew.sum = 1;
            ew.staytime = 65536;
            bf.wave.Add(ew);
        }
        static void SL_M_7()
        {
            QueueSourceEX.RegMatA(e_def_a00.enemy.mat_name, ref e_def_a00.enemy.mat_id);
            QueueSourceEX.RegMatA(e_def_b00.enemy.mat_name, ref e_def_b00.enemy.mat_id);
            QueueSourceEX.RegMatA(b_def_b03b.mat_name, ref b_def_b03b.mat_id);
            QueueSourceEX.RegMatA(b_def_b04.mat_name, ref b_def_b04.mat_id);
        }
        static void SetLevel7(ref BattelField bf)
        {
            EnemyPropertyEX e1 =  e_def_a00;
            EnemyPropertyEX e2 =  e_meteor;
            EnemyPropertyEX e3 =  e_def_b00;
            //e3.enemy.spt_index = 8;
            BulletPropertyEx[] bp1 = new BulletPropertyEx[] { b_def_b03b };
            BulletPropertyEx[] bp2 = new BulletPropertyEx[] { b_def_b03b };
            BulletPropertyEx[] bp4 = new BulletPropertyEx[] { b_def_b04 };
            bp2[0].speed = 0.003f;
            bf.wave.Clear();
            bf.level = 7;
            EnemyWave ew = new EnemyWave();
            ew.enemyppt = e1;
            ew.sum = 3;
            ew.staytime = 200;
            ew.enemyppt.enemy.move = EnemyMove.M_Dock_200;
            ew.enemyppt.enemy.shot = ShotBullet.Down_Arc3;
            ew.enemyppt.bpe = bp2;
            ew.enemyppt.enemy.shotfrequency = 100;
            ew.start = S_Dwon_3;
            bf.wave.Add(ew);
            bf.wave.Add(ew);
            ew.enemyppt = e1;
            ew.enemyppt.bpe = bp1;
            ew.enemyppt.enemy.move = EnemyMove.M_Downward_NoStop;
            ew.enemyppt.enemy.shot = ShotBullet.Angle6_Rotate;
            ew.enemyppt.enemy.shotfrequency = 100;
            ew.start = S_RandomDown_1();
            ew.sum = 1;
            ew.staytime = 50;
            bf.wave.Add(ew);
            ew.enemyppt.enemy.move = EnemyMove.M_Dock_200;
            ew.start = S_Dwon_3;
            ew.sum = 3;
            ew.staytime = 500;
            bf.wave.Add(ew);
            ew.enemyppt.bpe = bp2;
            ew.enemyppt.enemy.move = EnemyMove.M_Downward_NoStop;
            ew.staytime = 500;
            bf.wave.Add(ew);
            ew.enemyppt = e2;
            ew.enemyppt.enemy.move = EnemyMove.M_Downward_NoStop;
            ew.start = S_Up_3;
            ew.sum = 1;
            ew.staytime = 50;
            bf.wave.Add(ew);
            ew.enemyppt = e1;
            ew.enemyppt.bpe = bp1;
            ew.enemyppt.enemy.move = EnemyMove.M_Downward_NoStop;
            ew.enemyppt.enemy.shot = ShotBullet.Angle6_Rotate;
            ew.enemyppt.enemy.shotfrequency = 100;
            ew.start = S_RandomDown_1();
            ew.sum = 1;
            ew.staytime = 50;
            bf.wave.Add(ew);
            ew.enemyppt.bpe = new BulletPropertyEx[] { b_def_b03b };
            ew.enemyppt.enemy.move = EnemyMove.M_Dock_200;
            ew.enemyppt.enemy.shot = ShotBullet.Diamond;
            ew.enemyppt.bpe[0].move = BulletMoveEx.B_Diamond;
            ew.enemyppt.enemy.shotfrequency = 3000;
            ew.start = S_Dwon_2;
            ew.sum = 2;
            ew.staytime = 50;
            bf.wave.Add(ew);
            ew.enemyppt.bpe = bp1;
            ew.enemyppt.enemy.move = EnemyMove.M_Dock_180;
            ew.enemyppt.enemy.shot = ShotBullet.ThreeBeline10;
            ew.enemyppt.enemy.shotfrequency = 100;
            ew.start = S_Up_3;
            ew.sum = 1;
            bf.wave.Add(ew);
            ew.start = S_RandomDown_1();
            bf.wave.Add(ew);
            ew.start = S_RandomDown_1();
            bf.wave.Add(ew);
            ew.enemyppt = e3;
            ew.enemyppt.bpe = bp4;
            ew.enemyppt.enemy.move = EnemyMove.M_Dock_200;
            ew.enemyppt.enemy.shot = ShotBullet.Angle6_RotateB;
            ew.enemyppt.enemy.shotfrequency = 60;
            ew.start = S_Up_3;
            ew.sum = 1;
            ew.staytime = 50;
            bf.wave.Add(ew);
            ew.enemyppt = e3;
            ew.enemyppt.bpe = bp2;
            ew.enemyppt.enemy.move = EnemyMove.M_RightArc;
            ew.enemyppt.enemy.shot = ShotBullet.Aim_12;
            ew.enemyppt.enemy.shotfrequency = 160;
            ew.start = S_Right_1;
            ew.sum = 1;
            ew.staytime = 50;
            bf.wave.Add(ew);
            ew.enemyppt = e2;
            ew.enemyppt.enemy.move = EnemyMove.M_Downward_NoStop;
            ew.start = S_Dwon_3;
            ew.sum = 3;
            ew.staytime = 0;
            bf.wave.Add(ew);
            ew.enemyppt = e1;
            ew.enemyppt.bpe = bp4;
            ew.enemyppt.enemy.move = EnemyMove.M_Dock_180;
            ew.enemyppt.enemy.shot = ShotBullet.Angle6_RotateB;
            ew.enemyppt.enemy.shotfrequency = 60;
            ew.start = S_Up_3;
            ew.sum = 1;
            ew.staytime = 200;
            bf.wave.Add(ew);
            ew.enemyppt = e2;
            ew.enemyppt.enemy.move = EnemyMove.M_Downward_NoStop;
            ew.start = S_Up_1;
            ew.sum = 1;
            ew.staytime = 300;
            bf.wave.Add(ew);
            bf.wave.Add(bf.wave[0]);
            bf.wave.Add(bf.wave[1]);
            bf.wave.Add(bf.wave[3]);
            bf.wave.Add(bf.wave[5]);
            bf.wave.Add(bf.wave[11]);
            bf.wave.Add(bf.wave[9]);
            bf.wave.Add(bf.wave[2]);
            bf.wave.Add(bf.wave[12]);
            bf.wave.Add(bf.wave[7]);
            bf.wave.Add(bf.wave[8]);
            bf.wave.Add(bf.wave[4]);
            bf.wave.Add(bf.wave[11]);
            bf.wave.Add(bf.wave[14]);
            bf.wave.Add(bf.wave[3]);
            bf.wave.Add(bf.wave[7]);
            bf.wave.Add(bf.wave[8]);
            bf.wave.Add(bf.wave[9]);
            bf.wave.Add(bf.wave[10]);
            bf.wave.Add(bf.wave[2]);
            bf.wave.Add(bf.wave[12]);
            bf.wave.Add(bf.wave[6]);
            ew.staytime = 20000;
        }
        static void SL_M_8()
        {
            QueueSourceEX.RegMatA(Boss_Huijin.enemy.mat_name, ref Boss_Huijin.enemy.mat_id);
            QueueSourceEX.RegMatA(b_def_b04.mat_name, ref b_def_b04.mat_id);
            QueueSourceEX.RegMatA(b_bigblueboll.mat_name, ref b_bigblueboll.mat_id);
            QueueSourceEX.RegMatA(b_laser4.mat_name, ref b_laser4.mat_id);
            QueueSourceEX.RegMatA(b_missile01.mat_name, ref b_missile01.mat_id);
        }
        static void SetLevel8(ref BattelField bf)
        {
            bf.wave.Clear();
            SetLevel7(ref bf);
            bf.level = 8;
            EnemyWave ew = new EnemyWave();
            ew.enemyppt = Boss_Huijin;
            ew.enemyppt.bpe = new BulletPropertyEx[] { b_def_b04, b_def_b04, b_bigblueboll, b_laser4, b_def_b04, b_missile01, b_missile01 };
            ew.start = S_Up_3;
            ew.sum = 1;
            ew.staytime = 65536;
            bf.wave.Add(ew);
        }
        static void SetLevel9(ref BattelField bf)
        {
           
        }
        static void SetLevel10(ref BattelField bf)
        {
            
        }
#endregion
    }
}