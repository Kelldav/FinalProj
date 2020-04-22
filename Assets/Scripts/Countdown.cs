using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    public float timer=99.0f;
    public TextMeshProUGUI countdown;

    // Update is called once per frame
    void Update(){
      timer=timer-0.003f;
      countdown.text = timer.ToString("#");
    }
}
