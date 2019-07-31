using UnityEngine;
using DentedPixel;

public class LTPathExampleSimple : MonoBehaviour {

	public LeanTweenPath ltPath;
	private LTBezierPath ltBezierPath;
	private float iter;

	void Start () {
		Vector3[] v = new Vector3[]{new Vector3(25f,-7.025024f,42.0522f), new Vector3(22.76418f,-7.025024f,54.56692f), new Vector3(24.94595f,-7.025024f,49.29967f), new Vector3(17.67767f,-7.025024f,59.72987f), new Vector3(17.67767f,-7.025024f,59.72987f), new Vector3(7.247467f,-7.025024f,66.99815f), new Vector3(12.51471f,-7.025024f,64.81638f), new Vector3(-1.092785E-06f,-7.025024f,67.0522f), new Vector3(-1.092785E-06f,-7.025024f,67.0522f), new Vector3(-12.51472f,-7.025024f,64.81638f), new Vector3(-7.247468f,-7.025024f,66.99814f), new Vector3(-17.67767f,-7.025024f,59.72987f), new Vector3(-17.67767f,-7.025024f,59.72987f), new Vector3(-24.94594f,-7.025024f,49.29967f), new Vector3(-22.76418f,-7.025024f,54.56691f), new Vector3(-25f,-7.025024f,42.0522f), new Vector3(-25f,-7.025024f,42.0522f), new Vector3(-22.76418f,-7.025024f,29.53749f), new Vector3(-24.94594f,-7.025024f,34.80473f), new Vector3(-17.67767f,-7.025024f,24.37453f), new Vector3(-17.67767f,-7.025024f,24.37453f), new Vector3(-7.247469f,-7.025024f,17.10626f), new Vector3(-12.51471f,-7.025024f,19.28802f), new Vector3(2.98122E-07f,-7.025024f,17.0522f), new Vector3(2.98122E-07f,-7.025024f,17.0522f), new Vector3(12.51472f,-7.025024f,19.28802f), new Vector3(7.24747f,-7.025024f,17.10626f), new Vector3(17.67768f,-7.025024f,24.37454f), new Vector3(17.67768f,-7.025024f,24.37454f), new Vector3(24.94595f,-7.025024f,34.80473f), new Vector3(22.76418f,-7.025024f,29.53749f), new Vector3(25f,-7.025024f,42.0522f)};
		ltBezierPath = new LTBezierPath(v);
	}

	void Update () {
		transform.position = ltBezierPath.point( iter );
		iter += Time.deltaTime;
		if(iter>1.0f)
			iter = 0.0f;
	}
}