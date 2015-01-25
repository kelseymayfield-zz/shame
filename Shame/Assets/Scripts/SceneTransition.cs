using UnityEngine;
using System.Collections;

public class SceneTransition : MonoBehaviour {
	public void loadScene (string scene) {
		Application.LoadLevel(scene); // or level index
	}
}
