using huqiang;
using huqiang.Data;
using huqiang.UI;
using huqiang.UIComposite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class UICreateTest : CreateTestHelper
{
    ShareImage image;
    public TextAsset SpriteInfo;
    SpriteData sd;
    public override void CreateTestPage(ModelElement parent)
    {
        sd = new SpriteData();
        sd.LoadSpriteData(SpriteInfo.bytes);
        image = UICreator.CreateShareImage("test");
        image.Model.SetParent(parent);
        image.rawImage.ChangeTexture("enemy_b", "base.unity3d");

        ShareComponent share = new ShareComponent(image);
        share.SetUV(sd.FindSpriteUV("enemy_b", "enemy_b_0",ref share.Pivot));
        share.Angle = new Vector3(0,0,33);
        share.SizeDelta = new Vector2(300,300);
        share.LocalPosition = new Vector3(-300,100,0);
        share.Changed = true;

        share = new ShareComponent(image);
        share.SetUV(sd.FindSpriteUV("enemy_b", "enemy_b_7",ref share.Pivot));
        share.Angle = new Vector3(0, 0, -44);
        share.SizeDelta = new Vector2(300, 300);
        share.LocalPosition = new Vector3(100, 300, 0);
        share.Changed = true;

        share = new ShareComponent(image);
        share.SetUV(sd.FindSpriteUV("enemy_b", "enemy_b_9",ref share.Pivot));
        share.Angle = new Vector3(0, 0, 180);
        share.SizeDelta = new Vector2(300, 300);
        share.LocalPosition = new Vector3(0, -300, 0);
        share.Changed = true;

        image.Refresh();

    }
}