﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstTurret : BaseTurret {

	[SerializeField]
	private GameObject obstPrefab;
	[SerializeField]
	private Transform obstSpawn;
	protected int boxStrength;
	private float boxLifeTime;

	private void Start()
	{
		// get settings for obstacle turret
		ExtractSettings(settings);

		// setting up enemy detection radius
		GetComponent<SphereCollider>().radius = range;
	}

	protected override void Fire(Enemy enemy)
	{
		// instantiate the prefab
		GameObject obstacle = Instantiate(obstPrefab, obstSpawn.position, obstSpawn.rotation);

		// add velocity vector
		obstacle.GetComponent<Rigidbody>().velocity = UtilityFunctions.RandomizeShot(obstSpawn) * flySpeed;

		// scale the obstacle
		obstacle.transform.DOScale(2, 3);

		// set box's strength
		obstacle.GetComponent<ObstEffect>().boxStr = boxStrength;

		// destroy bomb after the time specified. Will be changed.
		Destroy(obstacle, boxLifeTime);
	}

	protected override void ExtractSettings(TurretSettings settings)
	{
		fireRate = settings.otSettings.fireRate;
		range = settings.otSettings.range;
		boxStrength = settings.otSettings.boxStrength;
		boxLifeTime = settings.otSettings.boxLifeTime;
		flySpeed = settings.otSettings.boxFlySpeed;
	}
}