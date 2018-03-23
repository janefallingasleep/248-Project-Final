using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leepy_controller : MonoBehaviour {

	// Use this for initialization
	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Player") {
			Debug.Log ("shadow hitting trunk trigger points");
			leepyPath.speed = 3.0f;
			leepyPath.start = true;
		}
	}
}
