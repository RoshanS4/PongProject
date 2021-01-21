using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{
   
    public GUISkin layout;

    GameObject theBall;
    // Start is called before the first frame update
    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball");
    }


    void OnGUI()
    {
       


        if (GUI.Button(new Rect(Screen.width / 2 + 285, 5, 150, 70), "PAUSE"))
        {

           
            theBall.SendMessage("PauseGame", 0.5f, SendMessageOptions.RequireReceiver);
        }

       
    }
    // Update is called once per frame
    void Update()
    {

    }
}

