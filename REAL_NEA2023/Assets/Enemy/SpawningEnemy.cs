using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefab;
    public float spawnHeight = 20f;
    public int minEnemies = 5;
    public int maxEnemies = 10;
    public float delay = 0.5f;
    public float scatterRange  = 70f;
    
    void Start() 
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        int enemyAmount = Random.Range(minEnemies,maxEnemies + 1);//random number of enemy/enemies
        for (int i=0; i< enemyAmount; i++) //a loop for each enemy spawn
        {
            for (int j=0; j< 2; j++) 
            {
                float randomX = Random.Range(-scatterRange, scatterRange); //gets a random x position for the enemy to spawn
                float randomZ = Random.Range(-scatterRange, scatterRange); //gets a random z position for the enemy to spawn

                Vector3 spawnPosition = new Vector3(randomX, spawnHeight, randomZ); //gets a random spawn position
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity); // "spawns" the enemy into the scene.
            }
            yield return new WaitForSeconds(delay); //0.5 second delay
        }
    }
//next i need to set a radius around the player that keeps updating, used so that enemies wont spawn that close to the player.

}
