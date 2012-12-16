using UnityEngine;
using System.Collections;

public class ContinueButton : MonoBehaviour {

	void OnClick() {
		if(PlayerPrefs.HasKey("currentlevel")) {
			Application.LoadLevel(PlayerPrefs.GetInt("currentlevel"));
		} else {
			Application.LoadLevel("Level1");
		}
	}
}
