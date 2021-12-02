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
    [SerializeField]
    private Transform groundDetector;

    Rigidbody2D playerRigidbody;
    

    void Start()
    {
        dirX = 1;
        playerRigidbody = GetComponent<Rigidbody2D>();
        if(gm==null)
        {
            GameObject.Find("GameManager");
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && gm.isGameOn() && CheckGround())
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

    public void SwitchSides()
    {
        if(CheckGround())
        dirX *= -1;
    }

    public bool CheckGround()
    {
        return Physics2D.OverlapCircle(groundDetector.position, 0.15f, groundLayer);
    }
}
