using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace huqiang
{
    public class BezierPath : MonoBehaviour
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a">起点</param>
        /// <param name="b">起点方向b-a</param>
        /// <param name="c">终点方向d-c</param>
        /// <param name="d">终点</param>
        /// <param name="arrowSize">箭头尺寸</param>
        /// <param name="arrowTransform"></param>
        public static void DrawBezierPath(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float arrowSize = 0.0f, Transform arrowTransform = null)
        {
            Vector3 last = a;
            Vector3 p;
            Vector3 aa = (-a + 3 * (b - c) + d);
            Vector3 bb = 3 * (a + c) - 6 * b;
            Vector3 cc = 3 * (b - a);

            float t;

            if (arrowSize > 0.0f)
            {
                Vector3 beforePos = arrowTransform.position;
                Quaternion beforeQ = arrowTransform.rotation;
                float distanceTravelled = 0f;

                for (float k = 1.0f; k <= 120.0f; k++)
                {
                    t = k / 120.0f;
                    p = ((aa * t + (bb)) * t + cc) * t + a;
                    Gizmos.DrawLine(last, p);
                    distanceTravelled += (p - last).magnitude;
                    if (distanceTravelled > 1f)
                    {
                        distanceTravelled = distanceTravelled - 1f;
                        arrowTransform.position = p;
                        arrowTransform.LookAt(last, Vector3.forward);
                        Vector3 to = arrowTransform.TransformDirection(Vector3.right);
                        Vector3 back = (last - p);
                        back = back.normalized;
                        Gizmos.DrawLine(p, p + (to + back) * arrowSize);
                        to = arrowTransform.TransformDirection(-Vector3.right);
                        Gizmos.DrawLine(p, p + (to + back) * arrowSize);
                    }
                    last = p;
                }

                arrowTransform.position = beforePos;
                arrowTransform.rotation = beforeQ;
            }
            else
            {
                for (float k = 1.0f; k <= 30.0f; k++)
                {
                    t = k / 30.0f;
                    p = ((aa * t + (bb)) * t + cc) * t + a;
                    Gizmos.DrawLine(last, p);
                    last = p;
                }
            }
        }
        public int count;
        private int k;
        public int lastCount = 1;
        public Transform[] pts;
        public Vector3[] vec3
        {
            get
            {
                Vector3[] p = new Vector3[pts.Length];
                // Debug.Log("p.Length:"+p.Length+" pts.Length:"+pts.Length);
                for (int i = 0; i < p.Length; i++)
                {
                    p[i] = i > 3 && i % 4 == 0 ? pts[i - 1].position : pts[i].position;
                }
                return p;
            }
        }
        public Vector3[] path;
        public void addNode()
        {
            this.count += 4;
        }
        public void addNodeAfter(int after)
        {
            if (after >= this.pts.Length - 1)
            {
                addNode();
            }
            else
            {

                Vector3[] from = this.vec3;
                this.pts = null;

                int addAmt = 4;
                this.path = new Vector3[from.Length + addAmt];
                Vector3 a = Vector3.zero;
                Vector3 b = Vector3.zero;
                Vector3 diff = Vector3.zero;

                for (int i = 0; i < this.path.Length; i++)
                {
                    if (i == after + 1)
                    {
                        a = from[i];
                        if (from.Length > 4)
                        {
                            b = from[i + 3];
                        }
                        else
                        {
                            b = from[3];
                        }

                        diff = b - a;
                    }

                    if (i > after && i < after + 4)
                    {
                        if (i % 4 == 0)
                        {
                            path[i] = a + diff * 0.0f;
                        }
                        else if (i % 4 == 1)
                        {
                            path[i] = a + diff * 0.33f;
                        }
                        else if (i % 4 == 2)
                        {
                            path[i] = a + diff * 0.17f;
                        }
                        else
                        {
                            //path[i] = a + diff * 0.3f; // Not used I don't think
                        }
                    }
                    else
                    {
                        if (i <= after)
                        {
                            path[i] = from[i];
                        }
                        else if (i < after + 8)
                        {
                            if (i % 4 == 0)
                            {
                                //path[i] = a + diff * 0.3f; // Not used I don't think
                            }
                            else if (i % 4 == 1)
                            {
                                path[i] = a + diff * 0.83f;
                            }
                            else if (i % 4 == 2)
                            {
                                path[i] = a + diff * 0.67f;
                            }
                            else
                            {
                                path[i] = a + diff * 0.5f;
                            }
                        }
                        else
                        { // much after
                            path[i] = from[i - 4];
                        }
                    }
                }

                //init();
            }
        }
    }
}
