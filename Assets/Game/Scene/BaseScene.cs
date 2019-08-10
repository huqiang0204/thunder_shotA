using huqiang.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Scene
{
    public class BaseScene
    {
        public static BaseScene Current;
        public ModelElement model;
        public ModelElement Parent;
        public object DataContext;
        public virtual void Initial(ModelElement parent,object dat)
        {
            Parent = parent;
            DataContext = dat;
        }
        public virtual void Update()
        {
        }
        public virtual void Dispose()
        {
            if (model != null)
            {
                ModelManagerUI.RecycleElement(model);
            }
        }
    }
}
