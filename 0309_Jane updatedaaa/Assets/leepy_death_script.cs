using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leepy_death_script : MonoBehaviour {
	public xiaodouDeath die_script;
	public Transform respawnPoint;

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "snowball") {
			Debug.Log ("snowball hit Leepy");
			StartCoroutine(die_script.TakeDamageAndRespawn(respawnPoint));
		}
	}
}
