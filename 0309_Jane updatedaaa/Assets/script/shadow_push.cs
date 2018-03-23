using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadow_push : MonoBehaviour {

	// Use this for initialization
	void OncolliderEnter(Collision c){
		float force = 0.2f;
		if (c.gameObject != null && c.gameObject.tag != "leepy") {
			Vector3 dir = c.contacts [0].point - transform.position;
			dir = dir.normalized;
			GetComponent<Rigidbody> ().AddForce (dir * force);
		}
		if (c.gameObject.tag == "killer_rock" || Input.GetKeyDown(KeyCode.P)){//|| col.collider.name == "shadowEmpty") {
			c.gameObject.GetComponent<Animator>().SetTrigger("move");
		}
	
	}
}
