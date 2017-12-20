using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour {

	[SerializeField]
	private Button startButton;

	private void Awake () {
		if (!startButton) {
			Debug.LogError("You've forgotten to set a parameter to GameMenu script");
		}
	}
	
	public void SetStartListener (UnityAction listener) {
		startButton.onClick.AddListener(listener);
	}
}
