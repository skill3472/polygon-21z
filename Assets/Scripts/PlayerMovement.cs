using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private int dirX;

   [SerializeField]
    private float playerSpeed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private GameManagerScript gm;
    [SerializeField]
    private LayerMask groundLayer;
    bool isGrounded;
    [SerializeField]
    private Transform groundDetector;

    Rigidbody2D playerRigidbody;
    

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        if(gm==null)
        {
            GameObject.Find("GameManager");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //default kierunek
        dirX = 1;
        isGrounded = Physics2D.OverlapCircle(groundDetector.position, 0.15f, groundLayer);
        if (Input.GetButtonDown("Jump") && gm.isGameOn() && isGrounded)
        {
            Debug.Log("Jump");
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
        }
    }
    private void FixedUpdate()
    {
        if (gm.isGameOn() == true)
        {
            playerRigidbody.velocity = new Vector2(dirX * playerSpeed, playerRigidbody.velocity.y);
        }
        else
        {
            playerRigidbody.velocity = Vector2.zero;
        }
    }
}
