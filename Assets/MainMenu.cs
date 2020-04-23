using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

  public bool isStart;
  public bool isQuit;

  void OnMouseUp(){
  	if(isStart){
  		SceneManager.LoadScene(sceneBuildIndex:1);
  	}
  	if (isQuit){
  		Application.Quit();
  	}
  }
  void Update(){
    if (Input.GetKey("escape"))
    {
        Application.Quit();
    }
}
}
