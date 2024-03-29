using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public int maxHealth = 20;
	public GameObject healthbarPrefab;
	
	protected GameObject healthbar;
	protected GameObject guipanel;
	
	protected UIFilledSprite filledSprite;
	
	protected int health;
	// Use this for initialization
	void Start () {
		health = maxHealth;
		guipanel = (GameObject)GameObject.Find("GUIPanel");
		healthbar = (GameObject)Instantiate(healthbarPrefab, Vector3.zero, Quaternion.identity);
		healthbar.transform.parent = guipanel.transform;
		healthbar.transform.localScale = new Vector3(1, 1, 1);
		
		filledSprite = (UIFilledSprite) healthbar.GetComponentInChildren<UIFilledSprite>();
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
	}
	
	public void TakeDamage(int damage) {
		health = Mathf.Clamp(health - damage, 0, maxHealth);
		if(health > 0) {
			filledSprite.fillAmount = (float)health / maxHealth;
		} else {
			healthbar.SetActive(false);
		}
	}
	
	public void AddHealth(int healthIncrease) {
		if((health <= 0) && (healthIncrease > 0)) {
			healthbar.SetActive(true);
		}
		health = Mathf.Clamp(health + healthIncrease, 0, maxHealth);
		filledSprite.fillAmount = (float)health / maxHealth;
	}
}
