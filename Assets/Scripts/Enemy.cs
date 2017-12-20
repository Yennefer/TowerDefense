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
		// Todo: Show dying animation
		Destroy(gameObject);
	}

	private void UpdateHealth() {
		// Todo: Show and update health bar
	}
}