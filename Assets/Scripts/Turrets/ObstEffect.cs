using UnityEngine;

public class ObstEffect : MonoBehaviour {

	private int boxStrength;

	public int boxStr { set { boxStrength = value; }}

	public void Hit(int damage) {
		// Enemy attacks the box and destroys it
		boxStrength -= damage;

		if (boxStrength <= 0) {
			Break();
		} else {
			UpdateHealth();
		}
	}

	private void Break() {
		Destroy(gameObject);
	}

	private void UpdateHealth() {
		// Show and update health bar
	}
}
