using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvent : UnityEvent<EventObject> {}

/*
	EventManager can invoke events and register listener for this events 
 */
public class EventManager : MonoBehaviour {

	private Dictionary<string, GameEvent> eventDictionary;
	private static EventManager eventManager;

	protected EventManager() {}
	
	public static EventManager instance {
		get {
			if (eventManager == null) {
				eventManager = (EventManager) FindObjectOfType (typeof (EventManager));

				if (eventManager == null) {
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
			eventDictionary = new Dictionary<string, GameEvent>();
		}
	}

	public static void RegisterListener (string eventName, UnityAction<EventObject> listener) {
		GameEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent)) {
			thisEvent.AddListener(listener);
		} else {
			thisEvent = new GameEvent();
			thisEvent.AddListener(listener);
			instance.eventDictionary.Add(eventName, thisEvent);
		}
	}

	public static void UnregisterListener (string eventName, UnityAction<EventObject> listener) {
		if (eventManager == null) {
			return;
		}

		GameEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent)) {
			thisEvent.RemoveListener(listener);
		}
	}

	public static void TriggerEvent(string eventName, EventObject message) {
		GameEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent)) {
			thisEvent.Invoke(message);
		}
	}
}