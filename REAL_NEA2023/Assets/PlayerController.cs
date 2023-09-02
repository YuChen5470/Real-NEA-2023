using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]  //adds PlayerMotor which adds RigidBody
public class PlayerController : MonoBehaviour{

   // [SerializeField] //used to mark private fields are serialisable so that unity can load these values, basically public, but not actually public 
   public float speed = 3f; // f is for setting numbers as a float, it must have the "f"
 
   public float sensitivity = 13f;

   [SerializeField]

   private float jumpForce = 2f;
   

   private PlayerMotor motor;
   public float _xMov;
   public float _zMov;

   void Start ()
   {
      motor = GetComponent<PlayerMotor>();  // gets component PlayerMotor and sets to motor
   }


   void Update ()
   {
      //Calc movement velocity as a 3D vector
      float _xMov = Input.GetAxisRaw("Horizontal"); //[raw] Full control, no interference with unity and processing
      float _zMov = Input.GetAxisRaw("Vertical");   // getting the axis from input manager. edit, project settings, take from input manager and take the Hor/Ver and set it to x/zMove
     
     //transform.right/forward will take in the rotation of the character
      Vector3 _movHorizontal = transform.right * _xMov;  //will change (x,y,z)
      Vector3 _movVertical = transform.forward * _zMov;

      Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed; //Final movement vector

      //Applying the movement

      motor.Move(_velocity);

      //calc rotation as a 3d vector this is for turning the players POV
      float _yRot = Input.GetAxisRaw("Mouse X"); //takes from input manager

      Vector3 _rotation = new Vector3 (0f, _yRot, 0f) * sensitivity;

      // Apply rotation
      motor.Rotate(_rotation);  // passing in _rotation into the rotate function which is a method called from the class called motor (private PlayerMotor motor)


      //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 


      //calc camera rotation as a 3d vector this is for turning the players POV
      float _xRot = Input.GetAxisRaw("Mouse Y"); //takes from input manager

      Vector3 _cameraRotation = new Vector3 (_xRot, 0f, 0f) * sensitivity;


      // Apply camera rotation
      motor.RotateCamera(_cameraRotation);

      // Calc jumping stuff 
      Vector3 _jumpForce = Vector3.zero;

      
      if (Input.GetButton("Jump")){
            _jumpForce = Vector3.up * jumpForce;   //Vector3.up is the same as going up in the coordinates 0,1,0 
      }
      // Applying jumping mechanics into player
      motor.ApplyJump(_jumpForce);



      //locking cursor into the middle
      Cursor.visible = false;
      Cursor.lockState = CursorLockMode.Locked;
   }
}
