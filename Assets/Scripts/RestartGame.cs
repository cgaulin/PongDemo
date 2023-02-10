using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(gameObject.name == "Left Wall")
        {
            FindObjectOfType<Score>().AddPlayerTwoScore();
        }
        else
        {
            FindObjectOfType<Score>().AddPlayerOneScore();
        }
    }
}
