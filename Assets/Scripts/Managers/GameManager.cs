using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private GameMenu gameMenu;
    [SerializeField]
    private EnemySpawner spawner;
	
    private void Awake() {
        if (!gameMenu || !spawner) {
			Debug.LogError("You've forgotten to set a parameter to GameManager script");
            return;
		}

        gameMenu.SetStartListener(StartGame);
    }

    private void StartGame() {
        gameMenu.gameObject.SetActive(false);
        spawner.StartSpawn();
    }
}