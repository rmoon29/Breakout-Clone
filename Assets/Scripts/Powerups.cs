using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Powerups : MonoBehaviour {
    
    // Use this for initialization
    Powerup powerup;
    public Sprite[] sprites;
    private float speed = 1f;
    private SpriteRenderer sprite;
	void Start () {
        powerup = (Powerup)Random.Range(0, 6);
        sprite = GetComponent<SpriteRenderer>();
        GetSprite(powerup.enumToInt());
        DelegateHandler.onLifeLost += this.DestroyPowerup;
    }
	

	// Update is called once per frame
	void Update () {
        this.transform.Translate(0, -speed * Time.deltaTime, 0);

	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag == "Player")
        {
            switch (powerup)
            {
                case Powerup.ExtendPaddle:
                    PowerUpEventHandler.extendPaddle();                   
                    break;
                case Powerup.ShrinkPaddle:
                    PowerUpEventHandler.shrinkPaddle();
                    break;
                case Powerup.BallSpeedUp:
                    PowerUpEventHandler.increaseBallSpeed();
                    break;
                case Powerup.BallSlowDown:
                    PowerUpEventHandler.decreaseBallSpeed();
                    break;
                case Powerup.DoubleBall:
                    PowerUpEventHandler.doubleBall();
                    break;                    
                case Powerup.ShrinkBall:
                    PowerUpEventHandler.shrinkBall();
                    break;
                case Powerup.GrowBall:
                    PowerUpEventHandler.growBall();
                    break;               
            }

            DestroyPowerup();

        }
        if (coll.collider.tag == "KillZone")
        {
            DestroyPowerup();
        }
    }
    void DestroyPowerup()
    {
        DelegateHandler.onLifeLost -= this.DestroyPowerup;
        Destroy(this.gameObject);
    }
    void GetSprite(int spriteNum)
    {
        sprite.sprite = sprites[spriteNum];
    }

}

public static class PowerupEnumInfo
{
    public static int enumToInt(this Powerup self)
    {
        switch (self)
        {
            case Powerup.ExtendPaddle:
                return 0;
            case Powerup.ShrinkPaddle:
                return 1;
            case Powerup.BallSpeedUp:
                return 2;
            case Powerup.BallSlowDown:
                return 3;
            case Powerup.DoubleBall:
                return 4;
            case Powerup.ShrinkBall:
                return 5;
            case Powerup.GrowBall:
                return 6;               
        }
        return 0;
    }
}
public enum Powerup
{
    ExtendPaddle, ShrinkPaddle, BallSpeedUp,
    BallSlowDown, DoubleBall, ShrinkBall, GrowBall
}
