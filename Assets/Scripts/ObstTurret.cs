using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstTurret : InitData {

	[SerializeField]
	private GameObject obstPrefab;
	[SerializeField]
	private Transform obstSpawn;

	private Transform head;

	void Start () 
	{
		head = UtilityFunctions.headTransform(transform);
	}
	
	// Update is called once per frame
	void Update () 
	{
		// get turret's head
		head.LookAt(targ.transform);

		// tie a function with inputmanager's delegate
		InputManager.ObstBoxFire = Fire;
	}

	private void Fire()
	{
		// instantiate the prefab
		GameObject obstacle = Instantiate(obstPrefab, obstSpawn.position, obstSpawn.rotation);

		// add velocity vector
		obstacle.GetComponent<Rigidbody>().velocity = obstSpawn.transform.right * 20;

		// destroy bomb after the time specified. Will be changed.
		Destroy(obstacle, 4.0f);


/*
		for (int i = 0; i <= 20; i++)
		{
			obstacle.transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime;
		}		
		
*/
	}

	
}
