using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Gravity")]
    public float gravityStrength = -9.18f;

    [Header("Movement")] //just headers so i can be able to seperate better
    public float moveSpeed;
    public float sprintSpeed =5.0f;
    public float currentSpeed;
    public float groundDrag;

    private bool isSprinting = false;
    

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;

    [Header("Ground Check")]
    public LayerMask ground;
    public Transform groundCheck;
    public float groundCheckDistance;
    bool isGrounded;
    
    [Header("Jumping and Double jumping")]
    public float jumpForce = 5f;
    public int jumpCount;
    public int maxJumps = 2;

    [Header("Crouching")]
    public KeyCode crouchKey = KeyCode.LeftControl;

    public float crouchSpeed = 2f;


private bool isCrouching = false;

    public Transform orientation;

    [Header("Inputs")]
    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.useGravity = false;
    }

    // Update is called once per frame
    private void Update()
    {
        //ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckDistance, ground);
        //resetting jumpcount when grounded
        if (isGrounded)
        {
            jumpCount = 0;
        }

        //jumping
        if (Input.GetButtonDown("Jump") && (isGrounded || jumpCount < maxJumps - 1)) //checks if jump button is pressed, if yes and isGrounded = true and jump is less than maxJumps-1 then jumps
       //then adds 1 to the jump count to allow double jumping
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); // Reset vertical velocity
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse); // adding force
            jumpCount++;
        }

        //sprinting toggle
        if (Input.GetKeyDown(sprintKey)){
            isSprinting = !isSprinting;
        }

        //crouching toggle
        if (Input.GetKeyDown(crouchKey))
        {
        isCrouching = !isCrouching;
        Crouch();
        }
        
        //kasndkjadkjandkanskdsa

        MyInput();
        SpeedControl();

        //drag
        if (isGrounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
        Vector3 gravity = new Vector3(0, gravityStrength, 0);
        rb.AddForce(gravity, ForceMode.Force);
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }


    private void MovePlayer()
    {

        // calc movement direction
    
        //float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : moveSpeed;  //checks if leftshift is pressed, compacted if statement, left side is if true right side is if false
        if (isCrouching)
        {
            currentSpeed = moveSpeed;
        }else{
            currentSpeed = isSprinting ? sprintSpeed : moveSpeed;
        }
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * currentSpeed * 10f, ForceMode.Force);
        
    }



    private void SpeedControl() // making sure speed doesnt go past x 
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Crouch()
    {
    
    moveSpeed = 7; 
    if (isCrouching)
    {
        transform.localScale = 0.5f *Vector3.up +  Vector3.right + Vector3.forward; //iteration 2
        moveSpeed = crouchSpeed; // sets speed to crouchspeed
    }
    else
    {
        transform.localScale = Vector3.one;
    }
    isSprinting = false; //making sure players cannot sprint while crouching
    }
    
}
