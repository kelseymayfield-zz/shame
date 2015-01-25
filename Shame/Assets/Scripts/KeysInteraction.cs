using UnityEngine;
using System.Collections;

public class KeysInteraction : MonoBehaviour {
	GameObject player;                          // Reference to the player GameObject.
	PlayerHealth playerHealth;                  // Reference to the player's health.
	public AudioClip keySound;
	void Awake ()
	{
		// Setting up the references.
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
	}
	
	bool enter;
	
	void OnTriggerStay(Collider other) {
		if (other.gameObject == player) {
			if(Input.GetKeyDown("f")) {
				playerHealth.hasKey = true;
				Destroy(this.gameObject);
			}
		}
	}
	
	void OnTriggerEnter (Collider other) {
		Debug.Log ("Player enter the keys trigger");
		if (other.gameObject.tag == "Player") {
			enter = true;
			audio.loop = false;
			audio.clip = keySound;
			audio.Play ();
		}
	}
	
	void OnTriggerExit (Collider other){
		Debug.Log ("Player exit the keys trigger");
		if (other.gameObject.tag == "Player") {
			enter = false;
		}
	}
	
	void OnGUI() {
		if (enter) {
			GUI.Label (new Rect (Screen.width / 2 - 75, Screen.height - 100, 200, 50), "Press F to pick up the keys");
			
		}
	}
}
