using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]
[RequireComponent (typeof(CharacterController))]

public class PlayerController : MonoBehaviour {
	public float fireDelay = 0.5f;
	public GameObject bulletPrefab;
	public Transform bulletOrigin;
	public Collider bodyCollider;
	public float moveSpeed = 20;
	public float jumpForce = 20;
	public float gravity = 10;
	
	protected float nextFire = 0;
	
	protected bool jumping = false;
	
	protected CharacterController characterController;
	
	protected float currentJumpForce = 0;
	protected float jumpTime = 0;
	
	// Use this for initialization
	void Start () {
		nextFire = Time.time; // Allow immediate firing.
		characterController = GetComponent<CharacterController>();
		jumpTime = Time.time - 1;
	}
	
	// Update is called once per frame
	void Update () {
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		
		Vector3 translation = new Vector3(horizontal * moveSpeed * Time.deltaTime, 0, 0);
		
		if(characterController.isGrounded && (vertical > 0.5)) {
			currentJumpForce = jumpForce;
			jumpTime = Time.time;
			Debug.Log("Jump!");
		}
		
		translation.y += currentJumpForce * Time.deltaTime;
		
		translation.y -= gravity * Time.deltaTime;
		
		currentJumpForce = Mathf.Lerp(jumpForce, 0, Time.time - jumpTime);
		
		characterController.Move(translation);
		
		if(Input.GetMouseButton(0)){
			Fire(Quaternion.FromToRotation(Vector3.up, Input.mousePosition - Camera.main.WorldToScreenPoint(bulletOrigin.position)));
		}
		
		Vector3 rightAnalog = new Vector3(Input.GetAxis("RightAnalog Horizontal"), Input.GetAxis("RightAnalog Vertical"), 0);
		if(rightAnalog.magnitude > 0.1) {
			Fire(Quaternion.FromToRotation(Vector3.up, rightAnalog));
		}
	}
	
	void Fire(Quaternion gunRotation) {
		if(Time.time >= nextFire) {
			nextFire = Time.time + fireDelay;

			GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletOrigin.position, gunRotation);
			foreach(Collider bulletCollider in bullet.GetComponentsInChildren<Collider>()) {
				Physics.IgnoreCollision(bulletCollider, bodyCollider);
			}
		}
	}
}
