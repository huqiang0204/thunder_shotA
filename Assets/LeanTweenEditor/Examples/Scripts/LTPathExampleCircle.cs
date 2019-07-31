using UnityEngine;
using System.Collections;
using DentedPixel;

public class LTPathExampleCircle : MonoBehaviour {

	public LeanTweenPath path;

	private GameObject lt;

	// Use this for initialization
	void Start () {
		lt = GameObject.Find("LeanTweenAvatar");
	
		loopAroundCircle();
	}
	
	void loopAroundCircle(){
		LeanTween.move(lt, path.vec3, 4.0f).setOrientToPath(false).setDelay(1.0f).setEase(LeanTweenType.easeInOutQuad).setOnComplete(loopAroundCircle);
	}
}
