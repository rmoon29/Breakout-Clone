using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour {

    public float speed = 0.1f;
    private GameObject ball;
    Collider2D coll;
    Collider2D ballColl;
    bool ballInPlay = false;
    float ballY;
    BallScript ballScript;
    private bool isBallAttached = false;
    private Vector3 origScale = new Vector3(0, 0, 0);

    // Use this for initialization
    void Start () {
        coll = this.GetComponent(typeof(Collider2D)) as Collider2D;
        DelegateHandler.onRespawnBall += this.setBall;
        DelegateHandler.onLifeLost += this.ResetPaddleLength;
        PowerUpEventHandler.ShrinkPaddle += this.ShrinkPaddle;
        PowerUpEventHandler.ExtendPaddle += this.ExtendPaddle;
        origScale = this.transform.localScale;
        //isBallAttached = false;
        //ball = Instantiate(Resources.Load("Ball", typeof(GameObject)), new Vector3(5, 5, 5), new Quaternion()) as GameObject;
        


    }

    public void setBall(GameObject newBall)
    {
        ball = newBall;
        //Debug.Log("this needs to be first");
        ballColl = ball.GetComponent(typeof(Collider2D)) as Collider2D;
        ballScript = ball.GetComponent(typeof(BallScript)) as BallScript;
        ballInPlay = false;
        isBallAttached = true;

    }
	
	// Update is called once per frame
	void Update () {

        MovePaddle();

        if (isBallAttached)
        {
            //Debug.Log("this needs to be second");
            AttachBallToPaddle();
        }
        if(Input.GetButtonDown("Fire1") && isBallAttached)
        {

            LaunchBall();
        }
        
        

           
	}
    void MovePaddle()
    {
        /*movePaddleAmount = Input.GetAxis("Horizontal") * speed;
        //Check bounds of Level
        if (coll.bounds.min.x > -8 && movePaddleAmount < 0)
        {
            this.transform.Translate(movePaddleAmount, 0, 0);
        }
        else if (coll.bounds.max.x < 8 && movePaddleAmount > 0)
        {
            this.transform.Translate(movePaddleAmount, 0, 0);
        }
        */
        
        this.transform.position = new Vector3 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, this.transform.position.y);

    }

    void AttachBallToPaddle()
    {

        //coll.enabled = !coll.enabled;
        ballY = coll.bounds.max.y + (ballColl.transform.position.y - ballColl.bounds.min.y);//(ballSprite.size.y / 2);

        ball.transform.SetPositionAndRotation(new Vector3(this.transform.position.x, ballY, 0), new Quaternion());
    }

    void LaunchBall()
    {
        ballScript.LaunchBall();
        //coll.enabled = !coll.enabled;
        ballInPlay = true;
        isBallAttached = false;
    }

    void ExtendPaddle()
    {
        this.transform.localScale = new Vector3(this.transform.localScale.x * 1.5f, 1, 1);
    }

    void ShrinkPaddle()
    {
        this.transform.localScale = new Vector3(this.transform.localScale.x * .75f, 1, 1);
    }

    void ResetPaddleLength()
    {
        this.transform.localScale = origScale;
    }
}
