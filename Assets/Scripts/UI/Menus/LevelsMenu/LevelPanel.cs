using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPanel : MonoBehaviour
{

    [SerializeField]
    private Text levelNumber;

    public Enums.Scene sceneName {set; get;}

    public void Init(LevelSettings levelSettings, int level)
    {
        levelNumber.text = "Level " + level.ToString();
        sceneName = levelSettings.levelScene;
        Debug.Log("Level N" + level + ": scene: " + sceneName + ", waves:");
        foreach (LevelSettings.Wave wave in levelSettings.waves)
        {
            Debug.Log("   Enemy count:" + wave.enemyCount);
        }

        Button b = gameObject.GetComponent<Button>();
        b.onClick.AddListener(StartLevel);
    }

    private void StartLevel() {
        EventManager.TriggerEvent(Events.selectLevel.ToString(), gameObject);
    }
}