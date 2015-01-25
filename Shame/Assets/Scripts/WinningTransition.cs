using UnityEngine;
using System.Collections;

public class WinningTransition : MonoBehaviour {
	GameObject player;                          // Reference to the player GameObject.
	PlayerHealth playerHealth;                  // Reference to the player's health.
	public Animator anim;                          // Reference to the animator component.
	
	void Awake ()
	{
		// Setting up the references.
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
	}

	void OnTriggerEnter (Collider other) {
		Debug.Log ("Player enter the winning trigger");
		if (other.gameObject.tag == "Player") {
			if (playerHealth.hasKey == true)
			{
				Debug.Log("Player entered the winning zone with key! Transiting to the wining stage...");
				anim.SetTrigger ("WinGame");
        
        StartCoroutine(transit());
			}
		}
	}
  
  IEnumerator transit() {
  Debug.Log("Before Waiting 5 seconds");
  yield return new WaitForSeconds(5);
  Debug.Log("After Waiting 5 Seconds");
  Application.LoadLevel("Credits");
 }
  
}
