using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpEventHandler : MonoBehaviour {

    public delegate void OnExtendPaddle();
    public static event OnExtendPaddle ExtendPaddle;

    public delegate void OnShrinkPaddle();
    public static event OnShrinkPaddle ShrinkPaddle;

    public delegate void OnBallSpeedIncrease();
    public static event OnBallSpeedIncrease BallSpeedIncrease;

    public delegate void OnBallSpeedDecrease();
    public static event OnBallSpeedDecrease BallSpeedDecrease;

    public delegate void OnDoubleBall();
    public static event OnDoubleBall DoubleBall;

    public delegate void OnShrinkBall();
    public static event OnShrinkBall ShrinkBall;

    public delegate void OnGrowBall();
    public static event OnGrowBall GrowBall;

    public static void extendPaddle()
    {
        if (ExtendPaddle != null)
        {
            ExtendPaddle();
        }
    }
    public static void shrinkPaddle()
    {
        if (ShrinkPaddle != null)
        {
            ShrinkPaddle();
        }
    }
    public static void increaseBallSpeed()
    {
        if (BallSpeedIncrease != null)
        {
            BallSpeedIncrease();
        }
    }
    public static void decreaseBallSpeed()
    {
        if (BallSpeedDecrease != null)
        {
            BallSpeedDecrease();
        }
    }
    public static void doubleBall()
    {
        if (DoubleBall != null)
        {
            DoubleBall();
        }
    }
    public static void shrinkBall()
    {
        if (ShrinkBall != null)
        {
            ShrinkBall();
        }
    }
    public static void growBall()
    {
        if (GrowBall != null)
        {
            GrowBall();
        }
    }



}
