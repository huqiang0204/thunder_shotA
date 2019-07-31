using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[System.Serializable]
public class LTSpline
{
    public static int DISTANCE_COUNT = 3; // increase for a more accurate constant speed
    public static int SUBLINE_COUNT = 20; // increase for a more accurate smoothing of the curves into lines

    /**
    * @property {float} distance distance of the spline (in unity units)
    */
    public float distance = 0f;

    public bool constantSpeed = true;

    public Vector3[] pts;
    [System.NonSerialized]
    public Vector3[] ptsAdj;
    public int ptsAdjLength;
    public bool orientToPath;
    public bool orientToPath2d;
    private int numSections;
    private int currPt;

    public LTSpline(Vector3[] pts)
    {
        init(pts, true);
    }

    public LTSpline(Vector3[] pts, bool constantSpeed)
    {
        this.constantSpeed = constantSpeed;
        init(pts, constantSpeed);
    }

    private void init(Vector3[] pts, bool constantSpeed)
    {
        if (pts.Length < 4)
        {
            LeanTween.logError("LeanTween - When passing values for a spline path, you must pass four or more values!");
            return;
        }

        this.pts = new Vector3[pts.Length];
        System.Array.Copy(pts, this.pts, pts.Length);

        numSections = pts.Length - 3;

        float minSegment = float.PositiveInfinity;
        Vector3 earlierPoint = this.pts[1];
        float totalDistance = 0f;
        for (int i = 1; i < this.pts.Length - 1; i++)
        {
            // float pointDistance = (this.pts[i]-earlierPoint).sqrMagnitude;
            float pointDistance = Vector3.Distance(this.pts[i], earlierPoint);
            //Debug.Log("pointDist:"+pointDistance);
            if (pointDistance < minSegment)
            {
                minSegment = pointDistance;
            }

            totalDistance += pointDistance;
        }

        if (constantSpeed)
        {
            minSegment = totalDistance / (numSections * SUBLINE_COUNT);
            //Debug.Log("minSegment:"+minSegment+" numSections:"+numSections);

            float minPrecision = minSegment / SUBLINE_COUNT; // number of subdivisions in each segment
            int precision = (int)Mathf.Ceil(totalDistance / minPrecision) * DISTANCE_COUNT;
            // Debug.Log("precision:"+precision);
            if (precision <= 1) // precision has to be greater than one
                precision = 2;

            ptsAdj = new Vector3[precision];
            earlierPoint = interp(0f);
            int num = 1;
            ptsAdj[0] = earlierPoint;
            distance = 0f;
            for (int i = 0; i < precision + 1; i++)
            {
                float fract = ((float)(i)) / precision;
                // Debug.Log("fract:"+fract);
                Vector3 point = interp(fract);
                float dist = Vector3.Distance(point, earlierPoint);

                // float dist = (point-earlierPoint).sqrMagnitude;
                if (dist >= minPrecision || fract >= 1.0f)
                {
                    ptsAdj[num] = point;
                    distance += dist; // only add it to the total distance once we know we are adding it as an adjusted point

                    earlierPoint = point;
                    // Debug.Log("fract:"+fract+" point:"+point);
                    num++;
                }
            }
            // make sure there is a point at the very end
            /*num++;
            Vector3 endPoint = interp( 1f );
            ptsAdj[num] = endPoint;*/
            // Debug.Log("fract 1f endPoint:"+endPoint);

            ptsAdjLength = num;
        }
        // Debug.Log("map 1f:"+map(1f)+" end:"+ptsAdj[ ptsAdjLength-1 ]);

        // Debug.Log("ptsAdjLength:"+ptsAdjLength+" minPrecision:"+minPrecision+" precision:"+precision);
    }

    public Vector3 map(float u)
    {
        if (u >= 1f)
            return pts[pts.Length - 2];
        float t = u * (ptsAdjLength - 1);
        int first = (int)Mathf.Floor(t);
        int next = (int)Mathf.Ceil(t);

        if (first < 0)
            first = 0;

        Vector3 val = ptsAdj[first];


        Vector3 nextVal = ptsAdj[next];
        float diff = t - first;

        // Debug.Log("u:"+u+" val:"+val +" nextVal:"+nextVal+" diff:"+diff+" first:"+first+" next:"+next);

        val = val + (nextVal - val) * diff;

        return val;
    }

    public Vector3 interp(float t)
    {
        currPt = Mathf.Min(Mathf.FloorToInt(t * (float)numSections), numSections - 1);
        float u = t * (float)numSections - (float)currPt;

        //Debug.Log("currPt:"+currPt+" numSections:"+numSections+" pts.Length :"+pts.Length );
        Vector3 a = pts[currPt];
        Vector3 b = pts[currPt + 1];
        Vector3 c = pts[currPt + 2];
        Vector3 d = pts[currPt + 3];

        Vector3 val = (.5f * (
            (-a + 3f * b - 3f * c + d) * (u * u * u)
            + (2f * a - 5f * b + 4f * c - d) * (u * u)
            + (-a + c) * u
            + 2f * b));
        // Debug.Log("currPt:"+currPt+" t:"+t+" val.x"+val.x+" y:"+val.y+" z:"+val.z);

        return val;
    }

