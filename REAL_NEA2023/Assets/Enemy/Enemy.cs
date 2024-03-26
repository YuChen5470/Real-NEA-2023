using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    [Header("Transforms")]
    public Transform player;
    public Transform enemy;

    [Header("Ground Check")]
    public LayerMask ground;
    public Transform groundCheck;
    public float groundCheckDistance;
    bool isGrounded;

    [Header("Enemy attacking")]
    private PlayerHealth playerHealthScript;
    private bool isAttacking = false;


    [Header("Enemy One")]
    public float enemyScore = 5f;
    public float enemyMoney = 10f;
    public float attackRange =0.01f;
    public float health = 50f;
    public float enemyDamage = 1f;
    public float speed = 7f;
    

    [Header("Changing enemyAmount")]
    public SpawningEnemy spawnerScript;


    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        playerHealthScript = player.gameObject.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckDistance, ground);
        
        if (isGrounded)
        {
            //iteration 1.
            //Vector3 direction = (player.position - enemy.position).normalized;
            //enemy.Translate(direction * speed * Time.deltaTime, player.position, player.position); 
            //iteration 2.
            enemy.position = Vector3.MoveTowards(enemy.position,player.position, speed * Time.deltaTime);
        }
        
        Vector3 positionX = player.position - enemy.position;
        positionX.y = 0f;
        Quaternion targetRotation = Quaternion.LookRotation(positionX);
        enemy.rotation = Quaternion.Slerp(enemy.rotation, targetRotation, speed * Time.deltaTime);  


        if ( !isAttacking && Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            StartCoroutine(EnemyAttack(2));

            // some new codde im trying
        }
    }

    IEnumerator EnemyAttack(float delay)
    {
        isAttacking = true;
        playerHealthScript.TakeDamage(enemyDamage);
        yield return new WaitForSeconds(delay);
        isAttacking = false;
    }

    public void TakeDamage (float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            playerHealthScript.AddRewards(enemyScore, enemyMoney);
            Destroy(gameObject);
            spawnerScript.amountCheck--;
        }
    }
}

