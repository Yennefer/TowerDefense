using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private GameMenu gameMenu;
    [SerializeField]
    private HUD headsUpDisplay;
    [SerializeField]
    private EnemySpawner spawner;
    [SerializeField]
    private int lives = 100;
    [SerializeField]
    private int money = 50;
	
    private void Awake() {
        if (!gameMenu || !spawner || !headsUpDisplay) {
			Debug.LogError("You've forgotten to set a parameter to GameManager script");
            return;
		}

        gameMenu.SetStartListener(StartGame);
    }

    private void StartGame() {
        gameMenu.gameObject.SetActive(false);

        headsUpDisplay.gameObject.SetActive(true);
        UpdateHUB();

        spawner.StartSpawn();
    }

    private void UpdateHUB() {
        headsUpDisplay.UpdateInfo(lives, money);
    }
}