using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Gravity")]
    public float gravityStrength = -9.18f;

    [Header("Movement")] //just headers so i can be able to seperate better
    public float moveSpeed = 7f; //initial movement speed of the player
    public float sprintSpeed =5.0f; //sprint speed of the player
    public float currentSpeed;//current speed of the player
    public float groundDrag;// ground drag

    private bool isSprinting = false;// checks if sprinting or not
    

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space; // space button
    public KeyCode sprintKey = KeyCode.LeftShift; // left shift button

    [Header("Ground Check")]
    public LayerMask ground; // ground 
    public Transform groundCheck; // checking the ground
    public float groundCheckDistance; // distance of ground check
    bool isGrounded;
    
    [Header("Jumping and Double jumping")]
    public float jumpForce = 5f; //how much power in jump
    public int jumpCount; // counts jumps
    public int maxJumps = 2; // maximum jumps

    [Header("Crouching")]
    public KeyCode crouchKey = KeyCode.LeftControl; //left control

    public float crouchSpeed = 2f; //crouching speed
    [Header("Pausing game")]
    public bool isPaused = false;// variable for if the game is paused
    public GameObject pauseMenu; // object pause menu
    public GameObject crosshair; // objec crosshair

    private bool isCrouching = false; //variable for if the person is crouching

    public Transform orientation; //orientation of player

    [Header("Inputs")]
    float horizontalInput; // horizontal input
    float verticalInput; // vertical input

    Vector3 moveDirection; //direction player will move

    Rigidbody rb; //rigidbody


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); //getting the rigidbody component
        rb.freezeRotation = true; // freezing the rotation
        rb.useGravity = false; 
        pauseMenu.SetActive(false); //sets the pause menu as inactive 
    }

    // Update is called once per frame
    private void Update()
    {
        //ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckDistance, ground);
        // checking if the player is on the ground using the distance between the sphere and the ground.
        
        if (isGrounded)//resetting jumpcount when grounded
        {
            jumpCount = 0;
        }

        //jumping
        if (Input.GetButtonDown("Jump") && (isGrounded || jumpCount < maxJumps - 1)) 
        //checks if jump button is pressed, if yes and isGrounded = true and jump is less than maxJumps-1 then jumps
        //then adds 1 to the jump count to allow double jumping
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse); // adding force
            jumpCount++; //+1 jump
        }

        //sprinting toggle
        if (Input.GetKeyDown(sprintKey)){
            isSprinting = !isSprinting; // sets sprinting to the opposite of what it was
        }

        //crouching toggle
        if (Input.GetKeyDown(crouchKey))
        {
        isCrouching = !isCrouching; // sets crouching to the opposite of what it was
        Crouch(); // calls crouching function
        }
        
        //kasndkjadkjandkanskdsa

        MyInput();  // calls myinput function
        SpeedControl(); // calls speedcontrol function

        //drag
        if (isGrounded) // checks if the player is on the ground
            rb.drag = groundDrag; // adds drag to player
        else
            rb.drag = 0; // drag is zero if in air


        if (Input.GetKeyDown(KeyCode.Escape)) // pausing the game
        {
            if (isPaused) 
            {
                ResumeGame(); //if game is paused, resume game and close the pause menu
                CloseMenu();
            }
            else{
                PauseGame(); // if game is not paused, pause the game and open the menu
                OpenMenu();
                
            }
        }
    }

    private void FixedUpdate()
    {
        MovePlayer(); //calls the funcion that moves the player
        Vector3 gravity = new Vector3(0, gravityStrength, 0); // sets the gravity variable to 
        rb.AddForce(gravity, ForceMode.Force); //adds gravity to the player
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal"); //gets horizontal component 
        verticalInput = Input.GetAxisRaw("Vertical"); //gets vertical component
    }


    private void MovePlayer()
    {

        // calc movement direction
    
        //float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : moveSpeed;  
        //checks if leftshift is pressed, compacted if statement, left side is if true right side is if false
        if (isCrouching)
        {
            currentSpeed = moveSpeed; // sets current speed to move speed
        }else{
            currentSpeed = isSprinting ? sprintSpeed : moveSpeed; // if statement
        }
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput; 
        //calculates where the player is moving

        rb.AddForce(moveDirection.normalized * currentSpeed * 10f, ForceMode.Force); 
        //adds the force for the player to move in
    }



    private void SpeedControl() // making sure speed doesnt go past a set amount   
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z); 
        
        if(flatVel.magnitude > moveSpeed) 
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed; 
            //calculates the limited velocity the player can move at
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z); 
            // sets the velocity of the player to the maximum possible when they surpass the limit
        }
    }

    private void Crouch()
    {
    
    moveSpeed = 7;  //sets movement speed to 7
    if (isCrouching) //checks if crouching
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
        Time.timeScale = 0f; // pauses the time in game
        isPaused = true; // sets paused as true
    }    
    private void ResumeGame()
    {
        Time.timeScale = 1f; // unpauses the time in game
        isPaused = false; // paused set to false
    }

    private void OpenMenu()
    {
        Time.timeScale = 0f; // freezes the time in game
        Cursor.lockState = CursorLockMode.None; // unlocks the cursor so users can use it
        Cursor.visible = true; // users can see cursor
        crosshair.SetActive(false); // crosshair object set to false
        pauseMenu.SetActive(true); // pause menu is set to true, shows the pause menu.
        
    }

    private void CloseMenu()
    {
        Time.timeScale = 1f; // resumes the time in the game
        Cursor.lockState = CursorLockMode.Locked; // locks the cursor
        Cursor.visible = false; // makes the cursor invisible
        crosshair.SetActive(true); //sets the crosshair object as true
        pauseMenu.SetActive(false); // sets the pause menu as false
    }

    public void ResumeButton()
    {
        isPaused = false; //sets isPause boolean to false
        Time.timeScale = 1f; //unpauses the time
        Cursor.lockState = CursorLockMode.Locked; //locks the cursor
        Cursor.visible = false; // makes the cursor invisible
        crosshair.SetActive(true); //sets the crosshair object to true, allows players to see crosshair
    }

    public void RestartGame()
    {
        isPaused = false; //sets isPause boolean to false
        Time.timeScale = 1f; //unpauses the time
        Cursor.lockState = CursorLockMode.None; //unlocks the users cursor
        Cursor.visible = true; // sets the cursor visibility to true, allows user to see cursor
        crosshair.SetActive(false); //sets the object crosshair to false, 
        SceneManager.LoadScene("Menu"); //loads the menu scene
    }
}
