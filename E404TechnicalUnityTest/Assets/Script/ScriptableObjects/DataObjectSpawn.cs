using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newObjectSpawnData", menuName = "Data/ObjectSpawnData/Base Data")]
public class ObjectSpawn : ScriptableObject
{
    public int maxHealth;
    public int pointsWin;
    public int pointsLose;
}