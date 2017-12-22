using System.Collections.Generic;
using UnityEngine;
using Settings;
using EventsSystem;

public class TurretsBuilder : MonoBehaviour {

	[SerializeField]
	private TurretsSettings turretsSettings;

	private string _id = System.Guid.NewGuid().ToString();
	private List<PrefabInfo> _turrets = new List<PrefabInfo>();
	private MeshRenderer mr;

	public string id { 
		get { return _id; }
	}

	public List<PrefabInfo> turrets { 
		get { return _turrets; }
	}

	private void Awake() {
		mr = GetComponent<MeshRenderer>();

		if (!mr) {
			Debug.LogError("Object with TurretsBuilder script should have a MeshRenderer component");
			return;
		} else if (!turretsSettings) {
			Debug.LogError("You've forgotten to set a parameter to TurretsBuilder script");
			return;
		}

		ParseSettings();
	}

	public void Init() {
		SetVisible(true);
		foreach(Transform child in transform) {
    		Destroy(child.gameObject);
		}
	}

	private void OnEnable() {
		EventManager.RegisterListener(Events.buildPrefub.ToString() + id, BuildTurret);
	}

	private void OnDisable() {
		EventManager.UnregisterListener(Events.buildPrefub.ToString() + id, BuildTurret);
	}

	private void OnMouseDown () {
		GameManager.instance.SelectTurretToBuild(this);
	}

	private void ParseSettings() {
		foreach (PrefabInfo turretPrefab in turretsSettings.prefabs) {
			_turrets.Add( turretPrefab );
		}
	}

	private void BuildTurret(EventObject eo) {
		GameObject turretPrefab = (GameObject) eo.getObjectData(EventDataTags.TURRET_TO_BUILD);
		Vector3 turretPos = transform.position;
		turretPos.y = 0;
		GameObject turret = Instantiate(turretPrefab, turretPos, transform.rotation);
		turret.transform.SetParent(this.transform);

		InitTurret(turret);
		SetVisible(false);
	}

	private void InitTurret(GameObject turret) {
		turret.GetComponentInChildren<BaseTurret>().Init(turretsSettings);
	}

	private void SetVisible(bool visibility) {
		mr.enabled = visibility;
	}
}