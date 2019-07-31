using UnityEngine;
using System.Collections;
using DentedPixel;

public class LTSplineIterate2d : MonoBehaviour {

	private float iter;
	public LeanTweenPath ltPath;
	public GameObject ltLogo;

	private LTSpline s;

	void Start () {
		s = new LTSpline( ltPath.splineVector() );
	}
	
	void Update () {
		s.place2d( ltLogo.transform, iter );

		iter += Time.deltaTime * 0.1f;
		if(iter>1f)
			iter = 0f;
	}
}
