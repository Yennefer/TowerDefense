using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GUIManager : MonoBehaviour {

	[SerializeField]
    private StartMenu startMenu;
    [SerializeField]
    private HUD headsUpDisplay;

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
        if (!startMenu || !headsUpDisplay) {
			Debug.LogError("You've forgotten to set a parameter to GUIManager script");
            return;
		}
        
		PopulateGUIStates();
    }

	private void PopulateGUIStates() {
		states = new Dictionary<GameState, GUIState>();
		states.Add(GameState.Starting, GUIStartingState.AddAsComponent(gameObject, startMenu, headsUpDisplay));
		states.Add(GameState.Playing, GUIPlayingState.AddAsComponent(gameObject, startMenu, headsUpDisplay));
		states.Add(GameState.Paused, GUIPausedState.AddAsComponent(gameObject, startMenu, headsUpDisplay));
		states.Add(GameState.Over, GUIOverState.AddAsComponent(gameObject, startMenu, headsUpDisplay));
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
			
			currentState.enabled = false;
		}

		currentState = state;
		currentState.enabled = true;
		currentState.InitGUI();
	}

	public void SetStartClickListener (UnityAction listener) {
		startMenu.SetStartClickListener(listener);
	}

    public void UpdateInfo(int lives, int money) {
		currentState.UpdateInfo(lives, money);
    }
}