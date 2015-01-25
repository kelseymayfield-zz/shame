using UnityEngine;
using System.Collections;

public class RoomTrigger : MonoBehaviour {
	public float changeOverTime;
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
			float health = playerHealth.currentHealth;
			if(health > 0.0 && health < 100.0)
			{
				float amount = -Mathf.Min(Mathf.Min (health, 100.0f - health), changeOverTime);
				playerHealth.TakeDamage (amount);
			}
		}
	}
}
