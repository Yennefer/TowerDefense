using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitData : MonoBehaviour {

	protected Transform targ;

	private void Awake()
	{
		// get a target to shoot at
		targ = GameObject.FindGameObjectWithTag("Target").transform;
	}
	
}
