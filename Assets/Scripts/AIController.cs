using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
  private CharacterController controller;
  [SerializeField] private float movementSpeed;
  private bool isMoving=false;
  private Rigidbody selfRigidbody;
  public float ComboTimer = 0.0f;
  public Fighter owner;
  public Fighter opponent;
  public float smooth = 1f;
  public float RunSpeed=2f;
  public float speed;
  public float jumpSpeed;
  public float gravity = 20.0F;
  private Vector3 moveDirection = Vector3.zero;
  private float MovementTimer=0.0f;
  public Animator animator;
  public HitColider axe;
  private float Timer=0.0f;
  private float actionTime=0.0f;
  private bool isActing=false;
  private UnityEngine.AI.NavMeshAgent agent;
    // Start is called before the first frame update
    void Start(){
      controller = GetComponent<CharacterController>();
      selfRigidbody = GetComponent<Rigidbody>();
      selfRigidbody.freezeRotation = true;
      selfRigidbody.isKinematic = true;
      animator = GetComponent<Animator>();
      GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX;
      agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    private void Awake() {

    }
    // Update is called once per frame
    void Update(){
      //PRELIMINARY
      if(owner.Health >0.0f){
      if(Timer >= 2.0f){
        //reset timer back to 0 along with action
        Timer = 0.0f;
        owner.animator.SetBool("Block",false);
        owner.animator.SetBool("Slash",false);
        isActing=false;
        Debug.Log("TICK");
      }
      Timer=Timer+0.01f;
      //DECISION TIME

      //Do we need to move forward?
      float dist=Mathf.Abs(opponent.transform.position.z - owner.transform.position.z);
      //Debug.Log(dist);
      if(dist >= 5.0f){
        agent.isStopped=false;
        agent.SetDestination(new Vector3(this.transform.position.x, this.transform.position.y, opponent.transform.position.z+5));
        owner.animator.SetBool("isWalking",true);
        if(dist <= 5.0f){
          //Emergency Shutoff
          agent.isStopped=true;
          owner.animator.SetBool("isWalking",false);
        }
      }
      else{
        owner.animator.SetBool("isWalking",false);
        if(isActing == false){
        //Combat mode
        //Guard or slash?
        int dTwo=Random.Range(0,5);
        if(dTwo == 0){
          isActing=true;
          owner.animator.SetBool("Slash",true);
        }
        else{
          isActing=true;
          owner.animator.SetBool("Block",true);
        }

      }
    }
      }
    }
}
