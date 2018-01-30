using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
    public float speedY;
    public float speedX;
    public Vector3 positionStart;
    public GameObject roof;
    public GameObject floor;
    public GameObject player1;
    public GameObject player2;
    public GameObject wallLeft;
    public GameObject wallRight;
    public GameController gameController;

    // Use this for initialization
    void Start() {
        positionStart = transform.position;
    }

    // Update is called once per frame
    void Update() {
        if (gameController.IsGameRunning)
        {
            transform.position += new Vector3(-speedX * Time.deltaTime, speedY * Time.deltaTime, 0);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == roof || collision.gameObject == floor)
        {
            speedY = -speedY;
        }

        if (collision.gameObject == player1 || collision.gameObject == player2)
        {
            speedX = -speedX;
        }

        if (collision.gameObject == wallLeft)
        {
            gameController.increaseScore(2);
            gameController.IsGameRunning = false;
            transform.position = positionStart;
        }

        if (collision.gameObject == wallRight)
        {
            gameController.increaseScore(1);
            gameController.IsGameRunning = false;
            transform.position = positionStart;
        }
    }
}
