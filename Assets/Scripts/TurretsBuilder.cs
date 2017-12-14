using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
	Builder instantiate object from "prefabsToBuild" array
	when prefub is selected from a menu
 */
public class TurretsBuilder : MonoBehaviour {

	[SerializeField]
	private GameObject[] turretsToBuild;

	private UnityAction<EventObject> turretBuildListener;

	private string id = System.Guid.NewGuid().ToString();

	private void Awake() {
		turretBuildListener = BuildTurret;
	}

	private void OnEnable() {
		EventManager.RegisterListener(Events.buildPrefub.ToString() + id, turretBuildListener);
	}

	private void OnDisable() {
		EventManager.UnregisterListener(Events.buildPrefub.ToString() + id, turretBuildListener);
	}

	private void OnMouseDown () {
		EventObject selectTurretEvent = new EventObject();
        selectTurretEvent.putData(EventDataTags.TURREUT_BUILDER_TAG, gameObject);
		EventManager.TriggerEvent(Events.selectPrefub.ToString(), selectTurretEvent);
	}

	public void Init(TurretSettings settings) {
		foreach (GameObject prefab in turretsToBuild) {
			prefab.GetComponent<BaseTurret>().Init(settings);
		}
	}

	public GameObject[] GetTurretsToBuild() {
		return turretsToBuild;
	}

	public string GetId() {
		return id;
	}

	private void BuildTurret(EventObject prefabEvent) {
		GameObject turretToBuild = prefabEvent.getGameObjectData(EventDataTags.PREFAB_TO_BUILD_TAG);
		Instantiate(turretToBuild, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}