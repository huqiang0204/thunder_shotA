using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Game
{
    public class MoveRoute
    {
        public static float CalculDistance(Vector3[] points)
        {
            float len = 0;
            int e = 1;
            for(int i=0;i<points.Length-1;i++)
            {
                float x = points[e].x - points[i].x;
                float y = points[e].y - points[i].y;
                points[i].z = Mathf.Sqrt(x * x + y * y);
                e++;
            }
            return len;
        }
        public static Vector2 Line(Vector3[] points,float time,float speed)
        {
            float d = time * speed;
            for(int i=0;i<points.Length -1;i++)
            {
                d -= points[i].z;
                if(d<0)
                {
                    float r = (points[i].z + d)/points[i].z;
                    Vector2 v = new Vector2();
                    v.x = (points[i + 1].x - points[i].x) * r + points[i].x;
                    v.y = (points[i + 1].y - points[i].y) * r + points[i].y;
                    return v;
                }
            }
            return points[points.Length - 1];
        }
    }
}
