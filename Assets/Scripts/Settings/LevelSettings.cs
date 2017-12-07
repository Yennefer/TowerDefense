using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSettings", menuName = "Settings/Level", order = 2)]
public class LevelSettings : ScriptableObject {
    public Enums.Scene levelScene;
    public List<Wave> waves;

    [Serializable]
    public class Wave
    {
        public int enemyCount;
    }
}