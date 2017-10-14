using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateHandler : MonoBehaviour {

    public delegate void ChangeScoreDelegate(int score);
    public static event ChangeScoreDelegate onScoreIncrease;

    public delegate void OnBallDeath();
    public static event OnBallDeath onBallDeath;

    public delegate void OnRespawnBall(GameObject ball);
    public static event OnRespawnBall onRespawnBall;

    public delegate void OnLifeLost();
    public static event OnLifeLost onLifeLost;

    public delegate void OnAddBrick();
    public static event OnAddBrick onAddBrick;

    public delegate void OnSubtractBrick();
    public static event OnSubtractBrick onSubtractBrick;

    public delegate void OnLevelComplete();
    public static event OnLevelComplete onLevelComplete;

    public delegate void OnNewLevel(int level);
    public static event OnNewLevel onNewLevel;


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
	
    public static void lifeLost()
    {
        if(onLifeLost != null)
        {
            onLifeLost();
        }
    }
    public static void addBrick()
    {
        if(onAddBrick != null)
        {
            onAddBrick();
        }
    }
    public static void subtractBrick()
    {
        if(onSubtractBrick!= null)
        {
            onSubtractBrick();
        }
    }
    public static void levelComplete()
    {
        if(onLevelComplete!= null)
        {
            onLevelComplete();
        }
    }
    public static void newLevel(int level)
    {
        if (onNewLevel != null)
        {
            Debug.Log("Passing Message to Generate Level");
            onNewLevel(level);
        }
    }
}
