using UnityEngine;
using System.Collections;

public class EnemyDie : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Die() {
		GameObject.Destroy(gameObject);
	}
}
