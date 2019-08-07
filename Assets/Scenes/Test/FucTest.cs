using huqiang;
using huqiang.Data;
using huqiang.Math;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FucTest : MonoBehaviour
{
    public TextAsset asset;
    Vector3[] path;
    BezierPathC bpc;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        DataBuffer db = new DataBuffer(asset.bytes);
        var array = db.fakeStruct.GetData<FakeStructArray>(1);
        path = db.GetArray<Vector3>(array[0,1]);
        bpc = new BezierPathC(path);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        float r = time / 10;
        r %= 1;
        var angle = Vector3.zero;
        var pos = bpc.place2d(r,ref angle);
        transform.localPosition = pos;
        transform.localEulerAngles = angle;
    }
}
