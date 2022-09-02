using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectSpawnerRate;

[CreateAssetMenu(fileName = "newObjectSpawnData", menuName = "Data/ObjectSpawnData/Base Data")]
public class DataObjectSpawn : ScriptableObject
{
    public ObjectSpawnType objectSpawnType;
    public int maxHealth;
    public int pointsWin;
    public int pointsLose;
}