using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using huqiang.UI;
using UnityEngine;

namespace huqiang.Math
{
    public class DotCollider2D:Collider2D
    {
        public DotCollider2D(ModelElement trans):base (trans)
        {
            Type = ColliderType.Dot;
        }
        public override bool CheckCollision(Collider2D target)
        {
            switch (target.Type)
            {
                case ColliderType.Box:
                case ColliderType.Polygon:
                    return Physics2D.DotToPolygon(target.Points,Position);
                case ColliderType.Circle:
                    var pos = target.Position - Position;
                    if (pos.x * pos.x + pos.y * pos.y <= target.Radius * target.Radius)
                        return true;
                    else return true;
                case ColliderType.Line:
                    return Physics2D.DotToLine(ref Position,ref target.Points[0],ref target.Points[1]);
                case ColliderType.Edge:
                    return Physics2D.DotToEdge(ref Position,target.Points);
            }
            return false;
        }
    }
}
