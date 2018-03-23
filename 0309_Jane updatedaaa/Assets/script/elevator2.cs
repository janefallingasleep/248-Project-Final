using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator2 : MonoBehaviour {
	public int ele2_count = 160;

	// Use this for initialization
	void Start () {
		//count = 160;
	}
	
	// Update is called once per frame
	void Update () {
		if (ele2_count >= 1 && ele2_count < 160) {
			//print (count);
			transform.Translate (0, Time.deltaTime * 2, 0);
			ele2_count = (ele2_count + 1)%320;
		} else {
			transform.Translate (0, -Time.deltaTime * 2, 0);
			ele2_count = (ele2_count + 1)%320;
		}
	}
}
