using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]

public class Shoot : MonoBehaviour {
	public float fireDelay = 0.5f;
	public GameObject bulletPrefab;
	public Transform bulletOrigin;
	public Collider bodyCollider;
	public AudioClip bulletSound;

	protected float nextFire = 0;

	// Use this for initialization
	void Start () {
		nextFire = Time.time; // Allow immediate firing.
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Fire(Quaternion gunRotation) {
		if(Time.time >= nextFire) {
			nextFire = Time.time + fireDelay;

			GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletOrigin.position, gunRotation);
			foreach(Collider bulletCollider in bullet.GetComponentsInChildren<Collider>()) {
				Physics.IgnoreCollision(bulletCollider, bodyCollider);
			}
			
			AudioSource audio = GetComponent<AudioSource>();
			audio.PlayOneShot(bulletSound);
		}
	}
}
