using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newDifficultyData", menuName = "Data/DifficultyData/Base Data")]
public class DataDifficulty : ScriptableObject
{
    public enum diffyculty
    {
        Easy,
        Medium,
        Hard
    }
    public diffyculty Diffyculty;
    public List<ObjectSpawnerRate> Object;
    public float MinTimeSpawn;
    public float MaxTimeSpawn;
    public int MinObjectSpawn;
    public int MaxObjectSpawn;
}
