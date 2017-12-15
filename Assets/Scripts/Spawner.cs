using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Settings;

/*
	Spawner instantiate all objects from "prefabsToSpawn" array once
	with random period of time specified in seconds 
	by "minSpawnTimePeriod" and "maxSpawnTimePeriod" variables
 */
public class Spawner : MonoBehaviour {

	[SerializeField]
	private EnemiesSpawnSettings enemiesSpawnSettings;

	private Timer timer;
	private UnityAction spawnAction;
	private List<GameObject> prefabsToSpawn = new List<GameObject>();

	private void Start() {
		spawnAction += Spawn;
		timer = Timer.AddAsComponent(gameObject, spawnAction);
	}

    private void Spawn() {
		if (prefabsToSpawn.Count > 0) {
			GameObject spawnObject = Instantiate(GetRandomObjectToSpawn(), transform.position, Quaternion.identity);
			spawnObject.transform.parent = gameObject.transform;
			//timer.RestartTimer(Random.Range(minSpawnTimePeriod, maxSpawnTimePeriod));
		} else {
			timer.StopTimer();
		}
	}

	private GameObject GetRandomObjectToSpawn() {
		int randomIndex = Random.Range(0, prefabsToSpawn.Count);
		GameObject objectToSpawn = prefabsToSpawn[randomIndex];
		prefabsToSpawn.Remove(objectToSpawn);
		return objectToSpawn;
	}
	
	public void AddObjectsToSpawn(GameObject prefabToSpawn, int objectsCount) {
		for (int i = 0; i < objectsCount; i++) {
			prefabsToSpawn.Add(prefabToSpawn);
		}
	}

	public void StartSpawn() {
		//timer.StartTimer(Random.Range(minSpawnTimePeriod, maxSpawnTimePeriod));
	}
}