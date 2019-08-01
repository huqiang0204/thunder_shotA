using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tttt : MonoBehaviour
{
    public static Vector3 GetGlobaInfo(Transform rect, bool Includeroot = true)
    {
        Vector3 pos = rect.localPosition;
        Vector3 scale = Vector3.one;
        Quaternion quate = Quaternion.identity;
         for(int i=0;i<32;i++)
        {
            var pr = rect.parent;
            if (pr == null)
                break;
            Vector3 p =pr.localPosition;
            Vector3 o = Vector3.zero;
            o.x = p.x * scale.x;
            o.y = p.y * scale.y;
            o.z = p.z * scale.z;
            pos += quate * pos;
            quate *= pr.localRotation;
            Vector3 s = pr.localScale;
            scale.x *= s.x;
            scale.y *= s.y;
        }
        return pos;
    }
    public static  Vector3 GetGlobaInfoA(Transform rect, bool Includeroot = true)
    {
        Transform[] buff = new Transform[32];
        buff[0] = rect;
        var parent = rect.parent;
        int max = 1;
        if (parent != null)
            for (; max < 32; max++)
            {
                buff[max] = parent;
                parent = parent.parent;
                if (parent == null)
                    break;
            }
        Vector3 pos, scale;
        Quaternion quate;
        if (Includeroot)
        {
            var p = buff[max];
            pos = p.localPosition;
            scale = p.localScale;
            quate = p.localRotation;
            max--;
        }
        else
        {
            pos = Vector3.zero;
            scale = Vector3.one;
            quate = Quaternion.identity;
            max--;
        }
        for (; max >= 0; max--)
        {
            var rt = buff[max];
            Vector3 p = rt.localPosition;
            Vector3 o = Vector3.zero;
            o.x = p.x * scale.x;
            o.y = p.y * scale.y;
            o.z = p.z * scale.z;
            pos += quate * o;
            quate *= rt.localRotation;
            Vector3 s = rt.localScale;
            scale.x *= s.x;
            scale.y *= s.y;
        }
        return pos;
    }
    public Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(trans.position);
        Debug.Log(GetGlobaInfo(trans));
        Debug.Log(GetGlobaInfoA(trans));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
