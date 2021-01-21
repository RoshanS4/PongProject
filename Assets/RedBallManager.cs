using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBallManager : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public static GameObject thePlayer;
    public static GameObject thePlayer2;
    public static GameObject redBall;
    public static float timeRemainingToReapper = 0;
    public static float timeToStart;
    public static float y;




    void GoBall()
    {
        redBall.SetActive(true);
        redBall.GetComponent<Renderer>().enabled = true;
        float rand = Random.Range(0, 2);// puts the ball in a random spot
        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(30, Random.Range(-40, 15))); // the first number is the speed and the second number is the direction.
        }
        else
        {
            rb2d.AddForce(new Vector2(-30, Random.Range(-40, 15)));
        }
    }
    void OnEnable()
    {
        GameObject[] otherObjects = GameObject.FindGameObjectsWithTag("Ball");
        GameObject[] otherObjects2 = GameObject.FindGameObjectsWithTag("GreenBall");

        foreach (GameObject obj in otherObjects)
        {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        foreach (GameObject obj in otherObjects2)
        {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
    void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        thePlayer2 = GameObject.FindGameObjectWithTag("Player2");
        redBall = GameObject.FindGameObjectWithTag("BallRed");
        CircleCollider2D coll = GetComponent<CircleCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        timeToStart = Random.Range(40, 50);
        redBall.GetComponent<Renderer>().enabled = false; // hides the object rather than disbaling it 
        Invoke("GoBall", timeToStart); // 3 seconds before the start
    }

    void Reset()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        timeToStart = Random.Range(70, 80);
        Invoke("GoBall", timeToStart);
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Player2")
        {
            timeRemainingToReapper = 1.5F;
            thePlayer.SetActive(false);
            y = Random.Range(-2.25f, 2.25f);
            thePlayer.transform.position = new Vector2(-4, y);
            Reset();

        }
        else if (col.collider.tag == "Player")
        {

            timeRemainingToReapper = 1.5F;
            thePlayer2.SetActive(false);
            y = Random.Range(-2.25f, 2.25f);
            thePlayer2.transform.position = new Vector2(4, y);
            Reset();
        }
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "RightWall")
        {
            Reset();
        }
        if (hitInfo.name == "LefttWall")
        {
            Reset();
        }
    }
    void Update()
    {
        if (timeRemainingToReapper > 0)
        {
            timeRemainingToReapper -= Time.deltaTime;
        }
        else
        {
            thePlayer.SetActive(true);
            thePlayer2.SetActive(true);

        }

    }

}
