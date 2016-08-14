#define pc
//#undef pc
#define unsafe
//#undef unsafe
//#define x64
//#undef x64
using System;
using UnityEngine;
using System.Collections.Generic;

namespace Assets.UnityVS.Script
{
    class ThunderMod:GameControl
    {
#if pc
        static string mat_bb = "Mat_PC/big_boom";
        static string mat_boom = "Mat_PC/bomb";
#else
        static string mat_bb = "Mat_Phone/big_boom";
        static string mat_boom = "Mat_Phone/bomb";
#endif
        #region data source
        static string[] change_bs = new string[] { "更换武器", "change bullet" };
        static string[] change_wing = new string[] { "更换僚机","change wing"};
        static EdgePropertyEx change_weapon = new EdgePropertyEx()
        {
            imagebase = new ImageProperty()
            {
                imagepath = "Picture/six_angle",
                scale = new Vector3(1, 1),
                sorting = 4,
                location = new Vector3(2.3f, -2.6f, layer)
            },
            text = new TextProperty()
            {
                color = Color.red,
                scale = new Vector2(0.1f, 0.1f)
            },
            property = new EdgeButtonBase()
            {
                points = six_angle_button
            }
        };
        static CirclePropertyEx skill_button = new CirclePropertyEx()
        {
            imagebase = new ImageProperty()
            {
                location = new Vector3(-2.15f, -2.6f, layer),
                imagepath = "Picture/magic_shiled",
                scale = new Vector3(1, 1),
                sorting = 4
            },
            property = new CircleButtonBase() { click = Skill_Click, r = 0.5f },
            text = new TextProperty() { text = "W", scale = new Vector3(0.1f, 0.1f) }
        };

        static ImageProperty big_boom_f = new ImageProperty()
        {
            sorting = 7,
            scale = origion_scale,
            location = new Vector3(-2.15f, -3.6f, layer),
            imagepath = "Picture/Center"
        };
        static ImageProperty big_boom_b = new ImageProperty()
        {
            sorting = 6,
            scale = origion_scale,
            location = new Vector3(-2.15f, -3.6f, layer),
            imagepath = "Picture/burn"
        };
        static TextProperty score_text = new TextProperty()
        {
            location = new Vector3(2,4.5f,layer),color=Color.green,scale=new Vector3(0.1f,0.1f),
            fontsize=33,text="score:"
        };
#endregion

