using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{



    static bool isOn;
    // Start is called before the first frame update
    void Start()
    {
        isOn = false;
        Debug.Log("Press Space to Start");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            ChangeGameState();
        }

        
    }


    public static bool isGameOn()
    {
        return isOn;
    }

    public static void ChangeGameState()
    {
        isOn = !isOn;
    }


}
