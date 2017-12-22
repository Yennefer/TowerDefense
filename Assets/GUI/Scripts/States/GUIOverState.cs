using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIOverState : GUIState {

	private string title = "Game Over";
	private string buttonText = "RESTART";

	public static GUIOverState AddAsComponent(GameObject gameObject, StartMenu startMenu, HUD headsUpDisplay) {
    	GUIOverState state = gameObject.AddComponent<GUIOverState>();
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