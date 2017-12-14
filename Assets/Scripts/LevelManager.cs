using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    private UnityAction<EventObject> initLevelListener;

    private void OnEnable() {
		EventManager.RegisterListener(Events.initLevel.ToString(), initLevelListener);
	}

	private void OnDisable() {
		EventManager.UnregisterListener(Events.initLevel.ToString(), initLevelListener);
	}

    private void Awake () {
        initLevelListener = InitLevel;
    }

    private void InitLevel(EventObject levelSettings) {
        LevelSettings settings = (LevelSettings) levelSettings.getObjectData(EventDataTags.LEVEL_SETTINGS_TAG);
        InitLevel(settings);
    }

    private void InitLevel(LevelSettings settings) {

    }
}