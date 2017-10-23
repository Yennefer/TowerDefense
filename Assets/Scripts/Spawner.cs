using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
	Spawner instantiate all objects from "prefabsToSpawn" array once
	with random period of time specified in seconds 
	by "minSpawnTimePeriod" and "maxSpawnTimePeriod" variables
 */
public class Spawner : MonoBehaviour {

	[SerializeField]
	private GameObject[] prefabsToSpawn;
	[SerializeField]
	private float minSpawnTimePeriod;
	[SerializeField]
	private float maxSpawnTimePeriod;

	private Timer timer;
	private UnityAction spawnAction;
	private int currentObjectIndex = 0;

	public void Start() {
		spawnAction += Spawn;
		timer = Timer.AddAsComponent(gameObject, spawnAction);
		timer.StartTimer(Random.Range(minSpawnTimePeriod, maxSpawnTimePeriod));
	}

    private void Spawn() {
		if (currentObjectIndex < prefabsToSpawn.Length) {
			timer.StopTimer();
			GameObject enemy = Instantiate(prefabsToSpawn[currentObjectIndex], transform.position, Quaternion.identity);
			enemy.transform.parent = gameObject.transform;
			currentObjectIndex++;
			timer.StartTimer(Random.Range(minSpawnTimePeriod, maxSpawnTimePeriod));
		} else {
			timer.StopTimer();
		}
	}
}
