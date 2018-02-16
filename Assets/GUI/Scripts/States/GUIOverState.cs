using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIOverState : GUIState {

	private StartMenu startMenu;

	private string title = "Game Over";
	private string buttonText = "RESTART";

	public GUIOverState (StartMenu startMenu) {
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