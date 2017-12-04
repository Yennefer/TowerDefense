using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	[SerializeField]
	private GameSettings gameSettings;
	[SerializeField]
	private Canvas levelsMenu;
	[SerializeField]
	private GameObject level;
	
	private Enums.Scene sceneName;
	private List<LevelSettings> levels;

	private void Awake () {
		DontDestroyOnLoad(gameObject);
	}

	private void Start() {
		ParseGameSettings(gameSettings);
		InitLevelsMenu();
	}

	private void ParseGameSettings(GameSettings gameSettings) {
		sceneName = gameSettings.gameScene;
		levels = gameSettings.levels;
		Debug.Log("Scene: " + sceneName + ", levels:");

		foreach (LevelSettings level in levels) {
			Debug.Log("   Level:");
			foreach (LevelSettings.Wave wave in level.waves) {
				Debug.Log("      Wave enemy count:" + wave.enemyCount);
			}
		}
	}

	private void InitLevelsMenu() {
		
	}
}