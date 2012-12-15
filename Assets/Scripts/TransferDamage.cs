using UnityEngine;
using System.Collections;

public class TransferDamage : MonoBehaviour {
	public GameObject target;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void TakeDamage(int damage) {
		target.SendMessage("TakeDamage", damage);
	}
}
