using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTurret : InitData {

	[SerializeField]
	private GameObject bombPrefab;
	[SerializeField]
	private Transform bombSpawn;

	private Transform head;

	private void Start()
	{
		// get turret's head
		head = UtilityFunctions.headTransform(transform);

		// tie a function with inputmanager's delegate
		InputManager.BombFire = Fire;
	}
	
	private void Update()
	{
		head.LookAt(targ.transform);
		bombSpawn.LookAt(targ.transform);
	}

	private void Fire()
	{
		// instantiate the prefab
		GameObject bomb = Instantiate(bombPrefab, bombSpawn.position, bombSpawn.rotation);

		// add velocity vector
		bomb.GetComponent<Rigidbody>().velocity = bombSpawn.forward * 50;

		// destroy bomb after the time specified
		Destroy(bomb, 2.0f);
	}
}
