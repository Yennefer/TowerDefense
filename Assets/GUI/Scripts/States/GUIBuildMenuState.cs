using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIBuildMenuState : GUIState {
    private BuildMenu buildMenu;
    private HUD headsUpDisplay;
    
    public GUIBuildMenuState(BuildMenu buildMenu, HUD headsUpDisplay) {
        this.buildMenu = buildMenu;
        this.headsUpDisplay = headsUpDisplay;
    }

    protected override void EnterState() {
        buildMenu.gameObject.SetActive(true);
        headsUpDisplay.gameObject.SetActive(true);
	}

	protected override void ExitState() {
        buildMenu.gameObject.SetActive(false);
        headsUpDisplay.gameObject.SetActive(false);
	}

    public override void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            buildMenu.Close();
        }
    }

    public override void UpdateMoney(int money) {
        buildMenu.UpdateMoney(money);
        headsUpDisplay.UpdateMoney(money);
	}

    public override void UpdateBuildMenu(TurretsBuilder builder) {
        buildMenu.SelectPrefub(builder);
	}
}