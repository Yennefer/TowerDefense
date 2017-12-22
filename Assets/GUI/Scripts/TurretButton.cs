using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Settings;

public class TurretButton : MonoBehaviour {

	private Text text;
	private GameObject _turretPrefab;
	private int _turretPrice;
	private string turretName;

	public GameObject turretPrefab {
		get { return _turretPrefab; }
		set { _turretPrefab = value; }
	}

	public int turretPrice {
		get { return _turretPrice; }
		set { _turretPrice = value; }
	}

	private void Awake() {
		text = this.gameObject.GetComponentInChildren<Text>();

		if (!text) {
			Debug.LogError("Object with TurretButton script should have a Text component on one of the children");
		}
	}

	public void Init(PrefabInfo turretInfo) {
		this.turretPrefab = turretInfo.prefab;
		this.turretName = turretInfo.name;
		this.turretPrice = turretInfo.price;

		text.text = turretName + " ($" + turretPrice + ")";
	}

	public void SetMoney(int money) {
		bool canBuyTurret = money >= turretPrice ? true : false;
		SetEnabled(canBuyTurret);
	}

	private void SetEnabled(bool enabled) {
		this.enabled = enabled;
		text.color = enabled ? Color.black : Color.gray;
	}
}
