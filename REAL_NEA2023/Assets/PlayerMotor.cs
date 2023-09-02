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
    private Vector3 jumpForce = Vector3.zero;
    private bool isGrounded;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    private Rigidbody rb;

    public float walkSpeed = 4f;
    public float sprintSpeed = 10f;
    public float speed;


    [Header("movement fixing")]
    public PhysicMaterial airPhysicsMaterial;
    public float airControlSpeed = 5f;
    public PlayerController playerController;
    public float inputHorizontal;
    public float inputVertical;
    public float moveSpeed;
    public float bunnyHopMultiplier = 3f;

    /*

    [Header("Crouching")]
    public float crouchYscale;
    public float crouchSpeed = 2f;
    private float startYscale;  


    put this in start()
    startYscale = transform.localScale.y;
    */

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
    // Gets a force vector for our jumps
    public void ApplyJump (Vector3 _jumpForce){
        
        jumpForce = _jumpForce;
    }

    // Run every physics iteration like movement rotation etc

    void Update()
    {
        float inputHorizontal = playerController._xMov;
        float inputVertical = playerController._zMov;
        float moveSpeed = playerController.speed;
    }
    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    //perform movement based on velocity variable

    void PerformMovement()      //includes walking, sprinting and crouching movements
     {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, .1f, ground );

        if (jumpForce != Vector3.zero && isGrounded){
            rb.AddForce(jumpForce, ForceMode.Impulse);
        }
        else 
        {
            if (Input.GetButtonDown("Jump") && inputVertical > 0)
            {
                Vector3 forwardForce = transform.forward * moveSpeed * bunnyHopMultiplier;
                rb.AddForce(forwardForce, ForceMode.Impulse);
            }
        }

        //sprinting
        speed = walkSpeed;
        if (Input.GetKey("left shift") && isGrounded)
        {
            speed = sprintSpeed;
        }
        Vector3 inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        Vector3 desiredVelocity = transform.TransformDirection(inputDirection) * speed;     // calculates the velocity based off input, leftshift or just W key
        rb.velocity = new Vector3(desiredVelocity.x, rb.velocity.y, desiredVelocity.z);    //applys the movement to rb

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
