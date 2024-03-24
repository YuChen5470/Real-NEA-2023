using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class AmountCheckDisplay : MonoBehaviour
{
    public TextMeshProUGUI AmountCheckText;
    public SpawningEnemy spawningEnemy;
    public float currentAmountCheck;

    void Update()
    {
        currentAmountCheck = spawningEnemy.amountCheck;
        AmountCheckText.text = "Enemies left: " + currentAmountCheck.ToString();
    }

}
