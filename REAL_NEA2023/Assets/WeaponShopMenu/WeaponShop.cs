using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShop : MonoBehaviour
{

    public bool isPaused = false; //check if paused
    [Header("Spawning weapon shop")]
    public GameObject weaponShop; // references gameobject called weaponshop
    public float spawnHeight = 10f; // spawn height of weapon shop
    public float scatterRange = 100f; //scatter range of weapon shop

    [Header("Spawning defence shop")]
    public GameObject defenceShop; //references gameobject called defenceshop
    public float spawnHeightTwo = 10f; //spawn height for defence shop
    public float scatterRangeTwo = 100f; //scatter range of weapon shop

    [Header("Interaction checks ")]
    public float interactionRadius = 5f; //if the distance between the shop's position and the player's current position is greater than 3, interaction is not permitted.
    public KeyCode interactKey = KeyCode.E; // sets interactkey as the E key
    public GameObject player; // gets the object player
    private GameObject shopInstance; // gets an object that will be the shop instance
    private GameObject shopInstanceTwo; //creating an instance for the defence shop.

    [Header("Shop Menus")]
    public GameObject weaponShopMenu;
    public GameObject defenceShopMenu; //will be creating a new defence shop menu that will have a bit less things than the wepaon shop
    public GameObject crosshair;
    void Start()
    {
        SpawnWeaponShop(); // spawn shops
    }

    void Update()
    {
        if (Vector3.Distance(shopInstance.transform.position, player.transform.position) <= interactionRadius && Input.GetKeyDown(interactKey)) //if the distance between the shop that is spawned and the player is less than the interaction radius, and they have presed E, open shop
        {
            showWeaponMenu();// opens weapon shop menu
            
        }
        if (Vector3.Distance(shopInstanceTwo.transform.position, player.transform.position) <= interactionRadius && Input.GetKeyDown(interactKey))//if the distance between the shop that is spawned and the player is less than the interaction radius, and they have presed E, open shop
        {
            showDefenceMenu();// opens defence shop menu
            
        }
        //Debug.Log(Vector3.Distance(shopInstance.transform.position, player.transform.position));
        // repeat if statement, but finding the distance between the player and the defence shop instance that was created
    }

    public void SpawnWeaponShop() // will repeat the whole random variable thing again so that I can spawn them in two different places.
    {
        float randomX = Random.Range(-scatterRange, scatterRange); // random x value
        float randomZ = Random.Range(-scatterRange, scatterRange); // random z value

        Vector3 spawnPosition = new Vector3(randomX, spawnHeight, randomZ); // random spawn position with the two random variables
        shopInstance = Instantiate(weaponShop, spawnPosition, Quaternion.identity); //shop is instantiated in the spawn position, and taking the weaponn shop object

        float randomXTwo = Random.Range(-scatterRangeTwo, scatterRangeTwo); //random x value, 2nd
        float randomZTwo = Random.Range(-scatterRangeTwo, scatterRangeTwo); //random z value, 2nd

        Vector3 spawnPositionTwo = new Vector3(randomXTwo, spawnHeightTwo, randomZTwo); // random spawn position with the two new random variables
        shopInstanceTwo = Instantiate(defenceShop, spawnPositionTwo, Quaternion.identity); //shop is instantiated in the spawn position, and taking the defence shop object 

    }

    public void showWeaponMenu()
    {
        Time.timeScale = 0f; //pauses the time
        Cursor.lockState = CursorLockMode.None; // unlocks cursor
        Cursor.visible = true; // allows players to see cursor
        crosshair.SetActive(false); //crosshair object is turned off
        weaponShopMenu.SetActive(true); // weapon shop menu is turned on for players to see
        isPaused = true; // paused is set to true
    }

    public void hideWeaponMenu()
    {
        Time.timeScale = 1f; // unpauses the time
        Cursor.lockState = CursorLockMode.Locked; //locks the cursor
        Cursor.visible = false; // sets the cursor to invisible
        crosshair.SetActive(true); // enables the crosshair object
        weaponShopMenu.SetActive(false); //disables the weapon shop menu object
        isPaused = false; // paused is set to false
        
    }

    public void showDefenceMenu()
    {
        Time.timeScale = 0f; // pauses the time
        Cursor.lockState = CursorLockMode.None; // unlocks cursor
        Cursor.visible = true; // sets the cursor to visible
        crosshair.SetActive(false); // sets crosshair object as false
        defenceShopMenu.SetActive(true); // shows the user the defence menu
        isPaused = true; //paused is set to true
    }

    public void hideDefenceMenu()
    {
        Time.timeScale = 1f; // unpauses the time
        Cursor.lockState = CursorLockMode.Locked;// locks the cursor
        Cursor.visible = false;// makes cursor invisible
        crosshair.SetActive(true); // sets the crosshair object as true
        defenceShopMenu.SetActive(false); // disables the defence shop menu 
        isPaused = false; // sets paused to false
        
    }

   
// will have to change some parts to this code, will have to make it so that it decides which shop I am choosing. 
// copy paste the SpawnWeaponShop and rename into SpawnDefenceShop for obvious reasons, instantiate and assign to a variable.
// have another if statment in the update function that would keep track of both shops and their distance away from the user.
// I may come across an error about the two shops being in the range and button pressed, may open the same shop and cause an error. 
// shorten the distance between the player and each shop? CHANGED  IT TO 5, not sure if this is a viable solution to this problem 
// if the error occurs I will add directional raycast that will hit one or the other shop, surely thatwill work I dont think I will need to do that.
// the likelyhood of the two being in the exact same x,y,z, position is almost zero to none.
    
}
