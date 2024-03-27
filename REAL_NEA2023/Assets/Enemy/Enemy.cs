using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    [Header("Transforms")]
    public Transform player; // referencing the player, will be changing its position and/or rotation 
    public Transform enemy; // referencing the enemy, will be changing its position and/or rotation

    [Header("Ground Check")]
    public LayerMask ground; //ground used for groundchecks
    public Transform groundCheck; //groundcheck position
    public float groundCheckDistance; //amount of distance the groundchecking will cover
    bool isGrounded; // variable that will declare if the player is grounded or not

    [Header("Enemy attacking")]
    private PlayerHealth playerHealthScript; //referencing the playerHealth script, used to access variables and use functions from different scripts 
    private bool isAttacking = false; // boolean for if the enemy is attacking


    [Header("Enemy One")]
    public float enemyScore = 5f; //score enemy gives playe
    public float enemyMoney = 10f; //amount of money enemy gives 
    public float attackRange =0.01f;// range of the enemy
    public float health = 50f; // health of the enemy
    public float enemyDamage = 1f; //damage enemy does
    public float speed = 7f; // speed of the enemy
    

    [Header("Changing enemyAmount")]
    public SpawningEnemy spawnerScript; //referencing the enemy script


    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>(); //gets the rigidbody component
        rb.constraints = RigidbodyConstraints.FreezeRotation; //freezing rotations
        playerHealthScript = player.gameObject.GetComponent<PlayerHealth>(); //getting component playerhealth and setting it to the variable playerHealthScript
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckDistance, ground); //checking if the enemy is on the ground
        
        if (isGrounded)
        {
            //iteration 1.
            //Vector3 direction = (player.position - enemy.position).normalized;
            //enemy.Translate(direction * speed * Time.deltaTime, player.position, player.position); 
            //iteration 2.
            enemy.position = Vector3.MoveTowards(enemy.position,player.position, speed * Time.deltaTime); //if the enemy is on the ground, it will start moving towards the player
        }
        
        Vector3 positionX = player.position - enemy.position; // calculates the rotation towards the player
        positionX.y = 0f; //locks the y rotation so the enemies only look in the general x direction of the player
        Quaternion targetRotation = Quaternion.LookRotation(positionX); // performs the rotation
        enemy.rotation = Quaternion.Slerp(enemy.rotation, targetRotation, speed * Time.deltaTime); //performs the rotation


        if ( !isAttacking && Vector3.Distance(transform.position, player.position) <= attackRange) // checks if the distance between the player and the enemy is close enough for the enemy to do damage to the player
        { 
            StartCoroutine(EnemyAttack(2)); // calls the IEnumerator with a delay of 2 seconds

            // some new codde im trying
        }
    }

    IEnumerator EnemyAttack(float delay) // takes in the parameter as the number of seconds to wait
    {
        isAttacking = true; // sets isAttacking to true
        playerHealthScript.TakeDamage(enemyDamage); // calls the takdamage function from player health
        yield return new WaitForSeconds(delay); // waits 2 sceonds
        isAttacking = false; // sets isAttacking to false
    }

    public void TakeDamage (float amount) // takes in an amount which will be the damge from the player
    {
        health -= amount; //subtracts damage from enemy health
        if (health <= 0) // if health reaches below or zero
        {
            playerHealthScript.AddRewards(enemyScore, enemyMoney); //calls a function that will give the player score and currency
            Destroy(gameObject);  //removes the enemy object from the scene
            spawnerScript.amountCheck--; // subtracts the number of enemies in the wave 
        }
    }
}

