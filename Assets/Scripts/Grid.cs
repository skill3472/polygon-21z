using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Grid 
{
    private int width;
    private int height;
    private float cellSize;
    private int[,] gridArray;
    private TextMesh[,] debugTextArray;

    public Grid(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridArray = new int[width, height];
        debugTextArray = new TextMesh[width, height];
        
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for(int y = 0; y < gridArray.GetLength(1); y++)
            {
                // rysuje grida w scenie, docelowo grid ma siê wyœwietlaæ tylko tam gdzie jest kursor ( pojedyncza komórka grida, ¿eby gracz wiedzia³ gdzie stawia klocek)
                debugTextArray[x,y] =  Utility.CreateWorldText(gridArray[x, y].ToString(), null, GetWorldPosition(x,y) + new Vector3(cellSize,cellSize) * 0.5f, 10, Color.white, TextAnchor.MiddleCenter);
                
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f); //Rysuje ramki grida
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);

            }

            Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);  // Rysuje dolna i gorna kreske grida xd do poprawienia bo dla pojedynczych komorek nie bêdzie dzia³a³o w ten sposób chyba
            Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
        }

        SetValue(2, 1, 56);

    }


    public void SetValue(int x, int y, int value)       //Ustawia wartoœæ danej komórki grida, bedzie przydatne przy ustalanie gdzie jaki klocek jest postawiony
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
            debugTextArray[x, y].text = gridArray[x, y].ToString();
        }
    }

    public void SetValue(Vector3 worldPosition, int value)  //Bierze worldposition i sprawdza czy jest w gridzie, jezeli tak to zmienia wartosc w danej komorce
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }


    private void GetXY(Vector3 worldPosition, out int x,out int y) // Zmienia surowy worldposition na x i y
    {
        x = Mathf.FloorToInt(worldPosition.x / cellSize);
        y = Mathf.FloorToInt(worldPosition.y / cellSize);
    }
    

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }



}
