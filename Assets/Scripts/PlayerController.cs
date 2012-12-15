using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]
[RequireComponent (typeof(CharacterController))]

public class PlayerController : MonoBehaviour {
	public Transform bulletOrigin;
	public float moveSpeed = 20;
	public float jumpForce = 40;
	public float gravity = 1;
	
	//protected float nextFire = 0;
	
	protected bool jumping = false;
	
	protected CharacterController characterController;
	
	protected float currentJumpForce = 0;
	protected float jumpTime = 0;
	
	protected float gravityAcceleration = 0;
	
	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController>();
		jumpTime = Time.time - 1;
	}
	
	// Update is called once per frame
	void Update () {
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");
		
		Vector3 translation = new Vector3(horizontal * moveSpeed * Time.deltaTime, 0, 0);
		
		if(characterController.isGrounded && (vertical > 0.5)) {
			currentJumpForce = jumpForce;
			jumpTime = Time.time;
		}
		
		if(characterController.isGrounded) {
			gravityAcceleration = 0;
		} else {
			gravityAcceleration += gravity * Time.deltaTime;
		}
		
		translation.y += currentJumpForce * Time.deltaTime;
		
		translation.y -= gravityAcceleration;
		
		currentJumpForce = Mathf.Lerp(jumpForce, 0, (Time.time - jumpTime) * 4);
		
		characterController.Move(translation);
		
		if(Input.GetMouseButton(0)){
			SendMessage("Fire", Quaternion.FromToRotation(Vector3.up, Input.mousePosition - Camera.main.WorldToScreenPoint(bulletOrigin.position)));
		}
		
		Vector3 rightAnalog = new Vector3(Input.GetAxis("RightAnalog Horizontal"), Input.GetAxis("RightAnalog Vertical"), 0);
		if(rightAnalog.magnitude > 0.1) {
			SendMessage("Fire", Quaternion.FromToRotation(Vector3.up, rightAnalog));
		}
	}
	
}
