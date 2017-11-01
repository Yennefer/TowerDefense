using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTurret : BaseTurret {

	[SerializeField]
	private GameObject bombPrefab;
	[SerializeField]
	private Transform bombSpawn;
	
	protected override void Fire(Enemy enemy)
	{
		// instantiate the prefab
		GameObject bomb = Instantiate(bombPrefab, bombSpawn.position, bombSpawn.rotation);

		// add velocity vector
		bomb.GetComponent<Rigidbody>().velocity = UtilityFunctions.randomizeShot(bombSpawn) * 50;
	}
}