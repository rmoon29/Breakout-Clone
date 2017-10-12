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
        spawnBall();

    }

    IEnumerator respawnBallTime()
    {
        yield return new WaitForSeconds(2);
    }

    void spawnBall()
    {
        ball = Instantiate(Resources.Load("Ball", typeof(GameObject)), new Vector3(5, 5, 5), new Quaternion()) as GameObject;
        paddleMovement.setBall(ball);
        DelegateHandler.respawnBall();
    }
}
