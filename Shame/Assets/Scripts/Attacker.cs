using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {
	GameObject player;                          // Reference to the player GameObject.
	PlayerHealth playerHealth;                  // Reference to the player's health.
	public OpenableDoor door;
	bool doorToggled;

	void Awake ()
	{
		// Setting up the references.
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter (Collider other)
	{
		// If the entering collider is the player...
		if(other.gameObject == player)
		{
			if(!doorToggled)
			{
				door.ToggleDoor ();
				doorToggled = true;
				//player.transform.LookAt(this.transform);
				// If the player has health to lose...
				if(playerHealth.currentHealth > 0)
				{
					// ... damage the player.
					playerHealth.TakeDamage (10);
				}
			}
		}
	}
}
