using UnityEngine;
using System.Collections;

public class LevelStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt("currentlevel", Application.loadedLevel);
	}
	
}
