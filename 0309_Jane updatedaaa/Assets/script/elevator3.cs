using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator3 : MonoBehaviour {
	public int ele3_count = 1;
	public static bool elevator_move = true;
	public Vector3 target;
	public float speed = 6.0f;

	// Use this for initialization
	void Start () {
		target = new Vector3(51.07f, 25.52f, -67.04f);
	}
		
	// Update is called once per frame
	void Update () {
		
		if (elevator_move) {
			transform.position = Vector3.MoveTowards (transform.position, target, speed * Time.deltaTime);
			
		}
	}
}
