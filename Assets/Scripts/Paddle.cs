using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] Ball ball;
    [SerializeField] Paddle playerTwo;
    [SerializeField] float paddleSpeed;
    private Rigidbody2D rb;
    private Vector2 paddlePosition, ballPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        paddlePosition = transform.position;
        ballPosition = ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        VerticalMovment();
        ClampYMovment();
    }

    private void VerticalMovment()
    {
        if(gameObject.name == "Pong Paddle")
        {
            if (Input.GetKey(KeyCode.W))
            {
                Vector2 paddleVelocity = new Vector2(rb.velocity.x, paddleSpeed * Time.deltaTime);
                rb.velocity = paddleVelocity;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                Vector2 paddleVelocity = new Vector2(rb.velocity.x, -paddleSpeed * Time.deltaTime);
                rb.velocity = paddleVelocity;
            }
            else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            {
                rb.velocity = Vector2.zero;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Vector2 paddleVelocity = new Vector2(rb.velocity.x, paddleSpeed * Time.deltaTime);
                rb.velocity = paddleVelocity;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                Vector2 paddleVelocity = new Vector2(rb.velocity.x, -paddleSpeed * Time.deltaTime);
                rb.velocity = paddleVelocity;
            }
            else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
            {
                rb.velocity = Vector2.zero;
            }
        }
    }

    private void ClampYMovment()
    {
        Vector3 clampedPosition = transform.position;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -4.4f, 4.4f);
        transform.position = clampedPosition;
    }

    public void ResetGame()
    {
        transform.position = paddlePosition;
        playerTwo.transform.position = -paddlePosition;
        ball.transform.position = ballPosition;
        FindObjectOfType<Ball>().NoVelocity();
    }
}
