using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using huqiang.UI;

namespace huqiang.Math
{
    public class DotCollider2D:Collider2D
    {
        public DotCollider2D(UITransform trans):base (trans)
        {
            Type = ColliderType.Dot;
        }
    }
}
