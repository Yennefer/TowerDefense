using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPanel : MonoBehaviour
{

    [SerializeField]
    private Text levelNumber;

    public const string LEVEL_INDEX_TAG = "Level index";
    public Enums.Scene scene {set; get;}

    private int level;

    public void Init(LevelSettings levelSettings, int level)
    {
        levelNumber.text = "Level " + level.ToString();
        scene = levelSettings.levelScene;
        this.level = level;
        Debug.Log("Level N" + level + ": scene: " + scene + ", waves:");
        foreach (LevelSettings.Wave wave in levelSettings.waves)
        {
            Debug.Log("   Enemy count:" + wave.enemyCount);
        }

        Button b = gameObject.GetComponent<Button>();
        b.onClick.AddListener(StartLevel);
    }

    private void StartLevel() {
        EventObject initLevelEvent = new EventObject();
        initLevelEvent.putData(LEVEL_INDEX_TAG, level);
        EventManager.TriggerEvent(Events.selectLevel.ToString(), initLevelEvent);
    }
}