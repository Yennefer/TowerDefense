using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTurret : MonoBehaviour {

	protected float fireRate;
	protected float range;
	private Transform rotator;
	private float nextFireTime;
	private LinkedList<Enemy> targets;
	protected TurretSettings settings;
	
	private void Awake()
	{
		// load scriptableobject from assets
		settings = Resources.Load("Turrets") as TurretSettings;

		// get turret's rotator
		rotator = GetComponent<Transform>();

		// init enemy list
		targets = new LinkedList<Enemy>();
	}

	private void Update()
	{
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

	protected virtual void Fire(Enemy enemy) 
	{
	}

	protected virtual void ExtractSettings(TurretSettings settings)
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		Enemy enemy = other.gameObject.GetComponent<Enemy>();
		if (enemy != null)
		{
			targets.AddLast(enemy);
			Debug.Log(gameObject.name + ": " + other.gameObject.name + " got in range. Target count = " + targets.Count);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		Enemy enemy = other.gameObject.GetComponent<Enemy>();
		if (enemy != null)
		{
			targets.Remove(enemy);
			Debug.Log(gameObject.name + ": " + other.gameObject.name + " leaved range. Target count = " + targets.Count);
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