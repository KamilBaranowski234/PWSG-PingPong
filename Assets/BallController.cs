using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody2D RB2D;
    public float speed = 2;
    public Vector2 vel;
    public bool gameStarted;
    public ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        RB2D = GetComponent<Rigidbody2D>();
        SendBallToRandomDirection();
        
    }

    private void SendBallToRandomDirection()
    {
        RB2D.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        RB2D.velocity=GenerateRandomVector2Without0(true)*speed;
        vel = RB2D.velocity;
        gameStarted = true;

    }


    private Vector2 GenerateRandomVector2Without0(bool ShouldReturnNormalized)
    {
        Vector2 newVelocity = new Vector2();
        bool ShouldGoRight = Random.Range(1, 100) > 50;
        newVelocity.x = ShouldGoRight ? Random.Range(.7f, .3f) : Random.Range(-.7f, -.3f);
        newVelocity.y = ShouldGoRight ? Random.Range(.7f, .3f) : Random.Range(-.7f, -.3f);
        if (ShouldReturnNormalized)
        return newVelocity.normalized;
        return newVelocity;
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        RB2D.velocity = Vector2.Reflect(vel, collision.contacts[0].normal);
        vel = RB2D.velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.position.x > 0)
            scoreManager.IncrementLeftPlayerScore();
        if (transform.position.x < 0)
           scoreManager.IncrementRightPlayerScore();
        RB2D.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        gameStarted = false;
        
    }

    private void OnAnimatorIK(int layerIndex)
    {
   
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && gameStarted==false)
            SendBallToRandomDirection();
    }

}
