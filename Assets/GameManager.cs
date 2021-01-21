using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0;
    public static int PlayerScore2 = 0;
    public static float timeRemaining = 3;
    public GUISkin layout;
    public bool showGUI = false;
    GameObject theBall;
    // Start is called before the first frame update
    void Start()
    {
         theBall = GameObject.FindGameObjectWithTag("Ball");
    }
    public static void Score (string wallID) {
        if (wallID == "RightWall")
        {
            PlayerScore1++;
            timeRemaining = 2;
        } 
        else
        {
            PlayerScore2++;
            timeRemaining = 2;
        }
    }
    void OnGUI () {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerScore2);
        if (showGUI){
            GUI.Label(new Rect(Screen.width / 2 - 15 , 200, 2000, 1000), "" + timeRemaining.ToString("0"));
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 70, 35, 170, 70), "RESTART"))
        {
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            theBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }

        if (PlayerScore1 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        } else if (PlayerScore2 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);    // The ‘SendMessage’ call is something we’ve been using a lot in this chunk of code - it will trigger any function that matches the name that we send it in a class we specify. So when we say theBall.SendMessage("ResetBall"), we tell the program to access the ‘BallControl’ class and trigger the ResetBall() method.
        }

        /*if (GUI.Button(new Rect(Screen.width / 2 - 370, -200, 3000, 3000), "PAUSE"))
      {

          theBall.SendMessage("PauseGame", 0.5f, SendMessageOptions.RequireReceiver);
      }
      */

    }

    // Update is called once per frame
    void Update()
    {
       if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            showGUI = true;
        }
        else{
            showGUI = false;
        }
    }
}
