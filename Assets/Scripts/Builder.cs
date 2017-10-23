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

	private UnityAction prefabBuildListener;
	
	public void Awake() {
		prefabBuildListener = BuildPrefab;
	}

	public void OnEnable() {
		EventManager.RegisterListener(Events.buildPrefub.ToString(), prefabBuildListener);
	}

	public void OnDisable() {
		EventManager.UnregisterListener(Events.buildPrefub.ToString(), prefabBuildListener);
	}

	public void OnMouseDown () {
		EventManager.TriggerEvent(Events.selectPrefub.ToString());
	}

	private void BuildPrefab() {
		Instantiate(prefabsToBuild[0], transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
