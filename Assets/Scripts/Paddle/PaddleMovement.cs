using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour {

    public float speed = 0.1f;
    public GameObject ball;
    float movePaddleAmount = 0;
    Collider2D coll;
    Collider2D ballColl;
    SpriteRenderer ballSprite;
    bool ballInPlay = false;
    float ballY;

    // Use this for initialization
    void Start () {
        coll = this.GetComponent(typeof(Collider2D)) as Collider2D;

        ball = Instantiate(Resources.Load("Ball", typeof(GameObject)), new Vector3(5, 5, 5), new Quaternion()) as GameObject;
        Debug.Log(ball.transform.position);
        ballColl = ball.GetComponent(typeof(Collider2D)) as Collider2D;
        ballSprite = ball.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;


    }
	
	// Update is called once per frame
	void Update () {

        MovePaddle();    
        if (!ballInPlay)
        {
            AttachBallToPaddle();
        }
        if(Input.GetAxis("Jump") > 0)
        {
            LaunchBall();
        }
        
        

           
	}
    void MovePaddle()
    {
        movePaddleAmount = Input.GetAxis("Horizontal") * speed;
        //Check bounds of Level
        if (coll.bounds.min.x > -8 && movePaddleAmount < 0)
        {
            this.transform.Translate(movePaddleAmount, 0, 0);
        }
        else if (coll.bounds.max.x < 8 && movePaddleAmount > 0)
        {
            this.transform.Translate(movePaddleAmount, 0, 0);
        }

    }

    void AttachBallToPaddle()
    {
        //Debug.Log("min: " + ballColl.bounds.min.y + "max: " + ballColl.bounds.max.y);
        ballY = coll.bounds.max.y + (ballColl.transform.position.y - ballColl.bounds.min.y);//(ballSprite.size.y / 2);

        ball.transform.SetPositionAndRotation(new Vector3(this.transform.position.x, ballY, 0), new Quaternion());
    }

    void LaunchBall()
    {

    }
}
