using huqiang.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace huqiang.Math
{
    public class Collider2D
    {
        public enum ColliderType
        {
            Dot, Line, Box, Circle, Edge, Polygon
        }
        public ColliderType Type;
        public Vector2[] Points;
        public float Radius;
        public Vector2 Position;
        public Coordinates coordinates;
        public ModelElement transform { get; private set; }
        public Collider2D(ModelElement trans)
        {
            transform = trans;
        }
        public virtual void Update()
        {
            coordinates = ModelElement.GetGlobaInfo(transform);
            Position = coordinates.Postion;
        }
        public virtual bool CheckCollision(Collider2D target)
        {
            return false;
        }
    }
}
