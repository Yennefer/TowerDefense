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

}
