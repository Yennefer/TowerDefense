using UnityEngine;
using EventsSystem;

public class Enemy : MonoBehaviour {

	[SerializeField]
	private int health = 100;
	[SerializeField]
	private int takesLives = 10;
	[SerializeField]
	private int givesMoney = 5;

	public void Hit(int damage) {
		health -= damage;
		
		if (health <= 0) {
			GameManager.instance.money += givesMoney;
			Die();
		} else {
			UpdateHealth();
		}
	}

	private void Die() {
		// Todo: Show dying animation
		Destroy(gameObject);
	}

	private void UpdateHealth() {
		// Todo: Show and update health bar
	}

	public void AchievedTarget() {
		GameManager.instance.lives -= takesLives;
		Die();
	}
}