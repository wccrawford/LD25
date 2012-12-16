using UnityEngine;
using System.Collections;

public class ExitTrigger : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		if(other.name == "Player") {
			Application.LoadLevel(Application.loadedLevel + 1);
		}
	}
}
