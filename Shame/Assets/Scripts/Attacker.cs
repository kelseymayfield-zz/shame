using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {
	public OpenableDoor door;
	public float damage;
	public string dialog;
	GameObject player;                          // Reference to the player GameObject.
	PlayerHealth playerHealth;                  // Reference to the player's health.
	bool doorToggled;
	bool showText;
	public bool isFemale;
	public AudioClip femaleAudio;
	public AudioClip maleAudio;
	GUIStyle fontStyle;

	void Awake ()
	{
		// Setting up the references.
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
		
		fontStyle = new GUIStyle();
		fontStyle.fontSize = 24;
		fontStyle.normal.textColor = Color.white;
		fontStyle.alignment = TextAnchor.MiddleCenter;

	}

	void OnTriggerEnter (Collider other)
	{
		Debug.Log ("Player enter the attacker's trigger");
		// If the entering collider is the player...
		if(other.gameObject == player)
		{
			if(!doorToggled)
			{
				showText = true;
				door.ToggleDoor ();
				doorToggled = true;
				//player.transform.LookAt(this.transform);
				// If the player has health to lose...
				if(playerHealth.currentHealth > 0)
				{
					// ... damage the player.
					playerHealth.TakeDamage (damage);
					if(isFemale)
					{
						audio.clip = femaleAudio;
						audio.Play ();
					}
					else
					{
						audio.clip = maleAudio;
						audio.Play ();
					}

				}
			}
		}
	}
	
	void OnTriggerExit (Collider other){
		Debug.Log ("Player exit the attacker's trigger");
		if (other.gameObject.tag == "Player") {
			showText = false;
		}
	}
	
	void OnGUI() {
		if (showText) {
			GUI.Label (new Rect (0, Screen.height-50, Screen.width, 30), dialog, fontStyle);
		}
	}
}
