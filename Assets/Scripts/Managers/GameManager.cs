using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private EnemySpawner spawner;
    [SerializeField]
    private int startLives = 100;
    [SerializeField]
    private int startMoney = 50;

    private int _lives;
    private int _money;
    private static GameManager gameManager;

	public static GameManager instance {
		get {
			if (gameManager == null) {
				gameManager = FindObjectOfType<GameManager>();

				if (gameManager == null) {
					Debug.LogError ("There needs to be one GameManager script on a GameObject in your scene");
				}
			}
			return gameManager;
		}
	}

    public int lives {
        get { return _lives; }
        set { 
            _lives = value;
            if (_lives <= 0) {
                EndGame();
            } else {
                GUIManager.instance.UpdateInfo(lives, money);
            }
        }
    }

    public int money {
        get { return _money; }
        set { 
            _money = value;
            GUIManager.instance.UpdateInfo(lives, money);
        }  
    }
	
    private void Awake() {
        if (!spawner) {
			Debug.LogError("You've forgotten to set a parameter to GameManager script");
		}

        GUIManager.instance.SetStartClickListener(StartGame);
        GUIManager.instance.SetState(GameState.Starting);
    }

    private void StartGame() {
        lives = startLives;
        money = startMoney;

        GUIManager.instance.SetState(GameState.Playing);
        GUIManager.instance.UpdateInfo(lives, money);

        spawner.StartSpawn();
    }

    private void EndGame() {
        spawner.StopSpawn();

        GUIManager.instance.SetState(GameState.Over);
    }
}