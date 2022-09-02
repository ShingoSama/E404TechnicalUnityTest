using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> ObjectSpawn;
    private float nextSpawnTime;
    private int totalObjectSpawn;
    private float totalRate;
    private GameObject objectSpawn;
    private DataDifficulty dataDifficulty;
    [SerializeField]
    private Transform spawnTransform;
    [SerializeField]
    private float minX;
    [SerializeField] 
    private float maxX;
    [SerializeField] 
    private float minY;
    [SerializeField]
    private float maxY;
    [SerializeField]
    private int coinsToSpawn;
    private int coinsToSpawnLeft;
    public void StartSpawner()
    {
        totalObjectSpawn = Random.Range(dataDifficulty.MinObjectSpawn, dataDifficulty.MaxObjectSpawn);
        for (int i = 0; i < totalObjectSpawn; i++)
        {
            objectSpawn = GetRandomObjectSpawn();
        }
        nextSpawnTime = Random.Range(dataDifficulty.MinTimeSpawn, dataDifficulty.MaxTimeSpawn);
        Invoke("UpdateSpawner", nextSpawnTime);
    }
    public void UpdateSpawner()
    {
        if (GameManager.instance.GetPlayingState())
        {
            totalObjectSpawn = Random.Range(dataDifficulty.MinObjectSpawn, dataDifficulty.MaxObjectSpawn);
            for (int i = 0; i < totalObjectSpawn; i++)
            {
                if (coinsToSpawnLeft > 0)
                {
                    coinsToSpawnLeft--;
                    objectSpawn = GetCoinObjectSpawn();
                }
                else
                {
                    objectSpawn = GetRandomObjectSpawn();
                }
                spawnTransform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0f);
                objectSpawn.transform.position = spawnTransform.position;
                Instantiate(objectSpawn);
            }
            nextSpawnTime = Random.Range(dataDifficulty.MinTimeSpawn, dataDifficulty.MaxTimeSpawn);
            Invoke("UpdateSpawner", nextSpawnTime);
        }
    }
    public void StopSpawner()
    {
        CancelInvoke();
    }
    public void SetDataDifficulty(DataDifficulty data)
    {
        dataDifficulty = data;
    }
    private GameObject GetRandomObjectSpawn()
    {
        GetTotalRate();
        float rateSpawn = Random.Range(0, totalRate);
        foreach (ObjectSpawnerRate item in dataDifficulty.Object)
        {
            if (item.spawnRate >= rateSpawn)
            {
                return item.objectSpawn;
            }
            rateSpawn -= item.spawnRate;
        }
        return null;
    }
    private GameObject GetCoinObjectSpawn()
    {
        foreach (ObjectSpawnerRate item in dataDifficulty.Object)
        {
            if (item.objectSpawnType == ObjectSpawnerRate.ObjectSpawnType.Coin)
            {
                return item.objectSpawn;
            }
        }
        return null;
    }
    private void GetTotalRate()
    {
        totalRate = 0;
        foreach (ObjectSpawnerRate item in dataDifficulty.Object)
        {
            totalRate += item.spawnRate;
        }
    }
    public void SpawnCoinsInitialize()
    {
        coinsToSpawnLeft = coinsToSpawn;
    }
}
