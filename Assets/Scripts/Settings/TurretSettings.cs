using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "Turrets", menuName = "Settings/Turrets", order =1)]
public class TurretSettings : ScriptableObject
{
	public BTSettings btSettings;
	public LTSettings ltSettings;
	public OTSettings otSettings;
}

[System.Serializable]
public class BTSettings
{
	public string name = "BombTurret";
	[Range(0, 10)]
	public float fireRate;
	[Range(5, 20)]
	public float range;
	[Range(0, 30)]
	public int damage;
	[Range(20, 60)]
	public int bombFlySpeed;
}

[System.Serializable]
public class LTSettings
{
	public string name = "LaserTurret";
	[Range(0, 10)]
	public float fireRate;
	[Range(5, 20)]
	public float range;
	[Range(0.05f, 0.5f)]
	public float laserDuration;
	[Range(1, 20)]
	public int damage;
}

[System.Serializable]
public class OTSettings
{
	public string name = "ObstTurret";
	[Range(0, 10)]
	public float fireRate;
	[Range(5, 20)]
	public float range;
	[Range(0.1f, 10f)]
	public float boxLifeTime;
	[Range(5, 20)]
	public int boxStrength;
	[Range(20, 60)]
	public int boxFlySpeed;
}