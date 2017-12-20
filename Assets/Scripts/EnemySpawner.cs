using System.Collections.Generic;
using UnityEngine;
using Settings;

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
			Debug.LogError("You've forgotten to set a parameter to EnemySpawner script");
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

	private float GetRandomTime() {
		return Random.Range(waves[currentWave].minTimeBetweenEnemies, waves[currentWave].maxTimeBetweenEnemies);
	}
}