using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public float destructibleTime = 1f;

    [Range(0f, 1f)]
    public float itemSpawnChance = 0.2f;
    public GameObject[] spawnableItems;

    private void Start()
    {
        Destroy(gameObject, destructibleTime);
    }

    private void OnDestroy()
    {
        if(spawnableItems.Length > 0 && Random.value > itemSpawnChance)
        {
            int randomIndex = Random.RandomRange(0, spawnableItems.Length);
            Instantiate(spawnableItems[randomIndex], transform.position, Quaternion.identity);
        }
    }
}
