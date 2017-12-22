using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIStartingState : GUIState {

	private string title = "Asteroid Defense";
	private string buttonText = "START";

	public static GUIStartingState AddAsComponent(GameObject gameObject, StartMenu startMenu, HUD headsUpDisplay) {
    	GUIStartingState state = gameObject.AddComponent<GUIStartingState>();
    	state.Init(startMenu, headsUpDisplay);
    	return state;
	}

	public override void InitGUI() {
		headsUpDisplay.gameObject.SetActive(false);

		startMenu.SetButtonName(buttonText);
		startMenu.SetTitle(title);
		startMenu.gameObject.SetActive(true);
	}

	public override void UpdateInfo(int lives, int money) {

	}
}