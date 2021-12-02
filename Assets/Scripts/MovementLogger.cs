using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
public class MovementLogger : MonoBehaviour
{
    [Header("In-game stuff")]
    private float timeRemaining;
    [SerializeField] private float timeStep;
    private int i;
    [SerializeField]
    private GameManagerScript gm;
    public List<float> movementLogY = new List<float>();
    public List<float> movementLogTime = new List<float>();
    private bool isLogging;
    private float timer = 0;
    [Space]
    [Header("System stuff")]
    [SerializeField] private string fileName;
    private string endFileName;

    // Start is called before the first frame update
    void Start()
    {
        if (gm == null)
        {
            GameObject.Find("GameManager");
        }
        timeRemaining = timeStep;
        isLogging = false;
        endFileName = Application.dataPath + "/" + fileName + ".csv";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && !isLogging && gm.isGameOn() == true) // Dodano sprawdzanie czy gra jest aktywna
        {
            Debug.Log("REC");
            isLogging = true;
            timer = 0;
        }

        if(timeRemaining > 0 && isLogging)
        {
            timeRemaining -= Time.deltaTime;
        }
        else if(isLogging)
        {
            timeRemaining = timeStep;
            movementLogY.Add(transform.position.y);
            movementLogTime.Add(timer);
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            SaveToFile();
        }
        timer += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isLogging = false;
        Debug.Log("STOP");
    }

    private void SaveToFile()
    {
        TextWriter tw = new StreamWriter(endFileName, false);
        tw.WriteLine("Time:Y");
        tw.Close();
        DataNormalizing();

        tw = new StreamWriter(endFileName, true);
        for (int i = 0; i < movementLogY.Count; i++)
        {
            tw.WriteLine(movementLogTime[i].ToString() + ":" + movementLogY[i].ToString());     //Zmieni³em znak podzielenia na :
        }
        tw.Close();
        Debug.Log("SAVED TO FILE");
    }

    private void DataNormalizing()      // Normalizuje funkcje by rysowa³a siê powy¿ej 0
    {
        float yMin = Mathf.Abs(movementLogY.AsQueryable().Min());
        float tMin = Mathf.Abs(movementLogTime.AsQueryable().Min());

        for (i=0; i < movementLogY.Count();i++)
        {
            movementLogY[i] += yMin;
            movementLogTime[i] += tMin;
        }
    }
}
