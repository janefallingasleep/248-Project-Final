using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xiaodouDeath : MonoBehaviour {
	public GameObject shadow_empty;

	private AudioSource shadow_audio;
	// audioclips
	public AudioClip uhoh;

	public IEnumerator TakeDamageAndRespawn (Transform respawnPoint) {
		Debug.Log ("taking damage and respawning");
		game_logic.life_count -= 1;
		gameObject.GetComponent<Animator> ().SetTrigger ("death");
		shadow_audio = GetComponent<AudioSource> ();
		//shadow_audio.PlayOneShot(uhoh,1F);
		yield return new WaitForSeconds (1.5f);
		shadow_audio.PlayOneShot(uhoh,1F);
		gameObject.transform.position = respawnPoint.transform.position;
		shadow_empty.transform.position = respawnPoint.transform.position;
	}
}
