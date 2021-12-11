using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private void Start()
    {
        Vector3 origin = new Vector3(-10, -5, 0);

        Grid grid = new Grid(100, 20, 0.3f,origin); 
    }
}
