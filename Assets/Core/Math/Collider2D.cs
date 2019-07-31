using huqiang.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace huqiang.Math
{
    public class Collider2D
    {
        protected enum ColliderType
        {
            Dot, Line, Box, Circle, Edge, Polygon
        }
        protected ColliderType Type;
        public UITransform transform { get; private set; }
        public Collider2D(UITransform trans)
        {
            transform = trans;
        }
        public virtual void Update()
        {
        }
        public virtual void CheckCollision(Collider2D target)
        {
        }
    }
}
