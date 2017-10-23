using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField]
	private int health = 100;

	public void Hit(int damage) {
		health -= damage;

		if (health <= 0) {
			Die();
		} else {
			UpdateHealth();
		}
	}

	private void Die() {
		// Play dying animation and destroy object
	}

	private void UpdateHealth() {
		// Show and update health bar
	}
}