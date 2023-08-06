using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]  // takes component rigidbody as it is needed
public class PlayerMotor : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //getting component RigidBody and setting as rb
    }
    
    // Takes a movement vector 
    public void Move (Vector3 _velocity)
    {
        velocity = _velocity;

    }
    // Run every physics iteration
    void FixedUpdate()
    {
        PerformMovement();
    }

    //perform movement based on velocity variable

    void PerformMovement()
     {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

}
