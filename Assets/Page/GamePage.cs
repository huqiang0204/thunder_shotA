using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using huqiang.UI;

namespace Assets.Page
{
    public class GamePage:UIPage
    {
        class View
        {

        }
        View view;
        public override void Initial(ModelElement parent, object dat = null)
        {
            model = ModelManagerUI.CloneModel("baseUI", "game");
            base.Initial(parent, dat);
            view = model.ComponentReflection<View>();
        }
    }
}
