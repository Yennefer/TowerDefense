using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelsMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject levelsPanel;

    [SerializeField]
    private Button level;

    public void Init(List<LevelSettings> levelsSettings)
    {
        
        for (int i = 0; i <= levelsSettings.Count - 1; i++)
        {
            Button levelInstance = Instantiate(level, levelsPanel.transform);
            levelInstance.GetComponent<LevelPanel>().Init(levelsSettings[i], i + 1);
        }
    }
}