using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTriggerScript : MonoBehaviour
{

    private PlayerMovement pm;
    [SerializeField]
    private Collider2D collid;
    
    private float timer = 0;
    [SerializeField]
    private float toTime;

    private void Start()
    {
        pm = transform.parent.gameObject.GetComponent<PlayerMovement>();
    }


    private void Update()
    {
        if(collid.enabled == false)
        {
            
            if (timer < toTime)
            {
                timer += Time.deltaTime;
                //Debug.Log(timer);
            }
            else
            {
                collid.enabled = true;
                timer = 0;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            Debug.Log("WESZLO");
            pm.SwitchSides();
            collid.enabled = false;
        }
    }


   
}
