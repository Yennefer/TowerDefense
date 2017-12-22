using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GUIManager : MonoBehaviour {

	[SerializeField]
    private StartMenu startMenu;
    [SerializeField]
    private HUD headsUpDisplay;
	[SerializeField]
    private PauseScreen pauseScreen;
	[SerializeField]
	private BuildMenu buildMenu;
	[SerializeField]
	private CameraController cameraController;

	private Dictionary<GameState, GUIState> states;
	private static GUIState currentState;
	private static GUIManager guiManager;

	public static GUIManager instance {
		get {
			if (guiManager == null) {
				guiManager = FindObjectOfType<GUIManager>();

				if (guiManager == null) {
					Debug.LogError ("There needs to be one GUIManager script on a GameObject in your scene");
				}
			}
			return guiManager;
		}
	}

	private void Awake() {
        if (!startMenu || !headsUpDisplay || !buildMenu || !cameraController) {
			Debug.LogError("You've forgotten to set a parameter to GUIManager script");
            return;
		}
        
		PopulateGUIStates();
		SetState(GameState.STARTING);
    }

	private void Update() {
		currentState.Update();
	}

	private void PopulateGUIStates() {
		states = new Dictionary<GameState, GUIState>();
		states.Add(GameState.STARTING, new GUIStartingState(startMenu));
		states.Add(GameState.PLAYING, new GUIPlayingState(headsUpDisplay, cameraController));
		states.Add(GameState.PAUSED, new GUIPausedState(pauseScreen));
		states.Add(GameState.IN_BUILD_MENU, new GUIBuildMenuState(buildMenu, headsUpDisplay));
		states.Add(GameState.OVER, new GUIOverState(startMenu));
	}

	public void SetState(GameState gameState) {
		GUIState state = null;
		if (!states.TryGetValue(gameState, out state)) {
			Debug.LogError("Couldnt find GUIState for " + gameState);
			return;
		}

		if (currentState != null) {
			if (currentState == state) {
				return;
			}
			
			currentState.active = false;
		}

		currentState = state;
		currentState.active = true;
	}

	public void SetStartClickListener (UnityAction listener) {
		startMenu.SetStartClickListener(listener);
	}

    public void UpdateLives(int lives) {
		currentState.UpdateLives(lives);
    }

	public void UpdateMoney(int money) {
		currentState.UpdateMoney(money);
    }

	public void UpdateBuildMenu(TurretsBuilder builder) {
		currentState.UpdateBuildMenu(builder);
    }
}