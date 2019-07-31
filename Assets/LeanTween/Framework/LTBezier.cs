using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

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

/**
* Manually animate along a bezier path with this class
* @class LTBezierPath
* @constructor
* @param {Vector3 Array} pts A set of points that define one or many bezier paths (the paths should be passed in multiples of 4, which correspond to each individual bezier curve)<br />
* It goes in the order: <strong>startPoint</strong>,endControl,startControl,<strong>endPoint</strong> - <strong>Note:</strong> the control for the end and start are reversed! This is just a *quirk* of the API.<br />
* <img src="http://dentedpixel.com/assets/LTBezierExplanation.gif" width="413" height="196" style="margin-top:10px" />
* @example 
* LTBezierPath ltPath = new LTBezierPath( new Vector3[] { new Vector3(0f,0f,0f),new Vector3(1f,0f,0f), new Vector3(1f,0f,0f), new Vector3(1f,1f,0f)} );<br /><br />
* LeanTween.move(lt, ltPath.vec3, 4.0f).setOrientToPath(true).setDelay(1f).setEase(LeanTweenType.easeInOutQuad); // animate <br />
* Vector3 pt = ltPath.point( 0.6f ); // retrieve a point along the path
*/
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
        // Debug.Log("beziers.Length:"+beziers.Length + " beziers:"+beziers);
        for (i = 0; i < beziers.Length; i++)
        {
            lengthRatio[i] = beziers[i].length / length;
        }
    }

    /**
    * @property {float} distance distance of the path (in unity units)
    */
    public float distance
    {
        get
        {
            return length;
        }
    }

    /**
    * <summary>Retrieve a point along a path</summary>
    * 
    * @method point
    * @param {float} ratio:float ratio of the point along the path you wish to receive (0-1)
    * @return {Vector3} Vector3 position of the point along the path
    * @example
    * transform.position = ltPath.point( 0.6f );
    */
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
        transform.localPosition = point(ratio);
        ratio += 0.001f;
        if (ratio <= 1.0f)
        {
            Vector3 v3Dir = point(ratio) - transform.localPosition;
            float angle = Mathf.Atan2(v3Dir.y, v3Dir.x) * Mathf.Rad2Deg;
            transform.localEulerAngles = new Vector3(0, 0, angle);
        }
    }

    /**
    * <summary>Place an object along a certain point on the path (facing the direction perpendicular to the path)</summary>
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
    * <summary>Place an object along a certain point on the path, with it facing a certain direction perpendicular to the path</summary>
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
        transform.position = point(ratio);
        ratio += 0.001f;
        if (ratio <= 1.0f)
            transform.LookAt(point(ratio), worldUp);

    }

    /**
    * <summary>Place an object along a certain point on the path (facing the direction perpendicular to the path) - Local Space, not world-space</summary>
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
    * <summary>Place an object along a certain point on the path, with it facing a certain direction perpendicular to the path - Local Space, not world-space</summary>
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
        // Debug.Log("place ratio:" + ratio + " greater:"+(ratio>1f));
        ratio = Mathf.Clamp01(ratio);
        transform.localPosition = point(ratio);
        // Debug.Log("ratio:" + ratio + " +:" + (ratio + 0.001f));
        ratio = Mathf.Clamp01(ratio + 0.001f);

        if (ratio <= 1.0f)
            transform.LookAt(transform.parent.TransformPoint(point(ratio)), worldUp);
    }

    public void gizmoDraw(float t = -1.0f)
    {
        Vector3 prevPt = point(0);

        for (int i = 1; i <= 120; i++)
        {
            float pm = (float)i / 120f;
            Vector3 currPt2 = point(pm);
            //Gizmos.color = new Color(UnityEngine.Random.Range(0f,1f),UnityEngine.Random.Range(0f,1f),UnityEngine.Random.Range(0f,1f),1);
            Gizmos.color = (previousBezier == currentBezier) ? Color.magenta : Color.grey;
            Gizmos.DrawLine(currPt2, prevPt);
            prevPt = currPt2;
            previousBezier = currentBezier;
        }
    }

    /**
    * <summary>Retrieve the closest ratio near the point</summary>
    * 
    * @method ratioAtPoint
    * @param {Vector3} point:Vector3 given a current location it makes the best approximiation of where it is along the path ratio-wise (0-1)
    * @return {float} float of ratio along the path
    * @example
    * ratioIter = ltBezier.ratioAtPoint( transform.position );
    */
    public float ratioAtPoint(Vector3 pt, float precision = 0.01f)
    {
        float closestDist = float.MaxValue;
        int closestI = 0;
        int maxIndex = Mathf.RoundToInt(1f / precision);
        for (int i = 0; i < maxIndex; i++)
        {
            float ratio = (float)i / (float)maxIndex;
            float dist = Vector3.Distance(pt, point(ratio));
            // Debug.Log("i:"+i+" dist:"+dist);
            if (dist < closestDist)
            {
                closestDist = dist;
                closestI = i;
            }
        }
        //Debug.Log("closestI:"+closestI+" maxIndex:"+maxIndex);
        return (float)closestI / (float)(maxIndex);
    }
}