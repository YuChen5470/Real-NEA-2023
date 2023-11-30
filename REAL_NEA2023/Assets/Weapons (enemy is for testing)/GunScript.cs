using System.Collections; //needed for coroutines to work
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float reloadDuration;

    public Camera fpsCam;
    

    [Header("Gun Delay")]
    public float timeBetweenShots;
    private float timeSinceLastShot;

    [Header("Bullet Count")]
    public float maxBullets = 25f;
    public float currentBullets;

    [Header("Reloading")]
    private bool isReloading;

    [Header("Hit Marker")]
    public Image hitMarker;

    void Start()
    {
        currentBullets = maxBullets;
        hitMarker.enabled = false;
    }

    void Update()
    {   
         if (isReloading)
            return;

        if (currentBullets <= 0 || Input.GetKeyDown(KeyCode.R))
        {
            if (currentBullets == maxBullets)
            {
                Debug.Log("Full Magazine");
            }else
            {
                StartCoroutine(Reload());
                return; 
            }
            
        }
        
        timeSinceLastShot += Time.deltaTime; //starts the timer from 0 and keeps counting 

        if (Input.GetMouseButton(0) && timeSinceLastShot >= timeBetweenShots) //once two conditions need to be met for the shoot function to happen, and timeSinceLastShot is reset to 0.
        {
            if (currentBullets > 0)
            {
                Shoot();
                timeSinceLastShot = 0f;
            }
        }
    }

    IEnumerator ShowHitMarker(float reloadDuration)
    {
        hitMarker.enabled = true;
        yield return new WaitForSeconds(reloadDuration);
        hitMarker.enabled = false;
    }


    IEnumerator Reload() //Reload function, nothing else is affected like movement. 
    {
        isReloading = true;
        Debug.Log("Reloading...");

        yield return new WaitForSeconds(2);

        currentBullets = maxBullets;
        isReloading = false;
        Debug.Log("Reloaded");
    }

    void Shoot()
    {
        RaycastHit hit;
       if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) //sends out a raycast from the players position forward.
       {

        Debug.Log(hit.transform.name); //placeholder

        Enemy target = hit.transform.GetComponent<Enemy>();

        if (target != null) //checking if target is actually an enemy
        {
            target.TakeDamage(damage); // references the TakeDamage function from different script
            StartCoroutine(ShowHitMarker(0.05f)); 
        }
        
        currentBullets--; // -1 bullets
       }   
    }
}
