using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField]
	private int health = 100;

	public void Hit(int damage) {
		Debug.Log(gameObject.name + ": Hit");

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

	// void OnCollisionEnter (Collision col)
    // {
	// 	Debug.Log(gameObject.name + ": OnCollisionEnter");
    //     //Destroy(col.gameObject);
    // }
}