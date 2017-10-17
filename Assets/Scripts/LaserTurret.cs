using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : InitData {

	[SerializeField]
	private Transform laserEmit;
	[SerializeField]
	private LineRenderer laserLine;
	private Transform head;

	private void Start()
	{
		// get turret's head
		head = UtilityFunctions.headTransform(transform);

		// get linerenderer
		laserLine = GetComponent<LineRenderer>();
	}
	
	private void Update()
	{
		head.LookAt(targ);

		RaycastHit hit;

		Physics.Raycast(laserEmit.position, targ.position, out hit, 50.0f);

		laserLine.SetPosition(0, laserEmit.position);

		Debug.DrawLine(laserEmit.position, targ.position, Color.red);
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

	private void Fire()
	{
		
	}
}
