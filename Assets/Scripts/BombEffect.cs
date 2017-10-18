using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffect : MonoBehaviour {

	[SerializeField]
	private float radius;

	[SerializeField]
	private float power;

	private void OnCollisionEnter(Collision other)
	{
		Vector3 explosionPos = transform.position;
		Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
		foreach (Collider hit in colliders)
		{
			Rigidbody rb = hit.GetComponent<Rigidbody>();
			if (rb != null)
			{
				rb.AddExplosionForce(power, explosionPos, radius, 4.0f);
				Destroy(rb.gameObject, 2);
			}
		}
		Destroy(this.gameObject);
	}
}
