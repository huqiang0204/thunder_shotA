using Assets.Game;
using huqiang;
using huqiang.Data;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BulletTest : MonoBehaviour
{
    public  void LoadBundle()
    {
#if UNITY_EDITOR
        if (ElementAsset.bundles.Count == 0)
        {
            AssetBundle.UnloadAllAssetBundles(true);
            ElementAsset.bundles.Clear();
            //var dic = Application.dataPath + "/StreamingAssets";
            var dic = Application.streamingAssetsPath;
            if (Directory.Exists(dic))
            {
                var bs = Directory.GetFiles(dic, "*.unity3d");
                for (int i = 0; i < bs.Length; i++)
                {
                    ElementAsset.bundles.Add(AssetBundle.LoadFromFile(bs[i]));
                }
            }
        }
#endif
    }
    BulletLauncher launcher;
    Carrier car;
    // Start is called before the first frame update
    void Start()
    {
        LoadBundle();
        App.RegUI();
        GameScenes.Initial(transform);
        EnemyManager.CreateEnemy("b-03b");
        
    }

    // Update is called once per frame
    void Update()
    {
        GameScenes.Update();
    }
    private void OnDestroy()
    {
        ThreadMission.DisposeAll();
        GameScenes.Dispose();
    }
    
}
