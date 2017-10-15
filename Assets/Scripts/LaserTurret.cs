using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : InitData {

	[SerializeField]
	private Transform laserEmit;
	[SerializeField]
	private LineRenderer laserLine;
	private Transform head;

	

	void Start () 
	{
		head = UtilityFunctions.headTransform(transform);

		

		laserLine = GetComponent<LineRenderer>();
	}
	
	void Update () 
	{
		head.LookAt(targ.transform);

		RaycastHit hit;

		Physics.Raycast(laserEmit.position, targ.transform.position, out hit, 50.0f);

		laserLine.SetPosition(0, laserEmit.transform.position);

		Debug.DrawLine(laserEmit.position, targ.transform.position, Color.red);
		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			laserLine.SetPosition(1, hit.point);
			laserLine.enabled = true;
			Debug.Log("test");
			Debug.Log(hit.collider.gameObject.name);
			Destroy(hit.collider.gameObject);
			laserLine.enabled = false;
		}
	}
}
