using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitColider : MonoBehaviour
{
    public string punchName;
    public float damage;
    public Fighter owner;
    //public Fighter opponent;

    public void OnTriggerEnter(Collider other){
      Fighter somebody = other.gameObject.GetComponent<Fighter>();
      if(somebody != null && somebody != owner){
        Debug.Log(somebody + " hit " + punchName);
        if(somebody.Defense == false)
          somebody.Health = somebody.Health - damage;
      }
    }
}
