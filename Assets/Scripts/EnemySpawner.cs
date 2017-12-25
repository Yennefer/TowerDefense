using System.Collections.Generic;
using UnityEngine;
using Settings;

public class EnemySpawner : MonoBehaviour {

	[SerializeField]
	private EnemiesSpawnSettings enemiesSpawnSettings;
	[SerializeField]
	private GameObject path;

	private Timer waveTimer;
	private Timer enemyTimer;
	private GameObject enemy;
	private List<Wave> waves;
	private int enemyCount = 0;
	private int currentWave = 0;

	private void Awake() {
		if (!enemiesSpawnSettings || !path) {
			Debug.LogError("You've forgotten to set a parameter to EnemySpawner script");
			return;
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
		currentWave = 0;
		enemyCount = 0;

		StartNewWave();
	}

	public void StopSpawn() {
		waveTimer.StopTimer();
		enemyTimer.StopTimer();

		foreach(Transform child in transform) {
    		Destroy(child.gameObject);
		}
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
			GameObject go = Instantiate(enemy, transform.position, transform.rotation);
			go.transform.parent = gameObject.transform;

			SetEnemyOnPath(go);
			
			enemyTimer.RestartTimer( GetRandomTime() );
		} else {
			enemyTimer.StopTimer();
			currentWave++;
			StartNewWave();
		}
	}

	private void SetEnemyOnPath(GameObject enemy) {
		Enemy e = enemy.GetComponent<Enemy>();

		PathMovement pm = enemy.GetComponent<PathMovement>();
		if (!pm) {
			Debug.LogError("PathMovement script does not attached to spawned enemy");
			return;
		}

		pm.StartPathMovement(path, () => e.AchievedTarget());
	}

	private float GetRandomTime() {
		return Random.Range(waves[currentWave].minTimeBetweenEnemies, waves[currentWave].maxTimeBetweenEnemies);
	}
}