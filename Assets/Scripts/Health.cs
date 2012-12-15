using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public int maxHealth = 20;
	
	protected int health;
	// Use this for initialization
	void Start () {
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0) {
			SendMessage("Die");
		}
	}
	
	public void TakeDamage(int damage) {
		health -= damage;
	}
}
