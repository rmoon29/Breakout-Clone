using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    private float speed = 5;
    private Vector3 velocity = new Vector3(0,0,0);
    private Rigidbody2D rb;
    private CircleCollider2D coll;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = velocity;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Wall" || collision.collider.tag == "Brick")
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.normal == new Vector2(0, 1) || contact.normal == new Vector2(0, -1))
                {
                    rb.velocity = new Vector2(rb.velocity.x, (-rb.velocity.y * 1.1f));
                }
                else
                {
                    rb.velocity = new Vector2((-rb.velocity.x * 1.1f), rb.velocity.y);
                }
            }
            if (collision.collider.tag == "Brick")
            {
                Destroy(collision.collider.gameObject);
                DelegateHandler.increaseScore(10);
                
            }
        }
        else if (collision.collider.tag == "Player")
        {
            Vector3 reboundPoint = collision.collider.transform.GetChild(0).transform.position;
            rb.velocity = ((this.transform.position - reboundPoint).normalized) * speed * 1.1f;
        }
        else if (collision.collider.tag == "DeathZone")
        {
            DelegateHandler.ballDeath();
            Destroy(this);

        }
        
    }

    public void LaunchBall()
    {
        velocity = new Vector3(Random.Range(-1f, 1f), 1, 0);
        velocity = velocity.normalized * speed;
        
        rb.velocity = velocity;
    }


}
