using Assets.Page;
using huqiang.Data;
using huqiang.UI;
using huqiang.UIComposite;
using System.Collections.Generic;
using UnityEngine;

public class UITest : TestHelper
{
    public TextAsset SpriteInfo;
    public override void LoadTestPage()
    {
        ElementAsset.AddSpriteData("baseInfo",SpriteInfo.bytes);
        Application.targetFrameRate = 60;
#if UNITY_IPHONE || UNITY_ANDROID
        //Scale.DpiScale = true;
#endif
        UIPage.LoadPage<LobbyPage>();
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}