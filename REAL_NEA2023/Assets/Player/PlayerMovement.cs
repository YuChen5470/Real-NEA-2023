using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Gravity")]
    public float gravityStrength = -9.18f;

    [Header("Movement")] //just headers so i can be able to seperate better
    public float moveSpeed = 7f;
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
    [Header("Pausing game")]
    public bool isPaused = false;
    public GameObject pauseMenu;
    public GameObject crosshair;

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
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        //ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckDistance, ground);
        
        if (isGrounded)//resetting jumpcount when grounded
        {
            jumpCount = 0;
        }

        //jumping
        if (Input.GetButtonDown("Jump") && (isGrounded || jumpCount < maxJumps - 1)) //checks if jump button is pressed, if yes and isGrounded = true and jump is less than maxJumps-1 then jumps
       //then adds 1 to the jump count to allow double jumping
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse); // adding force
            jumpCount++; //+1 jump
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


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
                CloseMenu();
            }
            else{
                PauseGame();
                OpenMenu();
                
            }
        }
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



    private void SpeedControl() // making sure speed doesnt go past  
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
        transform.localScale = Vector3.one; // returns character to normal size
    }
    isSprinting = false; //making sure players cannot sprint while crouching
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }    
    private void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }

    private void OpenMenu()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        crosshair.SetActive(false);
        pauseMenu.SetActive(true);
        
    }

    private void CloseMenu()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        crosshair.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void ResumeButton()
    {
        isPaused = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        crosshair.SetActive(true);
    }

    public void RestartGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        crosshair.SetActive(false);
        SceneManager.LoadScene("Menu");
    }
}
