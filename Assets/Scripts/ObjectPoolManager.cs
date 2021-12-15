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

    int b = 0;

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
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider.gameObject.tag != "platform" || hit.collider.gameObject.tag != "spikes")
            {
                PlacePlatform(Utility.GetMouseWorldPosition());
            }
        }
    }


    public void PlacePlatform(Vector3 _position)
    {
        _position = new Vector3(_position.x, _position.y, -1);
        if (b >= objNumber)
        {
            b = 0;
        }
        objList[b].transform.position = _position;
        objList[b].SetActive(true);
        Debug.Log("Pozdr");
        b += 1;

    }

    public void ScreenPlatformClean()
    {
        for (int i = 0; i < objNumber; i++)
        {

            objList[i].SetActive(false);
        }
        b = 0;
    }

}
