using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShop : MonoBehaviour
{
    public GameObject weaponShop;
    public float spawnHeight = 10f;
    public float scatterRange = 100f;
    void Start()
    {
        SpawnWeaponShop();
    }

    public void SpawnWeaponShop()
    {
        float randomX = Random.Range(-scatterRange, scatterRange); 
        float randomZ = Random.Range(-scatterRange, scatterRange); 

        Vector3 spawnPosition = new Vector3(randomX, spawnHeight, randomZ); 
        Instantiate(weaponShop, spawnPosition, Quaternion.identity);
    }
    
}
