using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.UnityVS.Script
{   
    public class CanvasControl
    {
        const float layer = 10;
        public static bool Quit;
        public static Action AppQuit;

        #region language
        static readonly string[] L_declare = new string[] { "用了一个多月架构重写\r\n一个人能力有限，开源了\r\nhttps://github.com/huqiang0204\r\n/thunder_shot\r\n我邮箱"+
            "\r\nhuqiang1990@outlook.com\r\n好想要份工作，没人要\r\n剔除了东方模块",
            "open resource,\r\nhttps://github.com/huqiang0204\r\n/thunder_shot\r\nmy email huqiang1990@outlook.com\r\nforget my english is bad,\r\ni want to a work.cry!" };
        static string lang_declare { get { return L_declare[Language]; } }
        public static int Language;
        static readonly string[] L_singlemod = new string[] { "单机模式", "Single Mode" };
        static string lang_single_mod { get {return L_singlemod[Language]; } }
        static readonly string[] L_store = new string[] { "仓库", "Store" };
        static string lang_store { get { return L_store[Language]; } }
        static readonly string[] L_win = new string[] { "战斗胜利", "you win" };
        static string lang_win { get { return L_win[Language]; } }
        static readonly string[] L_lose= new string[] { "战斗失败", "you lose" };
        static string lang_lose { get { return L_lose[Language]; } }
        static readonly string[] L_lang = new string[] { "英文", "Chinese" };
        static string lang_lang { get { return L_lang[Language]; } }
        static readonly string[] L_pass = new string[] { "关卡", "level " };
        static string lang_pass { get { return L_pass[Language]; } }       
        static readonly string[] L_level= new string[] { "等级", "level " };
        static string lang_level{ get { return L_level[Language]; } }
        static readonly string[] L_mainweapon= new string[] { "主武器", "main weapon" };
        static string lang_mainweapon { get { return L_mainweapon[Language]; } }
        static readonly string[] L_secondweapon = new string[] { "副武器", "second weapon" };
        static string lang_secondweapon { get { return L_secondweapon[Language]; } }
        static readonly string[] L_wingweapon = new string[] { "辅助武器", "wing weapon" };
        static string lang_wingdweapon { get { return L_wingweapon[Language]; } }
        static readonly string[] L_shiled = new string[] { "护罩", "shiled" };
        static string lang_shiled { get { return L_shiled[Language]; } }
        static readonly string[] L_skill= new string[] { "储能武器", "skill" };
        static string lang_skill{ get { return L_skill[Language]; } }
        static readonly string[] L_back = new string[] { "返回", "back" };
        static string lang_back { get { return L_back[Language]; } }
        static readonly string[] L_buy = new string[] { "购买", "buy" };
        static string lang_buy { get { return L_buy[Language]; } }
        static readonly string[] L_storage = new string[] { "存储", "storage" };
        static string lang_storage { get { return L_storage[Language]; } }
        static readonly string[] L_openstorage = new string[] { "打开存储", "open storage" };
        static string lang_openstorage { get { return L_openstorage[Language]; } }
        static readonly string[] L_closestorage = new string[] { "关闭存储", "close storage" };
        static string lang_closestorage { get { return L_closestorage[Language]; } }
        static readonly string[] L_fire= new string[] { "火力: ", "fire: " };
        static string lang_fire { get { return L_fire[Language]; } }
        static readonly string[] L_defence = new string[] { "防御: ", "defence: " };
        static string lang_defence{ get { return L_defence[Language]; } }
        static readonly string[] L_clear_bullet = new string[] { "子弹清除: ", "clear bullet: " };
        static string lang_clear_bullet { get { return L_clear_bullet[Language]; } }
        static readonly string[] L_yes = new string[] { "是", "yes" };
        static string lang_yes { get { return L_yes[Language]; } }
        static readonly string[] L_no = new string[] { "否", "no" };
        static string lang_no { get { return L_no[Language]; } }
        static readonly string[] L_blood = new string[] { "血量值: ", "blood: " };
        static string lang_blood { get { return L_blood[Language]; } }
        static readonly string[] L_deploy = new string[] { "装备", "deploy" };
        static string lang_deploy { get { return L_deploy[Language]; } }
        static readonly string[] L_gold = new string[] { "金币 ", "gold " };
        static string lang_gold { get { return L_gold[Language]; } }
        static readonly string[] L_forgold = new string[] { "获得金币: ", "for gold: " };
        static string lang_forgold { get { return L_forgold[Language]; } }
        static readonly string[] L_abandon = new string[] { "放弃任务", "abandon mission" };
        static string lang_abandon { get { return L_abandon[Language]; } }
        static readonly string[] L_continue = new string[] { "继续任务", "continue mission" };
        static string lang_continue { get { return L_continue[Language]; } }
        static readonly string[] L_sample = new string[] { "示例关卡", "sample level" };
        static string lang_sample { get { return L_sample[Language]; } }
        static readonly string[] L_thunder= new string[] { "雷霆战机", "thunder shot" };
        static string lang_thunder { get { return L_thunder[Language]; } }
        static readonly string[] L_project= new string[] { "东方", "east project" };
        static string lang_project { get { return L_project[Language]; } }
        #endregion

        #region allbutons
        const string buttonpicture = "Picture/button";
        const string BK_picture = "Picture/back_button";
        const string SM_picture = "Picture/singlemode";
        const string CR_picture = "Picture/center";
        const string Ri_picture = "Picture/rightgreen";
        static readonly Point2[] def_button = new Point2[]
                  {
                    new Point2(-0.8374165f,0.254037f),
                    new Point2(0.8374165f,0.254037f),
                    new Point2(0.8374165f,-0.254037f),
                    new Point2(-0.8374165f,-0.254037f)
                  };
        static readonly Point2[] right_button = new Point2[]
                  {
                    new Point2(-0.6f,0.32f),
                    new Point2(0.43f,0.32f),
                    new Point2(0.43f,-0.32f),
                    new Point2(-0.6f,-0.32f)
                  };
        static readonly Point2[] left_button = new Point2[]
                  {
                    new Point2(-0.43f,0.32f),
                    new Point2(0.6f,0.32f),
                    new Point2(0.6f,-0.32f),
                    new Point2(-0.43f,-0.32f),
                  };
        
        static CirclePropertyEx BT_back = new CirclePropertyEx()
        {
            property = new CircleButtonBase() { r=1.85f,click=BackClick},
            imagebase = new ImageProperty() {sorting=5, scale = new Vector3(0.3f, 0.3f),
                location = new Vector3(-2f, -4.5f, layer), imagepath = BK_picture }
            
        };
        static EdgePropertyEx BT_edge_def = new EdgePropertyEx()
        {
            imagebase = new ImageProperty()
            {
                imagepath = buttonpicture,
                scale = new Vector3(1, 1),
                sorting = 5
            },
            text = new TextProperty()
            {
                color = Color.red,
                scale = new Vector2(0.1f, 0.1f),
            },
            property = new EdgeButtonBase()
            {
                points = def_button,
            }
        };
        static EdgePropertyEx BT_edge_left = new EdgePropertyEx()
        {
            imagebase = new ImageProperty()
            {
                imagepath = Ri_picture,
                angle = new Vector3(0,0,180),
                scale = new Vector3(1, 1),
                sorting = 5
            },
            property = new EdgeButtonBase()
            {
                points = left_button
            }
        };
        static EdgePropertyEx BT_edge_right = new EdgePropertyEx()
        {
            imagebase = new ImageProperty()
            {
                imagepath = Ri_picture,
                scale = new Vector3(1, 1),
                sorting = 5
            },
            property = new EdgeButtonBase()
            {
                points = right_button
            }
        };
        static EdgePropertyEx BT_level1 = new EdgePropertyEx()
        {
            imagebase = new ImageProperty()
            {
                imagepath = buttonpicture,
                location = new Vector3(0, 0, 1),
                scale = new Vector3(1, 1),
                sorting = 5
            },
            text = new TextProperty()
            {
                text = lang_pass,
                color = Color.green,
                scale = new Vector2(0.1f, 0.1f)
            },
            property = new EdgeButtonBase()
            {
                points = def_button,
                click = thunder_click
            }
        };
        #endregion

        #region image
        static ImageProperty bk_ground = new ImageProperty()
        {
            scale = new Vector3(1, 1.5f),
            location = new Vector3(0, 0, layer),
            imagepath = "Picture/space1",
            sorting = 0
        };
        static ImageProperty goc_notify = new ImageProperty()
        {
            scale = new Vector3(1.2f, 1.5f),
            location = new Vector3(0, 0, layer),
            sorting = 2,
            imagepath = "Picture/bbk"
        };
        static TextProperty goc_text = new TextProperty()
        {
            location = new Vector3(0.5f, -0.2f, layer),
            fontsize = 55,
            scale = new Vector3(0.2f, 0.2f),
            color = Color.red,
        };
        static TextProperty goc_text1 = new TextProperty()
        {
            location = new Vector3(0f, -1.2f, layer),
            fontsize = 33,
            scale = new Vector3(0.1f, 0.1f),
            color = Color.yellow,
        };
        #endregion

        static Vector2 def_scale = new Vector2(1,1);
        static int[] buff_button = new int[20];
        static int[] buff_imgid = new int[20];
        static int bk_id ,test_id,current_level;
        static Action clear_current_button,back;

        #region zoom
        static float Zoom(float p)
        {
           return  (float)Screen.height / 1280*p;
        }
        static Point2 Zoom( Point2 p)
        {
            float a = (float)Screen.height / 1280;
            p.y *= a;
            p.x *= a;
            return p;
        }
        static Point2[] Zoom(Point2[] p)
        {
            float a =(float) Screen.height / 1280;
            for (int i = 0; i < p.Length; i++)
            {
                p[i].y *= a;
                p[i].x *= a ;
            }
            return p;
        }
        static Vector2 Zoom( Vector2 p)
        {
            float a = (float)Screen.height / 1280;
            p.y *= a;
            p.x *= a;
            return p;
        }
        static Vector2[] Zoom( Vector2[] p)
        {
            float a = (float)Screen.height / 1280;
            for (int i = 0; i < p.Length; i++)
            {
                p[i].y *= a;
                p[i].x *= a;
            }
            return p;
        }
        static Vector3 Zoom( Vector3 p)
        {
            float a = (float)Screen.height / 1280;
            p.y *= a;
            p.x *= a;
            return p;
        }
        #endregion

        #region main 
        static void Clear_Inital_Menu()
        {
            QueueSourceEX.DeleteEdgeButton(buff_button[0]);
            QueueSourceEX.DeleteEdgeButton(buff_button[1]);
            QueueSourceEX.DeleteEdgeButton(buff_button[2]);
            QueueSourceEX.RecycleText(test_id);
        }
        public static void Initial()
        {
            if (clear_current_button != null)
                clear_current_button();
            clear_current_button = Clear_Inital_Menu;
            back = null;

            bk_ground.imagepath = "Picture/space1";
            bk_ground.scale = new Vector3(1f, 1.5f);
            bk_id = QueueSourceEX.CreateImage(null, bk_ground);
            test_id = QueueSourceEX.CreateText(null, new TextProperty()
            {
                location = new Vector3(0, 0, layer),
                color = Color.red,
                scale = new Vector3(0.1f, 0.1f),
                text = lang_declare
            });
            EdgePropertyEx temp = BT_edge_def;
            temp.imagebase.location = new Vector3(2, 3, layer);
            temp.text.text = lang_sample;
            temp.property.click = SingleModeClick;
            buff_button[0] = QueueSourceEX.CreateEdgeButton(null, temp);
            temp.imagebase.location = new Vector3(2, -3, layer);
            temp.text.text = lang_lang;
            temp.property.click = LanguageClick;
            buff_button[1] = QueueSourceEX.CreateEdgeButton(null, temp);
            temp.imagebase.location = new Vector3(2, -2, layer);
            temp.text.text = lang_store;
            temp.property.click = StoreClick;
            buff_button[2] = QueueSourceEX.CreateEdgeButton(null, temp);
        }
        static void LanguageClick()
        {
            if (Language == 0)
            {
                Language = 1;
            }
            else
            {
                Language = 0;
            }
            int id = QueueSourceEX.GetEdgeButton(buff_button[0]).textid;
            QueueSourceEX.GetTextBase(id).textmesh.text = lang_single_mod;
            id = QueueSourceEX.GetEdgeButton(buff_button[1]).textid;
            QueueSourceEX.GetTextBase(id).textmesh.text = lang_lang;
            id = QueueSourceEX.GetEdgeButton(buff_button[2]).textid;
            QueueSourceEX.GetTextBase(id).textmesh.text = lang_store;
            QueueSourceEX.GetTextBase(test_id).textmesh.text = lang_declare;
        }
        static void single_mod_clear()
        {
            QueueSourceEX.DeleteEdgeButton(buff_button[0]);
            //QueueSourceEX.DeleteEdgeButton(buff_button[1]);
            QueueSourceEX.DeleteCircleButton(buff_button[2]);
        }
        static void SingleModeClick()
        {
            if (clear_current_button != null)
                clear_current_button();
            BT_level1.imagebase.location = new Vector3(0,-0.5f,layer);
            BT_level1.text.text = lang_thunder;
            BT_level1.property.click = thunder_click;
            buff_button[0]=QueueSourceEX.CreateEdgeButton(null, BT_level1);
            BT_level1.imagebase.location = new Vector3(0, 0.5f, layer);
            //BT_level1.text.text = lang_project;
            //BT_level1.property.click = Level_project_click;
            //buff_button[1]=QueueSourceEX.CreateEdgeButton(null, BT_level1);
            clear_current_button = single_mod_clear;
            back = Initial;
            buff_button[2] = QueueSourceEX.CreateCircleButton(null, BT_back);
        }
        static void OnlineModeClick()
        {

        }
        static void AboutAutherClick()
        {

        }
        #endregion

        #region game run
        static void clear_GOC()
        {
            QueueSourceEX.RecycleText(buff_imgid[2]);
            QueueSourceEX.RecycleText(buff_imgid[1]);
            QueueSourceEX.RecycleImage(buff_imgid[0]);
            QueueSourceEX.RecycleImage(bk_id);
            QueueSourceEX.DeleteCircleButton(buff_button[0]);
        }
        public static void GameOverCallBack(bool win ,int count)
        {
            clear_current_button = clear_GOC;
            back = Initial;
            bk_ground.imagepath = "Picture/space1";
            bk_ground.scale = new Vector3(1f, 1.5f);
            bk_id = QueueSourceEX.CreateImage(null, bk_ground);
            buff_button[0]=QueueSourceEX.CreateCircleButton(null,BT_back);
            buff_imgid[0] = QueueSourceEX.CreateImage(null, goc_notify);
            if(win)
            {
                goc_text.text = lang_win;
                Goods ga = FileManage.GetGood(9);
                count *= 10 + current_level;
                count /= 10;
                ga.exp +=count;
                if(ga.level==current_level)
                   ga.level++;
                FileManage.ResetGood(9, ga);
            }
            else
            {
                goc_text.text = lang_lose;
                count = 0;
            }
            buff_imgid[1]= QueueSourceEX.CreateText(null, goc_text);
            goc_text1.text = lang_forgold + count.ToString();
            buff_imgid[2] = QueueSourceEX.CreateText(null,goc_text1);          
        }
        static void Game_back()
        {
            GameControl.SuspendGame();
            EdgePropertyEx temp = BT_edge_def;
            temp.imagebase.location = new Vector3(0, 0.5f, layer);
            temp.text.text = lang_continue;
            temp.property.click = ContinueMission;
            buff_button[0] = QueueSourceEX.CreateEdgeButton(null, temp);
            temp.imagebase.location = new Vector3(0, -0.5f, layer);
            temp.text.text = lang_abandon;
            temp.property.click = AbandonMission;
            buff_button[1] = QueueSourceEX.CreateEdgeButton(null, temp);
            back = ContinueMission;
        }
        static void AbandonMission()
        {
            QueueSourceEX.DeleteEdgeButton(buff_button[0]);
            QueueSourceEX.DeleteEdgeButton(buff_button[1]);
            GameControl.GameOver(false);
        }
        static void ContinueMission()
        {
            QueueSourceEX.DeleteEdgeButton(buff_button[0]);
            QueueSourceEX.DeleteEdgeButton(buff_button[1]);
            GameControl.ContinueGame();
            back = Game_back;
        }
        #endregion

        #region single mode manage
        static void thunder_level_clear()
        {
            QueueSourceEX.DeleteListBox(buff_button[10]);
            QueueSourceEX.DeleteCircleButton(buff_button[2]);
            ThunderMod.UnPreLoad();
        }
        static void thunder_click()
        {
            QueueSourceEX.DeleteEdgeButton(buff_button[0]);
            //QueueSourceEX.DeleteEdgeButton(buff_button[1]);
            back = SingleModeClick;
            clear_current_button = thunder_level_clear;
            //Vector2 z = Zoom(new Vector2(150, 150));
            ListBox temp = new ListBox()
            {
                len = Zoom(720),
                per_len = Zoom(114),
                edgebutton = new EdgeButtonBase()
                {
                    points = Zoom(new Point2[] {
        new Point2(-180,360),new Point2(180,360),new Point2(180,-360),new Point2(-180,-360)})
                },
                vp_window = new UIImageProperty() { size = Zoom(new Vector2(584, 720)), imagepath = "Picture/989-bg-04", scale = new Vector3(1f, 1f) },
                item_bkg = new UIImageProperty() { size = Zoom(new Vector2(584, 114)), imagepath = "Picture/corps-001", scale = new Vector3(1, 1) }
            };
            temp.item_mod = new ListBoxItemMod()
            {
                img = new UIImageProperty[] {
        new UIImageProperty() { imagepath="Picture/lock",scale=new Vector3(0.8f,0.8f),location=Zoom( new Vector3(-228,0))}, },
                text = new UITextProperty[] { new UITextProperty() { text="",scale=new Vector3(1,1),size=Zoom( new Vector2(200,80)),
            location=Zoom( new Vector3(-54,-22))} }
            };
            temp.data = new List<ItemBindData>();
            int pass = FileManage.GetGood(9).level;           
            ItemBindData ibd = new ItemBindData();
            ibd.imgpath = new string[] { "Picture/lock" };
            for(int i=0;i<5;i++)
            {
                if (i > pass)
                {
                    ibd.imgpath = new string[] { "Picture/lock1" };
                }
                ibd.text = new string[] { "level" +(i+1).ToString()};
                temp.data.Add(ibd);                
            }
            temp.click = Level_thunder_click;
            buff_button[10] = QueueSourceEX.CreateUIlistbox(temp);
            GameControl.SetDispose(FileManage.GetCurrentSet());
            ThunderMod.PreLoad();
        }
        static void Level_thunder_click(int level)
        {
            if (level > FileManage.GetGood(9).level)
                return;
            QueueSourceEX.DeleteListBox(buff_button[10]);
            QueueSourceEX.DeleteCircleButton(buff_button[2]);
            current_level = level;           
            ThunderData.GetLevel(level);
            QueueSourceEX.RecycleImage(bk_id);
            ThunderMod.GameStart();
            clear_current_button = null;
            back = Game_back;
        }
        static void Level_project_click()
        {
            //current_level = 1;
            //GameControl.SetSecondWeapon(DataSource.SB_all[0]);
            //EastData.GetLevel(0);
            //single_mod_clear();
            //QueueSourceEX.RecycleImage(bk_id);           
            //clear_current_button = null;
            //back = Game_back;
            //EastProjectMod.GameStart();
        }
        #endregion
        public static bool BackUp()
        {
            if (clear_current_button == Clear_Inital_Menu)
                return false;
            BackClick();
            return true;
        }
        static void BackClick()
        {
            if(clear_current_button!=null)
            {
                clear_current_button();
                clear_current_button = null;
            }              
            back(); 
        }

        #region store manage
        static void Clear_Store_Menu()
        {
            if (storage_show)
                StorageHide();
            QueueSourceEX.RecycleImage(bk_id);
            QueueSourceEX.DeleteEdgeButton(buff_button[0]);
            QueueSourceEX.DeleteEdgeButton(buff_button[1]);
            QueueSourceEX.DeleteEdgeButton(buff_button[2]);
            QueueSourceEX.DeleteEdgeButton(buff_button[3]);
            QueueSourceEX.DeleteEdgeButton(buff_button[4]);
            QueueSourceEX.RecycleText(buff_button[5]);
            QueueSourceEX.RecycleText(buff_button[6]);
            QueueSourceEX.DeleteListBox(buff_button[10]);
            Store.View_Stop();
        }
        static int viewtype,view_index,lb_index1;
        static List<Goods> lg;
        static bool storage_show;
        static void Store_Left_Right(int d)
        {
            int i = 0;
            switch (viewtype)
            {
                case 0:
                    i = ThunderData.Plane_all.Length;
                    if (i <= 1)
                        return;
                    view_index+=d;
                    if (view_index >= i)
                        view_index = 0;
                    if (view_index < 0)
                        view_index += i;
                    Store.PlaneView(ThunderData.Plane_all[view_index]);
                    QueueSourceEX.GetTextBase(buff_button[5]).textmesh.text
                    = lang_fire + ThunderData.Plane_all[view_index].bpe.attack.ToString() + "\r\n" + lang_blood +
                ThunderData.Plane_all[view_index].blood.ToString() + "\r\n" + lang_gold + ThunderData.Plane_all[view_index].gold.ToString();
                    break;
                case 1:
                    i = ThunderData.SB_all.Length;
                    if (i <= 1)
                        return;
                    view_index+=d;
                    if (view_index >= i)
                        view_index = 0;
                    if (view_index < 0)
                        view_index += i;
                    Store.SecondView(ThunderData.SB_all[view_index]);
                    QueueSourceEX.GetTextBase(buff_button[5]).textmesh.text
                    = lang_fire + ThunderData.SB_all[view_index].bpe.attack.ToString() + "\r\n" +
                    "\r\n" + lang_gold + ThunderData.SB_all[view_index].gold.ToString();
                    break;
                case 2:
                    i = ThunderData.Wing_all.Length;
                    if (i <= 1)
                        return;
                    view_index+=d;
                    if (view_index >= i)
                        view_index = 0;
                    if (view_index < 0)
                        view_index += i;
                    Store.WingView(ThunderData.Wing_all[view_index]);
                    QueueSourceEX.GetTextBase(buff_button[5]).textmesh.text
                    = lang_fire + ThunderData.Wing_all[view_index].bpe.attack.ToString() + "\r\n" +
                     lang_gold + ThunderData.Wing_all[view_index].gold.ToString();
                    break;
                case 3:
                    i = ThunderData.Shiled_all.Length;
                    if (i <= 1)
                        return;
                    view_index+=d;
                    if (view_index >= i)
                        view_index = 0;
                    if (view_index < 0)
                        view_index += i;
                    Store.ShiledView(ThunderData.Shiled_all[view_index]);
                    QueueSourceEX.GetTextBase(buff_button[5]).textmesh.text
                    = lang_defence + ThunderData.Shiled_all[view_index].defence.ToString() + "\r\n" +
                    lang_gold + ThunderData.Shiled_all[view_index].gold.ToString();
                    break;
                case 4:
                    i = ThunderData.all_skill.Length;
                    if (i <= 1)
                        return;
                    view_index+=d;
                    if (view_index >= i)
                        view_index = 0;
                    if (view_index < 0)
                        view_index += i;
                    Store.SkillView(ThunderData.all_skill[view_index]);
                    QueueSourceEX.GetTextBase(buff_button[5]).textmesh.text
                    = lang_fire + ThunderData.all_skill[view_index].attack.ToString() + "\r\n" +
                     lang_gold + ThunderData.all_skill[view_index].gold.ToString();
                    break;
            }
        }
        static void Store_Left_Click()
        {
            Store_Left_Right(-1);
        }
        static void Store_Right_Click()
        {
            Store_Left_Right(1);
        }
        static void ListItemClick(int index)
        {
            view_index = 0;
            lb_index1 = index;
            if (storage_show)
            {
                viewtype = index;
                if (viewtype > 4)
                    viewtype -= 4;
                StorageHide();
                StorageShow();
            }
            else
            {
                viewtype = index;
                if (viewtype > 4)
                    viewtype -= 4;
                switch (viewtype)
                {
                    case 0:
                        Store.PlaneView(ThunderData.Plane_all[0]);
                        break;
                    case 1:
                        Store.SecondView(ThunderData.SB_all[0]);
                        break;
                    case 2:
                        Store.WingView(ThunderData.Wing_all[0]);
                        break;
                    case 3:
                        Store.ShiledView(ThunderData.Shiled_all[0]);
                        break;
                    case 4:
                        Store.SkillView(ThunderData.all_skill[0]);
                        break;
                }
            }          
        }
        static void StoreClick()
        {
            viewtype = 0;
            view_index = 0;
            lb_index1 = 0;
            if (clear_current_button != null)
                clear_current_button();
            clear_current_button = Clear_Store_Menu;
            back = Initial;

            bk_ground.imagepath = "Picture/989";
            bk_ground.scale = new Vector3(1.2f,1.5f);
            QueueSourceEX.ResetImage(null,bk_ground,bk_id);
            
            BT_edge_left.imagebase.location = new Vector3(-2.2f, 0f, layer);
            BT_edge_left.property.click = Store_Left_Click;
            buff_button[0] = QueueSourceEX.CreateEdgeButton(null, BT_edge_left);
            BT_edge_right.imagebase.location = new Vector3(2.2f,0f,layer);
            BT_edge_right.property.click = Store_Right_Click;
            buff_button[1] = QueueSourceEX.CreateEdgeButton(null, BT_edge_right);

            EdgePropertyEx epe = BT_edge_def;
            epe.imagebase.location = new Vector3(-1.88f, -3.46f, layer);
            epe.text.text = lang_back;
            epe.property.click = BackClick;
            buff_button[2] = QueueSourceEX.CreateEdgeButton(null, epe);
            epe.imagebase.location = new Vector3(0, -3.46f, layer);
            epe.text.text = lang_buy;
            epe.property.click = BuyClick;
            buff_button[3] = QueueSourceEX.CreateEdgeButton(null, epe);
            epe.imagebase.location = new Vector3(1.88f, -3.46f, layer);
            epe.text.text = lang_openstorage;
            epe.property.click = StorageClick;
            buff_button[4] = QueueSourceEX.CreateEdgeButton(null, epe);
            
            Store.View_Start(new Vector3(0,0,10));
            //Store.PlaneView(ThunderData.Plane_all[0]);

            TextProperty tp = new TextProperty() { color = Color.red, location = new Vector3(-2, -1, layer),scale=new Vector3(0.1f,0.1f) };
            tp.text = lang_fire + ThunderData.Plane_all[0].bpe.attack.ToString()+"\r\n"+lang_blood+
                ThunderData.Plane_all[0].blood.ToString()+"\r\n" + lang_gold+ ThunderData.Plane_all[0].gold.ToString();
            buff_button[5] = QueueSourceEX.CreateText(null, tp);

            tp.text=lang_gold+ FileManage.GetGood(9).exp.ToString();
            tp.color = Color.green;
            tp.location.y = -3;
            buff_button[6] = QueueSourceEX.CreateText(null, tp);

            //int d = Screen.width / 2;
            Vector2 z = Zoom(new Vector2( 150,150));
            ListBox temp = new ListBox()
            {
                landscape = true,
               // len=Screen.width,
                len=Zoom( 720),
                per_len =Zoom(150),
                edgebutton = new EdgeButtonBase()
                {
                    points =Zoom( new Point2[] {
                    new Point2(-360,75),new Point2(360,75),new Point2(360,-75),new Point2(-360,-75)})
                },
                vp_window = new UIImageProperty() {size=Zoom( new Vector2(720,150)), imagepath = "Picture/989-bg-04",
                    scale = def_scale,location=Zoom(new Vector2(0,-570)) },
                item_bkg = new UIImageProperty() {size=z, imagepath = "Picture/corps-001", scale = def_scale},
            };
            temp.item_mod = new ListBoxItemMod() { img=new UIImageProperty[] {
                new UIImageProperty() {size=z, imagepath = "Picture/corps-001", scale = def_scale} },
            text=new UITextProperty[] { new UITextProperty() { size=z,scale=def_scale,color=Color.green} }
            };
            temp.data = new List<ItemBindData>();
            ItemBindData ibd = new ItemBindData();
            Goods g= FileManage.GetGood(0);
            if (g.level > 0)
                ibd.imgpath = new string[] { ThunderData.img_all_plane[g.id&0xffff] };
            else
                ibd.imgpath = null;                     
            ibd.text = new string[] {lang_mainweapon };
            temp.data.Add(ibd);
            g = FileManage.GetGood(1);
            if (g.level > 0)
                ibd.imgpath = new string[] { ThunderData.img_all_second[g.id & 0xffff] };
            else
                ibd.imgpath = null;
            ibd.text = new string[] { lang_secondweapon };
            temp.data.Add(ibd);
            g = FileManage.GetGood(2);
            if (g.level > 0)
                ibd.imgpath = new string[] { ThunderData.img_all_wing[g.id & 0xffff] };
            else
                ibd.imgpath = null;
            ibd.text = new string[] { lang_wingdweapon };
            temp.data.Add(ibd);
            g = FileManage.GetGood(3);
            if (g.level > 0)
                ibd.imgpath = new string[] { ThunderData.Shiled_all[g.id & 0xffff].imgpath};
            else
                ibd.imgpath = null;
            ibd.text = new string[] { lang_shiled };
            temp.data.Add(ibd);
            g = FileManage.GetGood(4);
            if (g.level > 0)
                ibd.imgpath = new string[] { ThunderData.img_all_skill[g.id & 0xffff] };
            else
                ibd.imgpath = null;
            ibd.text = new string[] { lang_skill };
            temp.data.Add(ibd);
            g = FileManage.GetGood(5);
            if (g.level > 0)
                ibd.imgpath = new string[] { ThunderData.img_all_second[g.id & 0xffff] };
            else
                ibd.imgpath = null;
            ibd.text = new string[] { lang_secondweapon };
            temp.data.Add(ibd);
            g = FileManage.GetGood(6);
            if (g.level > 0)
                ibd.imgpath = new string[] { ThunderData.img_all_wing[g.id & 0xffff] };
            else
                ibd.imgpath = null;
            ibd.text = new string[] { lang_wingdweapon };
            temp.data.Add(ibd);
            temp.click = ListItemClick;
            buff_button[10] =QueueSourceEX.CreateUIlistbox(temp);
        }

        static void ListItemClick1(int index)
        {
            view_index = index;
        }
        static void StorageShow()
        {
             ListBoxItemMod lb_01_mod = new ListBoxItemMod()
            {
                img = new UIImageProperty[] {
        new UIImageProperty() { imagepath="Picture/p-06d",scale=new Vector3(0.8f,0.8f),location=Zoom( new Vector3(-228,0))}, },
                text = new UITextProperty[] { new UITextProperty() { text="",scale=new Vector3(1,1),size=Zoom( new Vector2(200,30)),
            location=Zoom( new Vector3(-54,-22))} }
            };
             ListBox lb_01 = new ListBox()
            {
                len =Zoom(720),
                per_len =Zoom( 114),
                edgebutton = new EdgeButtonBase()
                {
                    points =Zoom( new Point2[] {
        new Point2(-180,360),new Point2(180,360),new Point2(180,-360),new Point2(-180,-360)})
                },
                vp_window = new UIImageProperty() { size =Zoom( new Vector2(584, 720)), imagepath = "Picture/989-bg-04", scale = new Vector3(1f, 1f) },
                item_bkg = new UIImageProperty() { size =Zoom( new Vector2(584, 114)), imagepath = "Picture/corps-001", scale = new Vector3(1, 1) },
                item_mod = lb_01_mod
            };
            lg = FileManage.GetGoods(viewtype);
            lb_01.data = new List<ItemBindData>();
            lb_01.click = ListItemClick1;
            ItemBindData ibd = new ItemBindData();
            switch (viewtype)
            {
                case 0:
                    if (lg.Count > 0)
                        for (int i = 0; i < lg.Count; i++)
                        {
                            int index = lg[i].id & 0xffff;
                            ibd.imgpath = new string[] { ThunderData.img_all_plane[index] };
                            string s = (lg[i].level&0xffff).ToString();
                            ibd.text = new string[] { lang_level + s };
                            lb_01.data.Add(ibd);
                        }
                    break;
                case 1:
                    if (lg.Count > 0)
                        for (int i = 0; i < lg.Count; i++)
                        {
                            int index = lg[i].id & 0xffff;
                            ibd.imgpath = new string[] { ThunderData.img_all_second[index] };
                            string s = (lg[i].level & 0xffff).ToString();
                            ibd.text = new string[] { lang_level + s };
                            lb_01.data.Add(ibd);
                        }
                    break;
                case 2:
                    if (lg.Count > 0)
                        for (int i = 0; i < lg.Count; i++)
                        {
                            int index = lg[i].id & 0xffff;
                            ibd.imgpath = new string[] { ThunderData.img_all_wing[index] };
                            string s = (lg[i].level & 0xffff).ToString();
                            ibd.text = new string[] { lang_level + s };
                            lb_01.data.Add(ibd);
                        }
                    break;
                case 3:
                    if (lg.Count > 0)
                        for (int i = 0; i < lg.Count; i++)
                        {
                            int index = lg[i].id & 0xffff;
                            ibd.imgpath = new string[] { ThunderData.Shiled_all[index].imgpath };
                            string s = (lg[i].level & 0xffff).ToString();
                            ibd.text = new string[] { lang_level + s };
                            lb_01.data.Add(ibd);
                        }
                    break;
                case 4:
                    if (lg.Count > 0)
                        for (int i = 0; i < lg.Count; i++)
                        {
                            int index = lg[i].id & 0xffff;
                            ibd.imgpath = new string[] { ThunderData.img_all_skill[index] };
                            string s = (lg[i].level & 0xffff).ToString();
                            ibd.text = new string[] { lang_level + s };
                            lb_01.data.Add(ibd);
                        }
                    break;
            }
            lb_01.full_item = lg.Count;
            buff_button[11]= QueueSourceEX.CreateUIlistbox(lb_01);

            int t_id= QueueSourceEX.GetEdgeButton(buff_button[3]).textid;
            QueueSourceEX.GetTextBase(t_id).textmesh.text = lang_deploy;
            t_id = QueueSourceEX.GetEdgeButton(buff_button[4]).textid;
            QueueSourceEX.GetTextBase(t_id).textmesh.text = lang_closestorage;
        }
        static void StorageHide()
        {
            QueueSourceEX.DeleteListBox(buff_button[11]);
            int t_id = QueueSourceEX.GetEdgeButton(buff_button[3]).textid;
            QueueSourceEX.GetTextBase(t_id).textmesh.text = lang_buy;
            t_id = QueueSourceEX.GetEdgeButton(buff_button[4]).textid;
            QueueSourceEX.GetTextBase(t_id).textmesh.text = lang_openstorage;
        }
        static void StorageClick()
        {
            view_index = 0;
            if (storage_show)
            {
                StorageHide();
                QueueSourceEX.ShowEdgeButton(buff_button[0]);//left button
                QueueSourceEX.ShowEdgeButton(buff_button[1]);//right button
                Store.PlaneView(ThunderData.Plane_all[0]);
                storage_show = false;
            }               
            else
            {
                QueueSourceEX.HideEdgeButton(buff_button[0]);//left button
                QueueSourceEX.HideEdgeButton(buff_button[1]);//right button
                storage_show = true;
                StorageShow();
            }               
        }
        static void BuyClick()
        {
            if(storage_show)//deploy
            {
                if (lg.Count > 0)
                {
                    Goods g = FileManage.GetGood(lg[view_index].level>>16);
                    int p_id = g.id & 0xffff;                   
                    switch (viewtype)
                    {
                        case 0:                                                     
                            ItemBindData ibd = new ItemBindData();
                            ibd.imgpath = new string[] { ThunderData.img_all_plane[p_id] };
                            string s = (g.level & 0xffff).ToString();
                            ibd.text = new string[] { lang_level + s };
                            QueueSourceEX.ChangeItem(buff_button[10], lb_index1, ibd);
                            p_id = FileManage.GetGood(lb_index1).id & 0xffff;
                            ibd.imgpath = new string[] { ThunderData.img_all_plane[p_id] };
                            ibd.text = new string[] { lang_mainweapon };
                            QueueSourceEX.ChangeItem(buff_button[11], view_index, ibd);
                            lg[view_index] = g;
                            break;
                        case 1:
                            ibd.imgpath = new string[] { ThunderData.img_all_second[p_id] };
                            s = (g.level & 0xffff).ToString();
                            ibd.text = new string[] { lang_level + s };
                            QueueSourceEX.ChangeItem(buff_button[10], lb_index1, ibd);
                            p_id = FileManage.GetGood(lb_index1).id & 0xffff;
                            ibd.imgpath = new string[] { ThunderData.img_all_second[p_id] };
                            ibd.text = new string[] { lang_secondweapon };
                            QueueSourceEX.ChangeItem(buff_button[11], view_index, ibd);
                            lg[view_index] = g;
                            break;
                        case 2:
                            ibd.imgpath = new string[] { ThunderData.img_all_wing[p_id] };
                            s = (g.level & 0xffff).ToString();
                            ibd.text = new string[] { lang_level + s };
                            QueueSourceEX.ChangeItem(buff_button[10], lb_index1, ibd);
                            p_id = FileManage.GetGood(lb_index1).id & 0xffff;
                            ibd.imgpath = new string[] { ThunderData.img_all_wing[p_id] };
                            ibd.text = new string[] { lang_wingdweapon };
                            QueueSourceEX.ChangeItem(buff_button[11], view_index, ibd);
                            lg[view_index] = g;
                            break;
                        case 3:
                            ibd.imgpath = new string[] { ThunderData.Shiled_all[p_id].imgpath };
                            s = (g.level & 0xffff).ToString();
                            ibd.text = new string[] { lang_level + s };
                            QueueSourceEX.ChangeItem(buff_button[10], lb_index1, ibd);
                            p_id = FileManage.GetGood(lb_index1).id & 0xffff;
                            ibd.imgpath = new string[] { ThunderData.Shiled_all[p_id].imgpath };
                            ibd.text = new string[] { lang_shiled };
                            QueueSourceEX.ChangeItem(buff_button[11], view_index, ibd);
                            lg[view_index] = g;
                            break;
                        case 4:
                            ibd.imgpath = new string[] { ThunderData.img_all_skill[p_id] };
                            s = (g.level & 0xffff).ToString();
                            ibd.text = new string[] { lang_level + s };
                            QueueSourceEX.ChangeItem(buff_button[10], lb_index1, ibd);
                            p_id = FileManage.GetGood(lb_index1).id & 0xffff;
                            ibd.imgpath = new string[] { ThunderData.img_all_skill[p_id] };
                            ibd.text = new string[] { lang_skill };
                            QueueSourceEX.ChangeItem(buff_button[11], view_index, ibd);
                            lg[view_index] = g;
                            break;
                    }
                    FileManage.ReplaceWeapon(lb_index1, g);
                }
            }
            else//buy
            {
                Goods g= FileManage.GetGood(9);
                int pice = 10000;
                switch (viewtype)
                {
                    case 0:
                        pice= ThunderData.Plane_all[view_index].gold;
                        break;
                    case 1:
                        pice= ThunderData.SB_all[view_index].gold;
                        break;
                    case 2:
                        pice= ThunderData.Wing_all[view_index].gold;
                        break;
                    case 3:
                        pice= ThunderData.Shiled_all[view_index].gold;
                        break;
                    case 4:
                        pice=ThunderData.all_skill[view_index].gold;
                        break;
                }
                if(g.exp-pice>=0)
                {
                    g.exp -= pice;
                    FileManage.AddGood(viewtype,view_index);
                    FileManage.ResetGood(9,g);
                    QueueSourceEX.GetTextBase(buff_button[6]).textmesh.text = lang_gold+g.exp.ToString();
                }
            }
        }
        #endregion
    }
}
