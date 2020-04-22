using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public float MaxHealth=10000.0f;
    public float Health=10000.0f;
    public bool Defense=false;
    public Fighter opponent;
    public string fighterName;
    public Animator animator;
    public Rigidbody myBody;
    public float SuperMeter=0.0f;
    // Start is called before the first frame update
    void Start(){
      myBody = GetComponent<Rigidbody>();
      animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){
      animator.SetFloat("health",healthPercent);
      if(opponent != null){
        animator.SetFloat("opponent_health",opponent.healthPercent);
      }
      else{
        animator.SetFloat("opponent_health",1);
      }
    }
    public float healthPercent{
      get{
        return Health/MaxHealth;
      }
    }
    public Rigidbody body{
      get{
        return this.myBody;
      }
    }
}
