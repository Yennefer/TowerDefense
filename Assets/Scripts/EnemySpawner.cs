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
public class EnemySpawner : MonoBehaviour {

	[SerializeField]
	private EnemiesSpawnSettings enemiesSpawnSettings;

	private Timer waveTimer;
	private Timer enemyTimer;
	private GameObject enemy;
	private List<Wave> waves;
	private int enemyCount = 0;
	private int currentWave = 0;

	private void Awake() {
		if (!enemiesSpawnSettings) {
			Debug.LogError("You've forgotten to set a parameter to Spawner script");
		}

		ParseSettings();
	}

	private void ParseSettings() {
		enemy = enemiesSpawnSettings.enemy;
		waves = enemiesSpawnSettings.waves;
	}

	private void Start() {
		waveTimer = Timer.AddAsComponent(gameObject, SpawnWave);
		enemyTimer = Timer.AddAsComponent(gameObject, SpawnEnemy);
	}

	public void StartSpawn() {
		StartNewWave();
	}

	private void StartNewWave() {
		if (currentWave < waves.Count) {
			enemyCount = waves[currentWave].enemyCount;
			waveTimer.StartTimer(waves[currentWave].timeBeforeWave);
		}
	}

	private void SpawnWave() {
		waveTimer.StopTimer();
		enemyTimer.StartTimer( GetRandomTime() );
	}

    private void SpawnEnemy() {
		if (enemyCount > 0) {
			enemyCount--;
			GameObject spawn = Instantiate(enemy, transform.position, transform.rotation);
			spawn.transform.parent = gameObject.transform;
			enemyTimer.RestartTimer( GetRandomTime() );
		} else {
			enemyTimer.StopTimer();
			currentWave++;
			StartNewWave();
		}
	}

	public float GetRandomTime() {
		return Random.Range(waves[currentWave].minTimeBetweenEnemies, waves[currentWave].maxTimeBetweenEnemies);
	}
}