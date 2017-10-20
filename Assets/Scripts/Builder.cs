using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Builder : MonoBehaviour {

	[SerializeField]
	private GameObject[] prefabsToBuild;

	private UnityAction onPrefabSelected;
	
	public void Awake() {
		onPrefabSelected = BuildPrefab;
	}

	public void OnMouseDown () {
		Debug.Log("Clicked on " + gameObject.name);

		EventManager.RegisterListener("", onPrefabSelected);
	}

	private BuildPrefab() {

	}
}
