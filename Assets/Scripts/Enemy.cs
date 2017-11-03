using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField]
	private int health = 100;

	public void Hit(int damage) {
		health -= damage;

		Debug.Log(gameObject.name + ": Hit with " + damage + " damage. Health " + health);
		
		if (health <= 0) {
			Die();
		} else {
			UpdateHealth();
		}
	}

	private void Die() {
		// Show dying animation
		Destroy(gameObject);
	}

	private void UpdateHealth() {
		// Show and update health bar
	}
}