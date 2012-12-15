using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]
	
public class Bullet : MonoBehaviour {
	public float speed = 0.5f;
	public float lifeTime = 5;
	public int damage = 5;
	
	protected float deathTime;
	
	protected bool die = false;
	
	// Use this for initialization
	void Start () {
		deathTime = Time.time + lifeTime;
	}
	
	// Update is called once per frame
	void Update () {
		if(die || (Time.time >= deathTime)) {
			Destroy(gameObject);
			return;
		}
		
		rigidbody.transform.Translate(Vector3.up * speed);
	}
	
	void OnCollisionEnter(Collision collision) {
		collision.gameObject.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
		die = true;
	}
}
