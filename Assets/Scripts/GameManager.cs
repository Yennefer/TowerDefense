using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private GameSettings gameSettings;

    [SerializeField]
    private Canvas levelsMenu;
	
    private List<LevelSettings> levels;
    private UnityAction<GameObject> selectLevelListener;

    private void OnEnable() {
		EventManager.RegisterListener(Events.selectLevel.ToString(), selectLevelListener);
	}

	private void OnDisable() {
		EventManager.UnregisterListener(Events.selectLevel.ToString(), selectLevelListener);
	}

    private void Awake () {
        DontDestroyOnLoad(gameObject);
        selectLevelListener = LevelClicked;
    }

    private void Start() {
        levels = gameSettings.levels;
        InitLevelsMenu(levels);
    }

    private void ParseGameSettings(GameSettings gameSettings) {
        levels = gameSettings.levels;
    }

    private void InitLevelsMenu(List<LevelSettings> levelsSetting) {
        levelsMenu.GetComponent<LevelsMenu>().Init(levels);
    }

    private void LevelClicked(GameObject levelPanel) {
        int scene = (int) levelPanel.GetComponent<LevelPanel>().sceneName;
        SceneManager.LoadScene(scene);
    }
}