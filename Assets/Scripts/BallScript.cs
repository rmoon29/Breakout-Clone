using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    public float speed = 5;
    public Vector3 velocity = new Vector3(0,0,0);
    private Rigidbody2D rb;
    private CircleCollider2D coll;
    private int scoreMultiplier = 1;
    private int blockHitScore = 10;
    private AudioSource audio;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = velocity;
        EventSupscriptions();
        audio = GetComponent<AudioSource>();
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnDestroy()
    {
        EventUnsupscriptions();
    }

    void DestroyBall()
    {
        DelegateHandler.ballDeath();
        Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        audio.Play();
        if (collision.collider.tag == "Wall" || collision.collider.tag == "Brick")
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.normal == new Vector2(0, 1) || contact.normal == new Vector2(0, -1))
                {
                    rb.velocity = new Vector2(rb.velocity.x, (-rb.velocity.y));
                }
                else
                {
                    rb.velocity = new Vector2((-rb.velocity.x), rb.velocity.y);
                }
            }
            if (collision.collider.tag == "Brick")
            {
                Destroy(collision.collider.gameObject);
                DelegateHandler.increaseScore(blockHitScore * scoreMultiplier);
                scoreMultiplier++;
                DelegateHandler.subtractBrick();
                
            }
        }
        else if (collision.collider.tag == "Player")
        {
            Vector3 reboundPoint = collision.collider.transform.GetChild(0).transform.position;
            //Debug.Log(reboundPoint);
            rb.velocity = ((this.transform.position - reboundPoint).normalized) * rb.velocity.magnitude;
            //Debug.Log(rb.velocity);
            scoreMultiplier = 1;
        }
        else if (collision.collider.tag == "KillZone")
        {
            DestroyBall();

        }
        rb.velocity *= 1.01f;
        
    }

    public void LaunchBall()
    {
        velocity = new Vector3(Random.Range(-1f, 1f), 1, 0);
        velocity = velocity.normalized * speed;
        
        rb.velocity = velocity;
    }

    public void DoubleBall()
    {
        GameObject newBall = Instantiate(Resources.Load("Ball", typeof(GameObject)), new Vector3(this.transform.position.x, this.transform.position.y), new Quaternion()) as GameObject;
        
        if (newBall != null)
        {
            BallScript newBS = newBall.GetComponent<BallScript>();
            newBS.velocity = new Vector3(-this.velocity.x, this.velocity.y);
            newBS.speed = this.speed;
        }
    }

    void IncreaseBallSpeed()
    {
        rb.velocity = rb.velocity * 1.5f;
    }
    void DecreaseBallSpeed()
    {
        rb.velocity = rb.velocity * 0.75f;
    }
    void growBall()
    {
        this.transform.localScale = new Vector3(this.transform.localScale.x * 1.5f, this.transform.localScale.y * 1.5f);
    }
    void shrinkBall()
    {
        this.transform.localScale = new Vector3(this.transform.localScale.x * 0.75f, this.transform.localScale.y * 0.75f);
    }
    void EventSupscriptions()
    {
        PowerUpEventHandler.DoubleBall += this.DoubleBall;
        PowerUpEventHandler.BallSpeedIncrease += this.IncreaseBallSpeed;
        PowerUpEventHandler.BallSpeedDecrease += this.DecreaseBallSpeed;
        PowerUpEventHandler.GrowBall += this.growBall;
        PowerUpEventHandler.ShrinkBall += this.shrinkBall;
        DelegateHandler.onLevelComplete += this.DestroyBall;
    }

    void EventUnsupscriptions()
    {
        PowerUpEventHandler.DoubleBall -= this.DoubleBall;
        PowerUpEventHandler.BallSpeedIncrease -= this.IncreaseBallSpeed;
        PowerUpEventHandler.BallSpeedDecrease -= this.DecreaseBallSpeed;
        PowerUpEventHandler.GrowBall -= this.growBall;
        PowerUpEventHandler.ShrinkBall -= this.shrinkBall;
        DelegateHandler.onLevelComplete -= this.DestroyBall;
    }


}
