using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Transform> spawnPositions;
    public int  spawnDelay;
    public GameObject spawnObject;
    public GameObject player;

    public bool enemySpawner;
    void Start()
    {
        StartCoroutine(SpawnEnemiesWithDelay());
    }

    IEnumerator SpawnEnemiesWithDelay()
    {
        while (true)
        {
            var position = Random.Range(0, spawnPositions.Count);
            var newEnemy = Instantiate(spawnObject, spawnPositions[position].transform.position , Quaternion.identity);

            newEnemy.GetComponent<EnemyMovement>().SetPlayer(player);//olmasý gereken

            yield return new WaitForSeconds(spawnDelay);
        };
    }
}
