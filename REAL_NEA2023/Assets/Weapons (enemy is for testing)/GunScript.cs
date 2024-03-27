using System.Collections; //needed for coroutines to work
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
    public float damage = 10f; // damage of weapon
    public float range = 100f; // range of weapon
    public float reloadDuration; // reaload duration

    public Camera fpsCam; // gets a camera object to be assigned
    

    [Header("Gun Delay")]
    public float timeBetweenShots; // delay between shots
    private float timeSinceLastShot; // time from last shot

    [Header("Bullet Count")]
    public float maxBullets = 25f; //maximum bullets
    public float currentBullets;//current number of bullets

    [Header("Reloading")]
    private bool isReloading; // boolean variable that checks if the weapon is being reloaded

    [Header("Hit Marker")]
    public Image hitMarker; // hitmarker object

    void Start()
    {
        currentBullets = maxBullets; // sets the current number of bullets to the maximum
        hitMarker.enabled = false; // disables hitmarker at the start
    }

    void Update()
    {   
         if (isReloading) // checks if the player is reloading
            return;

        if (currentBullets <= 0 || Input.GetKeyDown(KeyCode.R)) // if the user has less than or equal to 0 bullets or presses the reload button
        {
            if (currentBullets == maxBullets) // if the player has maximum bullets 
            {
                Debug.Log("Full Magazine"); // outputs that they have maximum bullets and nothing happens
            }else
            {
                StartCoroutine(Reload()); // calls IEnumerator that will reload the weapon
                return; 
            }
            
        }
        
        timeSinceLastShot += Time.deltaTime; //starts the timer from 0 and keeps counting 

        if (Input.GetMouseButton(0) && timeSinceLastShot >= timeBetweenShots) //once two conditions need to be met for the shoot function to happen, and timeSinceLastShot is reset to 0.
        {
            if (currentBullets > 0) // if the current weapon has more than 0 bullets
            {
                Shoot(); // calls the shoot function
                timeSinceLastShot = 0f; // sets the time from last shot to 0 since the function has just been called
            }
        }
    }

    IEnumerator ShowHitMarker(float reloadDuration) // takes reload duration as a parameter
    {
        hitMarker.enabled = true; // sets the hitmarker as true 
        yield return new WaitForSeconds(reloadDuration); // waits for a few seconds
        hitMarker.enabled = false;// turns the hitmarker off again
    }


    IEnumerator Reload() //Reload function, nothing else is affected like movement. 
    {
        isReloading = true; // sets reloading boolean as true
        Debug.Log("Reloading..."); //outputs to the user that the gun is being reloaded

        yield return new WaitForSeconds(2); // pauses for 2 seconds

        currentBullets = maxBullets; // sets the current bullets to maximum bullets
        isReloading = false; // finished reloading so the boolean is false now
        Debug.Log("Reloaded"); // outputs that reloading is done
    }

    void Shoot()
    {
        RaycastHit hit; //raycast
       if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) //sends out a raycast from the players position forward.
       {

        Debug.Log(hit.transform.name); //tells the user what they have hit

        Enemy target = hit.transform.GetComponent<Enemy>(); //checking for target is enemy

        if (target != null) //checking if target is actually an enemy
        {
            target.TakeDamage(damage); // references the TakeDamage function from different script
            StartCoroutine(ShowHitMarker(0.05f)); //if hits, calls showhitmarker with a 0.05 second delay
        }
        
        currentBullets--; // -1 bullets
       }   
    }
}
