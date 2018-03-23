using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caibin_trigger : MonoBehaviour {
	public GameObject leepy_new;
	public GameObject leepy_old;

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Player") {
			Debug.Log ("shadow hitting elevator trigger points");
			leepy_new.SetActive (true);
			leepy_old.SetActive (false);
			buggy_leppy.speed = 3.0f;
			buggy_leppy.start = true;
			}
		}
	}
