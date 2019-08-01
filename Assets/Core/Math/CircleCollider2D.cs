using System;
using System.Collections.Generic;
using huqiang.UI;

namespace huqiang.Math
{
    public class CircleCollider2D:Collider2D
    {
        public CircleCollider2D(ModelElement element):base(element)
        {
            Type = ColliderType.Circle;
        }
        public override bool CheckCollision(Collider2D target)
        {
            switch(target.Type)
            {
                case ColliderType.Box:
                case ColliderType.Polygon:
                    return Physics2D.CircleToPolygon(Position,Radius,target.Points);
                case ColliderType.Circle:
                    
                    break;
                case ColliderType.Dot:

                    break;
                case ColliderType.Edge:

                    break;
                case ColliderType.Line:

                    break;
            }
            return false;
        }
    }
}
