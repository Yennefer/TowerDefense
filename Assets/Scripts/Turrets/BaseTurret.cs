using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTurret : MonoBehaviour {

	[SerializeField]
	private float fireRate = 0.5f;
	[SerializeField]
	private float range = 15f;

	private Transform rotator;
	private float nextFireTime;
	private LinkedList<Enemy> targets;
	
	private void Awake()
	{
		// get turret's rotator
		rotator = GetComponent<Transform>();

		// init enemy list
		targets = new LinkedList<Enemy>();

		// setting up enemy detection radius
		GetComponent<SphereCollider>().radius = range;
	}

	private void Update()
	{
		if (targets.Count > 0)
		{
			Enemy target = targets.First.Value;
			rotator.LookAt(target.transform);
			if (Time.time > nextFireTime)
			{
				nextFireTime = Time.time + fireRate;
				Fire(target);
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
}