using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.UnityVS.Script
{
    class Store:GameControl
    {
        #region preview
        //static ShotW[] pv_shot = new ShotW[3];
        //static int[] pv_shot_id = new int[5];
        static WarPlane pv_wp;
        static Wing pv_w;
        static SecondBullet pv_sb;
        //static AnimatBaseEx pv_skill;
        static int style,aid, iid ,bid;
        static int time,a_time;
        static void shot()
        {
            switch (style)
            {
                case 0:
                    pv_wp.extra_b += ts;
                    if(pv_wp.extra_b>=pv_wp.shotfrequency)
                    {
                        pv_wp.extra_b -= pv_wp.shotfrequency;
                        if(pv_wp.shot!=null)
                        pv_wp.shot(ref buff_b_ex[bid]);
                    }
                    break;
                case 1:
                    pv_sb.extra_b += ts;
                    if(pv_sb.extra_b>=pv_sb.shotfrequency)
                    {
                        pv_sb.extra_b -= pv_sb.shotfrequency;
                        pv_sb.shot(ref buff_b_ex[bid]);
                    }
                    break;
                case 2:
                    pv_w.extra_b += ts;
                    if(pv_w.extra_b>=pv_w.shotfrequency)
                    {
                        pv_w.extra_b -= pv_w.shotfrequency;
                        pv_w.shot(ref buff_b_ex[bid]);
                    }
                    break;
            }
        }
        static bool cr;
        static void PreView()
        {
            int t = DateTime.Now.Millisecond;
            ts = t - time;
            if (ts < 0)
                ts += 1000;
            time = t;
            int id = bex_id[bid];
            buff_img_ex[id].update(ref buff_img_ex[id]);
            buff_img_ex[iid].update(ref buff_img_ex[iid]);
            AsyncManage.AsyncDelegate(calcul);
            
        }
        static void calcul()
        {
            shot();
            if (buff_b_ex[bid].calcul != null)
                buff_b_ex[bid].calcul(ref buff_b_ex[bid], ref buff_b_ex[bid].b_s);
            else
                Cacul_Bullet(ref buff_b_ex[bid], ref buff_b_ex[bid].b_s);
            Ani_Update();
            a_time += ts;
            if (style < 4)
            {
                if (cr)
                {
                    if (a_time > 6000)
                    {
                        switch(style)
                        {
                            case 0:
                                if (pv_wp.lc != null)
                                    pv_wp.lc(ref pv_wp, ref buff_b_ex[bid], 2);
                                break;
                            case 1:
                                if (pv_sb.lc != null)
                                    pv_sb.lc(ref pv_sb, ref buff_b_ex[bid], 2);
                                break;
                            case 2:
                                if (pv_w.lc != null)
                                    pv_w.lc(ref pv_w, ref buff_b_ex[bid], 2);
                                break;
                        }
                        Ani_Run_D(1, aid);
                        cr = false;
                        a_time = 0;
                    }
                }
                else
                {
                    if (a_time > 3000)
                    {
                        switch (style)
                        {
                            case 0:
                                if (pv_wp.lc != null)
                                    pv_wp.lc(ref pv_wp, ref buff_b_ex[bid], 3);
                                break;
                            case 1:
                                if (pv_sb.lc != null)
                                    pv_sb.lc(ref pv_sb, ref buff_b_ex[bid], 3);
                                break;
                            case 2:
                                if (pv_w.lc != null)
                                    pv_w.lc(ref pv_w, ref buff_b_ex[bid], 3);
                                break;
                        }
                        Ani_Run_D(0, aid);
                        cr = true;
                    }
                }
            }
            else
            {
                Ani_Run_D(0, aid);
            }
        }
        static void s_up(ref ImageBaseEx ibe)
        {
            switch (style)
            {
                case 0://wp
                    ibe.gameobject.SetActive(true);
                    if(buff_ani[aid].up_v)
                    {
                        buff_ani[aid].up_v = false;
                        ibe.mesh.vertices = buff_ani[aid].vertex;
                    }
                    break;
                case 1://bs
                    ibe.gameobject.SetActive(false);
                    break;
                case 2://wing
                    ibe.gameobject.SetActive(true);
                    if (pv_w.animat)
                        if (buff_ani[aid].up_v)
                    {
                        buff_ani[aid].up_v = false;

                        ibe.mesh.vertices = buff_ani[aid].vertex;
                    }
                    break;
                case 3://shiled
                    ibe.gameobject.SetActive(false);
                    break;
                default://skill
                    ibe.gameobject.SetActive(true);
                    if (buff_ani[aid].up_v)
                    {
                        buff_ani[aid].up_v = false;
                        ibe.mesh.vertices = buff_ani[aid].vertex;
                    }
                    break;
            }
        }
        public static void View_Start(Vector3 l)
        {
            core_location = l;
            pv_wp = ThunderData.Plane_all[0];
            aid = RegAni(ref pv_wp.abe);
            string name = pv_wp.bpe.mat_name;
            int id = RegMat(name);
            CreateMat(name);
            pv_wp.bpe.mat_id = id;
            bid = RegBulletEx(ref pv_wp.bpe,0);
            iid = CreateImgNullEx(s_up,0);
            buff_img_ex[iid].mr.sortingOrder = 5;
            buff_img_ex[iid].transform.localPosition = core_location;
            string path = pv_wp.mat_name;
            Material mat= CreateMat(path);
            buff_img_ex[iid].mr.material = mat;
            Mesh me = buff_img_ex[iid].mesh;
            me.triangles = null;
            me.vertices = buff_ani[aid].vertex;
            me.uv = buff_ani[aid].uv;
            me.triangles = buff_ani[aid].tri;
            if(pv_wp.lc!=null)
            pv_wp.lc(ref pv_wp, ref buff_b_ex[bid],2);
            MainCamera.update = PreView;
        }
        public static void View_Stop()
        {
            ClearBullet(bid);
            int id = bex_id[bid];
            buff_img_ex[id].gameobject.SetActive(false);
            RecycleImgEx(iid);
            MainCamera.update = null;
        }
        public static void PlaneView(WarPlane wp)
        {
            style = 0;
            a_time = 0;
            pv_wp = wp;
            UnReg_Ani(aid);
            aid = RegAni(ref pv_wp.abe);
            buff_img_ex[iid].mr.material = CreateMat(wp.mat_name);

            Mesh me = buff_img_ex[iid].mesh;
            me.triangles = null;
            me.vertices = buff_ani[aid].vertex;
            me.uv = buff_ani[aid].uv;
            me.triangles = buff_ani[aid].tri;

            pv_wp.bpe.mat_id = RegMat(wp.bpe.mat_name);
            CreateMat(wp.bpe.mat_name);
            ClearBullet(bid);
            CopyBullet(ref buff_b_ex[bid], ref pv_wp.bpe);
            if (wp.bpe.up_img != null)
            {
                int id = bex_id[bid];
                buff_img_ex[id].update = wp.bpe.up_img;
            }
            else
            {
                int id = bex_id[bid];
                buff_img_ex[id].update = UpdateBulletEx;
            }
            if (pv_wp.lc != null)
                pv_wp.lc(ref pv_wp, ref buff_b_ex[bid], 2);
        }
        public static void SecondView(SecondBullet s)
        {
            style = 1;
            pv_sb = s;
            pv_sb.bpe.mat_id = RegMat(s.bpe.mat_name);
            CreateMat(s.bpe.mat_name);
            ClearBullet(bid);
            CopyBullet(ref buff_b_ex[bid], ref pv_sb.bpe);
            if (s.bpe.up_img != null)
            {
                int id = bex_id[bid];
                buff_img_ex[id].update = s.bpe.up_img;
            }
            else
            {
                int id = bex_id[bid];
                buff_img_ex[id].update = UpdateBulletEx;
            }
            if (pv_sb.lc != null)
                pv_sb.lc(ref pv_sb, ref buff_b_ex[bid], 2);
        }
        public static void WingView(Wing w)
        {
            style = 2;
            a_time = 0;
            pv_w = w;
            buff_img_ex[iid].mr.material = CreateMat(w.mat_name);
            UnReg_Ani(aid);
            if(w.animat)
            {
                aid = RegAni(ref pv_w.abe);
                Mesh me = buff_img_ex[iid].mesh;
                me.triangles = null;
                me.vertices = buff_ani[aid].vertex;
                me.uv = buff_ani[aid].uv;
                me.triangles = buff_ani[aid].tri;
            }
            else
            {
                Mesh me = buff_img_ex[iid].mesh;
                me.triangles = null;
                me.vertices = w.abe.vertex;
                me.uv = w.abe.uv;
                me.triangles = w.abe.tri;
            }

            pv_w.bpe.mat_id = RegMat(w.bpe.mat_name);
            CreateMat(w.bpe.mat_name);
            ClearBullet(bid);
            CopyBullet(ref buff_b_ex[bid], ref pv_w.bpe);
            if (w.bpe.up_img != null)
            {
                int id = bex_id[bid];
                buff_img_ex[id].update = w.bpe.up_img;
            }
            else
            {
                int id = bex_id[bid];
                buff_img_ex[id].update = UpdateBulletEx;
            }
            if (pv_w.lc != null)
                pv_w.lc(ref pv_w, ref buff_b_ex[bid], 2);
        }
        public static void ShiledView(Shiled s)
        {
            style = 3;
            UnReg_Ani(aid);
            ClearBullet(bid);
            a_time = 0;
        }
        public static void SkillView(Skill s)
        {
            style = 4;
            ClearBullet(bid);
            UnReg_Ani(aid);
            aid = RegAni(ref s.abe);
            buff_img_ex[iid].mr.material = CreateMat(s.mat_name);
            Mesh me = buff_img_ex[iid].mesh;
            me.triangles = null;
            me.vertices = buff_ani[aid].vertex;
            me.uv = buff_ani[aid].uv;
            me.triangles = buff_ani[aid].tri;
        }

        #endregion
    }
}
