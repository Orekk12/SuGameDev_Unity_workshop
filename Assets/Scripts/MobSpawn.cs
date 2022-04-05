using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Transform> spawnPositions;
    public int  spawnDelay;
    public GameObject enemy;

    void Start()
    {
        StartCoroutine(SpawnEnemiesWithDelay());
    }

    IEnumerator SpawnEnemiesWithDelay()
    {
        while (true)
        {
            var position = Random.Range(0, spawnPositions.Count);
            var newEnemy = Instantiate(enemy, spawnPositions[position].transform.position , Quaternion.identity);
            yield return new WaitForSeconds(spawnDelay);
        };
    }
}
