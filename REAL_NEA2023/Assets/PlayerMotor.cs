using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]  // takes component rigidbody as it is needed
public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;
    

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

    // Takes a rotation vector
    public void Rotate (Vector3 _rotation)
    {
        rotation = _rotation;

    }

    // Takes a rotation vector for the camera
     public void RotateCamera (Vector3 _cameraRotation)
    {
        cameraRotation = _cameraRotation;

    }

    // Run every physics iteration like movement rotation etc
    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    //perform movement based on velocity variable

    void PerformMovement()
     {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    //perform rotation 
    // Quaternion is some complicated thing just need it for rotation
    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler (rotation));
        if (cam != null)
        {
            cam.transform.Rotate (-cameraRotation);
        }
    }

}
