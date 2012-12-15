using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	public Transform bulletOrigin;
	
	protected GameObject target;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(target != null) {
			SendMessage("Fire", Quaternion.FromToRotation(Vector3.up, new Vector3(0, 1.5f, 0) + target.transform.position - bulletOrigin.position));
		}
	}

	void SetTarget(GameObject targetObject) {
		target = targetObject;
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Player")) {
			target = other.gameObject;
		}
	}
	
	void OnTriggerExit(Collider other) {
		if(other.gameObject == target) {
			target = null;
		}
	}
}
