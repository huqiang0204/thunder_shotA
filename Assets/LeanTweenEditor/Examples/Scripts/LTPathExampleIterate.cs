using UnityEngine;
using System.Collections;
using DentedPixel;

public class LTPathExampleIterate : MonoBehaviour {

	public LeanTweenPath editorPath;

	private GameObject lt1;
	private GameObject lt2;

	private LTBezierPath ltPath1;
	private LTBezierPath ltPath2;

	private float iter1 = 0.25f;
	private float iter2 = 0.5f;
	// Use this for initialization
	void Start () {
		lt1 = GameObject.Find("LeanTweenAvatar1");
		lt2 = GameObject.Find("LeanTweenAvatar2");

		ltPath1 = new LTBezierPath(editorPath.vec3);
		ltPath2 = new LTBezierPath(editorPath.vec3);
	}
	
	// Update is called once per frame
	void Update () {
		ltPath1.place( lt1.transform, iter1);
		lt2.transform.position = ltPath2.point( iter2 );

		iter1 += Time.deltaTime*0.1f;
		if(iter1>1.0f)
			iter1 = 0.0f;
		iter2 += Time.deltaTime*0.1f;
		if(iter2>1.0f)
			iter2 = 0.0f;
	}
}
