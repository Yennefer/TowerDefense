using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelsStructure", menuName = "Settings/Levels structure", order = 1)]
public class LevelsStructure : ScriptableObject {
    public List<Map> maps;

    [Serializable]
    public class Map
    {
        public Enums.Map scene;
        public List<LevelSettings> levels;
    }
}