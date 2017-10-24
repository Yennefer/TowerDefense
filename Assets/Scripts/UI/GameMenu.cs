using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameMenu : MonoBehaviour {

	[SerializeField]
	private Button selectButton;

	private UnityAction builderListener;
	
	public void Awake() {
		selectButton.onClick.AddListener(SelectClick);
		builderListener = SelectPrefub;
	}

	public void OnEnable() {
		EventManager.RegisterListener(Events.selectPrefub.ToString(), builderListener);
	}

	public void OnDisable() {
		EventManager.UnregisterListener(Events.selectPrefub.ToString(), builderListener);
	}

	public void SelectClick () {
		selectButton.gameObject.SetActive(false);
		EventManager.TriggerEvent(Events.buildPrefub.ToString());
	}

	private void SelectPrefub() {
		selectButton.gameObject.SetActive(true);
	}
}
