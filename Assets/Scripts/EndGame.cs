using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerPrefs.DeleteKey("currentlevel");
	}
	
}
