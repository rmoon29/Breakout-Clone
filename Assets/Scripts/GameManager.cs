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

    // Use this for initialization
    void Start() {
        
        DelegateHandler.onScoreIncrease += this.IncreaseScore;
        DelegateHandler.onBallDeath += this.ballDeath;
        spawnBall();
    }

    // Update is called once per frame
    void Update() {

    }

    void IncreaseScore(int score)
    {
        gameScore += score;
        Debug.Log(gameScore);
    }

    void ballDeath()
    {
        lives--;
        StartCoroutine(respawnBallTime());

    }

    IEnumerator respawnBallTime()
    {
        yield return new WaitForSeconds(respawnTime);
        spawnBall();
    }

    void spawnBall()
    {
        ball = Instantiate(Resources.Load("Ball", typeof(GameObject)), paddle.transform.position, new Quaternion()) as GameObject;
        paddleMovement.setBall(ball);
        DelegateHandler.respawnBall(ball);
    }
}
