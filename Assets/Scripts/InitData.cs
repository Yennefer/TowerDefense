using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitData : MonoBehaviour {

	protected GameObject targ;

	private void Awake()
	{
		// get a target to shoot at
		targ = GameObject.FindGameObjectWithTag("Target");
	}
	
	private void Update()
	{
		//randomizeShot();
	}

	// make shooting a bit randomized
	//private Vector3 randomizeShot(){
	//	randomShotCoords = 

	//}

}
