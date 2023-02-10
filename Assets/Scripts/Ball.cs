using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private float xVelocity;
    private float offset = 0.5f;
    private bool tick = false;
    public bool hasStarted;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hasStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        xVelocity = rb.velocity.x;
        LaunchBall();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Pong Paddle")
        {
            tick = true;
        }
        else if (other.gameObject.name == "Pong Paddle (1)")
        {
            tick = false;
        }
        else if (other.gameObject.name == "PaddleAI")
        {
            tick = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.name == "Middle Line" && tick)
        {
            rb.velocity = new Vector2(xVelocity + offset, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(xVelocity - offset, rb.velocity.y);
        }
    }

    public void LaunchBall()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !hasStarted)
        {
            rb.velocity = new Vector2(-2f, rb.velocity.y);
            hasStarted = true;
        }
    }

    public void NoVelocity()
    {
        rb.velocity = Vector2.zero;
    }
}
