using UnityEngine;
using System.Collections;
using DentedPixel;

public class TriggerPointExample : MonoBehaviour{
	private GameObject spotLight;

	void Awake(){
		spotLight = gameObject.transform.Find("Spotlight").gameObject;
		spotLight.SetActive( false );
	}

	void OnTriggerEnter(Collider info) {
		spotLight.SetActive( true );
	}

	void OnTriggerExit(Collider info) {
		spotLight.SetActive( false );
	}

}

public class LTPathExampleTriggers : MonoBehaviour {
	public GameObject prefabLightPost;

	public LeanTweenPath ltPathDefinition;

	private LTBezierPath ltBezierPath;
	private float iter;

	void Start () {
		// Create a LTBezierPath from the array of vectors made with the LeanTween Editor
		ltBezierPath = new LTBezierPath( ltPathDefinition.vec3 );

		// Adding Light Posts
		for(int i = 0; i < ltBezierPath.pts.Length; i++){
			// Add a Trigger at each bezier control node (which is every fourth point)
			if(i%4==0){
				GameObject post = GameObject.Instantiate( prefabLightPost );
				post.AddComponent<TriggerPointExample>(); // This component will track the entering and exiting of the car along the path
				post.transform.position = ltBezierPath.pts[ i ];
			}
		}
	}

	void Update () {
		ltBezierPath.place( transform, iter );
		iter += Time.deltaTime * 0.03f;
		if(iter>1.0f)
			iter = 0.0f;
	}
}
