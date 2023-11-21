using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShop : MonoBehaviour
{
    [Header("Spawning shop")]
    public GameObject weaponShop;
    public float spawnHeight = 10f;
    public float scatterRange = 100f;

    [Header("Interaction checks")]
    public float interactionRadius = 10f; //if the distance between the shop's position and the player's current position is greater than 3, interaction is not permitted.
    public KeyCode interactKey = KeyCode.E;
    public GameObject player;
    private GameObject shopInstance;
    void Start()
    {
        SpawnWeaponShop();
    }

    void Update()
    {
        if (Vector3.Distance(shopInstance.transform.position, player.transform.position) <= interactionRadius && Input.GetKeyDown(interactKey))
        {
            Debug.Log("testing opening shop");
        }
    }

    public void SpawnWeaponShop()
    {
        float randomX = Random.Range(-scatterRange, scatterRange); 
        float randomZ = Random.Range(-scatterRange, scatterRange);

        Vector3 spawnPosition = new Vector3(randomX, spawnHeight, randomZ); 
        shopInstance = Instantiate(weaponShop, spawnPosition, Quaternion.identity);
    }


    
}
