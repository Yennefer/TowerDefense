using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : InitData {

	[SerializeField]
	private Transform laserEmit;
	[SerializeField]
	private LineRenderer laserLine;

	private RaycastHit hit;
	//temp
	public Transform targ;

	private void Start()
	{
		// get linerenderer
		laserLine = GetComponent<LineRenderer>();

		// tie a function with inputmanager's delegate
		InputManager.LaserFire = Fire;
	}
	
	private void Update()
	{
		rotator.LookAt(targ);
		if (targ != null && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Fire();
		}

		Debug.DrawRay(rotator.position, rotator.forward * 50, Color.blue);
	}

	private void Fire()
	{
		if (Physics.Raycast(rotator.position, UtilityFunctions.randomizeShot(rotator), out hit, 50.0f))
		{
			Debug.Log(hit.collider.name);
			if (hit.collider.GetComponent<Rigidbody>())
			{
				Destroy(hit.collider.gameObject);
			}
		}
	}
}
