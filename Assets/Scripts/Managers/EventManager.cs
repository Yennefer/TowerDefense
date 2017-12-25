using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EventsSystem {
	public class GameEvent : UnityEvent<EventObject> {}

	public class EventManager : MonoBehaviour {

		private Dictionary<string, GameEvent> eventDictionary;
		private static EventManager eventManager;

		private static EventManager instance {
			get {
				if (eventManager == null) {
					eventManager = FindObjectOfType<EventManager>();

					if (eventManager == null) {
						Debug.LogError ("There needs to be one EventManager script on a GameObject in your scene");
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
}