using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using huqiang.UI;
using huqiang.UIComposite;
using huqiang.UIEvent;

namespace Assets.Page
{
    public class LevelPage:UIPage
    {
        class View
        {
            public EventCallBack back;
            public ScrollY scroll;
        }
        View view;
        class ItemView
        {
            public EventCallBack icon;
        }
        public override void Initial(ModelElement parent, object dat = null)
        {
            model = ModelManagerUI.CloneModel("baseUI", "level");
            base.Initial(parent, dat);
            view = model.ComponentReflection<View>();
            InitialUI();
        }
        void InitialUI()
        {
            view.back.Click = (o, e) => { LoadPage<LobbyPage>(); };
            view.scroll.SetItemUpdate<ItemView,int>(ItemUpdate);
            int[] dat = new int[20];
            for (int i = 0; i < 20; i++)
                dat[i] = i;
            view.scroll.BindingData = dat;
            view.scroll.Refresh();
        }
        void ItemUpdate(ItemView item,int level,int index)
        {
            var img = item.icon.Context.ColorController as ImageElement;
            item.icon.DataContext = index;
            item.icon.Click = ItemClick;
            if (level > 1)
            {
                item.icon.forbid = true;
                img.SetSprite("Icon_Locked","icons");
            }
            else
            {
                item.icon.forbid = false;
                img.SetSprite("Btn_sci-fi button02_n", "scientific");
            }
        }
        void ItemClick(EventCallBack eve,UserAction action)
        {
            LoadPage<GamePage>(eve.DataContext);
        }

    }
}
