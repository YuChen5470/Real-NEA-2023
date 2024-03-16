using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShop : MonoBehaviour
{
    [Header("Spawning weapon shop")]
    public GameObject weaponShop;
    public float spawnHeight = 10f;
    public float scatterRange = 100f;

    [Header("Spawning defence shop")]
    public GameObject defenceShop;
    public float spawnHeightTwo = 10f;
    public float scatterRangeTwo = 100f;

    [Header("Interaction checks ")]
    public float interactionRadius = 5f; //if the distance between the shop's position and the player's current position is greater than 3, interaction is not permitted.
    public KeyCode interactKey = KeyCode.E;
    public GameObject player;
    private GameObject shopInstance;
    private GameObject shopInstanceTwo; //creating an instance for the defence shop.

    [Header("Shop Menus")]
    public GameObject weaponShopMenu;
    public GameObject defenceShopMenu; //will be creating a new defence shop menu that will have a bit less things than the wepaon shop
    public GameObject crosshair;
    void Start()
    {
        SpawnWeaponShop();
    }

    void Update()
    {
        if (Vector3.Distance(shopInstance.transform.position, player.transform.position) <= interactionRadius && Input.GetKeyDown(interactKey))
        {
            showWeaponMenu();
            Debug.Log("testing opening Weapon shop");
        }
        if (Vector3.Distance(shopInstanceTwo.transform.position, player.transform.position) <= interactionRadius && Input.GetKeyDown(interactKey))
        {
            showDefenceMenu();
            Debug.Log("testing opening defence shop");
        }
        //Debug.Log(Vector3.Distance(shopInstance.transform.position, player.transform.position));
        // repeat if statement, but finding the distance between the player and the defence shop instance that was created
    }

    public void SpawnWeaponShop() // will repeat the whole random variable thing again so that I can spawn them in two different places.
    {
        float randomX = Random.Range(-scatterRange, scatterRange); 
        float randomZ = Random.Range(-scatterRange, scatterRange);

        Vector3 spawnPosition = new Vector3(randomX, spawnHeight, randomZ); 
        shopInstance = Instantiate(weaponShop, spawnPosition, Quaternion.identity);

        float randomXTwo = Random.Range(-scatterRangeTwo, scatterRangeTwo);
        float randomZTwo = Random.Range(-scatterRangeTwo, scatterRangeTwo);

        Vector3 spawnPositionTwo = new Vector3(randomXTwo, spawnHeightTwo, randomZTwo);
        shopInstanceTwo = Instantiate(defenceShop, spawnPositionTwo, Quaternion.identity);

    }

    public void showWeaponMenu()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        crosshair.SetActive(false);
        weaponShopMenu.SetActive(true);
    }

    public void hideWeaponMenu()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        crosshair.SetActive(true);
        weaponShopMenu.SetActive(false);
        
    }

    public void hideDefenceMenu()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        crosshair.SetActive(true);
        defenceShopMenu.SetActive(false);
        
    }

    public void showDefenceMenu()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        crosshair.SetActive(false);
        defenceShopMenu.SetActive(true);
    }
// will have to change some parts to this code, will have to make it so that it decides which shop I am choosing. 
// copy paste the SpawnWeaponShop and rename into SpawnDefenceShop for obvious reasons, instantiate and assign to a variable.
// have another if statment in the update function that would keep track of both shops and their distance away from the user.
// I may come across an error about the two shops being in the range and button pressed, may open the same shop and cause an error. 
// shorten the distance between the player and each shop? CHANGED  IT TO 5, not sure if this is a viable solution to this problem 
// if the error occurs I will add directional raycast that will hit one or the other shop, surely thatwill work I dont think I will need to do that.
// the likelyhood of the two being in the exact same x,y,z, position is almost zero to none.
    
}
