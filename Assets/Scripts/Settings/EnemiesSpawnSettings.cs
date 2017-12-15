using System;
using System.Collections.Generic;
using UnityEngine;

namespace Settings {
    
    [CreateAssetMenu(fileName = "EnemiesSpawn", menuName = "Settings/Enemies spawn", order = 0)]
    public class EnemiesSpawnSettings : ScriptableObject {
        public GameObject enemy;
        public List<Wave> waves;
    }

    [Serializable]
    public class Wave
    {
        public float timeBeforeWave;
        public float timeBetweenEnemies;
        public int enemyCount;
    }
}