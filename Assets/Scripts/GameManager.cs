using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public PaddleMovement paddleMovement;
    public GameObject paddle;
    public GameObject ball;
    public LevelGenerator levelGenerator;
    private int lives;
    private int gameScore;
    private float respawnTime = 2f;
    private int numBalls;

    // Use this for initialization
    void Start() {
        
        DelegateHandler.onScoreIncrease += this.IncreaseScore;
        DelegateHandler.onBallDeath += this.ballDeath;
        PowerUpEventHandler.DoubleBall += this.addBall;
        spawnBall();
    }

    // Update is called once per frame
    void Update() {

    }

    void IncreaseScore(int score)
    {
        gameScore += score;
        //Debug.Log(gameScore);
    }

    void ballDeath()
    {
        numBalls--;
        Debug.Log(numBalls);
        if (numBalls == 0)
        {
            lives--;
            StartCoroutine(respawnBallTime());
            DelegateHandler.lifeLost();
        }

    }

    IEnumerator respawnBallTime()
    {
        yield return new WaitForSeconds(respawnTime);
        spawnBall();
    }

    public void addBall()
    {
        numBalls*=2;
        Debug.Log(numBalls);
    }

    void spawnBall()
    {
        ball = Instantiate(Resources.Load("Ball", typeof(GameObject)), new Vector3(paddle.transform.position.x, paddle.transform.position.y +1), new Quaternion()) as GameObject;
        DelegateHandler.respawnBall(ball);
        paddleMovement.setBall(ball);
        numBalls++;
    }
}
