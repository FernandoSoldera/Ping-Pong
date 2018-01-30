using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed;
    public bool isPlayer1;
    public GameController gameController;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.IsGameRunning)
        {
            MovePlayer();
        }
    }

    void MovePlayer()
    {
        if (isPlayer1)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                MovePlayerDown();
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                MovePlayerUp();
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.S))
            {
                MovePlayerDown();
            }

            if (Input.GetKey(KeyCode.W))
            {
                MovePlayerUp();
            }
        }
    }

    void MovePlayerUp()
    {
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);
    }

    void MovePlayerDown()
    {
        transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
    }

    public void resetPosition()
    {
       transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }
}
