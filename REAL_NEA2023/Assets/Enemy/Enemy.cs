using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50f;
    public Transform player;
    public Transform enemy;
    public float speed = 7f;

    [Header("Ground Check")]
    public LayerMask ground;
    public Transform groundCheck;
    public float groundCheckDistance;
    bool isGrounded;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckDistance, ground);
        
        if (isGrounded)
        {
            //iteration 1.
            //Vector3 direction = (player.position - transform.position).normalized;
            //transform.Translate(direction * speed * Time.deltaTime, player.position, player.position); 
            //iteration 2.
            enemy.position = Vector3.MoveTowards(enemy.position,player.position, speed * Time.deltaTime);
        }
        
        Vector3 playerFace = player.position - enemy.position;
        Quaternion targetRotation = Quaternion.LookRotation(playerFace);
        enemy.rotation = Quaternion.Slerp(enemy.rotation, targetRotation, speed * Time.deltaTime);   
        
    }
    public void TakeDamage (float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