    /**
    * Retrieve a point along a path <summary>Move a GameObject to a certain location</summary>
    * 
    * @method ratioAtPoint
    * @param {Vector3} point:Vector3 given a current location it makes the best approximiation of where it is along the path ratio-wise (0-1)
    * @return {float} float of ratio along the path
    * @example
    * ratioIter = ltSpline.ratioAtPoint( transform.position );
    */
    public float ratioAtPoint(Vector3 pt)
    {
        float closestDist = float.MaxValue;
        int closestI = 0;
        for (int i = 0; i < ptsAdjLength; i++)
        {
            float dist = Vector3.Distance(pt, ptsAdj[i]);
            // Debug.Log("i:"+i+" dist:"+dist);
            if (dist < closestDist)
            {
                closestDist = dist;
                closestI = i;
            }
        }
        // Debug.Log("closestI:"+closestI+" ptsAdjLength:"+ptsAdjLength);
        return (float)closestI / (float)(ptsAdjLength - 1);
    }

    /**
    * Retrieve a point along a path <summary>Move a GameObject to a certain location</summary>
    * 
    * @method point
    * @param {float} ratio:float ratio of the point along the path you wish to receive (0-1)
    * @return {Vector3} Vector3 position of the point along the path
    * @example
    * transform.position = ltSpline.point( 0.6f );
    */
    public Vector3 point(float ratio)
    {
        float t = ratio > 1f ? 1f : ratio;
        return constantSpeed ? map(t) : interp(t);
    }

    public void place2d(Transform transform, float ratio)
    {
        transform.position = point(ratio);
        ratio += 0.001f;
        if (ratio <= 1.0f)
        {
            Vector3 v3Dir = point(ratio) - transform.position;
            float angle = Mathf.Atan2(v3Dir.y, v3Dir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angle);
        }
    }

    public void placeLocal2d(Transform transform, float ratio)
    {
        Transform trans = transform.parent;
        if (trans == null)
        { // this has no parent, just do a regular transform
            place2d(transform, ratio);
            return;
        }
        transform.localPosition = point(ratio);
        ratio += 0.001f;
        if (ratio <= 1.0f)
        {
            Vector3 ptAhead = point(ratio);//trans.TransformPoint(  );
            Vector3 v3Dir = ptAhead - transform.localPosition;
            float angle = Mathf.Atan2(v3Dir.y, v3Dir.x) * Mathf.Rad2Deg;
            transform.localEulerAngles = new Vector3(0, 0, angle);
        }
    }


    /**
    * Place an object along a certain point on the path (facing the direction perpendicular to the path) <summary>Move a GameObject to a certain location</summary>
    * 
    * @method place
    * @param {Transform} transform:Transform the transform of the object you wish to place along the path
    * @param {float} ratio:float ratio of the point along the path you wish to receive (0-1)
    * @example
    * ltPath.place( transform, 0.6f );
    */
    public void place(Transform transform, float ratio)
    {
        place(transform, ratio, Vector3.up);
    }

    /**
    * Place an object along a certain point on the path, with it facing a certain direction perpendicular to the path <summary>Move a GameObject to a certain location</summary>
    * 
    * @method place
    * @param {Transform} transform:Transform the transform of the object you wish to place along the path
    * @param {float} ratio:float ratio of the point along the path you wish to receive (0-1)
    * @param {Vector3} rotation:Vector3 the direction in which to place the transform ex: Vector3.up
    * @example
    * ltPath.place( transform, 0.6f, Vector3.left );
    */
    public void place(Transform transform, float ratio, Vector3 worldUp)
    {
        // ratio = Mathf.Repeat(ratio, 1.0f); // make sure ratio is always between 0-1
        transform.position = point(ratio);
        ratio += 0.001f;
        if (ratio <= 1.0f)
            transform.LookAt(point(ratio), worldUp);

    }

    /**
    * Place an object along a certain point on the path (facing the direction perpendicular to the path) - Local Space, not world-space <summary>Move a GameObject to a certain location</summary>
    * 
    * @method placeLocal
    * @param {Transform} transform:Transform the transform of the object you wish to place along the path
    * @param {float} ratio:float ratio of the point along the path you wish to receive (0-1)
    * @example
    * ltPath.placeLocal( transform, 0.6f );
    */
    public void placeLocal(Transform transform, float ratio)
    {
        placeLocal(transform, ratio, Vector3.up);
    }

    /**
    * Place an object along a certain point on the path, with it facing a certain direction perpendicular to the path - Local Space, not world-space <summary>Move a GameObject to a certain location</summary>
    * 
    * @method placeLocal
    * @param {Transform} transform:Transform the transform of the object you wish to place along the path
    * @param {float} ratio:float ratio of the point along the path you wish to receive (0-1)
    * @param {Vector3} rotation:Vector3 the direction in which to place the transform ex: Vector3.up
    * @example
    * ltPath.placeLocal( transform, 0.6f, Vector3.left );
    */
    public void placeLocal(Transform transform, float ratio, Vector3 worldUp)
    {
        transform.localPosition = point(ratio);
        ratio += 0.001f;
        if (ratio <= 1.0f)
            transform.LookAt(transform.parent.TransformPoint(point(ratio)), worldUp);
    }

