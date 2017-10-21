using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitData : MonoBehaviour {

	protected Transform rotator;

	protected float fireRate = 1.5f;

	protected float nextFire;
	
	private void Awake()
	{
		// get turret's rotator
		rotator = GetComponent<Transform>();
	}
	
}
