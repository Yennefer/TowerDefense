using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
	Builder instantiate object from "prefabsToBuild" array
	when prefub is selected from a menu
 */
public class Builder : MonoBehaviour {

	[SerializeField]
	private GameObject[] prefabsToBuild;

	private UnityAction<GameObject> prefabBuildListener;

	private string id = System.Guid.NewGuid().ToString();

	public void Awake() {
		prefabBuildListener = BuildPrefab;
	}

	public void OnEnable() {
		EventManager.RegisterListener(Events.buildPrefub.ToString() + id, prefabBuildListener);
	}

	public void OnDisable() {
		EventManager.UnregisterListener(Events.buildPrefub.ToString() + id, prefabBuildListener);
	}

	public void OnMouseDown () {
		EventManager.TriggerEvent(Events.selectPrefub.ToString(), gameObject);
	}

	public GameObject[] GetPrefabsToBuild() {
		return prefabsToBuild;
	}

	public string GetId() {
		return id;
	}

	private void BuildPrefab(GameObject prefabToBuild) {
		Instantiate(prefabToBuild, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
