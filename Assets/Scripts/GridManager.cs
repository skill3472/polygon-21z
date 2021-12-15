using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    private Vector3 origin;
    private Grid grid;
    private void Start()
    {

        grid = new Grid(100, 20, 0.3f,origin); 
    }

    private void Update()
    {
        
    }
}
