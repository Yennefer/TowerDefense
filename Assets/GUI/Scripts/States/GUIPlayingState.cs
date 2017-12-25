using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIPlayingState : GUIState {
	private HUD headsUpDisplay;
	private CameraController cameraController;

	public GUIPlayingState (HUD headsUpDisplay, CameraController cameraController) {
    	this.headsUpDisplay = headsUpDisplay;
		this.cameraController = cameraController;
	}

	protected override void EnterState() {
		headsUpDisplay.gameObject.SetActive(true);
		cameraController.active = true;
	}

	protected override void ExitState() {
		headsUpDisplay.gameObject.SetActive(false);
		cameraController.active = false;
	}

	public override void UpdateLives(int lives) {
		headsUpDisplay.UpdateLives(lives);
	}

	public override void UpdateMoney(int money) {
		headsUpDisplay.UpdateMoney(money);
	}
}