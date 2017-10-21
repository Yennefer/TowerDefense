using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTurret : InitData {

	[SerializeField]
	private GameObject bombPrefab;
	[SerializeField]
	private Transform bombSpawn;

	//temp
	public Transform targ;

	private void Start()
	{
		// tie a function with inputmanager's delegate
		InputManager.BombFire = Fire;
	}
	
	private void Update()
	{
		rotator.LookAt(targ);
		if (targ != null && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Fire();
		}
	}

	private void Fire()
	{
		// instantiate the prefab
		GameObject bomb = Instantiate(bombPrefab, bombSpawn.position, bombSpawn.rotation);

		// add velocity vector
		bomb.GetComponent<Rigidbody>().velocity = UtilityFunctions.randomizeShot(bombSpawn) * 50;
	}
}
