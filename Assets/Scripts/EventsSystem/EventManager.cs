using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
	EventManager can invoke events and register listener for this events 
 */
public class EventManager : MonoBehaviour {

	private Dictionary<string, UnityEvent> eventDictionary;
	private static EventManager eventManager;

	protected EventManager() {}
	
	public static EventManager instance {
		get {
			if (!eventManager) {
				eventManager = (EventManager) FindObjectOfType (typeof (EventManager));

				if (eventManager != null) {
					Debug.LogError ("There needs to be one active EventManager script on a GameObject in your scene.");
				} else {
					eventManager.Init();
				}
			}
			return eventManager;
		}
	}

	private void Init() {
		if (eventDictionary == null) {
			eventDictionary = new Dictionary<string, UnityEvent>();
		}
	}

	public static void RegisterListener (string eventName, UnityAction listener) {
		UnityEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent)) {
			thisEvent.AddListener(listener);
		} else {
			thisEvent = new UnityEvent();
			thisEvent.AddListener(listener);
			instance.eventDictionary.Add(eventName, thisEvent);
		}
	}

	public static void UnregisterListener (string eventName, UnityAction listener) {
		if (eventManager == null) {
			return;
		}

		UnityEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent)) {
			thisEvent.RemoveListener(listener);
		}
	}

	public static void TriggerEvent(string eventName) {
		UnityEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent)) {
			thisEvent.Invoke();
		}
	}
}
