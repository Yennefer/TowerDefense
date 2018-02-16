using System.Collections.Generic;
using UnityEngine;
using EventsSystem;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private EnemySpawner spawner;
    [SerializeField]
    private Transform builders;
    [SerializeField]
    private int startLives = 100;
    [SerializeField]
    private int startMoney = 50;

    private GameState currentState = GameState.STARTING;
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
                GUIManager.instance.UpdateLives(lives);
            }
        }
    }

    public int money {
        get { return _money; }
        set { 
            _money = value;
            GUIManager.instance.UpdateMoney(money);
        }  
    }

    private void Awake() {
        if (!spawner || !builders) {
			Debug.LogError("You've forgotten to set a parameter to GameManager script");
		}

        GUIManager.instance.SetStartClickListener(StartGame);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            PauseGame();
        }
    }

    public void SelectTurretToBuild(TurretsBuilder builder) {
        SetState(GameState.IN_BUILD_MENU);
        GUIManager.instance.UpdateMoney(money);
        GUIManager.instance.UpdateBuildMenu(builder);
        EventManager.RegisterListener(Events.closeBuildMenu.ToString() + builder.id, TurretToBuildSelected);
    }

    private void TurretToBuildSelected(EventObject eo) {
        string builderId = eo.getStringData(EventDataTags.BUILDER_ID);
        int spentMoney = eo.getIntData(EventDataTags.TURRET_PRICE);
        EventManager.UnregisterListener(Events.closeBuildMenu.ToString() + builderId, TurretToBuildSelected);

        money -= spentMoney;
        SetState(GameState.PLAYING);
    }

    private void StartGame() {
        SetState(GameState.PLAYING);

        lives = startLives;
        money = startMoney;

        InitGameObjects();
    }

    private void EndGame() {
        spawner.StopSpawn();

        SetState(GameState.OVER);
    }

    private void SetState(GameState state) {
        if (!CanChangeState(currentState, state)) {
            return;
        }

        currentState = state;
        GUIManager.instance.SetState(state);
    }

    private void InitGameObjects() {
        spawner.StartSpawn();
        foreach(Transform builder in builders) {
            builder.GetComponent<TurretsBuilder>().Init();
        }
    }

    private void PauseGame() {
        if (currentState == GameState.PAUSED) {
            SetState(GameState.PLAYING);
            Time.timeScale = 1;
        } else if (CanChangeState(currentState, GameState.PAUSED)) {
            SetState(GameState.PAUSED);
            Time.timeScale = 0;
        }
    }

    private bool CanChangeState(GameState from, GameState to) {
        switch (from) {
            case GameState.STARTING: {
                return (to == GameState.PLAYING);
            }
            case GameState.PLAYING: {
                return (to == GameState.PAUSED) || (to == GameState.IN_BUILD_MENU) || (to == GameState.OVER);
            }
            case GameState.PAUSED: {
                return (to == GameState.PLAYING);
            }
            case GameState.IN_BUILD_MENU: {
                return (to == GameState.PLAYING);
            }
            case GameState.OVER: {
                return (to == GameState.PLAYING);
            }
        }
        return false;
    }
}