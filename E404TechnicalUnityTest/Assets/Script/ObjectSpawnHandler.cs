using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnHandler : MonoBehaviour
{
    [SerializeField]
    private AudioSource clickSound;
    public DataObjectSpawn objectValues;
    private int currentHealth;
    private float timeToDestroy;
    private void Awake()
    {
        currentHealth = objectValues.maxHealth;
        timeToDestroy = Time.time + 5f;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeToDestroy && GameManager.instance.GetPlayingState())
        {
            GameManager.instance.AddScore(objectValues.pointsLose);
            Destroy(gameObject);
        }
        if (!GameManager.instance.GetPlayingState())
        {
            Destroy(gameObject);
        }
    }
    private void OnMouseDown()
    {
        clickSound.Play();
        currentHealth--;
        if (currentHealth <= 0)
        {
            if (objectValues.objectSpawnType == ObjectSpawnerRate.ObjectSpawnType.Target)
            {
                GameManager.instance.SpawnCoins();
            }
            GameManager.instance.AddScore(objectValues.pointsWin);
            Destroy(gameObject);
        }
    }
}