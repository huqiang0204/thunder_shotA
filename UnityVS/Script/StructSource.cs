using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Assets.UnityVS.Script
{
    #region delegate
    delegate bool ShaderEffect(ref Material mat, float timeratio);
    delegate void Sliding(Vector3 offset);
    delegate void BulletMoveExA(ref BulletPropertyEx bpe, ref BulletStateEx state);
    delegate void BulletShotEX(Transform parent, ref int count, int id);
    delegate bool EnemyMoveEX(ref EnemyBaseEX ebe);//return false is disappear
    delegate bool Shot(ref EnemyBaseEX ebe);
    delegate void ShotW(ref BulletPropertyEx bpe);
    delegate void DamageE(ref EnemyBaseEX ebe);
    delegate void ShotEx(ref BulletPropertyEx bpe,ref EnemyBaseEX ebe);
    delegate void GenerateProp(int max, Vector3 location);
    delegate void SetBattelField(ref BattelField bf);
    delegate bool CollisionEx(ref BulletPropertyEx bpe,ref BulletStateEx bs);
    delegate void Calcul(ref BulletPropertyEx bpe, ref BulletStateEx[] bs);
    delegate void AnimatInitial(ref AnimatEx[] ae);
    delegate bool AniRun(ref AnimatBaseEx abe, ref AnimatEx[] ae, float ta);
    delegate void levelChangeP(ref WarPlane wp,ref BulletPropertyEx bpe, int level);
    delegate void levelChangeS(ref SecondBullet sb,ref BulletPropertyEx bpe, int level);
    delegate void levelChangW(ref Wing w,ref BulletPropertyEx bpe, int level);
    delegate void IMGupdate(ref ImageBaseEx ibe);
    #endregion

    struct AnimatEx
    {
        public int parentid;
        public Vector2[] uv2;
        public Point2 pivot_p;//父支点 x=角度 y=半径  
        public Point2 location;//中心轴
        public float angle;//旋转角度
        public float scale;
        public Point2[] rect;
        //public int mat_id;
        public bool free;
    }
    struct AnimatBaseEx
    {
        public bool reg;
        public bool up_v;
        //public bool s_o;//stage over
        public float c_time;//current time
        public Vector2[] uv;
        public Vector3[] vertex;
        public int[] tri;
        public AnimatEx[] ae;
        public AnimatInitial ani_ini;
        public AniRun[] stage;
        public Color col;
        public float ex;
    }

    struct BattelField
    {
        public int mode;
        //public int time;
        //public int crt_bkg;
        public List<EnemyWave> wave;
    }

    struct BulletPropertyEx
    {
        public bool active;
        public float speed;
        public float maxrange;//sqr save performance pre-judgment
        public float minrange;//sqr save performance pre-judgment
        public Calcul calcul;
        public ShotW inital;
        public Action dispose;
        public BulletMoveExA move;
        public BulletMoveExA play;
        public CollisionEx collision;
        public IMGupdate up_img;//update and validate
        public bool update;
        public float radius;
        public float attack;
        public bool penetrate;
        public int max;
        public int s_count;//shot count sub thread
        public int a_count;
        public int parentid;//enemy id
        public bool offset;
        public Vector2[] t_uv;
        public Point2[] uv_rect;
        public Point2[] edgepoints;
        public Point3[] shotpoint;//x=x y=y z=angle
        public BulletStateEx[] b_s;
        public int extra;
        public int mat_id;
        public string mat_name;
        public Vector3[] vertexs;
        public Vector2[] uv;
    }
    struct BulletStateEx
    {
        public bool active;
        public int id;
        //public Point2[] edge;
        public Point2[] uv_rect;
        public int extra;
        public int extra2;
        public int extra_p;
        public Vector3 movexyz;
        public Vector2 location;
        public int angle;
        //public Vector2 scale;
    }

    struct CirclePropertyEx
    {
        public ImageProperty imagebase;
        public TextProperty text;
        public CircleButtonBase property;
    }
    struct CircleButtonBase
    {
        public int imageid;
        public int textid;
        public bool active;
        public bool ui;
        public Transform transform;
        public float r;
        public Action click;
        public Sliding sliding;
    }
    struct CurrentDispose
    {
        public int level;
        //public int power;
        public WarPlane warplane;
        public Wing wing;
        public SecondBullet B_second;
        public Shiled shiled;
        public Skill skill;
        public SecondBullet bs_back;
        public Wing w_back;
        //public BulletProperty wingweapon;

        //shiled
        //armor
        //backup second weapon
        //backup wing weap
        //Energy storage weapon 
        //power dispose
    }


    struct EnemyBaseEX
    {
        public bool boss;
        public bool show_blood;
        public float f_blood;//full blood
        public float c_blood;//current blood
        public float defance;
        public int mat_id;
        public string mat_name;
        public Vector2[] uv;
        public Vector3[] vertexs;
        public int[] triangle;
        public int extra_a;
        public int extra_b;//bullet recorder
        public int extra_m;
        public float radius;
        public float maxrange;
        public float minrange;
        public Vector3 location;
        public Vector3 olt;
        public Vector3 angle;
        public int points_style;
        public Point2[] points;
        public Point2[] offset;
        public int[] bulletid;
        public EnemyMoveEX move;
        public ShotEx shot;
        public int shotfrequency;

        public DamageE play;//帧动画
        public bool update_spt;
        public bool animat;                   
        public bool update;
        public int ani_id;
        public AnimatBaseEx abe;

    }
    struct EnemyPropertyEX
    {
        public EnemyBaseEX enemy;
        //public ImageProperty image;
        //public BulletProperty[] bullet;
        public BulletPropertyEx[] bpe;
    }
    struct EnemyWave
    {
        //public int level;
        public int staytime;
        public int sum;
        //public int interval;
        //public int time_c;
        public Point3[] start;
        public EnemyPropertyEX enemyppt;
    }
    struct EdgeButtonBase
    {
        public int imageid;
        public int textid;
        public bool active;
        public bool ui;
        public Transform transform;
        public Point2[] points;
        public Action click;
        public Sliding sliding;
        //public Action LoseFocus; 
    }
    struct EdgePropertyEx
    {
        public ImageProperty imagebase;
        public TextProperty text;
        public EdgeButtonBase property;
    }

    struct Grid
    {
        public int x;
        public int y;
        public Grid(int x1, int y1) { x = x1;y = y1; }
    }
    struct Goods
    {
        public Int32 id;//type and position
        public Int32 level;//store id and level
        public Int32 exp;
    }

    struct ImageBase
    {
        public bool reg;//只好用这个来比较
        //public bool restore;
        public GameObject gameobject;//子线程中比较null都有时候报错，悲催的unity多线程
        public Transform transform;
        public SpriteRenderer spriterender;
        public int spriteid;
    }
    struct ImageBaseEx
    {
        public bool reg;
        public bool restore;
        public GameObject gameobject;
        public Transform transform;
        public MeshRenderer mr;
        public Mesh mesh;
        public IMGupdate update;
        public int extra;
    }
    struct ImageProperty
    {
        public int spt_id;
        //public int spt_index;
        public Vector3 location;
        public Vector3 angle;
        public Vector3 scale;
        // public Rect[] rect;
        public Grid grid;
        public string imagepath;
        //public SpriteInfo[] sprite;
        public int sorting;
    }
    struct ItemBindData
    {
        public string[] imgpath;
        public string[] text;
        //public int[] data;
        //public bool slected;
    }

    struct ListboxItemID
    {
        public int[] img_id;
        public int[] txt_id;
    }
    struct ListBoxItemMod
    {
        public UIImageProperty[] img;
        public UITextProperty[] text;
    }
    struct ListBox
    {
        public bool reg;
        public bool landscape;
        public int current_item;
        public int full_item;
        public int s_index;
        public float len;
        public float per_len;
        public float start;
        public float over;
        public int bk_id;
        public UIImageProperty bk_ground;
        public int vp_id;
        public UIImageProperty vp_window;//view port window      
        public int[] it_id;
        public UIImageProperty item_bkg;//view port window
        public List<ItemBindData> data;
        public ListBoxItemMod item_mod;
        public ListboxItemID[] item_son_id;
        public int event_id;
        public EdgeButtonBase edgebutton;
        public Action<int> click;
    }

    struct MaterialBase
    {
        public Material mat;
        public string path;
        public ResourceRequest rr;
    }
    struct MeshData
    {
        public Vector3[] v3;
        public Vector2[] uv2;
        public int[] tri;
    }

    struct Point2
    {
        public float x;
        public float y;
        public Point2(float x1, float y1) { x = x1; y = y1; }
    }
    struct Point3
    {
        public float x;
        public float y;
        public float z;
        public Point3(float x1, float y1, float z1) { x = x1; y = y1; z = z1; }
        public static Point3 operator +(Point3 a,Point3 b)
        {
            a.x += b.x;
            a.y += b.y;
            a.z += b.z;
            return a;
        }
    }
    struct PropBase
    {
        public bool closely;
        public bool created;
        public int extra;
        public Vector3 location;
        public Vector3 motion;
    }
    struct Power
    {
        public int energy;
        public string[] explain;
        public ImageProperty image;
    }

    struct SpriteInfo
    {
        public Rect rect;
        public Vector2 pivot;
    }
    struct SecondBullet
    {
        public int gold;
        public int bulletid;
        public int shotfrequency;
        public ShotW shot;
        //public BulletPropertybullet;
        public BulletPropertyEx bpe;
        public int extra_b;
        public levelChangeS lc;
    }
    struct Shiled
    {
        public int gold;
        public float defence;
        public float max;
        public float current;
        public float resume;
        public string imgpath;
    }
    struct SpriteBaseEx
    {
        public int dataid;
        public ResourceRequest rr;
        public Texture2D texture;
        public Sprite[] sprites;
        public string path;
        public int count;
    }
    struct Skill
    {
        public int gold;
        public int during;
        public bool follow;
        public float energy_max;
        public float energy_c;//current energy
        public float energy_ec;//energy consumption
        public float energy_re;//resume
        public Vector3 location;
        public float r;
        public float attack;
        //public bool active;
        public bool force_clear;
        public string mat_name;
        public int mat_id;
        public int ani_id;
        public int img_id;
        public AnimatBaseEx abe;
        public IMGupdate update;
    }

    struct TextProperty
    {
        public Vector3 location;
        public Vector3 angle;
        public Vector3 scale;
        public int fontid;
        public int fontsize;
        public Color color;
        public string text;
    }
    struct TextBase
    {
        public GameObject gameobject;
        public Transform transform;
        public MeshRenderer meshrender;
        public TextMesh textmesh;
    }

    struct UITextBase
    {
        public GameObject gameobject;
        public RectTransform transform;
        public Text text;
    }
    struct UIImageBase
    {
        public GameObject gameobject;
        public RectTransform transform;
        public Image image;
        public int spriteid;
    }
    struct UIImageProperty
    {
        //public int spt_id;
        //public int spt_index;
        public Vector3 location;
        //public Vector3 angle;
        public Vector3 scale;
        public Vector2 size;
        public Grid grid;
        public string imagepath;
        //public SpriteInfo[] sprite;
    }
    struct UITextProperty
    {
        public Vector3 location;
        //public Vector3 angle;
        public Vector3 scale;
        public Vector2 size;
        public int fontid;
        public int fontsize;
        public Color color;
        public string text;
    }

    struct WarPlane
    {
        public int gold;
        public float blood;
        public float currentblood;
        public Vector2[] t_uv;
        public BulletPropertyEx bpe;
        public ShotW shot;
        public int shotfrequency;
        public int bulletid;
        public int extra_b;//bullet recorder
        public int mat_id;
        public string mat_name;
        public int ani_id;
        public bool animat;
        public AnimatBaseEx abe;
        public levelChangeP lc;
    }
    struct Wing
    {
        public int gold;
        public int bulletid;
        public int spt_id;
        public int shotfrequency;
        public BulletPropertyEx bpe;
        public Transform transform;
        public ShotW shot;
        public Vector3 angle;
        public Vector3 angle2;
        public Transform transform2;
        public int extra_b;
        public bool animat;
        public int ani_id;
        public AnimatBaseEx abe;
        public levelChangW lc;
        public IMGupdate update;
        public string mat_name;
        public int mat_id;
    }
}
