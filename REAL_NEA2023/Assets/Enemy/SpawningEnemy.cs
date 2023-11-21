using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Spawning enemies")]
    public GameObject enemyPrefab;
    public float spawnHeight = 10f;
    private int minEnemies = 5;
    private int maxEnemies = 10;
    public float delay = 0.1f; // delay caused  the loop to instatiate too slowly, may have caused bugs.
    public float scatterRange  = 70f;

    [Header("Wave Mangement")]
    public int waveCount = 0;
    public int amountCheck;
    
    void Start() 
    {
        amountCheck = 0;
    }  

    void Update()
    {
        if (amountCheck == 0)
        {
            StartCoroutine(SpawnEnemies(amountCheck));
            waveCount++;
        }
    }
    IEnumerator SpawnEnemies(int x)
    {   
        if (x == 0)
        {
            int enemyAmount = Random.Range(minEnemies,maxEnemies + 1);//random number of enemy/enemies
            amountCheck = enemyAmount;
            Debug.Log(amountCheck);
            for (int i=0; i < amountCheck; i++) //a loop for each enemy spawn
            {
                float randomX = Random.Range(-scatterRange, scatterRange); //gets a random x position for the enemy to spawn
                float randomZ = Random.Range(-scatterRange, scatterRange); //gets a random z position for the enemy to spawn

                Vector3 spawnPosition = new Vector3(randomX, spawnHeight, randomZ); //gets a random spawn position
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity); // "spawns" the enemy into the scene.
                yield return new WaitForSeconds(delay); //0.1 second delay
            } 
        }
        
    }


}
