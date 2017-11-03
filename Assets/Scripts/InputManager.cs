using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class InputManager : MonoBehaviour {

	public static Action BombFire;
	public static Action LaserFire;
	public static Action ObstBoxFire;

	[SerializeField]
	private KeyCode bombTurret;
	[SerializeField]
	private KeyCode laserTurret;
	[SerializeField]
	private KeyCode obstTurret;


	private void Start()
	{
		
	}
	
	private void Update()
	{
		// firing the bomb
		if (Input.GetKeyDown(bombTurret))
		{
			BombFire();
			Debug.Log("Bomb launched");
		}

		// firing the obstacle box
		if (Input.GetKeyDown(obstTurret))
		{
			ObstBoxFire();
			Debug.Log("Obstacle box launched");
		}

		// firing the laser
		if (Input.GetKeyDown(laserTurret))
		{
			LaserFire();
			Debug.Log("Laser fired");
		}
	}
}
