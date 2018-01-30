using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour{
    public int player1Points;
    public int player2Points;
    private bool isGameRunning;
    public GameObject ball;
    public PlayerMovement player1;
    public PlayerMovement player2;
    public Text player1Score;
    public Text player2Score;
    public Text gameOver;
    public bool isGameOver;
    public GameObject[] particles;

    public void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !isGameRunning)
        {
            isGameRunning = true;
            if (isGameOver)
            {
                isGameOver = false;
                player1Points = 0;
                player2Points = 0;
                player1Score.text = player1Points.ToString();
                player2Score.text = player2Points.ToString();
                gameOver.gameObject.SetActive(false);
                particles.ToList().ForEach(particle => particle.SetActive(false));
            }
        }
    }

    public bool IsGameRunning {
        get
        {
            return isGameRunning;
        }
        set
        {
            if(value == false)
            {
                StopMovement();
            }
            else
            {
                StartMovement();
            }
        }
    }

    public void StartMovement()
    {
        isGameRunning = true;
        ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation|RigidbodyConstraints.FreezePositionZ;
    }

    public void StopMovement()
    {
        isGameRunning = false;
        player1.resetPosition();
        player2.resetPosition();
        ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition|RigidbodyConstraints.FreezeRotation;
    }

    public void OnAwake()
    {
        isGameRunning = false;
        isGameOver = false;
    }

    public void increaseScore(int player)
    {
        if (player == 1)
        {
            player1Points++;
            player1Score.text = player1Points.ToString();
        }
        else
        {
            player2Points++;
            player2Score.text = player2Points.ToString();
        }

        if(player1Points >=3 || player2Points >= 3)
        {
            gameOver.gameObject.SetActive(true);
            isGameOver = true;
            particles.ToList().ForEach(particle => particle.SetActive(true));
        }
    }
}
