using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Settings;

/*
	Builder instantiate object from `turretsSettings`
	when prefub is selected from a menu
 */
public class TurretsBuilder : MonoBehaviour {

	[SerializeField]
	private TurretsSettings turretsSettings;

	private string id = System.Guid.NewGuid().ToString();
	private List<GameObject> turretPrefabs = new List<GameObject>();

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
		turretPrefabs.AddRange( turretsSettings.prefabs );
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

	public string GetId() {
		return id;
	}

	public List<GameObject> GetTurretPrefabs() {
		return turretPrefabs;
	}
}