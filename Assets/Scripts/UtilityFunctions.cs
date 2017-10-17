using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityFunctions
{
	public static Transform headTransform(Transform trans)
	{
		// get turret's head
		foreach (var cmp in trans.GetComponentsInChildren<Transform>())
		{
			if (cmp.name == TurretParts.Head.ToString())
			{
				return cmp;
			}
		}
		return null;
	}

	public static Vector3 randomizeShot(Transform trans)
	{
		float rndx = Random.Range(-0.1f, 0.1f);
		
		float rndz = Random.Range(-0.1f, 0.1f);

		return (trans.forward + new Vector3(rndx, 0, rndz));
	}
}
