using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{   
    public float sensX; // variable for x sensitivity
    public float sensY; // variable for y sensitivity
 
    public Transform orientation; // position of the orientation

    float xRotation; // x rotation
    float yRotation; // y rotation
    private void Start()
    {
        Cursor.visible = false; // setting the cursor to invisible
        Cursor.lockState = CursorLockMode.Locked; //locks the cursor to the middle of the screen
    }

    // Update is called once per frame
    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * sensX * Time.deltaTime; // calculations for rotations 
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensY * Time.deltaTime; // calculations for rotations

        yRotation += mouseX; //calculations for rotation 
        xRotation -= mouseY;// calculations for rotation
        
        xRotation = Mathf.Clamp(xRotation, -90f,90f); // rounding 

        //rotate camera and rotation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0); //moves along the x axis depending on the x sensitivity moves along the y axis depending on the y sensitivity
        orientation.Rotate(Vector3.up * mouseX); // rotation



        //askjasdjksbdahbasbjkabdjabsdjkbdkjkjsad
    }
}
 