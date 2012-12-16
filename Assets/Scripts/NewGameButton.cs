using UnityEngine;
using System.Collections;

public class NewGameButton : MonoBehaviour {

	void OnClick() {
		Application.LoadLevel("Level1");
	}
}
