using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTriggerScript : MonoBehaviour
{

    private PlayerMovement pm;

    private void Start()
    {
        pm = transform.parent.gameObject.GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            Debug.Log("WESZLO");
            pm.SwitchSides();
        }
    }
}
