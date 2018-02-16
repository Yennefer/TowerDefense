using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIStartingState : GUIState {

	private StartMenu startMenu;

	private string title = "Asteroid Defense";
	private string buttonText = "START";

	public GUIStartingState (StartMenu startMenu) {
    	this.startMenu = startMenu;
	}

	protected override void EnterState() {
		startMenu.SetButtonName(buttonText);
		startMenu.SetTitle(title);

		startMenu.gameObject.SetActive(true);
	}

	protected override void ExitState() {
		startMenu.gameObject.SetActive(false);
	}
}