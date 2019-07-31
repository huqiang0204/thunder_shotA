using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using huqiang.UI;
using huqiang.UIEvent;

namespace Assets.Page
{
    public class LobbyPage:UIPage
    {
        class View
        {
            public EventCallBack level;
            public TextElement txt_level;
            public EventCallBack store;
            public TextElement txt_store;
            public EventCallBack setting;
            public TextElement txt_set;
        }
        View view;
        public override void Initial(ModelElement parent, object dat = null)
        {
            model = ModelManagerUI.CloneModel("baseUI", "lobby");
            base.Initial(parent, dat);
            view = model.ComponentReflection<View>();
            InitialUI();
        }
        void InitialUI()
        {
            view.level.Click = (o, e) => { LoadPage<LevelPage>(); };
            view.store.Click = (o, e) => { LoadPage<StorePage>(); };
            view.setting.Click = (o, e) => { LoadPage<SettingPage>(); };
        }
    }
}
