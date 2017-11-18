using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTurret : BaseTurret {

	[SerializeField]
	private GameObject bombPrefab;
	[SerializeField]
	private Transform bombSpawn;
	protected int damage;
	
	private void Start()
	{
		// get settings for bomb turret
		ExtractSettings(settings);

		// setting up enemy detection radius
		GetComponent<SphereCollider>().radius = range;
	}
	protected override void Fire(Enemy enemy)
	{
		// instantiate the prefab
		GameObject bomb = Instantiate(bombPrefab, bombSpawn.position, bombSpawn.rotation);

		// add velocity vector
		bomb.GetComponent<Rigidbody>().velocity = UtilityFunctions.randomizeShot(bombSpawn) * 50;
	}

	protected override void ExtractSettings(TurretSettings settings)
	{
		fireRate = settings.btSettings.fireRate;
		range = settings.btSettings.range;
		damage = settings.btSettings.damage;
	}
}