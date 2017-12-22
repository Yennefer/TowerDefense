using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIPausedState : GUIState {

	public static GUIPausedState AddAsComponent(GameObject gameObject, StartMenu startMenu, HUD headsUpDisplay) {
    	GUIPausedState state = gameObject.AddComponent<GUIPausedState>();
    	state.Init(startMenu, headsUpDisplay);
    	return state;
	}
	
	public override void InitGUI() {
		headsUpDisplay.gameObject.SetActive(false);

		startMenu.gameObject.SetActive(false);
	}

	public override void UpdateInfo(int lives, int money) {

	}
}