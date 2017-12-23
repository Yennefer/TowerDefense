using UnityEngine;
using Settings;

public class LaserTurret : BaseTurret {

	[SerializeField]
	private Transform laserEmit;

	private float laserDuration;
	private int damage;
	private LineRenderer laserLine;
	private Timer timer;
	private SphereCollider coll;
	
	private void Start()
	{
		coll = GetComponent<SphereCollider>();
		if (!coll) {
			Debug.LogError("Object with LaserTurret script should have a SphereCollider component");
			return;
		}

		// setting up enemy detection radius
		coll.radius = range;

		// get linerenderer to draw laser line
		laserLine = GetComponent<LineRenderer>();

		laserLine.SetPosition(0, laserEmit.position);

		timer = Timer.AddAsComponent(gameObject, () => { laserLine.enabled = false; timer.StopTimer(); } );
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

	protected override void ExtractSettings(TurretsSettings settings)
	{
		fireRate = settings.ltSettings.fireRate;
		range = settings.ltSettings.range;
		damage = settings.ltSettings.damage;
		laserDuration = settings.ltSettings.laserDuration;
	}
}