using System.Collections.Generic;
using UnityEngine;
using Settings;

public class BaseTurret : MonoBehaviour {

	protected float fireRate;
	protected float range;
	protected int flySpeed;

	private Transform rotator;
	private float nextFireTime;
	private LinkedList<Enemy> targets;

	private void Awake() {

		// get turret's rotator
		rotator = GetComponent<Transform>();

		// init enemy list
		targets = new LinkedList<Enemy>();
	}

	private void Update() {
		Enemy enemy = null;
		if (HasNotNullTarget(out enemy))
		{
			rotator.LookAt(enemy.transform);
			if (Time.time > nextFireTime)
			{
				nextFireTime = Time.time + fireRate;
				Fire(enemy);
			}
		}
		else
		{
			rotator.Rotate(0, 0.5f, 0);
		}
		Debug.DrawRay(rotator.position, rotator.forward * 50, Color.blue);
	}

	public void Init(TurretsSettings settings) {
		ExtractSettings(settings);
	}

	protected virtual void Fire(Enemy enemy) {
	}

	protected virtual void ExtractSettings(TurretsSettings settings) {
	}

	private void OnTriggerEnter(Collider other)	{
		Enemy enemy = other.gameObject.GetComponent<Enemy>();
		if (enemy != null)
		{
			targets.AddLast(enemy);
		}
	}

	private void OnTriggerExit(Collider other) {
		Enemy enemy = other.gameObject.GetComponent<Enemy>();
		if (enemy != null)
		{
			targets.Remove(enemy);
		}
	}

	// We need this method because some of the targets in the list 
	// can be destroyed before leaving turrets range of fire (if a target was killed, for example)
	private bool HasNotNullTarget(out Enemy target) {
		target = null;
		if (targets.Count == 0) {
			return false;
		}

		target = targets.First.Value;
		if (target == null) {
			targets.RemoveFirst();
			return HasNotNullTarget(out target);
		}

		return true;
	}
}