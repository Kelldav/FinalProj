using UnityEngine;
using System.Collections;

public class FighterCamera : MonoBehaviour {
  public Transform[] playerTransforms;
  private void Start(){
    GameObject[] allPlayers = GameObject.FindGameObjectsWithTag("Player");
    playerTransforms = new Transform[allPlayers.Length];
    for (int i =0; i < allPlayers.Length;i++){
      playerTransforms[i] = allPlayers[i].transform;

    }
  }
  public float yOffset = 2.0f;
  public float minDistance = 7.5f;

  private float zMin,zMax,xMin,xMax;

   void Update(){
    if(playerTransforms.Length == 0){
      Debug.Log("HAVE NOT FOUND A PLAYER MAKE SURE PLAYER TAG IS ON");
      return;
    }
    zMin = zMax = playerTransforms[0].position.z;
    xMin = xMax = playerTransforms[0].position.y;

    for(int i = 1; i < playerTransforms.Length; i++){
      if(playerTransforms[i].position.z < zMin)
        zMin = playerTransforms[i].position.z;
      if(playerTransforms[i].position.z > zMax)
        zMax = playerTransforms[i].position.z;
      if(playerTransforms[i].position.x < xMin)
        xMin = playerTransforms[i].position.x;
      if(playerTransforms[i].position.x > xMax)
        xMax = playerTransforms[i].position.x;
    }
    //print((zMin," ", zMax));
    float zMiddle = (zMax - zMin) / 2;
    float xMiddle = (xMin + xMax) / 2;
    float distance= (zMax - zMin);
    if(distance < minDistance)
      distance=minDistance;
    transform.position= new Vector3(distance+260 , yOffset ,zMiddle+zMin);
  }
}
