using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public int maxHealth = 20;
	public GameObject healthbarPrefab;
	
	private GameObject healthbar;
	private GameObject guipanel;
	
	protected int health;
	// Use this for initialization
	void Start () {
		health = maxHealth;
		guipanel = (GameObject)GameObject.Find("GUIPanel");
		healthbar = (GameObject)Instantiate(healthbarPrefab, Vector3.zero, Quaternion.identity);
		healthbar.transform.parent = guipanel.transform;
		healthbar.transform.localScale = new Vector3(1, 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0) {
			if(healthbar != null) {
				Destroy(healthbar);
			}
			SendMessage("Die");
		}
		
		Vector3 healthbarLocation = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 2.5f, 0));
		healthbar.transform.position = new Vector3(
			(healthbarLocation.x) - (Screen.width / 2),
			(healthbarLocation.y) - (Screen.height / 2),
			0) / 225;
		Debug.Log (healthbarLocation);
	}
	
	public void TakeDamage(int damage) {
		health -= damage;
	}
}
