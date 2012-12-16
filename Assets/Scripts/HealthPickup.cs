using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) {
		Debug.Log(other.gameObject.name);
		if(other.gameObject.name == "Player") {
			Health health = (Health)other.gameObject.GetComponent<Health>();
			health.AddHealth(20);
			
			Destroy(gameObject);
			return;
		}
	}
}
