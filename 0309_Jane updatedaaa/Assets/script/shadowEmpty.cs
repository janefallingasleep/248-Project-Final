using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadowEmpty : MonoBehaviour {
	// gameobject components
	private CharacterController controller;
	private AudioSource shadow_audio;

	// constants to be used
	private float gravity = 14f;
	private float jumpForce = 5f;
	private float trampolineVel = 5f;
	private float downWellVel = -0.2f;
	private float upWellVel = 0.2f;

	// initialization of variables to be used
	private bool jumped = true;
	private bool cameraSwitched = false;
	private int onTrampoline = 0;
	private int downWell = 0;
	private int upWell = 0;
	private float verticalVelocity = 0f;
	private float jump = 0f;
	private int cameraSwitchCount = 0;

	// audioclips
	public AudioClip jump1;
	public AudioClip bounce;
	public AudioClip downWell_audio;
	public AudioClip upWell_audio;

	public float spd = 5;
	public GameObject well1;
	public GameObject well2;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		shadow_audio = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		// update the vertical velocity for 5 cases:
		// 1. jumping 2. bouncing trampoline 3. getting down the well 4. getting up the well 5. falling
		if (controller.isGrounded && Input.GetKeyDown (KeyCode.Space)) {
			verticalVelocity = jumpForce;
		} else if (onTrampoline >= 1 && onTrampoline <= 20) {
			verticalVelocity = trampolineVel;
			onTrampoline += 1;
		} else if (downWell >= 1 && downWell <= 30) {
			verticalVelocity = downWellVel;
			downWell += 1;
		} else if (upWell >= 1 && upWell <= 50) {
			verticalVelocity = upWellVel;
			upWell += 1;
		}
		else{
			verticalVelocity -= gravity * Time.deltaTime;
		}

		// moving using keyboard arrows
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical"); 
		Vector3 movement = new Vector3 (-1*moveVertical, verticalVelocity*0.5f, moveHorizontal);
		// if camera is switched
		if (cameraSwitched == true) {
			movement = Quaternion.AngleAxis (590, Vector3.up) * movement;
			shadowCamera.change ();
			shadow_motion.cameraChange ();
		}
		controller.Move(movement * Time.deltaTime * spd);

		// jumping using space
		if (Input.GetKeyDown(KeyCode.Space)) {
			shadow_audio.PlayOneShot(jump1, 0.2F);
			if (jumped == true) {
				jump = Time.deltaTime;
				jumped = false;
			}
		}
		if (jumped == false && Time.deltaTime - jump > 0.1f) {
			jumped = true;
		}

		// switch camera either using A or certain time after colliding with well1
		if (Input.GetKeyDown (KeyCode.A)) {
			cameraSwitched = true;
		}
		if (cameraSwitchCount >= 1 && cameraSwitchCount < 30) {
			cameraSwitchCount += 1;
		}
		if (cameraSwitchCount == 30) {
			cameraSwitched = true;
			upWell = 1;
			shadow_audio.PlayOneShot (upWell_audio, 1.0f);
			cameraSwitchCount += 1;
		}
		if (cameraSwitchCount == 31) {
			transform.position = well2.transform.position;
			cameraSwitchCount += 1;
		}
		//cheating the colliders
		if (Input.GetKeyDown (KeyCode.T)){
			onTrampoline = 1;
			shadow_audio.PlayOneShot (bounce, 1.0f);
		}
		/*if (Input.GetKeyDown (KeyCode.W)) {
			cameraSwitchCount = 1;
			downWell = 1;
			DestroyObject (well1);
			shadow_audio.PlayOneShot (downWell_audio, 1.0f);
		}*/

	}


	void OnCollisionEnter(Collision col){
		// on trampoline
		if (col.collider.name == "trampoline") {
			print ("colliding trampoline");
			onTrampoline = 1;
			shadow_audio.PlayOneShot (bounce, 1.0f);
		}
		// down the well
		if (col.collider.name == "well1") {
			cameraSwitchCount = 1;
			downWell = 1;
			DestroyObject (col.gameObject);
			shadow_audio.PlayOneShot (downWell_audio, 1.0f);
		}
	}
}
