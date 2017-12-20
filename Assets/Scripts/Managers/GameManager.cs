using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Settings;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private GameMenu gameMenu;
    [SerializeField]
    private EnemySpawner spawner;
	
    private List<Wave> waves;

    private void Awake() {
        if (!gameMenu || !spawner) {
			Debug.LogError("You've forgotten to set a parameter to GameManager script");
		}

        gameMenu.SetStartListener(StartGame);
    }

    private void StartGame() {
        gameMenu.gameObject.SetActive(false);
        spawner.StartSpawn();
    }
}