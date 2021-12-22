using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private int dirX;

    [SerializeField]
    GameObject startingPoint1;
    [SerializeField]
    GameObject startingPoint2;

    [SerializeField]
    ObjectPoolManager objPool;

    [SerializeField]
    Camera cam;

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
    private bool platformHit;
    [SerializeField]
    private Animator anim;
    Transform playerTransform;
    [SerializeField]
    private Collider2D collid;
    [SerializeField]
    public bool canSwitch = true;
    Rigidbody2D playerRigidbody;
    private int lvl = 1;
    

    void Start()
    {
        playerTransform = GetComponent<Transform>();
        dirX = 1;
        playerRigidbody = GetComponent<Rigidbody2D>();
        if(gm==null)
        {
            GameObject.Find("GameManager");
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            if (lvl == 1)
            {
                gm.TurnOff();
                playerTransform.position = startingPoint1.transform.position;
                objPool.ScreenPlatformClean();
                
            }
            if (lvl == 2)
            {

                gm.TurnOff();
                playerTransform.position = startingPoint2.transform.position;
                objPool.ScreenPlatformClean();
                
            }
        }
        if(gm.isGameOn())
        {
            anim.SetBool("isOn", true);

        }
        else if (gm.isGameOn() == false)
        {
            anim.SetBool("isOn", false);
            dirX = 1;
            playerTransform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
        }
        if (Input.GetButtonDown("Jump") && gm.isGameOn() && CheckGround())
        {
            Debug.Log("Jump");
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
        }
    }
    private void FixedUpdate()
    {
        if (gm.isGameOn() == true && CheckGround())
        {
            playerRigidbody.velocity = new Vector2(dirX * playerSpeed, playerRigidbody.velocity.y);
            
        }
        else if(gm.isGameOn() == false)
        {
            playerRigidbody.velocity = Vector2.zero;
        }
    }

    public void SwitchSides()
    {
        if (canSwitch)
        {
            dirX *= -1;
            playerTransform.localScale = new Vector3(playerTransform.localScale.x * -1, playerTransform.localScale.y, playerTransform.localScale.z);
            canSwitch = false;
            //collid.enabled = false;
        }
    }

    public bool CheckGround()
    {
        return Physics2D.OverlapCircle(groundDetector.position, 0.4f, groundLayer);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "spikes")
        {
            if(lvl == 1)
            {
                playerRigidbody.velocity = Vector2.zero;
                playerTransform.position = startingPoint1.transform.position;
                gm.TurnOff();
                
                objPool.ScreenPlatformClean();
                
            }
            if(lvl == 2)
            {
                playerRigidbody.velocity = Vector2.zero;
                playerTransform.position = startingPoint2.transform.position;
                gm.TurnOff();

                objPool.ScreenPlatformClean();
                
            }
        }
        if (other.gameObject.tag == "finish")
        {
            gm.ChangeGameState();
            playerTransform.position = startingPoint2.transform.position;
            objPool.ScreenPlatformClean();
            gm.isAlive = false;
            cam.transform.position = new Vector3(21.32f, 3.63f, cam.transform.position.z);
            lvl += 1;
            
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "stopX")
        {
            platformHit = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "stopX")
        {
            platformHit = false;
        }
    }
}
