using UnityEngine;
using System.Collections;

public class HallOfShame : MonoBehaviour {
	public float damageOverTime;
	GameObject player;                          // Reference to the player GameObject.
	PlayerHealth playerHealth;                  // Reference to the player's health.
	void Awake ()
	{
		// Setting up the references.
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
	}
	
	void OnTriggerStay (Collider other)
	{
		if(other.gameObject == player)
		{
			if(playerHealth.currentHealth > 0)
			{
				// ... damage the player.
				playerHealth.TakeDamage (damageOverTime);
			}
		}
	}
}
