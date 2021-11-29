using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    int dirX,dirY;
    Vector2 movement;

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
     
        
        movement = new Vector2(dirX * playerSpeed, playerRigidbody.velocity.y);
    }
    private void FixedUpdate()
    {
        if (GameManagerScript.isGameOn() == true)
        {
            playerRigidbody.velocity = movement;
        }
        else
        {
            playerRigidbody.velocity = Vector2.zero;
        }
    }
}
