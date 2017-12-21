using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	[SerializeField]
    private Text livesText;
    [SerializeField]
    private Text moneyText;

	private void Awake() {
        if (!livesText || !moneyText) {
			Debug.LogError("You've forgotten to set a parameter to HUD script");
		}
    }

	public void UpdateInfo(int lives, int money) {
		livesText.text = "Lives: " + lives;
		moneyText.text = "Money: " + money;
	}
}