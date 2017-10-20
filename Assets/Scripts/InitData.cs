using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitData : MonoBehaviour {

	protected Transform rotator;

	private void Awake()
	{
		// get turret's rotator
		rotator = GetComponent<Transform>();
	}
	
}
