using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIState : MonoBehaviour {

	protected StartMenu startMenu; 
	protected HUD headsUpDisplay;

	protected void Init(StartMenu startMenu, HUD headsUpDisplay) {
		this.startMenu = startMenu;
		this.headsUpDisplay = headsUpDisplay;
		enabled = false;
	}

    public virtual void InitGUI() {
	}

	public virtual void UpdateInfo(int lives, int money) {
	}
}