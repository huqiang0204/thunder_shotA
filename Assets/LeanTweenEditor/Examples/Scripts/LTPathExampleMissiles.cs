using UnityEngine;
using System.Collections;
using DentedPixel;

public class LTPathExampleMissiles : MonoBehaviour {

	public LeanTweenPath ltPath;

	private GameObject lt;
	private GameObject missile1;
	private GameObject missile2;
	private GameObject missile3;

	void Start () {
		lt = GameObject.Find("LeanTweenAvatar");
		missile1 = GameObject.Find("Missile1");
		missile2 = GameObject.Find("Missile2");
		missile3 = GameObject.Find("Missile3");

		fireMissile1();
		LeanTween.delayedCall(gameObject, 0.5f, fireMissile2);
		LeanTween.delayedCall(gameObject, 1.0f, fireMissile3);
	}

	void Update () {
		lt.transform.eulerAngles = new Vector3(lt.transform.eulerAngles.x, lt.transform.eulerAngles.y + Time.deltaTime * 30.0f, lt.transform.eulerAngles.z);
	}

	void fireMissile1(){
		LeanTween.moveLocal(missile1, ltPath.vec3, 2.5f).setOrientToPath(true).setDelay(1.0f).setEase(LeanTweenType.easeInOutQuad).setOnComplete(fireMissile1);
	}

	void fireMissile2(){
		Debug.Log("Fire missile 2");
		LeanTween.moveLocal(missile2, ltPath.vec3, 2.5f).setOrientToPath(true).setDelay(1.0f).setEase(LeanTweenType.easeInOutQuad).setOnComplete(fireMissile2);
	}

	void fireMissile3(){
		Debug.Log("Fire missile 3");
		LeanTween.moveLocal(missile3, ltPath.vec3, 2.5f).setOrientToPath(true).setDelay(1.0f).setEase(LeanTweenType.easeInOutQuad).setOnComplete(fireMissile3);
	}

}