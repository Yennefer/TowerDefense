using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityFunctions
{
	public static Vector3 randomizeShot(Transform trans)
	{
		float rndx = Random.Range(-0.1f, 0.1f);
		
		float rndz = Random.Range(-0.1f, 0.1f);

		return (trans.forward + new Vector3(0, 0, 0));
	}
}
