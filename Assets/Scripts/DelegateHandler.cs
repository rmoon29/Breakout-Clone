﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateHandler : MonoBehaviour {

    public delegate void ChangeScoreDelegate(int score);
    public static event ChangeScoreDelegate onScoreIncrease;

    public delegate void OnBallDeath();
    public static event OnBallDeath onBallDeath;

    public delegate void OnRespawnBall(GameObject ball);
    public static event OnRespawnBall onRespawnBall;


    public static void increaseScore(int score)
    {
        if (onScoreIncrease != null)
        {
            onScoreIncrease(score);
            
        }
    }

    public static void ballDeath()
    {
        if(onBallDeath != null)
        {
            Debug.Log("Ball dead");
            onBallDeath();
        }
    }

    public static void respawnBall(GameObject ball)
    {
        if(onRespawnBall != null)
        {
            onRespawnBall(ball);
        }
    }
	
}
