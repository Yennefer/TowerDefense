using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitData : MonoBehaviour {

	protected Transform rotator;

	protected float fireRate = 1.5f;

	protected float nextFire;

	protected Transform targ;
	
	private void Awake()
	{
		// get turret's rotator
		rotator = GetComponent<Transform>();
	}

	protected void Update()
	{
		if (targ == null)
		{
			rotator.Rotate(0, 0.5f, 0);
		}
		else
		{
			rotator.LookAt(targ);
			if (Time.time > nextFire)
			{
				nextFire = Time.time + fireRate;
				Fire();
			}
		}
		Debug.DrawRay(rotator.position, rotator.forward * 50, Color.blue);
	}

	public virtual void Fire()
	{
		Debug.Log("Firing!");
	}

	protected void OnTriggerEnter(Collider other)
	{
		if (!other.CompareTag("Shell"))
		{
			targ = other.transform;
			Debug.Log(other.gameObject.name);
		}
	}

	protected void OnTriggerExit(Collider other)
	{
		if (!other.CompareTag("Shell"))
		{
			targ = null;
			Debug.Log(other.gameObject.name);
		}
	}	
}
