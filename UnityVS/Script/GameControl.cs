#define pc
//#undef pc
//#define unsafe
//#undef unsafe
//#define x64
//#undef x64
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.UnityVS.Script
{
 
    class GameControl:QueueSourceEX
    {
#if pc
        static string mat_blood = "Mat_PC/blood";
        static string mat_blood2 = "Mat_PC/b_blood";
        protected static string mat_prop_u = "Mat_PC/prop_u";
        protected static string mat_prop_b = "Mat_PC/prop_b";
        static string mat_bk = "Mat_PC/bk";
#else
        static string mat_blood = "Mat_Phone/blood";
        static string mat_blood2 = "Mat_Phone/b_blood";
        protected static string mat_prop_u = "Mat_Phone/prop_u";
        protected static string mat_prop_b = "Mat_Phone/prop_b";
        static string mat_bk = "Mat_Phone/bk";
#endif

        protected static int ot, ts;//old time, timeslice
        protected static CurrentDispose current;       
        protected static ShotW damageA;
        protected static Action damageC;
        protected static ShotEx damageB;
        protected static GenerateProp generateA;
        protected static Action<bool> D_gameover;
        protected static int currentwave = 0, destory_enemy;
        protected static BattelField buff_wave;
        protected static bool gameover = true, plane_move;
        protected static Action update;
        protected static Action<int> propcollid;
        protected static EnemyWave crt_wave;
        protected static int[] tri_256;
        protected static Vector3 core_location,wing_location;
        static Vector3[] bld_v3;
        static Vector2[] bld_uv2;
        static int[] bld_tri;
        static float b_boss = 0;

#region data source
        protected static ImageProperty blood_back = new ImageProperty()
        {
            imagepath = "Picture/bloodt",
            scale = new Vector3(0.7f, 0.8f),
            location = new Vector3(-1.34f, 4.83f, layer),
            sorting = 6
        };
        protected static ImageProperty blood_g = new ImageProperty()
        {
            imagepath = "Picture/bloodg",
            scale = origion_scale,
            location = origion_location,
            sorting = 7
        };
        protected static ImageProperty blood_b = new ImageProperty()
        {
            imagepath = "Picture/bloodb",
            scale = origion_scale,
            location = origion_location,
            sorting = 7
        };
        protected static ImageProperty blood_y = new ImageProperty()
        {
            imagepath = "Picture/bloody",
            scale = origion_scale,
            location = origion_location,
            sorting = 7
        };

#endregion

        public static void LoadBaseComponent()
        {
            InitialBloodEx();
            blood_back.spt_id = CreateSprite(blood_back.imagepath);
            blood_b.spt_id = CreateSprite(blood_b.imagepath);
            blood_g.spt_id = CreateSprite(blood_g.imagepath);
            blood_y.spt_id = CreateSprite(blood_y.imagepath);
        }
        public static void InitialParameter()
        {
#region blood
            bld_v3 = new Vector3[80];
            bld_uv2 = new Vector2[80];
            bld_tri = new int[120];
            for (int i = 1; i < 80; i += 4)
            {
                bld_uv2[i].y = 1;
                bld_uv2[i + 1].y = 1;
            }
            int index = 0;
            for (int c = 0; c < 120; c += 6)
            {
                bld_tri[c] = index;
                bld_tri[c + 1] = index + 1;
                bld_tri[c + 2] = index + 2;
                bld_tri[c + 3] = index;
                bld_tri[c + 4] = index + 2;
                bld_tri[c + 5] = index + 3;
                index += 4;
            }
#endregion

#region prop
            md[0].v3 = new Vector3[16];
            md[0].uv2 = new Vector2[16];
            md[0].tri = GetTri(4);
            md[1].v3 = new Vector3[8];
            md[1].uv2 = new Vector2[8];
            md[1].tri = GetTri(2);
#endregion

#region bullet mesh buff
            tri_256 = GetTri(256);
#endregion

#region bullet state buff
            for(int i=0;i<38;i++)
            {
                buff_b_ex[i].vertexs = new Vector3[1024];
                buff_b_ex[i].uv = new Vector2[1024];
                buff_b_ex[i].b_s = new BulletStateEx[256];
            }
#endregion

            buff_wave = new BattelField();
            buff_wave.wave = new List<EnemyWave>();
        }
        static int[] GetTri(int len)
        {
            int l = len * 6;
            int[] temp = new int[l];
            int index = 0;
            for (int c = 0; c < l; c += 6)
            {
                temp[c] = index;
                temp[c + 1] = index + 1;
                temp[c + 2] = index + 2;
                temp[c + 3] = index;
                temp[c + 4] = index + 2;
                temp[c + 5] = index + 3;
                index += 4;
            }
            return temp;
        }
        protected static void ClearData()
        {
            for(int i=0;i<38;i++)
            {
                for (int c = 0; c < buff_b_ex[i].max; c++)
                    buff_b_ex[i].b_s[c].active = false;
                buff_b_ex[i].a_count = 0;
                buff_b_ex[i].s_count = 0;
                buff_b_ex[i].max = 0;
                buff_b_ex[i].active = false;
                int id = bex_id[i];
                buff_img_ex[id].update = UpdateBulletEx;
            }
            for(int i=0;i<20;i++)
            {
                buff_enemy[i].c_blood = 0;
                int id = enemy_id[i];
                buff_img_ex[id].update = UpdateEnemy;
            }
            b_boss = 0;
            for(int i=0;i<16;i++)
            {
                buff_ani[i].reg = false;
                buff_run[i] = null;
                md[0].v3[i] = Vector3.zero;
            }
            for(int i=0;i<8;i++)
            {
                md[1].v3[i] = Vector3.zero;
            }
            for (int i = 0; i < 4; i++)
            {
                buff_prop_u[i].created = false;
                buff_prop_u[i].closely = false;
            }
            buff_prop_b[0].created = false;
            buff_prop_b[0].closely = false;
            buff_prop_b[1].created = false;
            buff_prop_b[1].closely = false;
            generate = false; 
        }

#region move
        internal static void Plane_Move(Vector3 dot)
        {
            if (mousedown)
            {
                if (plane_move)
                {
                    Vector3 temp = dot - mouse_position;
                    temp.x *= 10 / screen.y;
                    temp.y *= 10 / screen.y;
                    mouse_position = dot;
                    temp += core_location;
                    if (temp.y < 4.8f & temp.y > -4.8f & temp.x < 2.5f & temp.x > -2.5f)
                    {
                        core_location = temp;
                    }
                }
            }
            mouse_position = dot;
        }
#endregion

#region  process
        public static void SuspendGame()
        {
            MainCamera.update = null;
            plane_move = false;
        }
        public static void ContinueGame()
        {
            MainCamera.update = update;
            ot = DateTime.Now.Millisecond;
            plane_move = true;
        }
        public static void GameOver(bool pass)
        {
            for (int i = 0; i < 128; i++)
                if(buff_img_ex[i].reg)
                buff_img_ex[i].gameobject.SetActive(false);
            D_gameover(pass);
        }
        public static void SetLevel(SetBattelField set)//u sub thread
        {
            set(ref buff_wave);
        }
#endregion
  
#region warplane dispose
        public static void SetDispose(CurrentDispose d)
        {
            current = d;
        }
#endregion

#region enemy control
        protected static EnemyBaseEX[] buff_enemy = new EnemyBaseEX[20];
        static int[] enemy_id=new int[20];
        static void UpdateEnemy(ref ImageBaseEx ibe)
        {
            int eid = ibe.extra;
            if (buff_enemy[eid].c_blood<=0)
            {
                ibe.gameobject.SetActive(false);
            }
            else
            {
                ibe.transform.localPosition = buff_enemy[eid].location;
                ibe.transform.localEulerAngles = buff_enemy[eid].angle;
                if(buff_enemy[eid].update)
                {
                    int mat_id = buff_enemy[eid].mat_id;
                    Material mat = buff_mat[mat_id].mat;
                    if (mat == null)
                        mat = CreateMat(mat_id);
                    if (mat == null)
                        return;
                    buff_enemy[eid].update = false;
                    ibe.mr.material = mat;
                    Mesh m = ibe.mesh;
                    m.triangles = null;
                    m.vertices = buff_enemy[eid].vertexs;
                    m.uv = buff_enemy[eid].uv;
                    m.triangles = buff_enemy[eid].triangle;
                }
                ibe.gameobject.SetActive(true);
            }
        }
        static void UpdateEnemy2(ref ImageBaseEx ibe)
        {
            int eid = ibe.extra;
            if (buff_enemy[eid].c_blood <= 0)
            {
                ibe.gameobject.SetActive(false);
            }
            else
            {
                ibe.transform.localPosition = buff_enemy[eid].location;
                ibe.transform.localEulerAngles = buff_enemy[eid].angle;
                int id;
                if (buff_enemy[eid].update)
                {
                    int mat_id = buff_enemy[eid].mat_id;
                    Material mat = buff_mat[mat_id].mat;
                    if (mat == null)
                        mat = CreateMat(mat_id);
                    if (mat == null)
                        return;
                    buff_enemy[eid].update = false;
                    ibe.mr.material = mat;
                    Mesh m = ibe.mesh;
                    m.triangles = null;
                    id = buff_enemy[eid].ani_id;
                    //if (buff_ani[id].vertex.Length != buff_ani[id].uv.Length)
                    //    Debug.Log("sdfdsf");
                    m.vertices = buff_ani[id].vertex;
                    m.uv = buff_ani[id].uv;
                    m.triangles = buff_ani[id].tri;
                }
                ibe.gameobject.SetActive(true);
                id = buff_enemy[eid].ani_id;
                if (buff_ani[id].up_v)
                {
                    buff_enemy[eid].abe.up_v = false;
                    Mesh m = ibe.mesh;                   
                    m.vertices = buff_ani[id].vertex;
                }
            }
        }
        public static void InitialEnemyA()
        {
            for(int i=0;i<20;i++)
            {
               int id= CreateImgNullEx(UpdateEnemy,i);
                enemy_id[i] = id;
                buff_img_ex[id].mr.sortingOrder = 2;
                buff_img_ex[id].gameobject.SetActive(false);
            }
        }
        protected static int CreateEnemy(ref EnemyPropertyEX target, Point3 p)
        {
            int i;
            for (i=0;i<20; i++)
            {
                if (buff_enemy[i].c_blood <= 0)
                    break;
            }
            buff_enemy[i] = target.enemy;
            int iid = enemy_id[i];
            if (target.enemy.animat)
            {
                buff_enemy[i].ani_id = RegAni(ref buff_enemy[i].abe);
                buff_img_ex[iid].update = UpdateEnemy2;
            }
            else
            {
                buff_img_ex[iid].update = UpdateEnemy;
            }
            buff_enemy[i].c_blood = target.enemy.f_blood;
            buff_enemy[i].location.x = p.x;
            buff_enemy[i].location.y = p.y;
            buff_enemy[i].location.z = layer;
            buff_enemy[i].angle.z = p.z;
            buff_enemy[i].update = true;
            if (target.bpe != null)
            {
                int len = target.bpe.Length;
                buff_enemy[i].bulletid = new int[len];
                for (int c = 0; c < target.bpe.Length; c++)
                {
                    buff_enemy[i].bulletid[c] = RegBulletEx(ref target.bpe[c],0);
                }
            }
            else buff_enemy[i].bulletid = null;
            return i;
        }
        protected static void CaculateEnemy()
        {
            area = CircleMoveArea(oldloaction, core_location, 0.09f, ref areapoints);
            oldloaction = core_location;
            xy.x = core_location.x;
            xy.y = core_location.y;
            int c = 0;
            for (int i = 0; i < 20; i++)
            {
                if (buff_enemy[i].c_blood >0)
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
                    }
                }
                else
                {
                    if(buff_enemy[i].move!=null)
                    {
                        buff_enemy[i].move = null;
                        if (buff_enemy[i].bulletid!=null)
                        for(int cc=0;cc<buff_enemy[i].bulletid.Length;cc++)
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
                        for(int d=0;d< max;d++)
                          CreateEnemy(ref crt_wave.enemyppt,crt_wave.start[d]);
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
                    for (int d = 0; d < max; d++)
                        CreateEnemy(ref crt_wave.enemyppt, crt_wave.start[d]);
                    crt_wave.sum = 0;
                    currentwave++;
                }
            }
        }
#endregion

#region Aim  
        static float atan(float dx, float dy)
        {
            //ax<ay
            float ax = dx < 0 ? -dx : dx, ay = dy < 0 ? -dy : dy;
            float a;
            if (ax < ay) a = ax / ay; else a = ay / ax;
            float s = a * a;
            float r = ((-0.0464964749f * s + 0.15931422f) * s - 0.327622764f) * s * a + a;
            if (ay > ax) r = 1.57079637f - r;
            r *= 57.32484f;
            if (dx < 0)
            {
                if (dy < 0)
                    r += 90;
                else r = 90 - r;
            }
            else
            {
                if (dy < 0)
                    r = 270-r;
                else r += 270;
            }
            return r;
        }
        internal static float Aim(ref Point3 self, ref Vector3 v)
        {
            float x = v.x-self.x;
            float y = v.y-self.y;
            return atan(x,y);
            //float ox = 0, a;
            //if (x < 0)
            //{
            //    x = 0 - x;
            //    if (y < 0)
            //    {
            //        y = 0 - y;
            //        ox = 270;
            //        a = Mathf.Atan2(y, x) * 57.29577951f;
            //    }
            //    else
            //    {
            //        ox = 180;
            //        a = Mathf.Atan2(x, y) * 57.29577951f;
            //    }
            //}
            //else
            //{
            //    if (y < 0)
            //    {
            //        y = 0 - y;
            //        a = Mathf.Atan2(x, y) * 57.29577951f;
            //    }
            //    else
            //    {
            //        ox = 90;
            //        a = Mathf.Atan2(y, x) * 57.29577951f;
            //    }
            //}
            //return a + ox;
        }
        internal static float Aim(ref Vector2 self, ref Vector3 v)
        {
            float x = v.x-self.x;
            float y = v.y-self.y;
            return atan(x,y);
        }
        internal static float Aim(ref Vector3 self, ref Vector3 v)
        {
            float x = v.x-self.x;
            float y = v.y-self.y;
            return atan(x,y);
        }
        internal static void Aim1(ref Vector2 self, ref Vector3 target, float speed)
        {
            float x = target.x - self.x;
            float y = target.y - self.y;
            if (x == 0)
            {
                if (y > 0)
                    self.y += speed;
                else
                    self.y -= speed;
                return;
            }
            if (y == 0)
            {
                if (x > 0)
                    self.x += speed;
                else
                    self.x -= speed;
                return;
            }
            float ratio = x / y;
            if (ratio < 0)
                ratio = 0 - ratio;
            float c = ratio * ratio;
            float y1 = Mathf.Sqrt(speed * speed / (c + 1));
            if (x > 0)
                self.x += ratio * y1;
            else
                self.x -= ratio * y1;
            if (y > 0)
                self.y += y1;
            else
                self.y -= y1;
        }
        internal static void Aim1(ref Vector3 self, ref Vector3 target, float speed)
        {
            float x = target.x - self.x;
            float y = target.y - self.y;
            if (x == 0)
            {
                if (y > 0)
                    self.y += speed;
                else
                    self.y -= speed;
                return;
            }
            if (y == 0)
            {
                if (x > 0)
                    self.x += speed;
                else
                    self.x -= speed;
                return;
            }
            float ratio = x / y;
            if (ratio < 0)
                ratio = 0 - ratio;
            float c = ratio * ratio;
            float y1 = Mathf.Sqrt(speed * speed / (c + 1));
            if (x > 0)
                self.x += ratio * y1;
            else
                self.x -= ratio * y1;
            if (y > 0)
                self.y += y1;
            else
                self.y -= y1;
        }
        internal static void Aim1(ref Vector2 self, ref Vector3 target, float speed, ref Vector3 up)
        {
            float x = target.x - self.x;
            float y = target.y - self.y;
            if (x == 0)
            {
                if (y > 0)
                {
                    up.x = 0;
                    up.y = speed;
                }
                else
                {
                    up.x = 0;
                    up.y = -speed;
                }
                return;
            }
            if (y == 0)
            {
                if (x > 0)
                {
                    up.x = speed;
                    up.y = 0;
                }
                else
                {
                    up.x = -speed;
                    up.y = 0;
                }
                return;
            }
            float ratio = x / y;
            if (ratio < 0)
                ratio = 0 - ratio;
            float c = ratio * ratio;
            float y1 = Mathf.Sqrt(speed * speed / (c + 1));
            if (x > 0)
            {
                up.x = ratio * y1;
            }
            else
            {
                up.x = -ratio * y1;
            }
            if (y > 0)
            {
                up.y = y1;
            }
            else
            {
                up.y = -y1;
            }
        }
        internal static void Aim1(ref Vector3 self, ref Vector3 target, float speed, ref Vector3 up)
        {
            float x = target.x - self.x;
            float y = target.y - self.y;
            if (x == 0)
            {
                if (y > 0)
                {
                    self.y += speed;
                    up.x = 0;
                    up.y = -speed;
                }
                else
                {
                    self.y -= speed;
                    up.x = 0;
                    up.y = speed;
                }
                return;
            }
            if (y == 0)
            {
                if (x > 0)
                {
                    self.x += speed;
                    up.x = -speed;
                    up.y = 0;
                }
                else
                {
                    self.x -= speed;
                    up.x = speed;
                    up.y = 0;
                }
                return;
            }
            float ratio = x / y;
            if (ratio < 0)
                ratio = 0 - ratio;
            float c = ratio * ratio;
            float y1 = Mathf.Sqrt(speed * speed / (c + 1));
            if (x > 0)
            {
                self.x += ratio * y1;
                up.x = ratio * y1;
            }
            else
            {
                self.x -= ratio * y1;
                up.x = -ratio * y1;
            }
            if (y > 0)
            {
                self.y += y1;
                up.y = y1;
            }
            else
            {
                self.y -= y1;
                up.y = -y1;
            }
        }
#endregion

#region blood manage
        public static void InitialBloodEx()
        {
            int id = CreateImgNullEx(UpdateBloodEx, 0);
            buff_img_ex[id].mr.material = CreateMat(mat_blood);
            buff_img_ex[id].gameobject.SetActive(false); 
            id= CreateImgNullEx(UpdateBossBloodEx, 0);
            buff_img_ex[id].mr.material = CreateMat(mat_blood2);
            buff_img_ex[id].mr.sortingOrder = 9;
            buff_img_ex[id].gameobject.SetActive(false);
            Mesh me = buff_img_ex[id].mesh;
            me.vertices = new Vector3[] {new Vector3(-2.2f,-0.1f),new Vector3(-2.2f,0.1f),new Vector3(2.2f,0.1f),new Vector3(2.2f,-0.1f) };
            me.uv = SP.uv_def_1x1;
            me.triangles = SP.tri_def;
            buff_img_ex[id].transform.localPosition = new Vector3(0,3.8f,layer);
        }
        static void UpdateBloodEx(ref ImageBaseEx ibe)
        {
            ibe.gameobject.SetActive(true);
            ibe.mesh.vertices = bld_v3;
            ibe.mesh.uv = bld_uv2;
            ibe.mesh.triangles = bld_tri;
        }
        static void UpdateBossBloodEx(ref ImageBaseEx ibe)
        {
            if(b_boss>0)
            {
                ibe.gameobject.SetActive(true);
                Material mat = ibe.mr.material;
                mat.SetFloat("_r",b_boss);
            }
            else
            {
                ibe.gameobject.SetActive(false);
            }
        }
        public static void UpdateBlood()
        {
            for(int i=0;i<20;i++)
            {
                CalculBlood(i);
            }
        }
        static void CalculBlood(int id)
        {
            float p = buff_enemy[id].c_blood / buff_enemy[id].f_blood;
            if(buff_enemy[id].boss)
            {
                b_boss = p;
                return;
            }
            int s = id * 4;
            if (p <= 0)
            {
                bld_v3[s].x = 0;
                bld_v3[s + 1].x = 0;
                bld_v3[s + 2].x = 0;
                bld_v3[s + 3].x = 0;
                return;
            }
            bld_uv2[s + 2].x = p;
            bld_uv2[s + 3].x = p;
            float x = buff_enemy[id].location.x;
            float y = buff_enemy[id].location.y;
            int b =(int) buff_enemy[id].angle.z;
            int a = b + 180;
            if (a >= 360)
                a -= 360;
            float x1 = x + angle_table[a].x * 0.66f;
            float y1 = y + angle_table[a].y * 0.66f;
            a = b + 100;
            if (a >= 360)
                a -= 360;
            float x2= bld_v3[s].x = x1 + angle_table[a].x * 0.3493856f;
            float y2= bld_v3[s].y = y1 + angle_table[a].y * 0.3493856f;
            s++;
            a = b + 80;
            if (a >= 360)
                a -= 360;
            float x3= bld_v3[s].x = x1 + angle_table[a].x * 0.3493856f;
            float y3= bld_v3[s].y = y1 + angle_table[a].y * 0.3493856f;
            // 88/128=0.6875f
            p *= 0.6875f;
            s++;
            a = b + 270;
            if (a >= 360)
                a -= 360;
            x = angle_table[a].x * p;
            y = angle_table[a].y * p;
            bld_v3[s].x = x3 + x;
            bld_v3[s].y = y3 + y;
            s++;
            bld_v3[s].x = x2 + x;
            bld_v3[s].y = y2 + y;
        }
#endregion

#region collision
        protected static Vector3 oldloaction = Vector3.zero;
        protected static Point2[] areapoints = new Point2[4];
        protected static Point2 xy = new Point2(0, 0);           
       
        protected static bool CircleMoveArea(Vector3 A, Vector3 B, float r, ref Point2[] temp)
        {
            float x = A.x - B.x;
            float y = A.y - B.y;
            float d = x * x + y * y;
            if (d < r)
                return false;
            float c = Mathf.Sqrt(d);
            x = r * x / c;
            y = r * y / c;
            temp[3].x = A.x + y;
            temp[3].y = A.y - x;
            temp[2].x = A.x - y;
            temp[2].y = A.y + x;
            temp[1].x = B.x - y;
            temp[1].y = B.y + x;
            temp[0].x = B.x + y;
            temp[0].y = B.y - x;
            return true;
        }
        public static bool CollisionCore(ref BulletPropertyEx bpe, ref BulletStateEx state)
        {
            float x, y, d;
            int z = state.angle;
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
            if (bpe.radius>0)
            {                
                if (area & d < 1)
                {
                   collid= CircleToPolygon(new Point2(state.location.x, state.location.y)
                      , bpe.radius, areapoints);
                }
            }else
            {
                if (area & d < 1)
                {
                    collid = PToP2(areapoints, RotatePoint2(ref bpe.edgepoints, new Point2(state.location.x, state.location.y), z));
                }else
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
        public static bool CollisionEnemy(ref BulletPropertyEx bpe, ref BulletStateEx state)
        {
            float x = state.location.x;
            float y = state.location.y;
            int z = state.angle;
            Point2 temp = new Point2(x, y);
            Point2[] P = new Point2[0];
            if (bpe.radius == 0)
                P = RotatePoint2(ref bpe.edgepoints, temp, z);
            for (int cc = 0; cc < 20; cc++)
            {
                if (buff_enemy[cc].c_blood >0)
                {
                    float x1 = buff_enemy[cc].location.x - x;
                    float y1 = buff_enemy[cc].location.y - y;
                    float d = x1 * x1 + y1 * y1;
                    if (d < bpe.minrange)
                    {
                        if (bpe.penetrate == false)
                            state.active = false;
                        damageB(ref bpe, ref buff_enemy[cc]);
                        return true;
                    }
                    if (d < bpe.maxrange)
                    {
                        bool collid = false;
                        if (bpe.radius > 0)
                        {
                            if(buff_enemy[cc].radius>0)
                            {
                                if(d<=buff_enemy[cc].minrange+bpe.minrange)
                                {
                                    if (bpe.penetrate == false)
                                        state.active = false;
                                    damageB(ref bpe, ref buff_enemy[cc]);
                                    return true;
                                }
                            }
                            else if(buff_enemy[cc].offset!=null)
                                collid = CircleToPolygon(temp, bpe.radius, buff_enemy[cc].offset);
                        }                            
                        else
                        {
                            if(buff_enemy[cc].radius>0)
                                collid = CircleToPolygon(buff_enemy[cc].location, buff_enemy[cc].radius, P);
                            else if(buff_enemy[cc].offset!=null)
                                collid = PToP2(buff_enemy[cc].offset, P);
                        }                            
                        if (collid)
                        {
                            damageB(ref bpe, ref buff_enemy[cc]);
                            if (bpe.penetrate == false)
                            {
                                state.active = false;
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        protected static bool area;
        
#endregion

#region prop contorl
        protected static System.Random lucky = new System.Random();
        private static PropBase[] buff_prop_u = new PropBase[4];
        private static PropBase[] buff_prop_b = new PropBase[2];
        protected static bool generate;
        protected static Vector3 build_position;
        protected static int build_type;
        static Grid prop_grid = new Grid(3, 2);
        protected static int[] pro_id = new int[4];
        static MeshData[] md = new MeshData[2];
        protected static void Prop_Inital()
        {
            int id = CreateImgNullEx(UpdateProp2, 0);
            pro_id[0] = id;
            buff_img_ex[id].mr.material = CreateMat(pro_id[2]);
            buff_img_ex[id].gameobject.SetActive(false);
            Mesh me = buff_img_ex[id].mesh;
            me.triangles = null;
            me.vertices = md[0].v3;
            me.uv = md[0].uv2;
            me.triangles = md[0].tri;
            id = CreateImgNullEx(UpdateProp2, 1);
            pro_id[1] = id;
            buff_img_ex[id].mr.material = CreateMat(pro_id[3]);
            buff_img_ex[id].gameobject.SetActive(false);
            me = buff_img_ex[id].mesh;
            me.triangles = null;
            me.vertices = md[1].v3;
            me.uv = md[1].uv2;
            me.triangles = md[1].tri;
        }
        protected static void Prop_Destory()
        {
            RecycleImgEx(pro_id[0]);
            RecycleImgEx(pro_id[1]);
        }
        static void Prop_mov(ref PropBase pb,ref Vector3[] v3,ref Vector2[] uv2,int offset ,int style)
        {
            float x, y,d;
            if(pb.closely)
            {
                Aim1(ref pb.location, ref core_location, 0.07f, ref pb.motion);
                x = pb.location.x;
                y = pb.location.y;
                x -= core_location.x; y -= core_location.y;
                d = x * x + y * y;
                if (d < 0.01)
                {
                    pb.closely = false;
                    pb.created = false;
                    propcollid(style);
                    v3[offset] = Vector3.zero;
                    v3[offset+1] = Vector3.zero;
                    v3[offset+2] = Vector3.zero;
                    v3[offset+3] = Vector3.zero;
                    return;
                }
            }
            else
            {
                if (pb.location.x > 2.6f)
                {
                    pb.motion.x = -0.02f - (float)lucky.NextDouble() / 50;
                }
                if (pb.location.x < -2.6f)
                {
                    pb.motion.x = 0.02f + (float)lucky.NextDouble() / 50;
                }
                if (pb.location.y > 4.78f)
                {
                    pb.motion.y = -0.02f - (float)lucky.NextDouble() / 50;
                    if (pb.motion.x == 0)
                        pb.motion.x = -0.04f + (float)lucky.NextDouble() / 12.5f;
                }
                if (pb.location.y < -4.78f)
                {
                    pb.motion.y = 0.02f + (float)lucky.NextDouble() / 50;
                    if (pb.motion.x == 0)
                        pb.motion.x = -0.04f + (float)lucky.NextDouble() / 12.5f;
                }
            }
            x = pb.location.x += pb.motion.x;
            y = pb.location.y += pb.motion.y;
            x -= core_location.x; y -= core_location.y;
            d = x * x + y * y;
            if (d < 1)
                pb.closely = true;
            x = pb.location.x-0.15625f;y = pb.location.y-0.15625f;
            float x1 = x + 0.3125f, y1 = y + 0.3125f;
            v3[offset].x = x;
            v3[offset].y = y;
            v3[offset + 1].x = x;
            v3[offset + 1].y = y1;
            v3[offset + 2].x = x1;
            v3[offset + 2].y = y1;
            v3[offset + 3].x = x1;
            v3[offset + 3].y = y;
            if (pb.extra > 59)
                pb.extra = 0;
            if (pb.extra % 10 == 0)
            {
                int index = pb.extra / 10;
                uv2[offset] = SP.uv_def_3x2[index][0];
                uv2[offset+1] = SP.uv_def_3x2[index][1];
                uv2[offset+2] = SP.uv_def_3x2[index][2];
                uv2[offset+3] = SP.uv_def_3x2[index][3];
            }
            pb.extra++;
        }
        static void Prop_create(ref PropBase pb ,ref Vector3[] v3,ref Vector2[] uv2, int offset)
        {
            float x = build_position.x - 0.15625f, y = build_position.y - 0.15625f;
            float x1 = x + 0.3125f, y1 = y + 0.3125f;
            v3[offset].x = x;
            v3[offset].y = y;
            v3[offset + 1].x = x;
            v3[offset + 1].y = y1;
            v3[offset + 2].x = x1;
            v3[offset + 2].y = y1;
            v3[offset + 3].x = x1;
            v3[offset + 3].y = y;
            uv2[offset] = SP.uv_def_3x2[0][0];
            uv2[offset + 1] = SP.uv_def_3x2[0][1];
            uv2[offset + 2] = SP.uv_def_3x2[0][2];
            uv2[offset + 3] = SP.uv_def_3x2[0][3];
            generate = false;
            pb.location = build_position;
            pb.extra = 1;
            pb.created = true;
            pb.motion.x = (float)lucky.NextDouble()/5-0.1f;
            pb.motion.y = (float)lucky.NextDouble() / 5 - 0.1f;
        }
        static void UpdateProp2(ref ImageBaseEx ibe)
        {
            int extra = ibe.extra;
            ibe.gameobject.SetActive(true);
            ibe.mesh.vertices = md[extra].v3;
            ibe.mesh.uv = md[extra].uv2;
        }
        protected  static void UpdateProp2A()
        {
            int offset = 0;
            for(int i=0;i<4;i++)
            {
                if (buff_prop_u[i].created)
                    Prop_mov(ref buff_prop_u[i] ,ref md[0].v3,ref md[0].uv2,offset,0);
                else if(generate& build_type==0)
                {
                    generate = false;
                    Prop_create(ref buff_prop_u[i],ref md[0].v3,ref md[0].uv2,offset);
                }
                offset += 4;
            }
            offset = 0;
            for (int i = 0; i < 2; i++)
            {
                if (buff_prop_b[i].created)
                    Prop_mov(ref buff_prop_b[i], ref md[1].v3, ref md[1].uv2, offset,1);
                else if (generate & build_type == 1)
                {
                    generate = false;
                    Prop_create(ref buff_prop_b[i],ref md[1].v3, ref md[1].uv2, offset);
                }
                offset += 4;
            }
            generate = false;
        }
#endregion

#region animation ex
        protected static AnimatBaseEx[] buff_ani = new AnimatBaseEx[16];
        protected static AniRun[] buff_run = new AniRun[16];
        protected static int RegAni(ref AnimatBaseEx abe)
        {
            int i;
            for( i=0;i<16;i++)
            {
                if (!buff_ani[i].reg)
                    goto label1;
            }
            i = 15;
            label1:;
            buff_ani[i] = abe;
            buff_ani[i].reg = true;
            Ani_inital(ref buff_ani[i],ref buff_ani[i].ae);
            return i;
        }
        protected static void UnReg_Ani(int id)
        {
            buff_ani[id].reg = false;
            buff_run[id] = null;
        }
        protected static void Ani_Run_D(int index,int id)// animation run as delegate
        {
            if (buff_ani[id].stage == null)
                return;
            if (index >= buff_ani[id].stage.Length)
                return;
            if(buff_run[id] != buff_ani[id].stage[index])
            {
                buff_run[id] = buff_ani[id].stage[index];
                buff_ani[id].c_time = 0;
            }
        }
        protected static void Ani_Pause(int id)
        {
            buff_run[id] = null;
            buff_ani[id].c_time = 0;
        }
        public static void Ani_Update()
        {
            for(int i=0;i<16;i++)
            {
                if(buff_run[i]!=null)
                {
                    buff_ani[i].c_time += ts;
                    if(buff_run[i](ref buff_ani[i], ref buff_ani[i].ae,buff_ani[i].c_time))
                    {
                        buff_ani[i].c_time = 0;
                        buff_run[i] = null;
                    }
                    Cacul_Ani(ref buff_ani[i], ref buff_ani[i].ae);
                    buff_ani[i].up_v = true;
                }
            }
        }
        protected static void Ani_inital(ref AnimatBaseEx abe,ref AnimatEx[] ae)
        {
            abe.c_time = 0;
            abe.up_v = true;
            int len = ae.Length;
            if (abe.tri == null)
            {
                abe.tri = GetTri(len);
            }
            len *= 4;
            if (abe.vertex==null)
            {
                abe.vertex = new Vector3[len];
            }
            if(abe.uv==null)
            {
                Vector2[] temp = new Vector2[len];
                int index = 0;
                for (int i = 0; i < ae.Length; i++)
                {
                    temp[index] = ae[i].uv2[0];
                    index++;
                    temp[index] = ae[i].uv2[1];
                    index++;
                    temp[index] = ae[i].uv2[2];
                    index++;
                    temp[index] = ae[i].uv2[3];
                    index++;
                }
                abe.uv = temp;
            }
            if (abe.ani_ini != null)
                abe.ani_ini(ref ae);
            int o = 0;
            for(int i=0;i<ae.Length;i++)
            {
                Cacul_Ani(ref abe, ref ae[i], ref abe.vertex, o);
                o += 4;
            }
        }
        protected static void Cacul_Ani(ref AnimatBaseEx abe, ref AnimatEx[] ae)//time ratio
        {
            int len = ae.Length;
            int o = 0;
            for(int i=0;i<len;i++)
            {
                Cacul_Ani(ref abe, ref ae[i], ref abe.vertex, o);
                o += 4;
            }
        }
        protected static void Cacul_Ani(ref AnimatBaseEx abe, ref AnimatEx ae, ref Vector3[] v3, int s)
        {
            float ss = ae.scale;
            if (ss == 0)
            {
                v3[s] = Vector3.zero;
                s++;
                v3[s] = Vector3.zero;
                s++;
                v3[s] = Vector3.zero;
                s++;
                v3[s] = Vector3.zero;
                s++;
                return;
            }
            float lx, ly;
            Point2[] p = ae.rect;
            if(ae.free)
            {
                lx = ae.location.x;
                ly = ae.location.y;
                goto label1;
            }
            if (ae.parentid < 0)
            {
                if (ae.pivot_p.y > 0)
                {
                    lx = angle_table[(int)ae.pivot_p.x].x * ae.pivot_p.y;
                    ly = angle_table[(int)ae.pivot_p.x].y * ae.pivot_p.y;
                    goto label0;
                }
                int tx ;
                float ty ;
                for (int i=0;i<4;i++)
                {
                    tx = (int)p[i].x;
                    ty = p[i].y;
                    v3[s].x = angle_table[tx].x * ty * ss;
                    v3[s].y = angle_table[tx].y * ty * ss;
                    s++;
                }
                ae.location.x = 0;
                ae.location.y = 0;
                return;
            }
            float x = abe.ae[ae.parentid].location.x;
            float y = abe.ae[ae.parentid].location.y;
            float scale = abe.ae[ae.parentid].scale;
            float angle = abe.ae[ae.parentid].angle;
            float a = angle + ae.pivot_p.x;
            if (a >= 360)
                a -= 360;
            lx = x + angle_table[(int)a].x * ae.pivot_p.y * scale;
            ly = y + angle_table[(int)a].y * ae.pivot_p.y * scale;
            label0:;
            ae.location.x = lx;
            ae.location.y = ly;
            label1:;
            for(int i=0;i<4;i++)
            {
                angle = ae.angle + p[i].x;
                if (angle >= 360)
                    angle -= 360;
                y = p[i].y;
                v3[s].x = lx + angle_table[(int)angle].x * y * ss;
                v3[s].y = ly + angle_table[(int)angle].y * y * ss;
                s++;
            }
        }
#endregion

#region bullet contronl ex
        protected static BulletPropertyEx[] buff_b_ex = new BulletPropertyEx[38];
        protected static int[] bex_id = new int[38];
        protected static void UpdateBulletEx(ref ImageBaseEx ibe)
        {
            int extra = ibe.extra;
            if (buff_b_ex[extra].a_count>0)
            {
                int len = buff_b_ex[extra].max;
                if (len == 0)
                    return;
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
//                                    //*iip = il;
//                                    //mesh.triangles = null;
//                                    mesh.vertices = buff_b_ex[extra].vertexs;
//                                    mesh.uv = buff_b_ex[extra].uv;
//                                //mesh.triangles = tri_256;
//                                }
//                                *ivp = 1024;
//                                *iup = 1024;
//                                //*iip = 1536;
//                            }
//                        }
//                    }
//                }
//#endif 
                if (buff_b_ex[extra].update)
                {
                    int mat_id = buff_b_ex[extra].mat_id;
                    Material mat = buff_mat[mat_id].mat;
                    if (mat==null)
                       mat= CreateMat(mat_id);
                    if (mat == null)
                        return;
                    buff_b_ex[extra].update = false;
                    ibe.mr.material = mat;
                }
                ibe.gameobject.SetActive(true);
            }
            else 
            {
                ibe.gameobject.SetActive(false);
            }
        }
        public static void IniB_ExA()
        {
            for(int i=0;i<26;i++)
            {
                int id=  CreateImgNullEx(UpdateBulletEx,i);
                bex_id[i] = id;
                buff_img_ex[id].mr.sortingOrder = 5;
                buff_img_ex[id].gameobject.SetActive(false);
            }
            for (int i = 26; i < 38; i++)
            {
                int id = CreateImgNullEx(UpdateBulletEx, i);
                bex_id[i] = id;
                //buff_img_ex[id].mr.sortingOrder = 2;
                buff_img_ex[id].gameobject.SetActive(false);
            }
        }
        protected static int RegBulletEx(ref BulletPropertyEx target,int start)
        {
            int i;
            for (i = start; i < 38; i++)
            {
                if (!buff_b_ex[i].active & buff_b_ex[i].a_count < 1)
                {
                    break;
                }
            }
            int iid = bex_id[i];
            if (target.up_img != null)
                buff_img_ex[iid].update = target.up_img;
            else buff_img_ex[iid].update = UpdateBulletEx;
            CopyBullet(ref buff_b_ex[i],ref target);
            return i;
        }
        protected static void CopyBullet(ref BulletPropertyEx target,ref BulletPropertyEx source)
        {
            if (target.calcul != null)
                if (target.dispose != null)
                    target.dispose();
            target.calcul = source.calcul;
            target.inital = source.inital;
            target.dispose = source.dispose;
            target.move = source.move;
            target.play = source.play;
            target.collision = source.collision;

            target.attack=source.attack;
            target.radius = source.radius;
            target.edgepoints=source.edgepoints;
            target.mat_id=source.mat_id;
            target.maxrange=source.maxrange;
            target.minrange=source.minrange;
            target.t_uv = source.t_uv;
            target.uv_rect = source.uv_rect;
            target.speed = source.speed;
            target.parentid = source.parentid;
            target.penetrate = source.penetrate;
            target.offset = source.offset;
            
            target.extra = 0;
            target.max = 0;
            target.s_count = 0;
            target.a_count = 0;
            if (target.calcul != null)
                if (target.inital != null)
                    target.inital(ref target);
            target.update = true;
            target.active = true;
        }
        protected static void UnRegBulletEx(int id)
        {
            buff_b_ex[id].active = false;
        }
        protected static void ClearBullet(int id)
        {
            buff_b_ex[id].active = false;
            buff_b_ex[id].a_count = 0;
            buff_b_ex[id].s_count = 0;
            buff_b_ex[id].max = 0;
            for (int i = 0; i < 256; i++)
                buff_b_ex[id].b_s[i].active = false;
        }
        protected static void Move_BulletEx(int start, int end, int interval)
        {
            for (int i = start; i < end; i += interval)
            {
                if (buff_b_ex[i].calcul == null)
                    Cacul_Bullet(ref buff_b_ex[i], ref buff_b_ex[i].b_s);
                else buff_b_ex[i].calcul(ref buff_b_ex[i],ref buff_b_ex[i].b_s);
            }
        }
        protected static void Cacul_Bullet(ref BulletPropertyEx bpe, ref BulletStateEx[] bse)
        {
            int a = 0;
            if (bpe.a_count > 0 | bpe.active)
            {
                int max = bpe.max;
                int offset = 0;
                if (max > 0)
                {
                    for (int c = 0; c < max; c++)
                    {
                        if (Calcul_BPEA(ref bpe, ref bse[c], ref bpe.vertexs, ref bpe.uv, offset))
                            a++;
                        offset += 4;
                    }
                }
                int s_count = bpe.s_count;
                if (s_count > 0)
                {
                    if (bpe.t_uv != null)
                    {
                        for (int c = 0; c < s_count; c++)
                        {
                            if (max >= 255)
                                break;
                            Create_BSEA(ref bpe, ref bse[max], ref bpe.vertexs, ref bpe.uv, offset, c);
                            bse[c].id = max;
                            offset += 4;
                            if (offset >= 1020)
                            {
                                bpe.s_count = 0;
                                max++;
                                break;
                            }
                            max++;
                        }
                    }
                    bpe.max = max;
                    bpe.s_count = 0;
                }
                bpe.a_count = a;
            }
        }
        protected static void Create_BSEA(ref BulletPropertyEx bpe, ref BulletStateEx bse,ref Vector3[] v3,ref Vector2[] uv2, int id, int c)
        {
            bse.active = true;
            bse.extra = 0;
            bse.extra2 = 0;
            bse.extra_p = 0;
            bse.uv_rect = bpe.uv_rect;
            float x = bse.location.x = bpe.shotpoint[c].x;
            float y = bse.location.y = bpe.shotpoint[c].y;
            if (bpe.offset)
            {
                v3[id].x = x + bse.uv_rect[0].x;
                v3[id].y = y + bse.uv_rect[0].y;
                v3[id + 1].x = x + bse.uv_rect[1].x;
                v3[id + 1].y = y + bse.uv_rect[1].y;
                v3[id + 2].x = x + bse.uv_rect[2].x;
                v3[id + 2].y = y + bse.uv_rect[2].y;
                v3[id + 3].x = x + bse.uv_rect[3].x;
                v3[id + 3].y = y + bse.uv_rect[3].y;
                return;
            }
            bse.angle = (int)bpe.shotpoint[c].z;
            int la = bse.angle;
            if (bpe.t_uv != null)
            {
                uv2[id] = bpe.t_uv[0];
                uv2[id + 1] = bpe.t_uv[1];
                uv2[id + 2] = bpe.t_uv[2];
                uv2[id + 3] = bpe.t_uv[3];
            }
            else
            {
                uv2[id] = SP.uv_def_1x1[0];
                uv2[id + 1] = SP.uv_def_1x1[1];
                uv2[id + 2] = SP.uv_def_1x1[2];
                uv2[id + 3] = SP.uv_def_1x1[3];
            }
            int a = (int)bse.uv_rect[0].x + la;
            if (a >= 360)
                a -= 360;
            float d = bse.uv_rect[0].y;
            v3[id].x = x + angle_table[a].x * d;
            v3[id].y = y + angle_table[a].y * d;
            a = (int)bse.uv_rect[1].x + la;
            if (a >= 360)
                a -= 360;
            d = bse.uv_rect[1].y;
            v3[id + 1].x = x + angle_table[a].x * d;
            v3[id + 1].y = y + angle_table[a].y * d;
            a = (int)bse.uv_rect[2].x + la;
            if (a >= 360)
                a -= 360;
            d = bse.uv_rect[2].y;
            v3[id + 2].x = x + angle_table[a].x * d;
            v3[id + 2].y = y + angle_table[a].y * d;
            a = (int)bse.uv_rect[3].x + la;
            if (a >= 360)
                a -= 360;
            d = bse.uv_rect[3].y;
            v3[id + 3].x = x + angle_table[a].x * d;
            v3[id + 3].y = y + angle_table[a].y * d;
        }
        protected static bool Calcul_BPEA(ref BulletPropertyEx bpe, ref BulletStateEx bse,ref Vector3[] v3, ref Vector2[] uv2, int id )
        {
            float x, y;
            if (bpe.move != null)
            {
                bpe.move(ref bpe, ref bse);
                if (bse.active)
                {
                    if(bpe.collision!=null)
                    {
                        bpe.collision(ref bpe, ref bse);
                        if (bse.active)
                            goto label1;
                    }
                }
            }
            else
            {
                x = bse.location.x;
                y = bse.location.y;
                if (y > 5.5f | y < -5.5f | x > 3f | x < -3f)
                {
                    bse.active = false;
                }
                else
                {
                    if (bse.extra == 0)
                    {
                        bse.extra++;
                        int z = bse.angle;
                        if (z < 0)
                            z += 360;
                        if (z > 360)
                            z -= 360;
                        float s = bpe.speed;
                        bse.movexyz.x = angle_table[z].x * s;
                        bse.movexyz.y = angle_table[z].y * s;
                    }
                    x = bse.movexyz.x * ts;
                    y = bse.movexyz.y * ts;
                    bse.location.x += x;
                    bse.location.y += y;
                    if (bpe.collision != null)
                    {
                        bpe.collision(ref bpe, ref bse);
                        if (bse.active)
                            goto label1;
                    } 
                }

            }
            if (bpe.s_count > 0)
            {
                bpe.s_count--;
                int s_count = bpe.s_count;
                bse.active = true;
                bse.extra = 0;
                bse.extra2 = 0;
                bse.extra_p = 0;
                bse.uv_rect = bpe.uv_rect;
                bse.location.x = bpe.shotpoint[s_count].x;
                bse.location.y = bpe.shotpoint[s_count].y;
                bse.angle = (int)bpe.shotpoint[s_count].z;
                uv2[id] = bpe.t_uv[0];
                uv2[id + 1] = bpe.t_uv[1];
                uv2[id + 2] = bpe.t_uv[2];
                uv2[id + 3] = bpe.t_uv[3];
                goto label1;
            }
            else
            {
                v3[id] = Vector3.zero;
                v3[id + 1] = Vector3.zero;
                v3[id + 2] = Vector3.zero;
                v3[id + 3] = Vector3.zero;
            }
            return false;
            label1:;
            if (bse.uv_rect == null)
                return false;
            x = bse.location.x;
            y = bse.location.y;
            if (bpe.play != null)
                bpe.play(ref bpe, ref bse);
            if (bpe.offset)
            {
                v3[id].x = x + bse.uv_rect[0].x;
                v3[id].y = y + bse.uv_rect[0].y;
                v3[id + 1].x = x + bse.uv_rect[1].x;
                v3[id + 1].y = y + bse.uv_rect[1].y;
                v3[id + 2].x = x + bse.uv_rect[2].x;
                v3[id + 2].y = y + bse.uv_rect[2].y;
                v3[id + 3].x = x + bse.uv_rect[3].x;
                v3[id + 3].y = y + bse.uv_rect[3].y;
                return true;
            }
            int la = bse.angle;
            int a = (int)bse.uv_rect[0].x + la;
            float d = bse.uv_rect[0].y;
            if (a >= 360)
                a -= 360;
            v3[id].x = x + angle_table[a].x * d;
            v3[id].y = y + angle_table[a].y * d;
            a = (int)bse.uv_rect[1].x + la;
            if (a >= 360)
                a -= 360;
            d = bse.uv_rect[1].y;
            v3[id + 1].x = x + angle_table[a].x * d;
            v3[id + 1].y = y + angle_table[a].y * d;
            a = (int)bse.uv_rect[2].x + la;
            if (a >= 360)
                a -= 360;
            d = bse.uv_rect[2].y;
            v3[id + 2].x = x + angle_table[a].x * d;
            v3[id + 2].y = y + angle_table[a].y * d;
            a = (int)bse.uv_rect[3].x + la;
            if (a >= 360)
                a -= 360;
            d = bse.uv_rect[3].y;
            v3[id + 3].x = x + angle_table[a].x * d;
            v3[id + 3].y = y + angle_table[a].y * d;
            return true;
        }
#endregion

#region background manage
        static int bk_id, bk_c_id,bk_chang;
        static float bk_t = 0;
        public static Material Mat_bk;// = Resources.Load("Mat/bk") as Material;
        public static void BK_Inital()
        {
            Mat_bk = Resources.Load(mat_bk) as Material;
            bk_id = CreateImgNullEx(BK_update, 0);
            buff_img_ex[bk_id].gameobject.SetActive(false);
            buff_img_ex[bk_id].mr.material = Mat_bk;
            Mesh me = buff_img_ex[bk_id].mesh;
            me.vertices = new Vector3[] { new Vector3(-3, -6), new Vector3(-3, 6), new Vector3(3, 6), new Vector3(3, -6) };
            me.uv = SP.uv_def_1x1;
            me.triangles = SP.tri_def;
        }
        static void BK_update(ref ImageBaseEx ibe)
        {
            if(gameover)
            {
                ibe.gameobject.SetActive(false);
            }
            else
            {
                ibe.gameobject.SetActive(true);
                bk_t += Time.deltaTime*0.1f;
                if (bk_t > 1.8f)
                    bk_t -= 1.8f;
                Material mat = ibe.mr.material;
                mat.SetFloat("_t", bk_t);
                if(bk_chang==2)
                {
                    bk_chang--;
                    if(bk_t<0.05f)
                    {
                        Texture2D t2d = buff_spriteex[bk_c_id].texture;
                        if (t2d == null)
                        {
                            t2d = buff_spriteex[bk_c_id].rr.asset as Texture2D;
                            buff_spriteex[bk_c_id].texture = t2d;
                        }
                        mat.SetTexture("_s", t2d);
                    }
                }
                else if(bk_chang==1)
                {
                    bk_chang--;
                    if(bk_t>0.9f)
                    {
                        Texture2D t2d = buff_spriteex[bk_c_id].texture;
                        if (t2d == null)
                        {
                            t2d = buff_spriteex[bk_c_id].rr.asset as Texture2D;
                            buff_spriteex[bk_c_id].texture = t2d;
                        }
                        mat.SetTexture("_MainTex", t2d);
                    }
                }
            }
        }
        public static void LoadBackGround(int t_id)
        {
            Texture2D t2d = buff_spriteex[t_id].texture;
            if (t2d == null)
            {
                t2d = buff_spriteex[t_id].rr.asset as Texture2D;
                buff_spriteex[t_id].texture = t2d;
            }
            Material mat = buff_img_ex[bk_id].mr.material;
            mat.SetTexture("_MainTex", t2d);
            mat.SetTexture("_s", t2d);
        }
        public static void ChangePicture(int t_id)
        {
            bk_c_id = t_id;
            bk_chang = 2;
        }
#endregion
    }
}