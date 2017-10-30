using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : BaseTurret {

	[SerializeField]
	private Transform laserEmit;

	private LineRenderer laserLine;
	private RaycastHit hit;
	private WaitForSeconds duration = new WaitForSeconds(0.08f);

	private void Start()
	{
		// get linerenderer
		laserLine = GetComponent<LineRenderer>();

		// tie a function with inputmanager's delegate
		InputManager.LaserFire = Fire;
	}
	
	protected override void Fire()
	{
		laserLine.SetPosition(0, laserEmit.position);
		if (Physics.Raycast(laserEmit.position, UtilityFunctions.randomizeShot(laserEmit), out hit, 50.0f))
		{
			laserLine.SetPosition(1, hit.point);
			StartCoroutine(laserRay());
			Debug.Log(gameObject.name + ": " + "hit " + hit.collider.name);
			if (hit.collider.GetComponent<Rigidbody>())
			{
				Destroy(hit.collider.gameObject);
			}
		}
	}

	private IEnumerator laserRay()
	{
		laserLine.enabled = true;
		yield return duration;
		laserLine.enabled = false;
	}
}
