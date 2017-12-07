using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Settings/Game Settings", order = 0)]
public class GameSettings : ScriptableObject {

    public List<LevelSettings> levels;
    public TurretSettings turrets;
}