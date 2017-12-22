using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIState {
	private bool _active = false;

	public bool active {
		get { return _active; }
		set {
			if (_active == value) {
				return;
			}

			_active = value;
			if (_active) {
				EnterState();
			} else {
				ExitState();
			}
		}
	}

	public virtual void Update() {
	}

    protected virtual void EnterState() {
	}

	protected virtual void ExitState() {
	}

	public virtual void UpdateLives(int lives) {
	}

	public virtual void UpdateMoney(int money) {
	}

	public virtual void UpdateBuildMenu(TurretsBuilder builder) {
	}
}