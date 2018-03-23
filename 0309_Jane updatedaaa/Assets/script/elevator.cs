using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour {
	public int ele1_count=0;

	// Use this for initialization
	void Start () {
		//count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (ele1_count >= 1 && ele1_count < 150) {
			//print (count);
			transform.Translate (0, Time.deltaTime * 2, 0);
			ele1_count = (ele1_count + 1) % 300;
		} else {
			transform.Translate (0, -Time.deltaTime * 2, 0);
			ele1_count = (ele1_count + 1) % 300;
		}
	}
}
