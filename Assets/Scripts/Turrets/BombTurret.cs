using UnityEngine;
using Settings;

public class BombTurret : BaseTurret {

	[SerializeField]
	private GameObject bombPrefab;
	[SerializeField]
	private Transform bombSpawn;

	private int damage;
	private SphereCollider coll;
	
	private void Start()
	{
		coll = GetComponent<SphereCollider>();
		if (!coll) {
			Debug.LogError("Object with BombTurret script should have a SphereCollider component");
			return;
		}

		// Setup enemy detection radius
		coll.radius = range;
	}
	
	protected override void Fire(Enemy enemy)
	{
		// instantiate the prefab
		GameObject bomb = Instantiate(bombPrefab, bombSpawn.position, bombSpawn.rotation);

		// add velocity vector
		bomb.GetComponent<Rigidbody>().velocity = UtilityFunctions.RandomizeShot(bombSpawn) * flySpeed;

		// set bomb's damage value
		bomb.GetComponent<BombEffect>().dmg = damage;
	}

	protected override void ExtractSettings(TurretsSettings settings)
	{
		fireRate = settings.btSettings.fireRate;
		range = settings.btSettings.range;
		damage = settings.btSettings.damage;
		flySpeed = settings.btSettings.bombFlySpeed;
	}
}