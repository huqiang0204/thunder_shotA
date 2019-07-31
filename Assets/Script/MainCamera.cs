#define Phone
#undef Phone
#define desktop
//#undef desktop
#define debug
#undef debug
using System;
using UnityEngine;
using Assets.UnityVS.Script;

class MainCamera : MonoBehaviour {
    // Use this for initialization
    //720/1280=0.5625
    Transform tf;
    int tid;
    static void Buff()
    {
#if desktop
        Screen.SetResolution(720,1280,false);
#endif
        GameControl.IniB_ExA();
        GameControl.InitialEnemyA();
        GameControl.LoadBaseComponent();
        GameControl.BK_Inital();
        update = null;
    }
    void  Start () {
        //QueueSourceEX.def_font = Resources.Load("Fonts/STXINGKA") as Font;
        tf = transform;
        QueueSourceEX.LoadBase();
#if Phone
        Vector3 scale = tf.localScale;
        scale.x = (float)Screen.width / (float)Screen.height / 0.5625f;
        tf.localScale = scale;  
#endif
        AsyncManage.Inital();
        FileManage.datapath = Application.dataPath;
        //AsyncManage.AsyncDelegate(FileManage.InitialData);
        AsyncManage.AsyncDelegate(FileManage.LoadDisposeFile);
        AsyncManage.AsyncDelegate(GameControl.InitialParameter);

        CanvasControl.Language = 0;       
        CanvasControl.Initial();
        
        GameObject temp = new GameObject();
        
        Canvas c= temp.AddComponent<Canvas>();      
        c.renderMode = RenderMode.ScreenSpaceOverlay;
        //c.worldCamera = Camera.main;
        //c.planeDistance = -1;
        QueueSourceEX.main_canvas = c.transform;
        c.transform.localScale = new Vector3(1,1);
        update=Buff;
#if debug
        TextProperty t = new TextProperty() {text="frame:", color=Color.yellow, scale=new Vector3(0.1f,0.1f),location=new Vector3(2,4.1f,10)};
        tid = QueueSourceEX.CreateText(null,t);
#endif    

    }
    // Update is called once per frame
    static int clicktime;
    void Update()
    {
#if debug
        float fr =1/ Time.deltaTime;
        int ti = (int)fr;
        QueueSourceEX.GetTextBase(tid).textmesh.text="frame:"+ti.ToString();
#endif
#if desktop
        Vector3 scale = tf.localScale;
        scale.x = (float)Screen.width / (float)Screen.height / 0.5625f;
        tf.localScale = scale;
#endif
        if (clicktime > 0)
            clicktime--;
        if (Input.GetMouseButtonDown(0))
        {
            QueueSourceEX.Mouse_Down(Input.mousePosition);
            clicktime = 20;
        }           
        else if (Input.GetMouseButtonUp(0))
        {
            if (clicktime > 0)
                QueueSourceEX.Mouse_Click(Input.mousePosition);
            QueueSourceEX.Mouse_Up(Input.mousePosition);
        }            
        else
            QueueSourceEX.Mouse_Move(Input.mousePosition);
#if desktop
        if (Input.GetKeyDown(KeyCode.Escape))
            if (CanvasControl.BackUp() == false)
            {
                AsyncManage.Stop();
                Application.Quit();
            }
#endif
#if Phone
        if (CanvasControl.Quit)
        {
            if (CanvasControl.BackUp() == false)
            {
                Application.Quit();
                CanvasControl.AppQuit();
            }
            else CanvasControl.Quit = false;
        }                         
#endif
        if (update != null)
            update();
        if(v)
        virbrate();
    }
    public static Action update;
    void OnApplicationQuit()
    { 
        if(CanvasControl.BackUp())
           Application.CancelQuit();
        FileManage.SaveDisposeFile();
    }
    public static bool v;
    public static float t;
    void virbrate()
    {
        t += Time.deltaTime;
        float t1 = t * 10;
        int c = (int)t1;
        float t2 = t1 - c;
        if (t2 > 0.5f)
            t2 = 1 - t2;
        t2 *= 0.2f;
        Vector3 temp = Vector3.zero;
        temp.x = t2;
        transform.localPosition = temp;
        if (t > 0.8f)
        {
            transform.localPosition = Vector3.zero;
            v = false;
            t = 0;
        }
    }
}
