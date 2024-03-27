using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Spawning enemies")]
    public GameObject enemyPrefab; // references the object enemyprefab
    public float spawnHeight = 10f; // height which the enemy spawns at
    private int minEnemies = 5; // minimum number of enemies
    private int maxEnemies = 10; //maximum number of enemies
    public float delay = 0.1f; // delay caused  the loop to instatiate too slowly, may have caused bugs.
    public float scatterRange  = 70f; // scatter range of the enemies

    [Header("Wave Mangement")]
    public int waveCount = 0; // counts the number of waves
    public int amountCheck; // counts the number of enemies in the current wave

    [Header("More Enemies")]
    public GameObject enemyPrefabTwo; // big enemies
    public GameObject enemyPrefabThree; // fast enemies
    public GameObject spawnPrefab; // decision between the two enemies, randomised
    void Start() 
    {
        amountCheck = 0; // sets the amount of enemies to 0 at the start of the game
    }  

    void Update()
    {
        if (amountCheck == 0) // if the amount is zero, start spawning some enemies
        {
            StartCoroutine(SpawnEnemies(amountCheck)); // calls the IEnumerator with amountCheck as the parameter
            waveCount++; // adds 1 to the wave count
        }
    }
    IEnumerator SpawnEnemies(int x) // takes amountCheck
    {   
        if (x == 0) // if there are no enemies,
        {   
            spawnPrefab = null;
            int enemyAmount = Random.Range(minEnemies,maxEnemies + 1);//random number of enemy/enemies
            amountCheck = enemyAmount; // sets amountCheck to the random number of enemies spawned from the random choice above
            Debug.Log(amountCheck); // outputs the amount of enemies that were spawned
            for (int i=0; i < amountCheck; i++) //a loop for each enemy spawn
            {
                float randomX = Random.Range(-scatterRange, scatterRange); //gets a random x position for the enemy to spawn
                float randomZ = Random.Range(-scatterRange, scatterRange); //gets a random z position for the enemy to spawn

                Vector3 spawnPosition = new Vector3(randomX, spawnHeight, randomZ); //gets a random spawn position
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity); // "spawns" the enemy into the scene.
             
            } 
            if (waveCount >= 4) // if the wave count reaches a certain number, different enemies will spawn
            {
                float chooseAtRandom = Random.Range(0,10); // chooses at random between 0,10
                if (chooseAtRandom % 2 != 0) // if it is an even number
                {
                    spawnPrefab = enemyPrefabTwo; // chooses the big enemy
                }else{
                    spawnPrefab = enemyPrefabThree; // chooses the small enemy
                }

                int enemyAmountTwo = Random.Range(0,5); // chooses a random number between 0,5
                amountCheck += enemyAmountTwo; // adds the random number to the amountCheck variable
                for (int j=0; j < enemyAmountTwo; j++)  // loops and instantiates the enemies
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
