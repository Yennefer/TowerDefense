using System.Collections.Generic;
using UnityEngine;

namespace EventsSystem {
	public class EventObject : Object {

		private Dictionary<string, object> data = new Dictionary<string, object>();

		public void putData(string tag, int data) {
			this.data.Add(tag, data);
		}

		public void putData(string tag, string data) {
			this.data.Add(tag, data);
		}

		public void putData(string tag, Object data) {
			this.data.Add(tag, data);
		}

		public int getIntData(string tag) {
			return (int) data[tag];
		}

		public string getStringData(string tag) {
			return (string) data[tag];
		}

		public Object getObjectData(string tag) {
			return (Object) data[tag];
		}
	}
}
