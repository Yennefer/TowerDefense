using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class InputManager : MonoBehaviour {

	public static Action BallFire;
	public static Action LaserFire;
	public static Action ObstBoxFire;

	[SerializeField]
	private KeyCode bombTurret;
	[SerializeField]
	private KeyCode laserTurret;
	[SerializeField]
	private KeyCode obstTurret;


	void Start () 
	{
		
	}
	
	void FixedUpdate () 
	{
		// firing the ball
		if (Input.GetKeyDown(bombTurret))
		{
			Debug.Log("Fire delegate");
			BallFire();
		}

		// firing the obstacle box
		if (Input.GetKeyDown(obstTurret))
		{
			Debug.Log("Fire delegate");
			ObstBoxFire();
		}

		// firing the laser

	}
}
