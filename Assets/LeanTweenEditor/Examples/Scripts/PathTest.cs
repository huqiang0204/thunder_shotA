using UnityEngine;
using System.Collections;

public class PathTest : MonoBehaviour {

	public LeanTweenPath leanTweenPath;

	// Use this for initialization
	void Start () {
		LeanTween.move( Camera.main.gameObject, leanTweenPath.vec3, 4.5f ).setEase(LeanTweenType.easeInOutQuad);
	}

	// Update is called once per frame
	void Update () {

	}
}