        static CircleButtonBase big_boom_button = new CircleButtonBase() { click = BigBoom, r = 0.5f };
        static int  hpid, hpid2, spid, spid2, epid, epid2;
#region sence control
        static void CaculateEnemyA()
        {
            area = CircleMoveArea(oldloaction, core_location, 0.25f, ref areapoints);
            oldloaction = core_location;
            xy.x = core_location.x;
            xy.y = core_location.y;
            int c = 0;
            for (int i = 0; i < 20; i++)
            {
                if (buff_enemy[i].c_blood > 0)
                {
                    c++;
                    if (buff_enemy[i].move(ref buff_enemy[i]))
                    {
                        if (buff_enemy[i].play != null)
                            buff_enemy[i].play(ref buff_enemy[i]);
                        float x = buff_enemy[i].location.x;
                        float y = buff_enemy[i].location.y;
                        Point2 temp = new Point2(x, y);
                        if (buff_enemy[i].radius == 0)
                        {
                            if (buff_enemy[i].points_style > 0)
                                buff_enemy[i].offset = GetPointsOffset(buff_enemy[i].location, ref buff_enemy[i].points);
                            else buff_enemy[i].offset = RotatePoint2(ref buff_enemy[i].points, temp, buff_enemy[i].angle.z);
                        }
                        float x1 = core_location.x - x;
                        float y1 = core_location.y - y;
                        float d = x1 * x1 + y1 * y1;
                        if (d < buff_enemy[i].minrange)
                        {
                            damageC();
                        }
                        else
                        if (buff_enemy[i].radius > 0)
                        {
                            if (area)
                            {
                                if (d < 1)
                                {
                                    if (CircleToPolygon(buff_enemy[i].location, buff_enemy[i].radius, areapoints))
                                        damageC();
                                }
                            }
                        }
                        else
                        {
                            if (d < buff_enemy[i].maxrange)
                            {
                                if (area)
                                {
                                    if (PToP2(areapoints, buff_enemy[i].offset))
                                        damageC();
                                }
                                else
                                {
                                    if (CircleToPolygon(core_location, 0.09f, buff_enemy[i].offset))
                                        damageC();
                                }
                            }
                        }
                        if (buff_ani[big_boom.ani_id].c_time>0)
                        {
                            x = big_boom.location.x - buff_enemy[i].location.x;
                            y = big_boom.location.y - buff_enemy[i].location.y;
                            d = x * x + y * y;
                            float d1 = big_boom.r * big_boom.r + buff_enemy[i].minrange;
                            if (d < d1)
                            {
                                buff_enemy[i].c_blood -= big_boom.attack * ts;
                            }
                        }
                        if (current.skill.attack>0 & buff_ani[current.skill.ani_id].c_time>0)
                        {
                            x = current.skill.location.x - buff_enemy[i].location.x;
                            y = current.skill.location.y - buff_enemy[i].location.y;
                            d = x * x + y * y;
                            float d1 = current.skill.r * current.skill.r + buff_enemy[i].minrange;
                            if (d < d1)
                            {
                                buff_enemy[i].c_blood -= current.skill.attack;
                                if (buff_enemy[i].c_blood <= 0)
                                {
                                    generateA(10 + currentwave, buff_enemy[i].location);
                                    score += buff_enemy[i].score;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (buff_enemy[i].move != null)
                    {
                        buff_enemy[i].move = null;
                        if (buff_enemy[i].bulletid != null)
                            for (int cc = 0; cc < buff_enemy[i].bulletid.Length; cc++)
                                UnRegBulletEx(buff_enemy[i].bulletid[cc]);
                        if (buff_enemy[i].animat)
                            UnReg_Ani(buff_enemy[i].ani_id);
                    }
                }
            }
            if (c == 0)
            {
                if (crt_wave.sum == 0)
                {
                    if (currentwave >= buff_wave.wave.Count)
                    {
                        gameover = true;
                    }
                    else
                    {
                        crt_wave = buff_wave.wave[currentwave];
                        int max = crt_wave.sum;
                        for (int d = 0; d < max; d++)
                            CreateEnemy(ref crt_wave.enemyppt, crt_wave.start[d]);
                        crt_wave.sum = 0;
                        currentwave++;
                    }
                }
                return;
            }
            if (crt_wave.enemyppt.enemy.boss == false)
                crt_wave.staytime--;
            if (crt_wave.staytime < 0)
            {
                if (currentwave >= buff_wave.wave.Count)
                {
                    gameover = true;
                }
                else
                {
                    crt_wave = buff_wave.wave[currentwave];
                    int max = crt_wave.sum;
                    if (max > crt_wave.start.Length)
                        Debug.Log(currentwave);
                    for (int d = 0; d < max; d++)
                        CreateEnemy(ref crt_wave.enemyppt, crt_wave.start[d]);
                    crt_wave.sum = 0;
                    currentwave++;
                }
            }
        }
        public static bool Collision(ref BulletPropertyEx bpe, ref BulletStateEx state)
        {
            float x, y, d;
            int z = state.angle;
            if (bpe.penetrate == false)
            {
                if (buff_ani[big_boom.ani_id].c_time > 0)
                {
                    x = big_boom.location.x - state.location.x;
                    y = big_boom.location.y - state.location.y;
                    d = x * x + y * y;
                    float d1 = big_boom.r * big_boom.r + bpe.minrange +
                        2 * big_boom.r * Mathf.Sqrt(bpe.minrange);
                    if (d < d1)
                    {
                        state.active = false;
                        return true;
                    }
                }
                if (current.skill.force_clear & buff_ani[current.skill.ani_id].c_time > 0)
                {
                    x = current.skill.location.x - state.location.x;
                    y = current.skill.location.y - state.location.y;
                    d = x * x + y * y;
                    float d1 = current.skill.r * current.skill.r + bpe.minrange +
                        2 * current.skill.r * Mathf.Sqrt(bpe.minrange);
                    if (d < d1)
                    {
                        int h = (int)(bpe.attack / 5);
                        current.skill.during -= h;
                        state.active = false;
                        return true;
                    }
                }
            }
            x = core_location.x - state.location.x;
            y = core_location.y - state.location.y;
            d = x * x + y * y;
            if (d < bpe.minrange)
            {
                damageA(ref bpe);
                if (bpe.penetrate == false)
                    state.active = false;
                return true;
            }
            bool collid = false;
            if (bpe.radius > 0)
            {
                if (area & d < 1)
                {
                    collid = CircleToPolygon(new Point2(state.location.x, state.location.y)
                       , bpe.radius, areapoints);
                }
            }
            else
            {
                if (area & d < 1)
                {
                    collid = PToP2(areapoints, RotatePoint2(ref bpe.edgepoints, new Point2(state.location.x, state.location.y), z));
                }
                else
                if (d < bpe.maxrange)
                {
                    collid = CircleToPolygon(xy, 0.09f, RotatePoint2(ref bpe.edgepoints,
                        new Point2(state.location.x, state.location.y), z));
                }
            }
            if (collid)
            {
                damageA(ref bpe);
                if (bpe.penetrate == false)
                    state.active = false;
                return true;
            }
            return false;
        }
        public static void PreLoad()
        {
            RegMatA(current.warplane.bpe.mat_name,ref current.warplane.bpe.mat_id);
            RegMatA(current.B_second.bpe.mat_name,ref current.B_second.bpe.mat_id);
            RegMatA(current.bs_back.bpe.mat_name,ref current.bs_back.bpe.mat_id);
            RegMatA(current.wing.bpe.mat_name,ref current.wing.bpe.mat_id);
            RegMatA(current.w_back.bpe.mat_name,ref current.w_back.bpe.mat_id);
            RegMatA(big_boom.mat_name,ref big_boom.mat_id);
            AsyncManage.AsyncDelegate(Preinital);
            RegSpriteA(big_boom_f.imagepath, ref big_boom_f.spt_id);
            RegSpriteA(big_boom_b.imagepath, ref big_boom_b.spt_id);
            RegMatA(big_boom.mat_name,ref big_boom.mat_id);
            RegMatA(current.warplane.mat_name,ref current.warplane.mat_id);
            RegMatA(current.wing.mat_name,ref current.wing.mat_id);
            RegMatA(current.w_back.mat_name,ref current.w_back.mat_id);
            RegMatA(current.skill.mat_name,ref current.skill.mat_id);

            RegMatA(mat_prop_u,ref pro_id[2]);
            RegMatA(mat_prop_b, ref pro_id[3]);
            RegMatA(mat_crystal,ref cry_mat_id);
            RegMatA(ThunderData.b_missile.mat_name,ref ThunderData.b_missile.mat_id);
            RegMatA(ThunderData.e_meteor.enemy.mat_name,ref ThunderData.e_meteor.enemy.mat_id);
            RegMatA(ThunderData.b_hit.mat_name,ref ThunderData.b_hit.mat_id);
        }
        static void Preinital()
        {
            current.warplane.ani_id = RegAni(ref current.warplane.abe);
            if (current.wing.animat)
                current.wing.ani_id = RegAni(ref current.wing.abe);
            if (current.w_back.animat)
                current.w_back.ani_id = RegAni(ref current.w_back.abe);
            current.skill.ani_id = RegAni(ref current.skill.abe);
            big_boom.ani_id = RegAni(ref big_boom.abe);
            current.warplane.bulletid = RegBulletEx(ref current.warplane.bpe,24);
            current.B_second.bulletid = RegBulletEx(ref current.B_second.bpe,24);
            current.wing.bulletid = RegBulletEx(ref current.wing.bpe,24);
            current.bs_back.bulletid = RegBulletEx(ref current.bs_back.bpe,24);
            current.w_back.bulletid = RegBulletEx(ref current.w_back.bpe,24);
        }
        public static void UnPreLoad()
        {
            AsyncManage.AsyncDelegate(ClearData);
        }
        static void FixedUpdate()
        {
            if (gameover)
            {
                if (current.warplane.currentblood > 0)
                    GameOver(true);
                else
                    GameOver(false);
                MainCamera.update = null;
                return;
            }
            int t = DateTime.Now.Millisecond;
            ts = t - ot;
            if (ts < 0)
                ts += 1000;
            ot = t;
            UpdateImgEx();
            UpdateWingLocation();
            AsyncManage.AsyncDelegate(ThreadA);
            AsyncManage.AsyncDelegate(ThreadB);
            AsyncManage.AsyncDelegate(ThreadC);

#if pc
            if (Input.GetKeyDown(KeyCode.Space))
                BigBoom();
            if (Input.GetKeyDown(KeyCode.W))
                Skill_Click();
            if (Input.GetKeyDown(KeyCode.A))
                ChangeSecondWeapon();
            if (Input.GetKeyDown(KeyCode.D))
                ChangeWing();
#endif
        }
        public static void GameStart()
        {
            loadgamebutton();
            current.level = 0;
            current.warplane.currentblood = current.warplane.blood;
            currentwave = 0;
            bg_create();
            LoadWarPlane();
            D_gameover = GameOverA;
            Prop_Inital();
            propcollid = Prop_Collider;
            Bomb_Initial();
            gameover = false;
            mouse_move = Plane_Move;
            plane_move = true;
            destory_enemy = 0;
            damageA = DamageCalculateA;
            damageB = DamageCalculateB;
            damageC = DamageCalculateC;
            generateA = GenerateProp;
            update = FixedUpdate;
            Missile_Inital();
            Cry_Inital();
            CollisionInital();
            score = 0;
            MainCamera.update = FixedUpdate;
            ot = DateTime.Now.Millisecond;
        }
        static void GameOverA(bool pass)
        {
            gameover = true;
            plane_move = false;
            mouse_move = null;
            AsyncManage.AsyncDelegate(() => {
                w_back = false;
                bs_back = false;
                ClearData();
                imageid = 0;
            });    
            Bomb_Clear();
            Prop_Destory();
            ClearWarPlane();
            unloadgamebutton();
            CanvasControl.GameOverCallBack(pass, score);
            Resources.UnloadUnusedAssets();
        }
        static void ThreadA()
        {
            Move_BulletEx(0, 32,2);
            PlanMove();
            CalculateSkill();
        }
        static void ThreadB()
        {
            Move_BulletEx(1, 32, 2);
            UpdateBlood();
        }
        static void ThreadC()
        {
            BulletCalcul();
            UpdateProp2A();
            Bomb_Update2A();
            Ani_Update();
            CaculateEnemyA();
            Update_missile();
            Cry_move();
        }
        #endregion

        #region plane control
        static int level4_during = 0,w_iid,wp_iid;
        static bool bs_back, w_back,w_change;
        static void freshgrade()
        {
            int index;
            if (current.warplane.lc != null)
            {
                index = current.warplane.bulletid;
                current.warplane.lc(ref current.warplane, ref buff_b_ex[index], current.level);
            } 
            if(current.B_second.lc!=null)
            {
                index = current.B_second.bulletid;
                current.B_second.lc(ref current.B_second,ref buff_b_ex[index],current.level);
            }
            if(current.bs_back.lc!=null)
            {
                index = current.bs_back.bulletid;
                current.bs_back.lc(ref current.bs_back,ref buff_b_ex[index],current.level);
            }
            if(current.wing.lc!=null)
            {
                index = current.wing.bulletid;
                current.wing.lc(ref current.wing,ref buff_b_ex[index],current.level);
            }
            if(current.w_back.lc!=null)
            {
                index = current.w_back.bulletid;
                current.w_back.lc(ref current.w_back,ref buff_b_ex[index],current.level);
            }
        }
        static void UpGrade()
        {
            if (current.level < 3)
            {
                current.level++;
                if (current.level == 3)
                {
                    level4_during = 6000;
                    if (current.warplane.animat)
                        Ani_Run_D(0,current.warplane.ani_id);
                }
                freshgrade();
            }
            else level4_during = 6000;
        }
        static void DeGrade()
        {
            if (current.level > 0& level4_during<1)
            {
                current.level--;
                freshgrade();
            }
        }
        static void GenerateProp(int max, Vector3 location)
        {
            int i = lucky.Next(0, max);
            if (i < 2)//upgard
            {
                generate = true;
                build_type = 0;
                build_position = location;
                return;
            }
            else
            if (i < 3)//blood
            {
                generate = true;
                build_type = 1;
                build_position = location;
                return;
            }
        }

        static void BulletCalcul()
        {
            int id;
            if (mousedown)
            {
                if (current.level > 3)
                    current.level = 3;
                if (current.level < 0)
                    current.level = 0;
                int slice = ts;
                int b = current.warplane.extra_b;
                int s = current.warplane.shotfrequency;
                if (b >= s)
                {
                    current.warplane.extra_b-=s;
                     id = current.warplane.bulletid;
                    if(current.warplane.shot!=null)
                        current.warplane.shot(ref buff_b_ex[id]);
                }
                current.warplane.extra_b+=slice;
                if(bs_back)
                {
                    b = current.bs_back.extra_b;
                    s = current.bs_back.shotfrequency;
                    if (b >= s)
                    {
                        current.bs_back.extra_b -= s;
                            id = current.bs_back.bulletid;
                            current.bs_back.shot(ref buff_b_ex[id]);
                    }
                    current.bs_back.extra_b+=slice;
                }
                else
                {
                    b = current.B_second.extra_b;
                    s = current.B_second.shotfrequency;
                    if (b >= s)
                    {
                        current.B_second.extra_b -= s;

                            id = current.B_second.bulletid;
                            current.B_second.shot(ref buff_b_ex[id]);
                    }
                    current.B_second.extra_b+=slice;
                }
                if (w_back)
                {
                    b = current.w_back.extra_b;
                    s = current.w_back.shotfrequency;
                    if (b > s)
                    {
                        current.w_back.extra_b -= s;
                        id = current.w_back.bulletid;
                        current.w_back.shot(ref buff_b_ex[id]);
                    }
                    current.w_back.extra_b+=slice;
                }
                else
                {
                    b = current.wing.extra_b;
                    s = current.wing.shotfrequency;
                    if (b > s)
                    {
                        current.wing.extra_b -= s;
                        id = current.wing.bulletid;
                        current.wing.shot(ref buff_b_ex[id]);
                    }
                    current.wing.extra_b+=slice;
                }
            }
            else
            {
                current.shiled.current += current.shiled.resume*3;
                if (current.shiled.current > current.shiled.max)
                {
                    current.shiled.current = current.shiled.max;
                    current.skill.energy_c += current.skill.energy_re;
                    if (current.skill.energy_c > current.skill.energy_max)
                        current.skill.energy_c = current.skill.energy_max;
                }
            }
        }
        static void LoadWarPlane()
        {
            hpid = CreateImage(null, blood_back);
            hpid2 = CreateImage(buff_img[hpid].transform, blood_g);
            buff_img[hpid2].spriterender.material = Mat_Blood;
            buff_img[hpid2].spriterender.material.SetFloat("_r", 1);

            blood_back.location.y -= 0.16f;
            spid = CreateImage(null, blood_back);
            spid2 = CreateImage(buff_img[spid].transform, blood_b);
            buff_img[spid2].spriterender.material = Mat_Blood;
            buff_img[spid2].spriterender.material.SetFloat("_r", 0);

            blood_back.location.y -= 0.16f;
            epid = CreateImage(null, blood_back);
            epid2 = CreateImage(buff_img[epid].transform, blood_y);
            buff_img[epid2].spriterender.material = Mat_Blood;
            buff_img[epid2].spriterender.material.SetFloat("_r", 0);
            blood_back.location.y += 0.32f;

            CreateWP(ref current.warplane);
            CreateWing(ref current.wing);
            skill_initial(ref current.skill);
            core_location = origion_location;
            wing_location = origion_location;

        }
        static void CreateWP(ref WarPlane wp)
        {
            if (wp.animat)
                wp_iid = CreateImgNullEx(wp_up2, 0);
            else wp_iid = CreateImgNullEx(wp_up, 0);
            int mat_id = wp.mat_id;
            Material mat = buff_mat[mat_id].mat;
            if (mat == null)
                mat = CreateMat(mat_id);
            buff_img_ex[wp_iid].mr.sortingOrder = 4;
            buff_img_ex[wp_iid].mr.material = mat;
            Mesh mesh = buff_img_ex[wp_iid].mesh;
            if (wp.animat)
            {
                int id = wp.ani_id;
                mesh.triangles = null;
                mesh.vertices = buff_ani[id].vertex;
                mesh.uv = buff_ani[id].uv;
                mesh.triangles = buff_ani[id].tri;
            }
            else
            {
                mesh.triangles = null;
                mesh.vertices = SP.v_def128;
                mesh.uv = wp.t_uv;
                mesh.triangles = SP.tri_def;
            }
        }
        static void CreateWing(ref Wing w)
        {
            if(w.update!=null)
                w_iid = CreateImgNullEx(w.update, w.ani_id);
            else
                w_iid = CreateImgNullEx(wing_up, w.ani_id);
            Mesh me = buff_img_ex[w_iid].mesh;
            me.triangles = null;
            me.vertices = w.abe.vertex;
            me.uv = w.abe.uv;
            me.triangles = w.abe.tri;
            Material mat = buff_mat[w.mat_id].mat;
            if (mat == null)
                mat = CreateMat(w.mat_id);
            buff_img_ex[w_iid].mr.material = mat;
        }
        static void ClearWarPlane()
        {
            RecycleImgEx(wp_iid);
            RecycleImgEx(w_iid);
            RecycleImgEx(current.skill.img_id);
            RecycleImgEx(bg_id);
            ClearImage(hpid);
            ClearImage(hpid2);
            ClearImage(epid);
            ClearImage(epid2);
            ClearImage(spid);
            ClearImage(spid2);
        }
        static void UpdateWingLocation()//and blood
        {
            buff_img[hpid2].spriterender.material.SetFloat("_r", current.warplane.currentblood / current.warplane.blood);
            buff_img[spid2].spriterender.material.SetFloat("_r", current.shiled.current / current.shiled.max);
            buff_img[epid2].spriterender.material.SetFloat("_r", current.skill.energy_c / current.skill.energy_max);
            buff_img[buff_button[4]].spriterender.material.SetFloat("_r", Big_boomaready *0.0000333f);
            buff_text[buff_button[6]].textmesh.text = "score:" + score.ToString();
        }
        static void PlanMove()//x 0.8-1.2 y-0.3
        {
            if (Big_boomaready > 0)
                Big_boomaready-=ts;
            float x = wing_location.x-core_location.x;
            float y = wing_location.y-core_location.y;
            float x1 = x > 0 ? x : -x;
            if(x1>0.02f)
            {
                if(x>0.3f)
                {
                    wing_location.x = core_location.x + 0.3f;
                }else if(x<-0.3f)
                {
                    wing_location.x = core_location.x - 0.3f;
                }
                else
                {
                    if (x < 0)
                        wing_location.x += 0.02f;
                    else wing_location.x -= 0.02f;
                }
            }
            float y2 = y > 0 ? y : -y;
            if(y2>0.02f)
            {
                if(y>0.3f)
                {
                    wing_location.y = core_location.y + 0.3f;
                }else if (y < -0.3f)
                {
                    wing_location.y = core_location.y - 0.3f;
                }
                else
                {
                    if (y < 0)
                        wing_location.y += 0.02f;
                    else wing_location.y -= 0.02f;
                }
            }
        }
        static void CalculateSkill()
        {
            if (buff_ani[current.skill.ani_id].c_time > 0)
            {
                //current.skill.during--;
                //if (current.skill.during < 0)
                //    current.skill.active = false;
                current.skill.energy_c -= current.skill.energy_ec;
                if (current.skill.energy_c < 0)
                {
                    Ani_Pause(current.skill.ani_id);
                }
                else if (current.skill.follow)
                {
                    current.skill.location = core_location;
                }
            }
            if (shiled_resume == 0)
            {
                current.shiled.current += current.shiled.resume;
                if (current.shiled.current > current.shiled.max)
                {
                    current.shiled.current = current.shiled.max;
                    current.skill.energy_c += current.skill.energy_re;
                    if (current.skill.energy_c > current.skill.energy_max)
                        current.skill.energy_c = current.skill.energy_max;
                }
            }
            else shiled_resume--;
            if (current.level == 3)
            {
                level4_during-=ts;
                if (level4_during <= 0)
                {
                    if (current.warplane.animat)
                        Ani_Run_D(1,current.warplane.ani_id);
                    DeGrade();
                }
            }
        }

        static int shiled_resume;
        static void Prop_Collider(int style)
        {
            if (style == 0)
                UpGrade();
            else
            if (style == 1)
            {
                current.warplane.currentblood += current.warplane.blood * 0.1f;
                if (current.warplane.currentblood > current.warplane.blood)
                    current.warplane.currentblood = current.warplane.blood;
            }
        }
        static void wp_up(ref ImageBaseEx ibe)
        {
            if(gameover)
            {
                ibe.gameobject.SetActive(false);
                ibe.restore = true;
            }
            else
            {
                ibe.transform.localPosition = core_location;
            }
        }
        static void wp_up2(ref ImageBaseEx ibe)
        {
            if (gameover)
            {
                ibe.gameobject.SetActive(false);
                ibe.restore = true;
            }else ibe.transform.localPosition = core_location;
            int id = current.warplane.ani_id;
            if (buff_ani[id].up_v)
            {
                buff_ani[id].up_v = false;
                Mesh m = ibe.mesh;
                m.vertices = buff_ani[id].vertex;
            }
        }
        static void wing_up(ref ImageBaseEx ibe)
        {
            int mid;
            ibe.transform.localPosition = wing_location;
            if (w_back)
            {
                
                if(w_change)
                {
                    mid = current.w_back.mat_id;
                    goto label1;
                }
            }
            else
            {
                if (w_change)
                {
                    mid = current.wing.mat_id;
                    goto label1;
                }
            }
            return;
            label1:;
            w_change = false;
            Material mat = buff_mat[mid].mat;
            if (mat == null)
            {
                mat = CreateMat(mid);
            }
        }
        public static void wing_up2(ref ImageBaseEx ibe)
        {
            int extra = ibe.extra;
            ibe.mesh.vertices = buff_ani[extra].vertex;
            ibe.transform.localPosition = wing_location;
        }
#endregion

#region skill update
        static void skill_initial(ref Skill s)
        {
            int id= s.img_id = CreateImgNullEx(s.update,s.ani_id);
            buff_img_ex[id].gameobject.SetActive(false);
            int mid = s.mat_id;
            Material mat = buff_mat[mid].mat;
            if (mat == null)
                mat = CreateMat(mid);
            buff_img_ex[id].mr.material = mat;
            Mesh me = buff_img_ex[id].mesh;
            me.triangles = null;
            id = s.ani_id;
            buff_ani[id].up_v = false;
            me.vertices = buff_ani[id].vertex;
            me.uv = buff_ani[id].uv;
            me.triangles = buff_ani[id].tri;
        }
        public static void sh_up(ref ImageBaseEx ibe)
        {
            int aid = ibe.extra;
            if(buff_ani[aid].up_v)
            {
                buff_ani[aid].up_v = false;
                ibe.gameobject.SetActive(true);
                ibe.transform.localPosition = core_location;
                Vector3 v = Vector3.zero;
                v.z = buff_ani[aid].ae[0].angle;
                ibe.transform.localEulerAngles = v;
            }
            else
            {
                ibe.gameobject.SetActive(false);
            }
        }
#endregion

#region demage //暂时改成无敌
        public static void DamageCalculateA(ref BulletPropertyEx bpe)
        {
            float harm = 0;
            if (current.shiled.current > 10)
            {
                harm = bpe.attack - current.shiled.defence;
                if (harm > 0)
                {
                    harm = 1;//删除此行
                    current.shiled.current -= harm;
                    if (current.shiled.current < 0)
                    {
                        current.warplane.currentblood += current.shiled.current;
                        current.shiled.current = 0;
                    }
                    shiled_resume = 100;
                }
            }
            else
            {
                current.warplane.currentblood -= bpe.attack;
                DeGrade();
            }
            if (current.warplane.currentblood <= 0)
                gameover = true;
        }
        static void DamageCalculateB(ref BulletPropertyEx bpe, ref EnemyBaseEX epe)
        {
            if (epe.c_blood < 0)
                return;
            float harm = bpe.attack - epe.defance;
            if (harm > 0)
            {
                epe.c_blood -= harm;
                if (epe.c_blood < 0)
                {
                    destory_enemy++;
                    if (bomb_count < 15)
                    {
                        bomb_queue[bomb_count] = epe.location;
                        bomb_count++;
                    }
                    generateA(10 + currentwave, epe.location);
                    score += epe.score;
                    if(!epe.boss)
                    Cry_create(epe.score,epe.location.x,epe.location.y);
                }
            }
        }
        static void DamageCalculateC()
        {
            current.warplane.currentblood -= 100;
            DeGrade();
            if (current.warplane.currentblood <= 0)
                gameover = true;
        }
#endregion

#region gamerun button
        static float Big_boomaready;
        static int[] buff_button = new int[7];
        
        static void loadgamebutton()
        {
            buff_button[0] = CreateCircleButton(null, skill_button);
            change_weapon.imagebase.location.y = -2.6f;
            change_weapon.property.click = ChangeSecondWeapon;
            change_weapon.text.text = change_bs[CanvasControl.Language];
            buff_button[1] = CreateEdgeButton(null, change_weapon);
            change_weapon.imagebase.location.y = -3.6f;
            change_weapon.property.click = ChangeWing;
            change_weapon.text.text = change_wing[CanvasControl.Language];
            buff_button[2] = CreateEdgeButton(null, change_weapon);
            buff_button[3] = CreateImage(null, big_boom_b);
            buff_button[4] = CreateImage(null, big_boom_f);
            buff_img[buff_button[4]].spriterender.material = Mat_fan;
            big_boom_button.transform = buff_img[buff_button[4]].transform;
            buff_button[5] = RegCircleButton(big_boom_button);
            buff_button[6] = CreateText(null,score_text);
        }
        static void unloadgamebutton()
        {
            DeleteCircleButton(buff_button[0]);
            DeleteEdgeButton(buff_button[1]);
            DeleteEdgeButton(buff_button[2]);
            ClearImage(buff_button[3]);
            ClearImage(buff_button[4]);
            UnRegCircleButton(buff_button[5]);
            RecycleText(buff_button[6]);
        }
        static void Skill_Click()
        {
            if(plane_move)
            {
                int id = current.skill.ani_id;
                if (buff_ani[id].c_time == 0 & current.skill.energy_c / current.skill.energy_max > 0.2f)
                {
                    Ani_Run_D(0, id);
                    current.skill.energy_c -= current.skill.energy_max * 0.2f;
                }
            }
        }
        static void BigBoom()//核弹攻击在此处改
        {
            if(plane_move)
            if (Big_boomaready <= 0)
            {
                Big_boomaready = 30000;
                MainCamera.v = true;
                Ani_Run_D(0,big_boom.ani_id);
            }
        }
        static void ChangeSecondWeapon()
        {
            if(plane_move)
            if(bs_back)
            {
                bs_back = false;
            }
            else
            {
                bs_back = true;
            }
        }
        static void ChangeWing()
        {
            if(plane_move)
            {
                if (w_back)
                {
                    w_back = false;
                    if (current.w_back.animat)
                    {
                        int aid = current.w_back.ani_id;
                        Ani_Pause(aid);
                    }
                    change_w(ref current.wing, ref buff_img_ex[w_iid]);
                }
                else
                {
                    w_back = true;
                    if (current.wing.animat)
                    {
                        int aid = current.wing.ani_id;
                        Ani_Pause(aid);
                    }
                    change_w(ref current.w_back, ref buff_img_ex[w_iid]);
                }
                w_change = true;
            }
        }
        static void change_w(ref Wing w,ref ImageBaseEx ibe)
        {
            int mid = w.mat_id;
            Material mat = buff_mat[mid].mat;
            if (mat == null)
                mat = CreateMat(mid);
            ibe.mr.material = mat;
            if (w.update != null)
                ibe.update = w.update;
            else ibe.update = wing_up;
            Mesh me = ibe.mesh;
            me.triangles = null;
            if (w.animat)
            {
                int aid = w.ani_id;
                ibe.extra = aid;
                me.vertices = buff_ani[aid].vertex;
                me.uv = buff_ani[aid].uv;
                me.triangles = buff_ani[aid].tri;
                Ani_Run_D(0,aid);
            }
            else
            {
                me.vertices = w.abe.vertex;
                me.uv = w.abe.uv;
                me.triangles = w.abe.tri;
            }
        }

#endregion

#region big boom
        static int bg_id;
        static Skill big_boom = new Skill() {attack=5, mat_name = mat_bb, abe = Ani.bigboom, location = new Vector3(0, 2, layer),  force_clear = true, r = 3f };
        static void bg_create()
        {
            bg_id = CreateImgNullEx(bg_update,big_boom.ani_id);
            buff_img_ex[bg_id].gameobject.SetActive(false);
            Material mat = CreateMat(big_boom.mat_id);
            buff_img_ex[bg_id].mr.material = mat;
        }
        static void bg_update(ref ImageBaseEx ibe)
        {
            int extra = ibe.extra;
            if( buff_ani[extra].up_v)
            {
                buff_ani[extra].up_v = false;
                ibe.gameobject.SetActive(true);
                Material mat = ibe.mr.material;
                mat.SetColor("_c",buff_ani[extra].col);
                Mesh me = ibe.mesh;
                if (me.triangles.Length != buff_ani[extra].tri.Length)
                {
                    ibe.transform.localPosition = big_boom.location;
                    me.triangles = null;
                    me.vertices = buff_ani[extra].vertex;
                    me.uv = buff_ani[extra].uv;
                    me.triangles = buff_ani[extra].tri;
                    return;
                }
                me.vertices = buff_ani[extra].vertex;
            }
            else
            {
                ibe.gameobject.SetActive(false);
            }
        }
#endregion

#region bomb ex
        static Vector3[] bomb_v3;
        static Vector2[] bomb_uv2;
        static int[] bomb_tri;
        static int[] bomb_state=new int[17];
        static int bomb_count;
        static Vector3[] bomb_queue = new Vector3[16];
        static void Bomb_Initial()
        {
            int id = CreateImgNullEx(Bomb_Update2, 0);
            bomb_state[16] = id;
            buff_img_ex[id].mr.material = CreateMat(mat_boom);
            buff_img_ex[id].gameobject.SetActive(false);
            bomb_v3 = new Vector3[64];
            bomb_uv2 = new Vector2[64];
            bomb_tri = new int[96];
            int index = 0;
            for (int c = 0; c < 96; c += 6)
            {
                bomb_tri[c] = index;
                bomb_tri[c + 1] = index + 1;
                bomb_tri[c + 2] = index + 2;
                bomb_tri[c + 3] = index;
                bomb_tri[c + 4] = index + 2;
                bomb_tri[c + 5] = index + 3;
                index += 4;
            }
        }
        static void Bomb_Update2(ref ImageBaseEx ibe)
        {
            ibe.gameobject.SetActive(true);
            ibe.mesh.vertices = bomb_v3;
            ibe.mesh.uv = bomb_uv2;
            ibe.mesh.triangles = bomb_tri;
        }
        static void Bomb_Update2A()
        {
            int t = 0;
            for(int i=0; i<16;i++)
            {
                if(bomb_state[i]>0xffff)
                {
                    int index = bomb_state[i] & 0xff;
                    if(index<31)
                    {
                        if(index%2==0)
                        {
                            index /= 2;
                            bomb_uv2[t] = SP.uv_def_4x4[index][0];
                            bomb_uv2[t + 1] = SP.uv_def_4x4[index][1];
                            bomb_uv2[t + 2] = SP.uv_def_4x4[index][2];
                            bomb_uv2[t + 3] = SP.uv_def_4x4[index][3];
                        }
                        bomb_state[i]++;
                        goto label1;
                    }
                    else
                    {
                        bomb_state[i] = 0;
                        bomb_v3[t] = Vector3.zero;
                        bomb_v3[t+1] = Vector3.zero;
                        bomb_v3[t+2] = Vector3.zero;
                        bomb_v3[t+3] = Vector3.zero;
                        bomb_state[i] = 0;
                    }
                }
                if (bomb_count > 0)
                {
                    bomb_count--;
                    float x = bomb_queue[bomb_count].x-0.5f;
                    float y = bomb_queue[bomb_count].y-0.5f;
                    float x1 = x +1;
                    float y1 = y +1f;
                    bomb_v3[t].x = x;
                    bomb_v3[t].y = y;
                    bomb_v3[t + 1].x = x;
                    bomb_v3[t + 1].y= y1;
                    bomb_v3[t + 2].x = x1;
                    bomb_v3[t + 2].y = y1;
                    bomb_v3[t + 3].x = x1;
                    bomb_v3[t + 3].y = y;
                    bomb_uv2[t] = SP.uv_def_4x4[0][0];
                    bomb_uv2[t + 1] = SP.uv_def_4x4[0][1];
                    bomb_uv2[t + 2] = SP.uv_def_4x4[0][2];
                    bomb_uv2[t + 3] = SP.uv_def_4x4[0][3];
                    bomb_state[i] = 0x10000;
                }
                label1:;
                t += 4;
            }
        }
        static void Bomb_Clear()
        {
            RecycleImgEx(bomb_state[16]);
        }
        #endregion


        #region laser cut
        static LaserProject lp;
        static bool lp_up;
        public static void Laser_Initial(ref BulletPropertyEx bpe)
        {
            lp = new LaserProject(bpe.t_uv);
        }
        public static void Laser_shot(ref BulletPropertyEx bpe)
        {
            float distance;
            if (current.level == 3)
                distance = 0.64f;
            else distance = 0.44f;
            Point2 location = new Point2(core_location.x, core_location.y);
            lp.SetLaser(bpe.edgepoints, location);
            for (int i = 0; i < 20; i++)
            {
                if (buff_enemy[i].move != null)
                {
                    if (buff_enemy[i].boss & buff_enemy[i].offset != null)
                    {
                        lp.ProjectRect(ref buff_enemy[i].offset, i);
                    }
                    else
                    {
                        if (buff_enemy[i].offset != null)
                        {
                            float d = location.x - buff_enemy[i].location.x;
                            if (d < 0)
                                d = -d;
                            if (d < distance)
                            {
                                d = location.y - buff_enemy[i].location.y;
                                if (d < 0)
                                    lp.ProjectRect(ref buff_enemy[i].offset, i);
                            }
                        }
                    }
                }
            }
            int count = 0;
            Point2T[] buff;
            count = lp.Complete(out buff);
            float len = bpe.edgepoints[2].x - bpe.edgepoints[0].x;
            float attck = bpe.attack;
            for (int i = 0; i < count; i++)
            {
                int tag = buff[i].tag;
                if (buff_enemy[tag].c_blood > 0)
                {
                    float at = buff[i].x / len * attck;
                    at -= buff_enemy[tag].defance;
                    if (at > 0)
                    {
                        buff_enemy[tag].c_blood -= at;
                        if (buff_enemy[tag].c_blood <= 0)
                        {
                            destory_enemy++;
                            if (bomb_count < 15)
                            {
                                bomb_queue[bomb_count] = buff_enemy[tag].location;
                                bomb_count++;
                            }
                            generateA(10 + currentwave, buff_enemy[tag].location);
                        }
                    }
                }
            }
            lp_up = true;
        }
        public static void Laser_Calculate(ref BulletPropertyEx bpe,ref BulletStateEx[] bse)
        {
            //if (!mousedown)
            //    return;
            //float distance;
            //if(current.level==3)
            //    distance = 0.64f;
            //else distance = 0.44f;
            //Point2 location = new Point2(core_location.x,core_location.y);
            //lp.SetLaser(bpe.edgepoints,location);
            //for(int i=0;i<20;i++)
            //{
            //    if(buff_enemy[i].move!=null)
            //    {
            //        if(buff_enemy[i].boss & buff_enemy[i].offset != null)
            //        {
            //            lp.ProjectRect(ref buff_enemy[i].offset, i);
            //        }
            //        else
            //        {
            //            if(buff_enemy[i].offset != null)
            //            {
            //                float d = location.x - buff_enemy[i].location.x;
            //                if (d < 0)
            //                    d = -d;
            //                if (d < distance)
            //                {
            //                    d = location.y - buff_enemy[i].location.y;
            //                    if (d < 0)
            //                        lp.ProjectRect(ref buff_enemy[i].offset, i);
            //                }
            //            }
            //        }
            //    }
            //}
            //int count = 0;
            //Point2T[] buff;
            //count= lp.Complete(out buff);
            //float len = bpe.edgepoints[2].x - bpe.edgepoints[0].x;
            //float attck = bpe.attack; 
            //for (int i=0;i<count;i++)
            //{
            //    int tag = buff[i].tag;
            //    if (buff_enemy[tag].c_blood > 0)
            //    {
            //        float at = buff[i].x / len * attck;
            //        at -= buff_enemy[tag].defance;
            //        if (at > 0)
            //        {
            //            buff_enemy[tag].c_blood -= at;
            //            if (buff_enemy[tag].c_blood <= 0)
            //            {
            //                destory_enemy++;
            //                if (bomb_count < 15)
            //                {
            //                    bomb_queue[bomb_count] = buff_enemy[tag].location;
            //                    bomb_count++;
            //                }
            //                generateA(10 + currentwave, buff_enemy[tag].location);
            //            }
            //        }
            //    } 
            //}
        }
        public static void Laser_Update(ref ImageBaseEx ibe)
        {
            if (lp_up)//& lp!=null
            {
                lp_up = false;
                int extra = ibe.extra;
                buff_b_ex[extra].a_count = 0;
                ibe.gameobject.SetActive(true);
                lp.UpdateMesh(ref ibe.mesh);
                if(buff_b_ex[extra].update)
                {
                    buff_b_ex[extra].update = false;
                    int mat_id = buff_b_ex[extra].mat_id;
                    Material mat = buff_mat[mat_id].mat;
                    if (mat == null)
                        mat = CreateMat(mat_id);
                    mat.SetFloat("_Speed", 40);
                    mat.SetFloat("_Miny", 0.06f);
                    mat.SetFloat("_Maxy", 0.86f);
                    ibe.mr.material = mat;
                }
            }
            else
            {
                ibe.gameobject.SetActive(false); 
            }
        }
        public static void Laser_Dispose()
        {
            lp.Dispose();
            lp = null;
            lp_up = false;
        }
#endregion

#region chain spore
        static int c_s;
        static float chain_at,c_speed;
        public static void Chain_Shot(ref BulletPropertyEx bpe)
        {
            int c = 0, i;
            for (i = 0; i < 256; i++)
            {
                if (!bpe.b_s[i].active)
                {
                    bpe.b_s[i].location = core_location;
                    bpe.b_s[i].active = true;
                    bpe.b_s[i].extra = 0;
                    bpe.b_s[i].extra_p = 0;
                    if (c == 0)
                    {
                        c++;
                        bpe.b_s[i].location.x -= 0.1f;
                        bpe.b_s[i].angle = 60;
                    }
                    else if (c == 1)
                    {
                        bpe.b_s[i].location.x += 0.1f;
                        bpe.b_s[i].angle = 300;
                        if (current.level < 3)
                            break;
                        c++;
                    }
                    else if (c == 2)
                    {
                        c++;
                        bpe.b_s[i].location.x -= 0.1f;
                        bpe.b_s[i].angle = 80;
                    }
                    else
                    {
                        bpe.b_s[i].location.x += 0.1f;
                        bpe.b_s[i].angle = 280;
                        break;
                    }
                }
            }
            if (i > bpe.max)
                bpe.max = i + 1;
            bpe.a_count = 2;
        }
        static int Chain_Multi(ref BulletPropertyEx bpe, int extra, int enemyid ,int start)
        {
            int index = start;
            float x = buff_enemy[enemyid].location.x;
            float y = buff_enemy[enemyid].location.y;
            for(int i=0;i<20;i++)
            {
                if (buff_enemy[i].c_blood>0)
                    if (i != enemyid)
                    {
                        float x1 = buff_enemy[i].location.x - x;
                        float y1 = buff_enemy[i].location.y - y;
                        float d = x1 * x1 + y1 * y1;
                        if (d < 10)
                        {
                            for (int c = index; c < 256; c++)
                            {
                                if (!bpe.b_s[c].active)
                                {
                                    bpe.b_s[c].active = true;
                                    int z = (int)Aim(ref buff_enemy[enemyid].location, ref buff_enemy[i].location);
                                    bpe.b_s[c].location = buff_enemy[enemyid].location;
                                    bpe.b_s[c].angle = z;
                                    bpe.b_s[c].extra = 25;
                                    bpe.b_s[c].extra2 = i;
                                    bpe.b_s[c].extra_p = extra;
                                    bpe.a_count++;
                                    index = c;
                                    chain_create(ref bpe.vertexs,ref bpe.uv_rect,ref buff_enemy[enemyid].location,z,index*4);
                                }
                            }
                        }
                    }
            }
            return index;
        }
        static void chain_create(ref Vector3[] v3, ref Point2[] uv_rect,ref Vector3 loca,int angle ,int s)
        {
            for(int i=0;i<4;i++)
            {
                int a = (int)uv_rect[i].x + angle;
                if (a >= 360)
                    a -= 360;
                v3[s].x = loca.x + angle_table[a].x * uv_rect[i].y;
                v3[s].y = loca.y + angle_table[a].y * uv_rect[i].y;
                s++;
            }
        }
        public static void Chain_Calcul(ref BulletPropertyEx bpe,ref BulletStateEx[] bse)
        {
            if (bpe.a_count == 0)
                return;
            float at = chain_at;
            at *= 5 + current.level;
            at /= 5;
            bpe.attack = at;
            c_s = 0;
            c_speed = bpe.speed * ts;
            bpe.a_count = 0;
            int offset = 0;
            for (int i = 0; i < bpe.max; i++)
            {
                chainmove(ref bpe, ref bse[i], offset);
                offset += 4;
            }
            if (c_s >= bpe.max)
                bpe.max = c_s + 1;
        }
        static void chainmove(ref BulletPropertyEx bpe, ref BulletStateEx bse,int ss)
        {
            if (bse.active)
            {
                float x = bse.location.x;
                float y = bse.location.y;
                if (y > 5.5f | y < -5.5f | x > 3.5f | x < -3.5f)
                {
                    goto label1;
                }
                if (bse.extra == 0)
                {
                    bse.extra2 = BulletMoveEx.LockEnemy(bse.location);
                    int z = bse.angle;
                    bse.movexyz.x = angle_table[z].x * c_speed;
                    bse.movexyz.y = angle_table[z].y * c_speed;
                }
                int index = bse.extra2;
                if (index >= 0 & bse.extra<300)
                {
                    if (buff_enemy[index].c_blood <= 0)
                    {
                        bse.extra2 = -1;
                        goto label2;
                    }
                    x -= buff_enemy[index].location.x;
                    y -= buff_enemy[index].location.y;
                    if (x * x + y * y < 0.3f)
                    {
                        int s = bse.extra_p;
                        if (s < 2 & c_s<255)
                            c_s = Chain_Multi(ref bpe, s + 1, index, c_s);
                        DamageCalculateB(ref bpe ,ref buff_enemy[index]);
                        CreateCollision(ref bse.location,0);
                        goto label1;
                    }
                    int a = (int)Aim(ref bse.location, ref buff_enemy[index].location);
                    int z = bse.angle;
                    int change = 5;
                    if (bse.extra > 25)
                        change = 10;
                    if (a > z)//顺时针
                    {
                        float b = a - z;//顺时针
                        if (b < change)
                        {
                            z = a;
                            goto label3;
                        }
                        float cc = 360 - a + z;
                        if (b > cc)
                        {
                            z -= change;
                        }
                        else
                        {
                            z += change;
                        }
                    }
                    else//逆时针
                    {
                        float b = z - a;//逆时针
                        if (b < change)
                        {
                            z = a;
                            goto label3;
                        }
                        float cc = 360 - z + a;
                        if (b > cc)
                        {
                            z += change;
                        }
                        else
                        {
                            z -= change;
                        }
                    }
                    if (z > 359)
                        z = 0;
                    if (z < 0)
                        z = 359;
                    label3:;
                    bse.angle = z;
                    bse.movexyz.x = angle_table[z].x * c_speed;
                    bse.movexyz.y = angle_table[z].y * c_speed;
                }
                label2:;
                if(bse.movexyz.x==0&bse.movexyz.y==0)
                {
                    int z=bse.angle;
                    bse.movexyz.x = angle_table[z].x * c_speed;
                    bse.movexyz.y = angle_table[z].y * c_speed;
                }
                float x1 = bse.location.x += bse.movexyz.x;
                float y1 = bse.location.y += bse.movexyz.y;
                bse.extra++;
                for (int c = 0; c < 4; c++)
                {
                    int a = (int)(bpe.uv_rect[c].x) + bse.angle;
                    if (a > 360)
                        a -= 360;
                    float d = bpe.uv_rect[c].y;
                    bpe.vertexs[ss].x = x1 + angle_table[a].x * d;
                    bpe.vertexs[ss].y = y1 + angle_table[a].y * d;
                    bpe.vertexs[ss].z = 1;
                    ss++;
                }
                bpe.a_count++;
            }
            return;
            label1:;
            bse.active = false;
            bse.extra = 0;
            bse.extra2 = -1;
            for (int c = 0; c < 4; c++)
            {
                bpe.vertexs[ss].x = 0;
                bpe.vertexs[ss].y = 0;
                ss++;
            }
        }
        public static void Chain_Initial(ref BulletPropertyEx bpe)
        {
            chain_at = bpe.attack;
#if unsafe
            unsafe
            {
                fixed (Vector2* v2=&bpe.uv[0])
                {
                    Vector2* v = v2;
                    Vector2[] v_r = bpe.t_uv;
                    for(int i=0;i<256;i++)
                    {
                        *v = v_r[0];
                        v++;
                        *v = v_r[1];
                        v++;
                        *v = v_r[2];
                        v++;
                        *v = v_r[3];
                        v++;
                    }
                }
            }
#endif
        }
#endregion

#region red alert 2 laser
        static float ra2l_at;
        static void ra2l_Demage(int enemyid,float attack)
        {
            if (buff_enemy[enemyid].c_blood < 1)
                return;
            float harm = attack - buff_enemy[enemyid].defance;
            if (harm > 0)
            {
                buff_enemy[enemyid].c_blood -= harm;
                if (buff_enemy[enemyid].c_blood <= 0)
                {
                    destory_enemy++;
                    if (bomb_count < 15)
                    {
                        bomb_queue[bomb_count] = buff_enemy[enemyid].location;
                        bomb_count++;
                    }
                    generateA(10 + currentwave, buff_enemy[enemyid].location);
                }
            }
        }
        public static void ra2l_Initial(ref BulletPropertyEx bpe)
        {
            ra2l_at = bpe.attack;
#if unsafe
            unsafe
            {
                fixed(Vector2* v2=&bpe.uv[0])
                {
                    Vector2* t = v2;
                    for(int i=0;i<40;i+=4)
                    {
                        t->x = 0;
                        t->y = 0;
                        t++;
                        t->x = 0;
                        t->y = 1;
                        t++;
                        t->x = 1;
                        t->y = 1;
                        t++;
                        t->x = 1;
                        t->y = 0;
                        t++;
                    }
                }
            }
#endif
        }
        public static void ra2l_calcul(ref BulletPropertyEx bpe,ref BulletStateEx[] bse)
        {
            if (bpe.speed >= 1)
                return;
            int c = bpe.extra;
            if (c > 45)
                return;
            if (c > 0 & c <= 45)
            {
                bpe.speed = (float)c / 45;
            }
            bpe.extra++;
        }
        public static void ra2l_shot(ref BulletPropertyEx bpe)
        {
            float x = wing_location.x-1;
            float y = wing_location.y;
            float x1 = wing_location.x+1;
            float d1 = 1000, d2 = 1000;
            int c1 = -1, c2 = -1,s=0;
            for (int i = 0; i < 20; i++)
            {
                if (buff_enemy[i].c_blood>0)
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
            if (c1 >= 0)
            {
                ra2l_Demage(c1, bpe.attack * 0.3f);
                ra2l_Demage(c2, bpe.attack * 0.3f);
                Vector3 v = new Vector3(x,y);
                ra2l_connect(ref v, ref buff_enemy[c1].location, ref bpe.vertexs, 0);
                v.x = x1;
                ra2l_connect(ref v, ref buff_enemy[c2].location, ref bpe.vertexs, 4);
                s = 8;
                s = ra2l_reflect(ref bpe.vertexs,c1, s);
                s = ra2l_reflect(ref bpe.vertexs,c2, s);
            }
            bpe.extra = 0;
            bpe.speed = 0;
            bpe.max = s / 4;
        }
        static int ra2l_reflect(ref Vector3[] v3, int id ,int s)
        {
            float x = buff_enemy[id].location.x;
            float y = buff_enemy[id].location.y;
            for(int i=0;i<20;i++)
            {
                if(i!=id)
                {
                    if (buff_enemy[i].c_blood>0)
                    {
                        float xx = buff_enemy[i].location.x - x;
                        float yy = buff_enemy[i].location.y - y;
                        float dd = xx * xx + yy * yy;
                        if (dd<10)
                        {
                            ra2l_Demage(i, ra2l_at * 0.3f);
                            ra2l_connect(ref buff_enemy[id].location,ref buff_enemy[i].location,ref v3,s);
                            s+=4;
                        }
                    }
                }
            }
            return s;
        }
        public static void Updatera2l(ref ImageBaseEx ibe)
        {
            int extra = ibe.extra;
            if (buff_b_ex[extra].speed < 1)
            {
                int len = buff_b_ex[extra].max;
                if (len == 0)
                    return;
                ibe.gameobject.SetActive(true);
                ibe.mr.material.SetFloat("_Alpha", buff_b_ex[extra].speed);
                Mesh mesh = ibe.mesh;
                int vl = len * 4;
                int il = len * 6;
                
                if (il != mesh.triangles.Length)
                {
                    mesh.triangles = null;
                    Vector3[] tv = new Vector3[vl];
                    for (int i = 0; i < vl; i++)
                        tv[i] = buff_b_ex[extra].vertexs[i];
                    mesh.vertices = tv;
                    Vector2[] tu = new Vector2[vl];
                    for (int i = 0; i < vl; i++)
                        tu[i] = buff_b_ex[extra].uv[i];
                    mesh.uv = tu;
                    int[] tr = new int[il];
                    for (int i = 0; i < il; i++)
                        tr[i] = tri_256[i];
                    mesh.triangles = tr;
                }
                else
                {
                    Vector3[] tv = new Vector3[vl];
                    for (int i = 0; i < vl; i++)
                        tv[i] = buff_b_ex[extra].vertexs[i];
                    mesh.vertices = tv;
                    Vector2[] tu = new Vector2[vl];
                    for (int i = 0; i < vl; i++)
                        tu[i] = buff_b_ex[extra].uv[i];
                    mesh.uv = tu;
                }

//#if unsafe
//                unsafe
//                {
//                    fixed (Vector3* vp = &buff_b_ex[extra].vertexs[0])
//                    {
//                        fixed (Vector2* up = &buff_b_ex[extra].uv[0])
//                        {
//                            fixed (int* ip = &tri_256[0])
//                            {
//                                int* ivp = (int*)vp;
//                                int* iup = (int*)up;
//                                int* iip = ip;
//#if x64
//                                ivp -= 2;
//                                iup -= 2;
//                                iip -= 2;
//#else
//                                ivp--;
//                                iup--;
//                                iip--;
//#endif
//                                *ivp = vl;
//                                *iup = vl;
//                                if (il != mesh.triangles.Length)
//                                {
//                                    *iip = il;
//                                    mesh.triangles = null;
//                                    mesh.vertices = buff_b_ex[extra].vertexs;
//                                    mesh.uv = buff_b_ex[extra].uv;
//                                    mesh.triangles = tri_256;
//                                    *iip = 1536;
//                                }
//                                else
//                                {
//                                    mesh.vertices = buff_b_ex[extra].vertexs;
//                                    mesh.uv = buff_b_ex[extra].uv;
//                                }
//                                *ivp = 1024;
//                                *iup = 1024;
//                            }
//                        }
//                    }
//                }
//#endif 
                if (buff_b_ex[extra].update)
                {
                    buff_b_ex[extra].update = false;
                    int mat_id = buff_b_ex[extra].mat_id;
                    Material mat = buff_mat[mat_id].mat;
                    if (mat == null)
                        mat = CreateMat(mat_id);
                    ibe.mr.material = mat;
                }
            }
            else
            {
                ibe.gameobject.SetActive(false);
            }
        }
        static void ra2l_connect(ref Vector3 l1,ref Vector3 l2,ref Vector3[] v3,int offset)
        {
            int a =(int) Aim(ref l1,ref l2)+90;
            if (a >= 360)
                a -= 360;
            float x = angle_table[a].x * 0.1015625f;
            float y = angle_table[a].y * 0.1015625f;
            v3[offset].x = l1.x + x;
            v3[offset].y = l1.y + y;
            offset++;
            v3[offset].x = l2.x + x;
            v3[offset].y = l2.y + y;
            offset++;
            a+=180;
            if (a >= 360)
                a -= 360;
            x = angle_table[a].x * 0.1015625f;
            y = angle_table[a].y * 0.1015625f;
            v3[offset].x = l2.x + x;
            v3[offset].y = l2.y + y;
            offset++;
            v3[offset].x = l1.x + x;
            v3[offset].y = l1.y + y;
        }
#endregion

#region moth laser
        static int[] laser02_tri = new int[] { 0, 1, 2, 0, 2, 3, 4, 5, 8, 4, 8, 9, 5, 6, 7, 5, 7, 8 };
        static Vector4 v4A = Vector4.one;
        static Vector4 v4B = Vector4.one;
        static void laser02_inital(ref Vector3[] v3)
        {
            for (int i = 0; i < 10; i++)
            {
                v3[i] = Vector3.zero;
            }
            v4A = Vector4.one;
            v4B = v4A;
        }
        internal static void CaculLaser02(ref BulletPropertyEx bpe, ref BulletStateEx[] bse)
        {
            if (bpe.s_count > 0)
            {
                bpe.s_count = 0;
                bpe.a_count = 1;
                bpe.extra = 0;
                laser02_inital(ref bpe.vertexs);
            }
            else if (bpe.a_count > 0)
            {
                bpe.extra += ts;
                float ratio = (float)bpe.extra / 2000f;
                if (ratio > 1)
                {
                    bpe.a_count = 0;
                    return;
                }
                insA(ratio);
                float x, y;
                int id = bpe.parentid;
                x = buff_enemy[id].location.x;
                y = buff_enemy[id].location.y - 0.76f;
                if (ratio > 0.26f)
                {
                    insB(ratio);
                    laser_stageC(ref bpe.vertexs, x, y);
                    if (laser_collison(x, y, 0.3984f, 8))
                        DamageCalculateA(ref bpe);
                }
                else
                {
                    float x1, y1, y2;
                    if (ratio > 0.2f)//x=0.609 y1=8
                    {
                        y2 = ratio * 3.68f;
                        x1 = x + y2;
                        y1 = y + 0.25f;
                        laser_stageA(ref bpe.vertexs, x - y2, y - 0.25f, x1, y1);
                        y2 = ratio - 0.2f;
                        y2 *= 124;
                        laser_stageB(ref bpe.vertexs, x, y, y2);
                        if (laser_collison(x, y, 0.3984f,y2))
                            DamageCalculateA(ref bpe);
                    }
                    else//max x=0.2 y=0.25
                    {
                        y2 = ratio * 1.015625f;
                        x1 = x + y2;
                        x -= y2;
                        y2 = ratio * 1.25f;
                        y1 = y + y2;
                        y -= y2;
                        laser_stageA(ref bpe.vertexs, x, y, x1, y1);
                    }
                }
            }
        }
        static void insA(float ca)
        {
            if (ca > 0.5f)
            {
                float t = ca - 0.5f;
                v4A.x = 1 - t * 2f;
                v4A.w = 1 - t * 2f;
            }
            else
            if (ca > 0.33f)
            {
                float t = ca - 0.33f;
                v4A.x = 1 - t * 2.75f;
                v4A.y = 1 - t * 5.5f;
                v4A.z = 1 - t * 5.5f;
            }
            else if (ca > 0.2f)
            {
                float t = ca - 0.2f;
                v4A.x = 2 - t * 7.5f;
                v4A.y = 2 - t * 7.5f;
                v4A.z = 2 - t * 7.5f;
            }
            else
            {
                v4A.x = 1 + ca * 5f;
                v4A.y = 1 + ca * 5f;
                v4A.z = 1 + ca * 5f;
            }
        }
        static void insB(float ca)
        {
            if (ca > 0.86f)
            {
                float t = ca - 0.86f;
                v4B.x = 1 - t * 7.14f;
                v4B.w = 1 - t * 7.14f;
            }
            else if (ca > 0.53f)
            {
                float t = ca - 0.53f;
                v4B.x = 2 - t * 3.33f;
                v4B.y = 2 - t * 5f;
                v4B.z = 2 - t * 5f;
            }
            else
            {
                v4B.x = 1 + ca * 5f;
                v4B.y = 1 + ca * 5f;
                v4B.z = 1 + ca * 5f;
            }
        }
        static void laser_stageA(ref Vector3[] v3, float x, float y, float x1, float y1)
        {
            v3[0].x = x;
            v3[0].y = y;
            v3[1].x = x;
            v3[1].y = y1;
            v3[2].x = x1;
            v3[2].y = y1;
            v3[3].x = x1;
            v3[3].y = y;
        }
        static void laser_stageB(ref Vector3[] v3, float x, float y, float len)
        {
            float x1 = x + 0.6094f;
            x -= 0.6094f;
            float y1 = y - 0.6f;
            v3[6].x = x;
            v3[6].y = y;
            v3[7].x = x1;
            v3[7].y = y;
            v3[5].x = x;
            v3[5].y = y1;
            v3[8].x = x1;
            v3[8].y = y1;
            if (len > 0.6f)
            {
                y1 = y - len;
                v3[4].x = x;
                v3[4].y = y1;
                v3[9].x = x1;
                v3[9].y = y1;
            }
        }
        static void laser_stageC(ref Vector3[] v3, float lx, float ly)
        {
            float x = lx - 0.6094f;
            float x1 = lx + 0.6094f;
            float y = ly - 0.25f;
            float y1 = ly + 0.25f;
            v3[0].x = x;
            v3[0].y = y;
            v3[1].x = x;
            v3[1].y = y1;
            v3[2].x = x1;
            v3[2].y = y1;
            v3[3].x = x1;
            v3[3].y = y;
            y1 = ly - 0.6f;
            v3[6].x = x;
            v3[6].y = ly;
            v3[7].x = x1;
            v3[7].y = ly;
            v3[5].x = x;
            v3[5].y = y1;
            v3[8].x = x1;
            v3[8].y = y1;
            y1 = ly - 8;
            v3[4].x = x;
            v3[4].y = y1;
            v3[9].x = x1;
            v3[9].y = y1;
        }
        static bool laser_collison(float x, float y, float w ,float h)
        {
            float x1 = x + w;
            x -= w;
            float y1 = y - h;
            if (area)
            {
                Point2[] tp = new Point2[4];
                tp[0].x = x;
                tp[0].y = y1;
                tp[1].x = x;
                tp[1].y = y;
                tp[2].x = x1;
                tp[2].y = y;
                tp[3].x = x1;
                tp[3].y = y1;
                if (PToP2(tp, areapoints))
                    return true;
            }
            else
            {
                x -= 0.02f;
                x1 += 0.02f;
                float a = core_location.x;
                float b = core_location.y;
                if (a >= x & a <= x1)
                    if (b >= y1 & b <= y)
                        return true;
            }
            return false;
        }
        public static void Laser02_update(ref ImageBaseEx ibe)
        {
            int extra = ibe.extra;
            if (buff_b_ex[extra].a_count > 0)
            {
                ibe.gameobject.SetActive(true);
                Mesh mesh = ibe.mesh;
                if (buff_b_ex[extra].update)
                    mesh.triangles = null;
                Vector3[] tv = new Vector3[10];
                for (int i = 0; i < 10; i++)
                    tv[i] = buff_b_ex[extra].vertexs[i];
                mesh.vertices = tv;
//#if unsafe
//                unsafe
//                {
//                    fixed (Vector3* vp = &buff_b_ex[extra].vertexs[0])
//                    {
//                        int* ivp = (int*)vp;
//#if x86
//                        ivp --;
//#else
//                            ivp-=2;
//#endif
//                        *ivp = 10;
//                        mesh.vertices = buff_b_ex[extra].vertexs;
//                        *ivp = 1024;
//                    }
//                }
//#endif 
                if (buff_b_ex[extra].update)
                {
                    buff_b_ex[extra].update = false;
                    int mat_id = buff_b_ex[extra].mat_id;
                    Material mat = buff_mat[mat_id].mat;
                    if (mat == null)
                        mat = CreateMat(mat_id);
                    ibe.mr.material = mat;
                    mesh.uv = buff_b_ex[extra].t_uv;
                    mesh.triangles = laser02_tri;
                }
                else
                {
                    Material mat = ibe.mr.material;
                    mat.SetVector("_V1", v4A);
                    mat.SetVector("_V2", v4B);
                }
            }
            else
            {
                ibe.gameobject.SetActive(false);
            }
        }
        #endregion

        #region huijin lasesr
        static int[] laser04_tri=GetTri(4) ;
        static Vector3[] ls04_v3=new Vector3[16];
        static Vector2[] ls04_uv=new Vector2[16];
        static void ls04_insV(ref Vector3[] v3,float x,float y ,int s)
        {
            float x1 = x - 0.5f;
            x += 0.5f;
            float y1 = y - 8;
            v3[s].x = x1;
            v3[s].y = y1;
            s++;
            v3[s].x = x1;
            v3[s].y = y;
            s++;
            v3[s].x = x;
            v3[s].y = y;
            s++;
            v3[s].x = x;
            v3[s].y = y1;
            s++;
            y -= 0.4f;
            v3[s].x = x1;
            v3[s].y = y1;
            s++;
            v3[s].x = x1;
            v3[s].y = y;
            s++;
            v3[s].x = x;
            v3[s].y = y;
            s++;
            v3[s].x = x;
            v3[s].y = y1;
        }
        static void ls04_insUV(ref Vector2[] uv, int s)
        {
            for (int c = 0; c < 4; c++)
            {
                uv[s] = SP.uv_def_8x1[0][c];
                s++;
            }
            for (int c = 0; c < 4; c++)
            {
                uv[s] = SP.uv_def_8x1[3][c];
                s++;
            }
        }
        static void  ls04_insUV(ref Vector2[] uv,int s,int id)
        {
            int t = id  + 3;
            for (int c = 0; c < 4; c++)
            {
                uv[s] = SP.uv_def_8x1[t][c];
                s++;
            }  
        }
        public static void CaculLaser04(ref BulletPropertyEx bpe,ref BulletStateEx[] bse)
        {
            if (bpe.s_count > 0)
            {
                bpe.s_count = 0;
                bpe.a_count = 1;
                bpe.extra = 0;
                bse[1].extra = 0;
                bse[3].extra = 0;
                ls04_insV(ref ls04_v3,bse[0].location.x,bse[0].location.y,0);
                ls04_insV(ref ls04_v3, bse[2].location.x, bse[2].location.y, 8);
                ls04_insUV(ref ls04_uv,0);
                ls04_insUV(ref ls04_uv,8);
            }
            else if (bpe.a_count > 0)
            {
                bpe.extra += ts;
                if(bpe.extra>1500)
                {
                    bpe.extra = 0;
                    bpe.a_count = 0;
                    return;
                }
                int i = 1;
                label1:;
                bse[i].extra++;
                if(bse[i].extra>19)
                {
                    bse[i].extra = 0;
                }
                if(bse[i].extra%5==0)
                {
                    int c = bse[i].extra / 5;
                    if(i>2)
                        ls04_insUV(ref ls04_uv, 12, c);
                    else
                    ls04_insUV(ref ls04_uv,4,c);
                }
                i += 2;
                if (i < 4)
                    goto label1;
                if( laser_collison(bse[0].location.x,bse[0].location.y,0.25f,8))
                    DamageCalculateA(ref bpe);
                if( laser_collison(bse[2].location.x, bse[2].location.y, 0.25f, 8))
                    DamageCalculateA(ref bpe);
            }
        }
        public static void Laser04_update(ref ImageBaseEx ibe)
        {
            int extra = ibe.extra;
            if (buff_b_ex[extra].a_count > 0)
            {
                ibe.gameobject.SetActive(true);
                Mesh mesh = ibe.mesh;
                if (buff_b_ex[extra].update)
                {
                    mesh.triangles = null;
                    buff_b_ex[extra].update = false;
                    int mat_id = buff_b_ex[extra].mat_id;
                    Material mat = buff_mat[mat_id].mat;
                    if (mat == null)
                        mat = CreateMat(mat_id);
                    ibe.mr.material = mat;
                    mesh.vertices = ls04_v3;
                    mesh.uv = ls04_uv;
                    mesh.triangles = laser04_tri;
                    return;
                }
                mesh.vertices = ls04_v3;
                mesh.uv = ls04_uv;
            }
            else
            {
                ibe.gameobject.SetActive(false);
            }
        }
        #endregion

        #region enemyA
        static Vector3 boss_v = Vector3.zero;
        static int boss_state=0;
        static int a10_extra=0;
        static void Boss_Move(ref Vector3 v)
        {
            if (v.x > 0.8f)
            {
                boss_v.x = -0.01f - (float)lucky.NextDouble() * 0.01f;
            }
            if (v.x < -0.8f)
            {
                boss_v.x = 0.01f + (float)lucky.NextDouble() * 0.01f;
            }
            if (v.y > 4f)
            {
                boss_v.y = -0.01f - (float)lucky.NextDouble() * 0.01f;
                if (boss_v.x == 0)
                    boss_v.x = -0.02f + (float)lucky.NextDouble() * 0.04f;
            }
            if (v.y < 2.6f)
            {
                boss_v.y = 0.02f + (float)lucky.NextDouble() * 0.04f;
                if (boss_v.x == 0)
                    boss_v.x = -0.01f + (float)lucky.NextDouble() * 0.01f;
            }
        }
        public static bool M_a10(ref EnemyBaseEX ebe)
        {
            if (ebe.extra_m < 100)
            {
                ebe.extra_m++;
                ebe.location.y -= 0.05f;
                return true;
            }
            else//mov
            {
                if (ebe.extra_m == 100)
                {
                    ebe.extra_m++;
                    boss_v.x = -0.02f - (float)lucky.NextDouble() / 50;
                    boss_v.y = 0.02f + (float)lucky.NextDouble() / 50;
                }
            }
            int eid;
            float x = ebe.location.x;
            float y = ebe.location.y;
            switch (boss_state)
            {                
                case 0:
                    {                       
                        if (ebe.extra_b > 2)
                        {
                            ebe.extra_b = 0;
                            eid = ebe.extra_a & 1;
                            eid = ebe.bulletid[eid];
                            y += 0.5f;
                            float z = a10_extra;
                            Point3[] pt = new Point3[5];
                            for (int i = 0; i < 5; i++)
                            {
                                pt[i]= new Point3(x,y,z);
                                z += 72;
                            }
                            buff_b_ex[eid].shotpoint = pt;
                            buff_b_ex[eid].s_count = 5;
                            if (ebe.extra_a < 16)
                            {
                                a10_extra += 5;
                                if (ebe.extra_a == 8)
                                    a10_extra = 0;
                                if (ebe.extra_a == 15)
                                {
                                    //buff_enemy[id].extra_b = -10;
                                    a10_extra = 60;
                                }
                            }
                            else
                            {
                                a10_extra -= 5;
                                if (ebe.extra_a ==24)
                                    a10_extra = 60;
                                if (ebe.extra_a >= 31)
                                {
                                    a10_extra = 0;
                                    ebe.extra_a = 0;
                                    ebe.extra_b = -100;
                                    boss_state = 1;
                                    break;
                                }
                            }
                            ebe.extra_a++;
                        }
                        break;
                    }
                case 1:
                    {
                        if (ebe.extra_b > 20)
                        {
                            ebe.extra_b = -50;
                            eid = ebe.bulletid[2];
                            x -= 0.3f;
                            y -= 0.5f;            
                            float z = 156;
                            Point3[] pt = new Point3[5];
                            for (int i=0;i<5;i++)
                            {
                                pt[i] = new Point3(x,y,z);
                                x += 0.1f;
                                z += 12;
                            }
                            buff_b_ex[eid].shotpoint = pt;
                            buff_b_ex[eid].s_count = 5;
                            boss_state =2;
                        }
                        break;
                    }
                case 2:
                    {
                        Boss_Move(ref ebe.location);
                        ebe.location += boss_v;
                        if (ebe.extra_b>8)
                        {
                            eid = ebe.bulletid[0];
                            float z = Aim(ref ebe.location, ref core_location);
                            y -= 1f;
                            z -= 30;
                            if (z < 0)
                                z += 360;
                            Point3[] pt = new Point3[6];
                            for (int i = 0; i < 6; i++)
                            {
                                pt[i] = new Point3(x,y,z);
                                z += 10;
                                if (z > 360)
                                    z -= 360;
                            }
                            buff_b_ex[eid].shotpoint = pt;
                            buff_b_ex[eid].s_count = 6;
                            ebe.extra_b = 0;
                            ebe.extra_a++;
                            if(ebe.extra_a>12)
                            {
                                ebe.extra_a = 0;
                                boss_state = 3;
                            }
                        }                       
                        break;
                    }
                case 3:
                    { 
                        if(ebe.extra_b>2)
                        {
                            if(ebe.extra_a==0)
                            {
                                a10_extra = 0;
                            }
                            if ((ebe.extra_a & 8) == 0)
                                a10_extra += 5;
                            else a10_extra -= 5;
                            eid = ebe.bulletid[1];
                            y -= 1f;
                            buff_b_ex[eid].shotpoint = new Point3[] {new Point3(x,y,180+a10_extra) , new Point3(x, y, 180 - a10_extra) };
                            buff_b_ex[eid].s_count = 2;
                            ebe.extra_b = 0;
                            ebe.extra_a++;
                            if (ebe.extra_a > 36)
                            {
                                ebe.extra_a = 0;
                                boss_state = 4;
                            }
                        }
                        break;
                    }
                case 4:
                    if (ebe.extra_b > 30)
                    {
                        ebe.extra_b = 0;
                        int bid = ebe.bulletid[3];
                        if (ebe.extra_a >= 10)
                            ShotBullet.Angle6_RotateA(ref buff_b_ex[bid], ref ebe.location, ref ebe.extra_b);
                        else
                            ShotBullet.Angle6_Rotate(ref buff_b_ex[bid], ref ebe.location, ref ebe.extra_b);
                        ebe.extra_a++;
                        if (ebe.extra_a >= 20)
                        {
                            ebe.extra_a = 0;
                            boss_state = 0;
                            ebe.extra_b = -600;
                            buff_b_ex[bid].extra = 0;
                        }
                    }
                    break;
            }           
            ebe.extra_b+=ts;
            return true;
        }
        public static bool M_Moth(ref EnemyBaseEX ebe)
        {
            if(ebe.c_blood/ebe.f_blood<=0.5f)
            {
                Ani_Run_D(0,ebe.ani_id);
                ebe.move = M_MothA;
                ebe.points = SP.p_mothB;
                return true;
            }
            if (ebe.extra_m < 200)
            {
                ebe.extra_m++;
                ebe.location.y -= 0.015f;
                return true;
            }
            else//mov
            {
                if (ebe.extra_m == 200)
                {
                    ebe.extra_m++;
                    boss_v.x = -0.01f - (float)lucky.NextDouble() *0.01f;
                    boss_v.y = 0.01f + (float)lucky.NextDouble() * 0.01f;
                    ebe.extra_a = lucky.Next(0, 4);
                }
            }
            ebe.extra_b += ts;
            switch (ebe.extra_a)
            {
                case 0:
                    Boss_Move(ref ebe.location);
                    ebe.location += boss_v;
                    if(ebe.extra_b>0)
                    {
                        int bid = ebe.bulletid[0];
                        buff_b_ex[bid].move = BulletMoveEx.Parabola;
                        ShotBullet.Parabola(ref buff_b_ex[bid], ref ebe.location,ref ebe.extra_b);
                        if (ebe.extra_b < 0)
                        {
                            ebe.extra_a = lucky.Next(0, 6);
                            ebe.extra_b = -500;
                        }
                    }
                    break;
                case 1:
                    if (ebe.extra_b > 100)
                    {
                        ebe.extra_b = 0;
                        int bid = ebe.bulletid[4];
                        buff_b_ex[bid].move = null;
                        buff_b_ex[bid].speed = 0.003f;
                        ShotBullet.Sharp_V(ref buff_b_ex[bid], ref ebe.location, ref ebe.extra_b);
                        if (ebe.extra_b < 0)
                        {
                            ebe.extra_a = lucky.Next(0, 6);
                            ebe.extra_b = -500;
                        }
                    }
                    break;
                case 2:
                    Boss_Move(ref ebe.location);
                    ebe.location += boss_v;
                    if (ebe.extra_b > 60)
                    {
                        ebe.extra_b = 0;
                        int bid = ebe.bulletid[2];
                        buff_b_ex[bid].move = null;
                        buff_b_ex[bid].t_uv = SP.uv_def_3x1[1];
                        ShotBullet.ThreeBeline20(ref buff_b_ex[bid], ref ebe.location, ref ebe.extra_b);
                        if (ebe.extra_b < 0)
                        {
                            ebe.extra_a = lucky.Next(0, 6);
                            ebe.extra_b = -400;
                        }
                    }
                    break;
                case 3:
                    if (ebe.extra_b > 60)
                    {
                        ebe.extra_b = 0;
                        int bid = ebe.bulletid[3];
                        buff_b_ex[bid].move = null;
                        buff_b_ex[bid].t_uv = SP.uv_def_3x1[0];
                        ShotBullet.Rotate_right(ref buff_b_ex[bid], ref ebe.location, ref ebe.extra_b);
                        if (ebe.extra_b < 0)
                        {
                            ebe.extra_a = lucky.Next(0, 6);
                            ebe.extra_b = -500;
                        }
                    }
                    break;
                case 4:
                    if (ebe.extra_b > 60)
                    {
                        ebe.extra_b = 0;
                        int bid = ebe.bulletid[2];
                        buff_b_ex[bid].move = null;
                        buff_b_ex[bid].t_uv = SP.uv_def_3x1[0];
                        ShotBullet.Rotate_left(ref buff_b_ex[bid], ref ebe.location, ref ebe.extra_b);
                        if (ebe.extra_b < 0)
                        {
                            ebe.extra_a = lucky.Next(0, 6);
                            ebe.extra_b = -500;
                        }
                    }
                    break;
                default:
                    int id5 = ebe.bulletid[5];
                    if (ebe.extra_b > 0)
                    {
                        buff_b_ex[id5].s_count = 1;
                        ebe.extra_b = -800;
                        ebe.extra_a = lucky.Next(0, 4);
                    }
                    break;
            }
            return true;
        }
        static bool M_MothA(ref EnemyBaseEX ebe)
        {
            ebe.extra_b += ts;
            switch (ebe.extra_a)
            {
                case 0:
                    Boss_Move(ref ebe.location);
                    ebe.location += boss_v;
                    if (ebe.extra_b > 200)
                    {
                        ebe.extra_b =0;
                        int bid = ebe.bulletid[4];
                        buff_b_ex[bid].move = null;
                        ShotBullet.Random(ref buff_b_ex[bid], ref ebe.location, ref ebe.extra_b);
                        if (ebe.extra_b < 0)
                        {
                            ebe.extra_a = lucky.Next(0, 6);
                            ebe.extra_b = -500;
                        }
                    }
                    break;
                case 1:
                    if (ebe.extra_b > 100)
                    {
                        ebe.extra_b = 0;
                        int bid = ebe.bulletid[4];
                        buff_b_ex[bid].move = null;
                        buff_b_ex[bid].speed = 0.003f;
                        ShotBullet.Sharp_O(ref buff_b_ex[bid], ref ebe.location, ref ebe.extra_b);
                        if (ebe.extra_b < 0)
                        {
                            ebe.extra_a = lucky.Next(0, 6);
                            ebe.extra_b = -500;
                        }
                    }
                    break;
                case 2:
                    Boss_Move(ref ebe.location);
                    ebe.location += boss_v;
                    if (ebe.extra_b > 60)
                    {
                        ebe.extra_b = 0;
                        int bid = ebe.bulletid[2];
                        buff_b_ex[bid].move = null;
                        buff_b_ex[bid].t_uv = SP.uv_def_3x1[1];
                        ShotBullet.MultiBeline(ref buff_b_ex[bid], ref ebe.location, ref ebe.extra_b);
                        if (ebe.extra_b < 0)
                        {
                            ebe.extra_a = lucky.Next(0, 6);
                            ebe.extra_b = -800;
                        }
                    }
                    break;
                case 3:
                    if (ebe.extra_b > 60)
                    {
                        ebe.extra_b = 0;
                        int bid = ebe.bulletid[3];
                        buff_b_ex[bid].move = null;
                        buff_b_ex[bid].t_uv = SP.uv_def_3x1[0];
                        ShotBullet.Rotate_right(ref buff_b_ex[bid], ref ebe.location, ref ebe.extra_b);
                        if (ebe.extra_b < 0)
                        {
                            ebe.extra_a = lucky.Next(0, 6);
                            ebe.extra_b = -500;
                        }
                    }
                    break;
                case 4:
                    if (ebe.extra_b > 60)
                    {
                        ebe.extra_b = 0;
                        int bid = ebe.bulletid[2];
                        buff_b_ex[bid].move = null;
                        buff_b_ex[bid].t_uv = SP.uv_def_3x1[0];
                        ShotBullet.Rotate_left(ref buff_b_ex[bid], ref ebe.location, ref ebe.extra_b);
                        if (ebe.extra_b < 0)
                        {
                            ebe.extra_a = lucky.Next(0, 6);
                            ebe.extra_b = -500;
                        }
                    }
                    break;
                default:
                    int id5 = ebe.bulletid[5];
                    if (ebe.extra_b > 0)
                    {
                        buff_b_ex[id5].s_count = 1;
                        ebe.extra_b = -800;
                        ebe.extra_a = lucky.Next(0, 4);
                    }
                    break;
            }
            return true;
        }
        public static bool M_huijin(ref EnemyBaseEX ebe)
        {
            if (ebe.c_blood / ebe.f_blood <= 0.5f)
            {
                Ani_Run_D(0, ebe.ani_id);
                ebe.move = M_huijinA;
                ebe.points = SP.p_hjB;
                return true;
            }
            ebe.extra_b += ts;
            if (ebe.extra_m < 200)
            {
                ebe.extra_m++;
                ebe.location.y -= 0.015f;
                return true;
            }
            else//mov
            {
                if (ebe.extra_m == 200)
                {
                    ebe.extra_m++;
                    boss_v.x = -0.01f - (float)lucky.NextDouble() * 0.01f;
                    boss_v.y = 0.01f + (float)lucky.NextDouble() * 0.01f;
                    //ebe.extra_a = lucky.Next(0, 4);
                }
                
            }
            switch (ebe.extra_a)
            {
                case 0:
                    Boss_Move(ref ebe.location);
                    ebe.location += boss_v;
                    if (ebe.extra_b>60)
                    {
                        ebe.extra_b = 0;
                        int bid = ebe.bulletid[0];
                        Vector3 v = ebe.location;
                        v.x -= 1f;
                        v.y -= 1.5f;
                        ShotBullet.ThreeBeline20(ref buff_b_ex[bid], ref v, ref ebe.extra_b);
                        v.x += 2f;
                        bid = ebe.bulletid[1];
                        ShotBullet.ThreeBeline20(ref buff_b_ex[bid], ref v, ref ebe.extra_b);
                        if (ebe.extra_b < 0)
                        {
                            ebe.extra_b = -500;
                            ebe.extra_a = lucky.Next(0, 5);
                        }
                    }
                    break;
                case 1:
                    if (ebe.extra_b > 60)
                    {
                        ebe.extra_b = 0;
                        int bid = ebe.bulletid[0];
                        Vector3 v = ebe.location;
                        v.x -= 1f;
                        v.y -= 1.5f;
                        ShotBullet.Aim_Arc6(ref buff_b_ex[bid], ref v, ref ebe.extra_b);
                        v.x += 2f;
                        bid = ebe.bulletid[1];
                        ShotBullet.Aim_Arc6(ref buff_b_ex[bid], ref v, ref ebe.extra_b);
                        if (ebe.extra_b < 0)
                        {
                            ebe.extra_b = -500;
                            ebe.extra_a = lucky.Next(0, 5);
                        }
                    }
                    break;
                case 2:
                    if(ebe.extra_b>1800)
                    {
                        ebe.extra_b = -400;
                        ebe.extra_a = lucky.Next(0, 4);
                        Ani_Run_D(2,ebe.ani_id);
                    }else if(ebe.extra_b<0)
                    {
                        boss_state = 0;
                        ebe.extra_b = 0;
                        Ani_Run_D(1, ebe.ani_id);
                    }
                    if (boss_state<1& ebe.extra_b > 100)
                    {
                        boss_state = 1;
                        int bid = ebe.bulletid[3];
                        Vector2 v = ebe.location;
                        v.x -= 1;
                        v.y -= 1.2f;
                        buff_b_ex[bid].b_s[0].location = v;
                        v.x += 2;
                        buff_b_ex[bid].b_s[2].location = v;
                        buff_b_ex[bid].s_count = 1;
                    }
                    break;
                case 3:
                    if (ebe.extra_b > 60)
                    {
                        ebe.extra_b = 0;
                        int bid = ebe.bulletid[2];
                        Vector3 v = ebe.location;
                        v.y -= 1.5f;
                        ShotBullet.Aim_Arc3(ref buff_b_ex[bid], ref v, ref ebe.extra_b);
                        ebe.extra_b = -500;
                        ebe.extra_a = lucky.Next(0, 5);
                    }
                    break;
                default:
                    Boss_Move(ref ebe.location);
                    ebe.location += boss_v;
                    if (ebe.extra_b > 200)
                    {
                        ebe.extra_b = 0;
                        int bid = ebe.bulletid[2];
                        Vector3 v = ebe.location;
                        v.y -= 1.5f;
                        ShotBullet.Aim_3(ref buff_b_ex[bid], ref v, ref ebe.extra_b);
                        if (ebe.extra_b < 0)
                        {
                            ebe.extra_b = -500;
                            ebe.extra_a = lucky.Next(0, 5);
                        }
                    }
                    break;
            }
            return true;
        }
        static bool M_huijinA(ref EnemyBaseEX ebe)
        {
            ebe.extra_b += ts;
            switch (ebe.extra_a)
            {
                case 0:
                    Boss_Move(ref ebe.location);
                    ebe.location += boss_v;
                    if (ebe.extra_b > 60)
                    {
                        ebe.extra_b = 0;
                        int bid = ebe.bulletid[0];
                        Vector3 v = ebe.location;
                        v.y -= 1.5f;
                        ShotBullet.ThreeBeline20(ref buff_b_ex[bid], ref v, ref ebe.extra_b);
                        v.x -= 1.4f;
                        bid = ebe.bulletid[1];
                        ShotBullet.ThreeBeline20(ref buff_b_ex[bid], ref v, ref ebe.extra_b);
                        v.x += 2.8f;
                        bid = ebe.bulletid[4];
                        ShotBullet.ThreeBeline20(ref buff_b_ex[bid], ref v, ref ebe.extra_b);
                        if (ebe.extra_b < 0)
                        {
                            ebe.extra_b = -500;
                            ebe.extra_a = lucky.Next(0, 5);
                        }
                    }
                    break;
                case 1:
                    if (ebe.extra_b > 60)
                    {
                        ebe.extra_b = 0;
                        int bid = ebe.bulletid[0];
                        Vector3 v = ebe.location;
                        v.x -= 1.4f;
                        v.y -= 1.5f;
                        ShotBullet.Aim_Arc6(ref buff_b_ex[bid], ref v, ref ebe.extra_b);
                        v.x += 2.8f;
                        bid = ebe.bulletid[1];
                        ShotBullet.Aim_Arc6(ref buff_b_ex[bid], ref v, ref ebe.extra_b);
                        if (ebe.extra_b < 0)
                        {
                            ebe.extra_b = -300;
                            ebe.extra_a = lucky.Next(0, 5);
                        }
                    }
                    break;
                case 2:
                    if (ebe.extra_b > 1800)
                    {
                        ebe.extra_b = -400;
                        ebe.extra_a = lucky.Next(0, 4);
                        Ani_Run_D(2, ebe.ani_id);
                    }
                    else if (ebe.extra_b < 0)
                    {
                        boss_state = 0;
                        ebe.extra_b = 0;
                        Ani_Run_D(1, ebe.ani_id);
                    }
                    if (boss_state < 1 & ebe.extra_b > 100)
                    {
                        boss_state = 1;
                        int bid = ebe.bulletid[3];
                        Vector2 v = ebe.location;
                        v.x -= 1.4f;
                        v.y -= 1.5f;
                        buff_b_ex[bid].b_s[0].location = v;
                        v.x += 2.8f;
                        buff_b_ex[bid].b_s[2].location = v;
                        buff_b_ex[bid].s_count = 1;
                    }
                    break;
                case 3:
                    if (ebe.extra_b > 60)
                    {
                        ebe.extra_b = 0;
                        int bid = ebe.bulletid[2];
                        Vector3 v = ebe.location;
                        v.y -= 1.5f;
                        ShotBullet.Aim_Arc3(ref buff_b_ex[bid], ref v, ref ebe.extra_b);
                        ebe.extra_b = -500;
                        ebe.extra_a = lucky.Next(0, 5);
                    }
                    break;
                default:
                    Boss_Move(ref ebe.location);
                    ebe.location += boss_v;
                    if (ebe.extra_b > 60)
                    {
                        ebe.extra_b = 0;
                        int bid = ebe.bulletid[5];
                        Vector3 v = ebe.location;
                        v.x -= 1;
                        v.y -= 1.5f;
                        ShotBullet.ThreeDown(ref buff_b_ex[bid], ref v, ref ebe.extra_b);
                        v.x += 2;
                        bid = ebe.bulletid[6];
                        ShotBullet.ThreeDown(ref buff_b_ex[bid], ref v, ref ebe.extra_b);
                        if (ebe.extra_b < 0)
                        {
                            ebe.extra_b = -500;
                            ebe.extra_a = lucky.Next(0, 5);
                        }
                    }
                    break;
            }
            return true;
        }
        public static bool M_bee(ref EnemyBaseEX ebe)
        {
            if (ebe.extra_m < 100)
            {
                ebe.extra_m++;
                ebe.location.y -= 0.03f;
                return true;
            }
            else//mov
            {
                if (ebe.extra_m == 100)
                {
                    ebe.extra_m++;
                    boss_v.x = -0.02f - (float)lucky.NextDouble() / 50;
                    boss_v.y = 0.02f + (float)lucky.NextDouble() / 50;
                    boss_state = lucky.Next(0,5);
                }
            }
            float x = ebe.location.x;
            float y = ebe.location.y;
            switch (boss_state)
            {
                case 0:
                    if (ebe.extra_b > 60)
                    {
                        ebe.extra_b = 0;
                        int bid =ebe.bulletid[0];
                        ShotBullet.Angle5_Rotate(ref buff_b_ex[bid],ref ebe.location,ref ebe.extra_b);
                        bid = ebe.bulletid[1];
                        ShotBullet.Angle5_RotateA(ref buff_b_ex[bid], ref ebe.location, ref ebe.extra_b);
                        ebe.extra_a++;
                        if (ebe.extra_b < 0)
                            ebe.extra_b = 0;
                        if(ebe.extra_a>30)
                        {
                            ebe.extra_a = 0;
                            ebe.extra_b = -600;
                            boss_state = lucky.Next(1, 5);
                        }
                    }
                    break;
                case 1:
                    if (ebe.extra_b > 0)
                    {
                        int bid = ebe.bulletid[2];
                        x -= 0.3f;
                        y -= 0.5f;
                        Vector3 v = Vector3.zero;
                        v.x = x;
                        v.y = y;
                        ShotBullet.Aim_Arc3(ref buff_b_ex[bid],ref v,ref ebe.extra_b);
                        ebe.extra_b = -500;
                        boss_state = lucky.Next(3, 5);
                    }
                    break;
                case 2:
                    Boss_Move(ref ebe.location);
                    ebe.location += boss_v;
                    if (ebe.extra_b>120)
                    {
                        ebe.extra_b = 0;
                        int bid = ebe.bulletid[0];
                        ShotBullet.Aim_Arc6(ref buff_b_ex[bid],ref ebe.location,ref ebe.extra_b);
                        ebe.extra_a++;
                        if (ebe.extra_a > 3)
                        {
                            ebe.extra_a = 0;
                            ebe.extra_b = -500;
                            boss_state = 3;
                        }
                    }
                    break;
                case 3:
                    if (ebe.extra_b > 30)
                    {
                        int bid = ebe.bulletid[1];
                        Vector3 v = ebe.location;
                        v.y -= 1f;
                        ShotBullet.DwonAngleA(ref buff_b_ex[bid],ref v,ref ebe.extra_b);
                        ebe.extra_a++;
                        ebe.extra_b = 0;
                        if (ebe.extra_a > 36)
                        {
                            ebe.extra_b = -500;
                            ebe.extra_a = 0;
                            boss_state = lucky.Next(0, 3);
                        }
                    }
                    break;
                default:
                    if(ebe.extra_b>200)
                    {
                        ebe.extra_b = 0;
                        int bid = ebe.bulletid[3];
                        ShotBullet.Three_Circle36(ref buff_b_ex[bid], ref ebe.location, ref ebe.extra_b);
                        ebe.extra_a++;
                        if (ebe.extra_a>=3)
                        {
                            ebe.extra_a = 0;
                            boss_state = 0;
                            ebe.extra_b = -600;
                            boss_state = lucky.Next(0, 4);
                        }
                    }  
                    break;
            }
            ebe.extra_b+=ts;
            return true;
        }
        #endregion
    }

}
