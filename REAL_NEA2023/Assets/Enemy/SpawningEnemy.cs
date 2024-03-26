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

    [Header("More Enemies")]
    public GameObject enemyPrefabTwo; // big enemies
    public GameObject enemyPrefabThree; // fast enemies
    public GameObject spawnPrefab;
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
            spawnPrefab = null;
            int enemyAmount = Random.Range(minEnemies,maxEnemies + 1);//random number of enemy/enemies
            amountCheck = enemyAmount;
            Debug.Log(amountCheck);
            for (int i=0; i < amountCheck; i++) //a loop for each enemy spawn
            {
                float randomX = Random.Range(-scatterRange, scatterRange); //gets a random x position for the enemy to spawn
                float randomZ = Random.Range(-scatterRange, scatterRange); //gets a random z position for the enemy to spawn

                Vector3 spawnPosition = new Vector3(randomX, spawnHeight, randomZ); //gets a random spawn position
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity); // "spawns" the enemy into the scene.
             
            } 
            if (waveCount >= 4)
            {
                float chooseAtRandom = Random.Range(0,10);
                if (chooseAtRandom % 2 != 0)
                {
                    spawnPrefab = enemyPrefabTwo;
                }else{
                    spawnPrefab = enemyPrefabThree;
                }

                int enemyAmountTwo = Random.Range(0,5);
                amountCheck += enemyAmountTwo;
                for (int j=0; j < enemyAmountTwo; j++) 
                {
                    float randomX = Random.Range(-scatterRange, scatterRange); //gets a random x position for the enemy to spawn
                    float randomZ = Random.Range(-scatterRange, scatterRange); //gets a random z position for the enemy to spawn
                    
                    Vector3 spawnPositionTwo = new Vector3(randomX, spawnHeight, randomZ); //gets a random spawn position
                    Instantiate(spawnPrefab, spawnPositionTwo, Quaternion.identity); // "spawns" the enemy into the scene.
                }
            }
        yield return new WaitForSeconds(delay); //0.1 second delay
          
        }
    }


}
