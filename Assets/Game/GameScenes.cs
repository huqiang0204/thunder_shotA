using huqiang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Game
{
    public class GameScenes
    {
        static RectTransform UIRoot;
        static ThreadMission mission;
        public static void Initial(Transform uiRoot)
        {
            UIRoot = uiRoot as RectTransform;
            if (UIRoot == null)
            {
                UIRoot = new GameObject("Game", typeof(Canvas)).transform as RectTransform;
                UIRoot.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            }
            mission = new ThreadMission("Game");
        }
        public static void Update()
        {
            mission.AddSubMission(SubThread, null);
        }
        public static void LoadScene(string scene)
        {
            mission.AddMainMission(ChangeScene,scene);
        }
        static void ChangeScene(object obj)
        {

        }
        static void SubThread(object obj)
        {
            
        }
    }
}
