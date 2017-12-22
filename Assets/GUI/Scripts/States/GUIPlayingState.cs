using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIPlayingState : GUIState {

	public static GUIPlayingState AddAsComponent(GameObject gameObject, StartMenu startMenu, HUD headsUpDisplay) {
    	GUIPlayingState state = gameObject.AddComponent<GUIPlayingState>();
    	state.Init(startMenu, headsUpDisplay);
    	return state;
	}

	public override void InitGUI() {
		headsUpDisplay.gameObject.SetActive(true);

		startMenu.gameObject.SetActive(false);
	}

	public override void UpdateInfo(int lives, int money) {
		headsUpDisplay.UpdateInfo(lives, money);
	}
}