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
    private int _lives = 100;
    [SerializeField]
    private int _money = 50;

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
            UpdateHUB();
        }
    }

    public int money {
        get { return _money; }
        set { 
            _money = value;
            UpdateHUB();
        }  
    }
	
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