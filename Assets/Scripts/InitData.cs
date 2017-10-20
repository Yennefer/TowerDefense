﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitData : MonoBehaviour {

	protected Transform rotator;

	protected float fireRate = 10.5f;

	protected float nextFire;

	protected Transform targ;

	protected bool stillFiring = false;

	protected Queue<GameObject> targets;
	
	private void Awake()
	{
		// get turret's rotator
		rotator = GetComponent<Transform>();

		//init the queue
		targets = new Queue<GameObject>();
	}

	protected void Update()
	{
		if (targets.Count > 0 && !stillFiring)
		{
			//targ = (targets.ToArray()[0].gameObject != null) ? targets.Dequeue().transform : null;
			targ = targets.Dequeue().transform;
			stillFiring = true;
		}
		else if (targ == null)
		{
			stillFiring = false;
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
			targets.Enqueue(other.gameObject);
			Debug.Log(other.gameObject.name);
			Debug.Log(targets.Count);
		}
	}

	protected void OnTriggerExit(Collider other)
	{
		if (!other.CompareTag("Shell"))
		{
			if (targets.Contains(other.gameObject))
			{
				targets.Dequeue();
			}
			else
			{
				targ = null;
			}
			Debug.Log(other.gameObject.name);
		}
	}
}