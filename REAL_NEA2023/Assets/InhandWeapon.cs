using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InhandWeapon : MonoBehaviour
{
    public GunSwitching gunSwitching;

    public TextMeshProUGUI inhandWeaponText;
    
    public GameObject _currentWeapon;
    // Update is called once per frame
    void Start()
    {
        _currentWeapon = gunSwitching.currentWeapon;
    }
    void Update()
    {
        inhandWeaponText.text = "Currently Upgrading: " + _currentWeapon;
    }
}
