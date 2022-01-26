using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{


    [SerializeField]
    private bool isOn;
    public bool isAlive = false;
    // Start is called before the first frame update
    void Start()
    {
        isOn = false;
        Debug.Log("Press Space to Start");
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOn() == false)
        {

            if (Input.GetButtonDown("Cancel"))
            {
                ChangeGameState();
                
            }

        }
    }


    public bool isGameOn()
    {
        return isOn;
    }

    public void ChangeGameState()
    {
        isOn = !isOn;
        
    }

    public void TurnOff()
    {
        isOn = false;
    }


}
