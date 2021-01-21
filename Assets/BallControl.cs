using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    
    private Rigidbody2D rb2d;
    public static GameObject theBall;
    public static GameObject redBall;

    void GoBall(){              // puts the ball in a random spot
        float rand = Random.Range(0, 2);
        if(rand < 1){
            rb2d.AddForce(new Vector2(20,Random.Range(-15, 15))); // the first number is the speed and the second number is the direction.
        } else {
            rb2d.AddForce(new Vector2(-20, Random.Range(-15, 15)));
        }
    }

    void OnEnable()
    {
        GameObject[] otherObjects = GameObject.FindGameObjectsWithTag("BallRed");
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

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        CircleCollider2D coll = GetComponent<CircleCollider2D>();
        Invoke("GoBall", 3); // 3 seconds before the start
        theBall = GameObject.FindGameObjectWithTag("Ball");
        redBall = GameObject.FindGameObjectWithTag("BallRed");
    }
    void ResetBall(){
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }
    void RestartGame(){
        ResetBall();
        PlayerControls.ResetPlayer();
        Invoke("GoBall", 2);
    }

    void PauseGame()
    {
        Time.timeScale = Mathf.Approximately(Time.timeScale, 0.0f) ? 1.0f : 0.0f;
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }


    void OnCollisionEnter2D (Collision2D col) {
         if (col.gameObject.name == "Paddle1")
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * 10;
        }

        if (col.gameObject.name == "Paddle2")
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction
            Vector2 dir = new Vector2(-1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
