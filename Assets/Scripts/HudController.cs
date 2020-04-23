using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HudController : MonoBehaviour {

  public Fighter player1;
  public Fighter player2;
  private int player1roundcount=0;
  private int player2roundcount=0;
  public  SimpleHealthBar leftBar;
  public  SimpleHealthBar rightBar;
  public SimpleHealthBar bottomLeft;
  public SimpleHealthBar bottomRight;
  public TextMeshProUGUI text;
  public TextMeshProUGUI countdown;
  private float timer=99.0f;
  private float selfTimer=0.0f;
  public TextMeshProUGUI p1rounds;
  public TextMeshProUGUI p2rounds;
  void Update(){
       leftBar.UpdateBar(player1.Health,player1.MaxHealth);
       rightBar.UpdateBar(player2.Health,player2.MaxHealth);
       bottomLeft.UpdateBar(player1.SuperMeter,1.0f);
       bottomRight.UpdateBar(player2.SuperMeter,1.0f);
       timer=timer-0.003f;
       countdown.text = timer.ToString("#");
       if(player1roundcount == 1){
         p1rounds.text="X";
       }
       if(player2roundcount == 1){
         p2rounds.text="X";
       }
       if(player1roundcount == 2){
         p1rounds.text="X X";
       }
       if(player2roundcount == 2){
         p2rounds.text="X X";
       }
       //Check For Death
       if(player1.Health <= 0.0f){
         text.text= "KNOCKOUT";
         selfTimer=selfTimer+0.003f;
         if(selfTimer>=3.0f){

           if(player2roundcount == 1) {
              SceneManager.LoadScene(sceneBuildIndex:2);
           }

           else{
            player1.transform.position = new Vector3(260.0f,1.0f,410.16f);
            player2.transform.position = new Vector3(260.0f,1.0f,437.04f);
            player1.Health = player1.MaxHealth;
            player2.Health = player2.MaxHealth;
            timer=99.0f;
            player2roundcount=player2roundcount+1;
            text.text="";
            selfTimer=0.0f;
          }

         }
       }

       if(player2.Health <= 0.0f){
         if(player1roundcount == 2) {
           SceneManager.LoadScene(sceneBuildIndex:2);

         }
         else{
           text.text="KNOCKOUT";
           selfTimer=selfTimer+0.003f;
           if(selfTimer>=3.0f){
             player1.transform.position = new Vector3(260.0f,1.0f,410.16f);
             player2.transform.position = new Vector3(260.0f,1.0f,437.04f);
             player1.Health = player1.MaxHealth;
             player2.Health = player2.MaxHealth;
             player1roundcount=player1roundcount+1;
             timer=99.0f;
             text.text="";
             selfTimer=0.0f;
           }
        }

        //TIMER SCAM
        if(timer==0){
          if(player1.Health > player2.Health){
            if(player2roundcount == 2) {
              text.text="GAME OVER \n PLAYER 1 WINS";
              //Load Character Select Screen
              SceneManager.LoadScene(sceneBuildIndex:2);

            }
            else{
            text.text="TIMES UP PLAYER 1 WINS";
            selfTimer=selfTimer+0.003f;
            if(selfTimer>=3.0f){
              player1.transform.position = new Vector3(260.0f,1.0f,410.16f);
              player2.transform.position = new Vector3(260.0f,1.0f,437.04f);
              player1.Health = player1.MaxHealth;
              player2.Health = player2.MaxHealth;
              player2roundcount=player2roundcount+1;
              timer=99.0f;
              text.text="";
              selfTimer=0.0f;
              }
            }
          }

          if(player2.Health < player2.Health){
            if(player1roundcount == 2) {
              text.text="GAME OVER \n PLAYER 1 WINS";
              //Load Character Select Screen
              SceneManager.LoadScene(sceneBuildIndex:2);

            }
            else{
            text.text="TIMES UP PLAYER 2 WINS";
            selfTimer=selfTimer+0.003f;
            if(selfTimer>=3.0f){
              player1.transform.position = new Vector3(260.0f,1.0f,410.16f);
              player2.transform.position = new Vector3(260.0f,1.0f,437.04f);
              player1.Health = player1.MaxHealth;
              player2.Health = player2.MaxHealth;
              player1roundcount=player1roundcount+1;
              timer=99.0f;
              text.text="";
              selfTimer=0.0f;
              }
            }
          }

          if(player1.Health == player2.Health){
            if(player1roundcount == 2) {
              SceneManager.LoadScene(sceneBuildIndex:2);
            }
            else{
            text.text="DRAW";
            selfTimer=selfTimer+0.003f;
            if(selfTimer>=3.0f){
              player1.transform.position = new Vector3(260.0f,1.0f,410.16f);
              player2.transform.position = new Vector3(260.0f,1.0f,437.04f);
              player1.Health = player1.MaxHealth;
              player2.Health = player2.MaxHealth;
              player2roundcount=player2roundcount+1;
              player1roundcount=player1roundcount+1;
              timer=99.0f;
              text.text="";
              selfTimer=0.0f;
            }
          }
        }
      }
    }
  }
}
