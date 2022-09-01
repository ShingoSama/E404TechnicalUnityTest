using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnHandler : MonoBehaviour
{
    public DataObjectSpawn objectValues;
    private int currentHealth;
    private void Awake()
    {
        currentHealth = objectValues.maxHealth;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        Debug.Log("Click");
        currentHealth--;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
