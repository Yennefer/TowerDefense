﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstTurret : InitData {

	[SerializeField]
	private GameObject obstPrefab;
	[SerializeField]
	private Transform obstSpawn;

	private Transform head;

	private void Start()
	{
		// get turret's head
		head = UtilityFunctions.headTransform(transform);

		// tie a function with inputmanager's delegate
		InputManager.ObstBoxFire = Fire;
	}
	
	// Update is called once per frame
	private void Update()
	{
		head.LookAt(targ);
		obstSpawn.LookAt(targ);
	}

	private void Fire()
	{
		// instantiate the prefab
		GameObject obstacle = Instantiate(obstPrefab, obstSpawn.position, obstSpawn.rotation);

		// add velocity vector
		obstacle.GetComponent<Rigidbody>().velocity = UtilityFunctions.randomizeShot(obstSpawn)* 20;

		// scale the obstacle
		obstacle.transform.DOScale(2, 3);

		// destroy bomb after the time specified. Will be changed.
		Destroy(obstacle, 4.0f);
	}
}