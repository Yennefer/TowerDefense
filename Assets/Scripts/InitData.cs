using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitData : MonoBehaviour {

	protected GameObject targ;

	void Awake ()
	{
		targ = GameObject.FindGameObjectWithTag("Target");
	}
	
	void Update ()
	{
		//randomizeShot();
	}

	// make shooting a bit randomized
	//private Vector3 randomizeShot(){
	//	randomShotCoords = 

	//}

}
