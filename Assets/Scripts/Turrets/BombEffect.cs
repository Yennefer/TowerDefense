using UnityEngine;

public class BombEffect : MonoBehaviour {

	[SerializeField]
	private float radius;
	[SerializeField]
	private float power;

	private int damage;
	
	public int dmg { 
		set { damage = value; }
	}

	private void OnCollisionEnter(Collision other) {
		Vector3 explosionPos = transform.position;
		Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
		foreach (Collider hit in colliders) {
			Enemy enemy = hit.GetComponent<Enemy>();
			if (enemy != null) {
				// Not doing force yet, because of animation problems
				// ApplyExplosionForce(enemy.gameObject, explosionPos);
				enemy.Hit(damage);
			}
		}
		Destroy(this.gameObject);
	}

	private void ApplyExplosionForce(GameObject target, Vector3 fromPosition) {
		Rigidbody rb = target.GetComponent<Rigidbody>();
		rb.AddExplosionForce(power, fromPosition, radius, 40.0f);
	}
}