    public void gizmoDraw(float t = -1.0f)
    {
        if (ptsAdj == null || ptsAdj.Length <= 0)
            return;

        Vector3 prevPt = ptsAdj[0];

        for (int i = 0; i < ptsAdjLength; i++)
        {
            Vector3 currPt2 = ptsAdj[i];
            // Debug.Log("currPt2:"+currPt2);
            //Gizmos.color = new Color(UnityEngine.Random.Range(0f,1f),UnityEngine.Random.Range(0f,1f),UnityEngine.Random.Range(0f,1f),1);
            Gizmos.DrawLine(prevPt, currPt2);
            prevPt = currPt2;
        }
    }

    public void drawGizmo(Color color)
    {
        if (this.ptsAdjLength >= 4)
        {

            Vector3 prevPt = this.ptsAdj[0];

            Color colorBefore = Gizmos.color;
            Gizmos.color = color;
            for (int i = 0; i < this.ptsAdjLength; i++)
            {
                Vector3 currPt2 = this.ptsAdj[i];
                // Debug.Log("currPt2:"+currPt2);

                Gizmos.DrawLine(prevPt, currPt2);
                prevPt = currPt2;
            }
            Gizmos.color = colorBefore;
        }
    }

    public static void drawGizmo(Transform[] arr, Color color)
    {
        if (arr.Length >= 4)
        {
            Vector3[] vec3s = new Vector3[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                vec3s[i] = arr[i].position;
            }
            LTSpline spline = new LTSpline(vec3s);
            Vector3 prevPt = spline.ptsAdj[0];

            Color colorBefore = Gizmos.color;
            Gizmos.color = color;
            for (int i = 0; i < spline.ptsAdjLength; i++)
            {
                Vector3 currPt2 = spline.ptsAdj[i];
                // Debug.Log("currPt2:"+currPt2);

                Gizmos.DrawLine(prevPt, currPt2);
                prevPt = currPt2;
            }
            Gizmos.color = colorBefore;
        }
    }


    public static void drawLine(Transform[] arr, float width, Color color)
    {
        if (arr.Length >= 4)
        {

        }
    }

    /*public Vector3 Velocity(float t) {
        t = map( t );

        int numSections = pts.Length - 3;
        int currPt = Mathf.Min(Mathf.FloorToInt(t * (float) numSections), numSections - 1);
        float u = t * (float) numSections - (float) currPt;
                
        Vector3 a = pts[currPt];
        Vector3 b = pts[currPt + 1];
        Vector3 c = pts[currPt + 2];
        Vector3 d = pts[currPt + 3];

        return 1.5f * (-a + 3f * b - 3f * c + d) * (u * u)
                + (2f * a -5f * b + 4f * c - d) * u
                + .5f * c - .5f * a;
    }*/

    public void drawLinesGLLines(Material outlineMaterial, Color color, float width)
    {
        GL.PushMatrix();
        outlineMaterial.SetPass(0);
        GL.LoadPixelMatrix();
        GL.Begin(GL.LINES);
        GL.Color(color);

        if (constantSpeed)
        {
            if (this.ptsAdjLength >= 4)
            {

                Vector3 prevPt = this.ptsAdj[0];

                for (int i = 0; i < this.ptsAdjLength; i++)
                {
                    Vector3 currPt2 = this.ptsAdj[i];
                    GL.Vertex(prevPt);
                    GL.Vertex(currPt2);

                    prevPt = currPt2;
                }
            }

        }
        else
        {
            if (this.pts.Length >= 4)
            {

                Vector3 prevPt = this.pts[0];

                float split = 1f / ((float)this.pts.Length * 10f);

                float iter = 0f;
                while (iter < 1f)
                {
                    float at = iter / 1f;
                    Vector3 currPt2 = interp(at);
                    // Debug.Log("currPt2:"+currPt2);

                    GL.Vertex(prevPt);
                    GL.Vertex(currPt2);

                    prevPt = currPt2;

                    iter += split;
                }
            }
        }


        GL.End();
        GL.PopMatrix();

    }

    public Vector3[] generateVectors()
    {
        if (this.pts.Length >= 4)
        {
            List<Vector3> meshPoints = new List<Vector3>();
            Vector3 prevPt = this.pts[0];
            meshPoints.Add(prevPt);

            float split = 1f / ((float)this.pts.Length * 10f);

            float iter = 0f;
            while (iter < 1f)
            {
                float at = iter / 1f;
                Vector3 currPt2 = interp(at);
                //                Debug.Log("currPt2:"+currPt2);

                //                GL.Vertex(prevPt);
                //                GL.Vertex(currPt2);
                meshPoints.Add(currPt2);

                //                prevPt = currPt2;

                iter += split;
            }

            meshPoints.ToArray();
        }
        return null;
    }
}
