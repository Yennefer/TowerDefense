using System.Collections.Generic;
using UnityEngine;
using Settings;

public class TurretsBuilder : MonoBehaviour {

	[SerializeField]
	private TurretsSettings turretsSettings;

	private string _id = System.Guid.NewGuid().ToString();
	private List<GameObject> _turretPrefabs = new List<GameObject>();

	public string id { 
		get { return _id; }
	}

	public List<GameObject> turretPrefabs { 
		get { return _turretPrefabs; }
	}

	private void Awake() {
		if (!turretsSettings) {
			Debug.LogError("You've forgotten to set a parameter to TurretsBuilder script");
		}

		ParseSettings();
	}

	private void OnEnable() {
		EventManager.RegisterListener(Events.buildPrefub.ToString() + id, BuildTurret);
	}

	private void OnDisable() {
		EventManager.UnregisterListener(Events.buildPrefub.ToString() + id, BuildTurret);
	}

	private void OnMouseDown () {
		EventObject eo = new EventObject();
        eo.putData(EventDataTags.TURRET_BUILDER, this);
		EventManager.TriggerEvent(Events.selectPrefub.ToString(), eo);
	}

	public void ParseSettings() {
		_turretPrefabs.AddRange( turretsSettings.prefabs );
	}

	private void BuildTurret(EventObject eo) {
		GameObject turretToBuild = (GameObject) eo.getObjectData(EventDataTags.TURRET_TO_BUILD);
		GameObject turret = Instantiate(turretToBuild, transform.position, transform.rotation);
		InitTurret(turret);
		Destroy(gameObject);
	}

	public void InitTurret(GameObject prefab) {
		BaseTurret bt = prefab.GetComponentInChildren<BaseTurret>();
		bt.Init(turretsSettings);
	}
}