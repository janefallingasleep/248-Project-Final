using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class elevator_brake : MonoBehaviour {

	// Use this for initialization
	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Player") {
			Debug.Log ("shadow hitting trunk trigger points");
			leepyPath.speed = 3.0f;
			leepyPath.start = true;
		}
		if (col.gameObject.tag == "leepy" && leepyPath.start){
			Debug.Log("leepy reached target points,stop moving");
			leepyPath.speed= 3.0f;
			leepyPath.start = false;

		}
	}
}
