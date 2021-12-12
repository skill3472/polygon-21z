using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    private int index;
    [SerializeField]
    private GameObject ObjectManager;
    [SerializeField]
    private int objNumber;
    [SerializeField]
    private GameObject Platform;
    [SerializeField]
    private List<GameObject> objList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < objNumber; i++)
        {

            GameObject platform = Instantiate(Platform);
            objList.Add(platform);
            objList[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlacePlatform(Utility.GetMouseWorldPosition());
        }
    }


    public void PlacePlatform(Vector3 _position)
    {
        objList[0].transform.position = _position;
        objList[0].SetActive(true);
        Debug.Log("Pozdr");
        objList.RemoveAt(0);

    }
}
