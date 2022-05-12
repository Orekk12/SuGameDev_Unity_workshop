using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAreaSpawn: MonoBehaviour
{
    public float xSize = 11f;
    public float ySize = 5f;
    public float spawnInterval = 7f;
    public GameObject spawnPrefab;

    Vector2 PickPointInArea()
    {
        float xVal = Random.Range(-xSize, xSize);
        float yVal = Random.Range(-ySize, ySize);

        return new Vector2(xVal, yVal);
    }

    void SpawnPickup()
    {
        Vector2 spawnPos = PickPointInArea();

        Instantiate(spawnPrefab, spawnPos, spawnPrefab.transform.rotation);
    }

    private void Start()
    {
        InvokeRepeating("SpawnPickup", 3f, spawnInterval);
    }
}
