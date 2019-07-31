using UnityEngine;
using System.Collections;
using DentedPixel;

public class LTSplineIterate : MonoBehaviour {

	private LTSpline s;

	private float iter;
	public GameObject ltLogo;
	public Transform[] p;

	// Use this for initialization
	void Start () {
		// When manually forming a spline, you must pass a beginning control point and ending control point. These points are not represented on the spline at all but effect how the spline curves.
		s = new LTSpline( new Vector3[]{ p[0].position, p[0].position, p[1].position, p[2].position, p[3].position, p[3].position } );
	}
	
	// Update is called once per frame
	void Update () {
		ltLogo.transform.position = s.point( iter );

		iter += Time.deltaTime * 0.1f;
		if(iter>1f)
			iter = 0f;
	}

	void OnDrawGizmos(){
		if(s!=null)
			s.gizmoDraw();	
	}
}
