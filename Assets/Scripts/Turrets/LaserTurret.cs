using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LaserTurret : BaseTurret {

	[SerializeField]
	private Transform laserEmit;
	[SerializeField]
	private float laserDuration = 0.08f;
	[SerializeField]
	private int damage = 10;

	private LineRenderer laserLine;
	private Timer timer;
	private UnityAction hideRayAction;

	private void Start()
	{
		// get linerenderer
		laserLine = GetComponent<LineRenderer>();
		laserLine.SetPosition(0, laserEmit.position);

		hideRayAction += HideRayWithTimer;
		timer = Timer.AddAsComponent(gameObject, hideRayAction);
	}
	
	protected override void Fire(Enemy enemy)
	{
		DrawRayTo(enemy.transform.position);
		enemy.Hit(damage);
	}

	private void DrawRayTo(Vector3 position)
	{
		laserLine.SetPosition(1, position);
		laserLine.enabled = true;
		timer.StartTimer(laserDuration);
	}

	private void HideRayWithTimer()
	{
		laserLine.enabled = false;
		timer.StopTimer();
	}
}