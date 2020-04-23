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

    void Start(){
    }
    public void OnTriggerEnter(Collider other){
      somebody = other.gameObject.GetComponent<Fighter>();
      if(somebody != null && somebody != owner){
        Debug.Log(somebody + " hit " + punchName);
        if(somebody.Defense == false)
          somebody.Health = somebody.Health - damage;
          hitStun=2.0f;
          somebody.animator.SetTrigger("isHit");
      }
    }
    void Update(){
      if(hitStun>=0.0f)
      hitStun=hitStun-0.1f;
      if(hitStun == 0 && somebody != null && somebody != owner)
        somebody.animator.SetTrigger("isHit");
    }
}
