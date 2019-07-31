using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace huqiang.Math
{
    public class LTBezier
    {
        public float length;

        private Vector3 a;
        private Vector3 aa;
        private Vector3 bb;
        private Vector3 cc;
        private float len;
        private float[] arcLengths;

        public LTBezier(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float precision)
        {
            this.a = a;
            aa = (-a + 3 * (b - c) + d);
            bb = 3 * (a + c) - 6 * b;
            cc = 3 * (b - a);

            this.len = 1.0f / precision;
            arcLengths = new float[(int)this.len + (int)1];
            arcLengths[0] = 0;

            Vector3 ov = a;
            Vector3 v;
            float clen = 0.0f;
            for (int i = 1; i <= this.len; i++)
            {
                v = bezierPoint(i * precision);
                clen += (ov - v).magnitude;
                this.arcLengths[i] = clen;
                ov = v;
            }
            this.length = clen;
        }

        private float map(float u)
        {
            float targetLength = u * this.arcLengths[(int)this.len];
            int low = 0;
            int high = (int)this.len;
            int index = 0;
            while (low < high)
            {
                index = low + ((int)((high - low) / 2.0f) | 0);
                if (this.arcLengths[index] < targetLength)
                {
                    low = index + 1;
                }
                else
                {
                    high = index;
                }
            }
            if (this.arcLengths[index] > targetLength)
                index--;
            if (index < 0)
                index = 0;

            return (index + (targetLength - arcLengths[index]) / (arcLengths[index + 1] - arcLengths[index])) / this.len;
        }

        private Vector3 bezierPoint(float t)
        {
            return ((aa * t + (bb)) * t + cc) * t + a;
        }

        public Vector3 point(float t)
        {
            return bezierPoint(map(t));
        }
    }
    public class LTBezierPath
    {
        public Vector3[] pts;
        public float length;
        public bool orientToPath;
        public bool orientToPath2d;

        private LTBezier[] beziers;
        private float[] lengthRatio;
        private int currentBezier = 0, previousBezier = 0;

        public LTBezierPath() { }
        public LTBezierPath(Vector3[] pts_)
        {
            setPoints(pts_);
        }

        public void setPoints(Vector3[] pts_)
        {
            if (pts_.Length < 4)
                LeanTween.logError("LeanTween - When passing values for a vector path, you must pass four or more values!");
            if (pts_.Length % 4 != 0)
                LeanTween.logError("LeanTween - When passing values for a vector path, they must be in sets of four: controlPoint1, controlPoint2, endPoint2, controlPoint2, controlPoint2...");

            pts = pts_;

            int k = 0;
            beziers = new LTBezier[pts.Length / 4];
            lengthRatio = new float[beziers.Length];
            int i;
            length = 0;
            for (i = 0; i < pts.Length; i += 4)
            {
                beziers[k] = new LTBezier(pts[i + 0], pts[i + 2], pts[i + 1], pts[i + 3], 0.05f);
                length += beziers[k].length;
                k++;
            }
            for (i = 0; i < beziers.Length; i++)
            {
                lengthRatio[i] = beziers[i].length / length;
            }
        }

        public float distance
        {
            get
            {
                return length;
            }
        }
        public Vector3 point(float ratio)
        {
            float added = 0.0f;
            for (int i = 0; i < lengthRatio.Length; i++)
            {
                added += lengthRatio[i];
                if (added >= ratio)
                    return beziers[i].point((ratio - (added - lengthRatio[i])) / lengthRatio[i]);
            }
            return beziers[lengthRatio.Length - 1].point(1.0f);
        }

        public Vector3 place2d(float ratio, ref Vector3 angle)
        {
            var pos = point(ratio);
            ratio += 0.001f;
            if (ratio <= 1.0f)
            {
                Vector3 v3Dir = point(ratio) - pos;
                angle.x = 0;
                angle.y = 0;
                angle.z = Mathf.Atan2(v3Dir.y, v3Dir.x) * Mathf.Rad2Deg;
            }
            return pos;
        }
        public float ratioAtPoint(Vector3 pt, float precision = 0.01f)
        {
            float closestDist = float.MaxValue;
            int closestI = 0;
            int maxIndex = Mathf.RoundToInt(1f / precision);
            for (int i = 0; i < maxIndex; i++)
            {
                float ratio = (float)i / (float)maxIndex;
                float dist = Vector3.Distance(pt, point(ratio));
                if (dist < closestDist)
                {
                    closestDist = dist;
                    closestI = i;
                }
            }
            return (float)closestI / (float)(maxIndex);
        }
    }
}
