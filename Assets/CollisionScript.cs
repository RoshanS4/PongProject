using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    public static GameObject thePlayer;
    public static GameObject thePlayer2;
    public static GameObject redBall;
    public static float timeRemaining = 0;
    public static float timeRemaining1 = 0;
    public static GameObject greenBall;
    public static Vector2 originalScale;
    // Start is called before the first frame update



    void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        thePlayer2 = GameObject.FindGameObjectWithTag("Player2");
        redBall = GameObject.FindGameObjectWithTag("BallRed");
        greenBall = GameObject.FindGameObjectWithTag("GreenBall");
        originalScale = thePlayer.transform.localScale;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else{
          thePlayer.SetActive(true);

       }
       if (timeRemaining1 > 0)
        {
            timeRemaining1 -= Time.deltaTime;
        }
        else{
          thePlayer2.gameObject.transform.localScale = originalScale;
       }
    
    }


    public void OnCollisionEnter2D(Collision2D col){
        if(col.collider.tag == "BallRed"){
            timeRemaining = 1.5f;
            redBall.SetActive(false);
        }
        if(col.collider.tag == "GreenBall"){
            timeRemaining1 = 7;
            greenBall.SetActive(false);
            thePlayer2.gameObject.transform.localScale += new Vector3(.5f, 2, 1);
           
        }
    }
}
