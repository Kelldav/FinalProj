using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class FirstPlayerInput : MonoBehaviour
{

      private CharacterController controller;

      [SerializeField] private float movementSpeed;
      //private bool isJumping=false;
      private bool isRunning=false;
      private bool isMoving=false;
      private Rigidbody selfRigidbody;
      public float ComboTimer = 0.0f;
      public Fighter owner;
      public float smooth = 1f;
      public float RunSpeed=2f;
	    public float speed;
	    public float jumpSpeed;
	    public float gravity = 9.8F;
	    //private Quaternion lookLeft;
	    //private Quaternion lookRight;
	    private Vector3 moveDirection = Vector3.zero;
      private float MovementTimer=0.0f;
      public Vector3 jump;
      Animator animator;



      private void Awake() {
          controller = GetComponent<CharacterController>();
          selfRigidbody = GetComponent<Rigidbody>();
          selfRigidbody.freezeRotation = true;
          selfRigidbody.isKinematic = true;
          animator = GetComponent<Animator>();
          GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX;;
      }

      void Start(){
  		  Cursor.visible = false;
  		  Time.timeScale = 1;

  		  //lookRight = transform.rotation;
  		  //lookLeft = lookRight * Quaternion.Euler(0, 180, 0);
  	  }
      private void Update(){
          // movement
          MovementTimer= MovementTimer-0.01f;
          if(MovementTimer <= 0.0f){
            MovementTimer = 0.0f;
          }
          float horizontal = Input.GetAxis("Horizontal") * movementSpeed;
          float vertical = Input.GetAxis("Vertical") * movementSpeed;
          Vector3 forwardMovement = transform.forward * vertical;
          Vector3 rightMovement = transform.right * horizontal;
          //Debug.Log(forwardMovement);
          controller.SimpleMove(forwardMovement * Time.deltaTime);// + rightMovement);
          //JUMP CODE
          //Dont need it
          if (controller.isGrounded) {
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetKeyDown("space")){
              moveDirection.y = jumpSpeed;
              animator.SetBool("isJumping",true);
            }
          }
          moveDirection.y -= gravity * Time.deltaTime;
          controller.Move(moveDirection * Time.deltaTime);


          if(Input.GetKeyUp("space")){
            animator.SetBool("isJumping",false);
          }

          if(Input.GetKeyDown("left shift")){
            isRunning=true;
            movementSpeed=movementSpeed+RunSpeed;
            animator.SetBool("isRunning",isRunning);
          }
          if(Input.GetKeyUp("left shift")){
            isRunning=false;
            movementSpeed=movementSpeed-RunSpeed;
            animator.SetBool("isRunning",isRunning);

          }

          if(Input.GetKeyDown("d") ){
            isMoving=true;
            animator.SetBool("isMoving",isMoving);

          }
          if(Input.GetKeyDown("a")){

            animator.SetBool("isMovingBack",true);
          }
          if(Input.GetKeyUp("d") ){
            isMoving=false;
            animator.SetBool("isMoving",isMoving);
          }
          if(Input.GetKeyUp("a")){
            animator.SetBool("isMovingBack",false);
          }
          if(Input.GetKeyUp("s")){
            MovementTimer=3.0f;
          }
          if(Input.GetKeyDown("p") && owner.SuperMeter>= 1.0f && MovementTimer > 0.0f){
             animator.SetTrigger("Super");
             MovementTimer=0.0f;
             owner.SuperMeter=0.0f;
             ComboTimer=5.0f;
           }
          if(ComboTimer > 0.0f){
            ComboTimer=ComboTimer- (1*Time.deltaTime);
          }
          //PUNCH TIME
          if(Input.GetKeyDown("u")){
            animator.SetTrigger("L. Punch");
            ComboTimer=0.5f;
            animator.SetFloat("Combo Timer",ComboTimer);
            animator.SetBool("Reset",false);
            print("PUNCH 1 ACTIVATED");
            owner.SuperMeter = owner.SuperMeter + 0.05f;

            }

          if(Input.GetKeyDown("i") && ComboTimer>0.0f){
              animator.SetTrigger("M. Punch");
              ComboTimer=0.5f;
              animator.SetFloat("Combo Timer",ComboTimer);
              print("PUNCH 2 ACTIVATED");
              owner.SuperMeter = owner.SuperMeter + 0.01f;

            }

          if(Input.GetKeyDown("o") && ComboTimer>0.0f){
              animator.SetTrigger("H. Punch");
              ComboTimer=0.3f;
              animator.SetFloat("Combo Timer",ComboTimer);
              print("PUNCH 3 ACTIVATED");
              owner.SuperMeter=owner.SuperMeter+0.05f;
            }
          if(Input.GetKeyDown("i")){
            animator.SetTrigger("M. Punch");
            ComboTimer=0.3f;
            animator.SetFloat("Combo Timer",ComboTimer);
          }
          if(Input.GetKeyDown("o")){
            animator.SetTrigger("H. Punch");
            ComboTimer=0.3f;
            animator.SetFloat("Combo Timer",ComboTimer);
          }
          if(ComboTimer <= 0.0f){
              //print("BACK TO NEUTRAL");
              animator.SetBool("Reset",true);
              animator.ResetTrigger("L. Punch");
              animator.ResetTrigger("M. Punch");
              animator.ResetTrigger("H. Punch");
              animator.ResetTrigger("Super");
            }

            //KICKS
            if(Input.GetKeyDown("k")){
              animator.SetTrigger("L. Kick");
              ComboTimer=0.5f;
              owner.SuperMeter = owner.SuperMeter + 0.01f;
              animator.SetFloat("Combo Timer",ComboTimer);
              animator.SetBool("Reset",false);
              print("PUNCH 1 ACTIVATED");
              }

            if(Input.GetKeyDown("l") && ComboTimer>0.0f){
                animator.SetTrigger("H. Kick");
                ComboTimer=0.3f;
                owner.SuperMeter = owner.SuperMeter + 0.05f;
                animator.SetFloat("Combo Timer",ComboTimer);
                print("PUNCH 2 ACTIVATED");
              }
              if(Input.GetKeyDown("l")){
                  animator.SetTrigger("H. Kick");
                  ComboTimer=0.1f;
                  animator.SetFloat("Combo Timer",ComboTimer);
                }
            if(ComboTimer <= 0.0f){
                //print("BACK TO NEUTRAL");
                animator.SetBool("Reset",true);
                animator.ResetTrigger("L. Kick");
                animator.ResetTrigger("H. Kick");
                animator.ResetTrigger("Super");
              }

            //GUARD
            if(Input.GetKeyDown("j")){
              animator.SetBool("Guard",true);
              owner.Defense=true;
            }
            if(Input.GetKeyUp("j")){
              animator.SetBool("Guard",false);
              owner.Defense=false;
            }

          }
}
