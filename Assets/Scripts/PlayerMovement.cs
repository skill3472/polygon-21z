using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    int dirX,dirY;
    Vector3 movement;

   [SerializeField]
    float playerSpeed;

    Rigidbody playerRigidbody;
    

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        dirX = 0;
        dirY = 0;

        //default kierunek
        dirX = 1;

        
        movement = new Vector3(dirX * playerSpeed, dirY * playerSpeed, 0);
    }
    private void FixedUpdate()
    {
        if (GameManagerScript.isGameOn() == true)
        {
            playerRigidbody.velocity = movement;
        }
        else
        {
            playerRigidbody.velocity = Vector3.zero;
        }
    }
}
