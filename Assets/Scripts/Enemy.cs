using UnityEngine;
using EventsSystem;

public class Enemy : MonoBehaviour {

	[SerializeField]
	private int health = 100;
	[SerializeField]
	private int _takesLives = 10;

	public int takesLives { 
		get { return _takesLives; } 
	}

	public void Hit(int damage) {
		health -= damage;
		
		if (health <= 0) {
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
		Die();
	}
}