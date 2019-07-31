using UnityEngine;
using System.Collections;

public class VisualEditor_TargetManyObjects : MonoBehaviour {

	public DentedPixel.LTEditor.LeanTweenVisual scaleVisual;

	public GameObject target1;
	public GameObject target2;
	public GameObject target3;

	void Update () {
		if(Time.frameCount==10){
			scaleVisual.start( target1 );
		}else if(Time.frameCount==20){
			scaleVisual.start( target2 );
		}else if(Time.frameCount==30){
			scaleVisual.start( target3 );
		}
	}
}
