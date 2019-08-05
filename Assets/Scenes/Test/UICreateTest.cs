using huqiang;
using huqiang.Data;
using huqiang.UI;
using UnityEngine;

public partial class UICreateTest : CreateTestHelper
{
    public TextAsset SpriteInfo;
    public override void CreateTestPage(ModelElement parent)
    {
        ElementAsset.AddSpriteData("spriteInfo", SpriteInfo.bytes);
        CreateUI().SetParent(parent);
    }
}
public partial class UICreateTest
{


     ModelElement CreateUI()
    {
        var mod = ModelElement.CreateNew("test");
        mod.data.sizeDelta = new Vector2(400, 400);
        var img = mod.AddComponent<ShareImageElement>();
        img.ChangeTexture("enemy_b", "base.unity3d");

        //ShareModelElement son = new ShareModelElement();
        //son.SetParent(mod);
        //son.SetUV(ElementAsset.FindSpriteUV("enemy_b", "enemy_b_0", ref son.data.pivot));
        //son.data.localRotation = Quaternion.Euler(0,0,33);
        //son.data.sizeDelta = new Vector2(300,300);
        //son.data.localPosition = new Vector3(-300,100,0);
        //son.IsChanged = true;
        //son.RegEvent<EventCallBack>();
        //son.baseEvent.Click = (o, e) => { Debug.Log("one is ok"); };

        //son = new ShareModelElement();
        //son.SetParent(mod);
        //son.SetUV(ElementAsset.FindSpriteUV("enemy_b", "enemy_b_7", ref son.data.pivot));
        //son.data.localRotation = Quaternion.Euler(0, 0, -44);
        //son.data.sizeDelta = new Vector2(300, 300);
        //son.data.localPosition = new Vector3(100, 300, 0);
        //son.IsChanged = true;
        //son.RegEvent<EventCallBack>();
        //son.baseEvent.Click = (o, e) => { Debug.Log("tow is ok"); };

        //son = new ShareModelElement();
        //son.SetParent(mod);
        //son.SetUV(ElementAsset.FindSpriteUV("enemy_b", "enemy_b_9", ref son.data.pivot));
        ////son.data.localRotation = Quaternion.Euler(0, 0, 180);
        //son.data.sizeDelta = new Vector2(300, 300);
        ////son.data.localPosition = new Vector3(0, -300, 0);
        //son.IsChanged = true;
        //son.RegEvent<EventCallBack>();
        //son.baseEvent.Click = (o, e) => { Debug.Log("three is ok"); };
        //son.FillAmount = 0.66f;
        //son.Changed();

        return mod;
    }
}