using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitColider : MonoBehaviour{
    public string punchName;
    public float damage;
    public Fighter owner;
    private Fighter somebody;
    //public Fighter opponent;
    public float hitStun=0.0f;

    public void OnTriggerEnter(Collider other){
      somebody = other.gameObject.GetComponent<Fighter>();
      if(owner.Defense == false && somebody.Defense == false){
        if(somebody != null && somebody != owner){
          Debug.Log(somebody + " hit " + punchName);
          if(somebody.Defense == false){
            somebody.Health = somebody.Health - damage;
            somebody.animator.SetFloat("HitStun",2.0f);
            somebody.animator.SetBool("isHit",true);
          }
        }
      }
    }

    void Update(){
      //if(hitStun>0.0f)
        //hitStun=hitStun-0.1f;

      //if(hitStun <= 0 && somebody != null && somebody != owner)
        //somebody.animator.SetBool("isHit",false);
    }

}
