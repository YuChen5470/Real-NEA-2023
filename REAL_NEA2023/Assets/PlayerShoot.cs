using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public PlayerWeapon weapon;
    
    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask mask;

    void Start()
    {
       if (cam == null)
       {
            this.enabled = false;
       } 
    }
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        
    }

    void Shoot()
    {
        RaycastHit _hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, mask))
        {
           Debug.Log("we hit" + _hit.collider.name);
        }


        // something was hit
    }
    
}
