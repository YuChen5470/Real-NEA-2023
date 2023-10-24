using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 5.0f;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-40,40),1,Random.Range(-40,40));

            Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}

/*
if (Input.GetKeyDown(KeyCode.Space))
        {      
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-40,41),1,Random.Range(-40,41));
        Instantiate(EnemyPrefab,randomSpawnPosition,Quaternion.identity);
        } 
*/
