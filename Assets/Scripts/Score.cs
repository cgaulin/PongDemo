using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text playerOne;
    [SerializeField] Text playerTwo;
    [SerializeField] int playerOneScore = 0;
    [SerializeField] int playerTwoScore = 0;


    // Start is called before the first frame update
    void Start()
    {
        playerOne.text = playerOneScore.ToString();
        playerTwo.text = playerTwoScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerWin();
    }

    private void PlayerWin()
    {
        if(playerOneScore == 7)
        {
            Debug.Log("Player One Wins");
        }
        else if (playerTwoScore == 7)
        {
            Debug.Log("Player Two Wins");
        }
    }

    public void AddPlayerOneScore()
    {
        playerOneScore++;
        playerOne.text = playerOneScore.ToString();
        FindObjectOfType<Paddle>().ResetGame();
        FindObjectOfType<Ball>().hasStarted = false;
        FindObjectOfType<Ball>().LaunchBall();
    }

    public void AddPlayerTwoScore()
    {
        playerTwoScore++;
        playerTwo.text = playerTwoScore.ToString();
        FindObjectOfType<Paddle>().ResetGame();
        FindObjectOfType<Ball>().hasStarted = false;
        FindObjectOfType<Ball>().LaunchBall();
    }
}
