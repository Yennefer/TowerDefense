using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTurret : InitData {

	[SerializeField]
	private GameObject bombPrefab;
	[SerializeField]
	private Transform bombSpawn;

	private void Start()
	{
		// tie a function with inputmanager's delegate
		InputManager.BombFire = Fire;
	}
	
	public override void Fire()
	{
		// instantiate the prefab
		GameObject bomb = Instantiate(bombPrefab, bombSpawn.position, bombSpawn.rotation);

		// add velocity vector
		bomb.GetComponent<Rigidbody>().velocity = UtilityFunctions.randomizeShot(bombSpawn) * 50;
	}
}
