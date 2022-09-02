using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newObjectSpawnRateData", menuName = "Data/SpawnRateData/Base Data")]
public class ObjectSpawnerRate : ScriptableObject
{
    public enum ObjectSpawnType
    {
        Coin,
        Block,
        Box,
        Shield,
        Sphere,
        Target
    }
    public ObjectSpawnType objectSpawnType;
    public float spawnRate;
    public GameObject objectSpawn;
}
