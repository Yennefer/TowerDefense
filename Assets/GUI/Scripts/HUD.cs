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

	public void UpdateLives(int lives) {
		livesText.text = "Lives: " + lives;
	}

	public void UpdateMoney(int money) {
		moneyText.text = "Money: " + money;
	}
}