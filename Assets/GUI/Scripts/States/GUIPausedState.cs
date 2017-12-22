using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIPausedState : GUIState {
    private PauseScreen pauseScreen;
    
    public GUIPausedState(PauseScreen pauseScreen) {
        this.pauseScreen = pauseScreen;
    }

    protected override void EnterState() {
        pauseScreen.gameObject.SetActive(true);
	}

	protected override void ExitState() {
        pauseScreen.gameObject.SetActive(false);
	}
}