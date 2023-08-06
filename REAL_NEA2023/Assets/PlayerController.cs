using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]  //adds PlayerMotor which adds RigidBody
public class PlayerController : MonoBehaviour{

   [SerializeField] //used to mark private fields are serialisable so that unity can load these values, basically public, but not actually public 
   private float speed = 5f; // f is for setting numbers as a float, it must have the "f"

   private PlayerMotor motor;

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


   }
}
