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
    private UnityAction<EventObject> selectLevelListener;

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
        ParseGameSettings(gameSettings);
        InitLevelsMenu(levels);
    }

    private void ParseGameSettings(GameSettings gameSettings) {
        levels = gameSettings.levels;
    }

    private void InitLevelsMenu(List<LevelSettings> levelsSetting) {
        levelsMenu.GetComponent<LevelsMenu>().Init(levels);
    }

    private void LevelClicked(EventObject clickedLevel) {
        int level = clickedLevel.getIntData(LevelPanel.LEVEL_INDEX_TAG);
        LevelSettings levelSettings = levels[level];
        SceneManager.LoadScene((int) levelSettings.levelScene);
        InitLevel(levelSettings);
    }

    private void InitLevel(LevelSettings levelSettings) {
        EventObject initLevelEvent = new EventObject();
        initLevelEvent.putData(EventDataTags.LEVEL_SETTINGS_TAG, levelSettings);
        EventManager.TriggerEvent(Events.initLevel.ToString(), initLevelEvent);
    }
}