using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour {

	[SerializeField]
	private Button startButton;
	[SerializeField]
	private Text title;
	[SerializeField]
	private Text startButtonName;

	private void Awake () {
		if (!startButton || !startButtonName || !title) {
			Debug.LogError("You've forgotten to set a parameter to GameMenu script");
		}
	}
	
	public void SetStartClickListener (UnityAction listener) {
		startButton.onClick.AddListener(listener);
	}

	public void SetButtonName(string s) {
		startButtonName.text = s;
	}

	public void SetTitle(string s) {
		title.text = s;
	}
}
