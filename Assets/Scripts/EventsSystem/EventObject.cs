using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventObject : Object {

	private Dictionary<string, int> intData = new Dictionary<string, int>();
	private Dictionary<string, string> stringData = new Dictionary<string, string>();
	private Dictionary<string, Object> objectData = new Dictionary<string, Object>();
	private Dictionary<string, GameObject> gameObjectData = new Dictionary<string, GameObject>();

	public void putData(string tag, int data) {
		intData.Add(tag, data);
	}

	public void putData(string tag, string data) {
		stringData.Add(tag, data);
	}

	public void putData(string tag, Object data) {
		objectData.Add(tag, data);
	}

	public void putData(string tag, GameObject data) {
		gameObjectData.Add(tag, data);
	}

	public int getIntData(string tag) {
		return intData[tag];
	}

	public string getStringData(string tag) {
		return stringData[tag];
	}

	public Object getObjectData(string tag) {
		return objectData[tag];
	}

	public GameObject getGameObjectData(string tag) {
		return gameObjectData[tag];
	}
}
