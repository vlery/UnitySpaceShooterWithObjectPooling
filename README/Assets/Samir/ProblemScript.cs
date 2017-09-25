using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cube;
public class ProblemScript : MonoBehaviour
{

    public Tile[,] grid;
    private Vector3[,] gridVertices;
    [System.NonSerialized]
    public int size = 5;
    public float offset = 1.0f;

    LineRenderer lineRenderer;
    private Vector3[] linePoints;
    private int linePointsSize = 0;

    private GameObject cube;
    private GameObject solCube;

    //private List<PlacedCube> Cubes;

    public GameObject cubePrefab;

    void Awake()
    {
        cube = GameObject.Find("Player Controlled Cube");
        solCube = GameObject.Find("Puzzle Cube");
        lineRenderer = GetComponent<LineRenderer>();
        AllocateGrid(size);
    }

    // Use this for initialization
    void Start()
    {
        SetupGrid(size);
        Level1();
    }



    // Update is called once per frame
    void Update()
    {
    }


    void Render()
    {

    }

    public void Resize(int size)
    {
        AllocateGrid(size);
        SetupGrid(size);
    }

    void AllocateGrid(int size)
    {
        grid = new Tile[size, size];
        gridVertices = new Vector3[size + 1, size + 1];
        linePointsSize = 4 + size * 2 + (size % 2 == 0 ? 1 : 0) + 1 + size * 2;
        linePoints = new Vector3[linePointsSize];
    }

    void SetupGrid(int size)
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                GameObject gameObject = Instantiate(cubePrefab, new Vector3(i * offset, offset * 0.5f, j * offset), Quaternion.identity);
                gameObject.SetActive(false);
                grid[i, j] = new Tile(gameObject, false);
            }
        }

        Vector3 startingPoint = new Vector3(-offset * 0.5f, 0, -offset * 0.5f);
        for (int i = 0; i < size + 1; i++)
        {
            for (int j = 0; j < size + 1; j++)
            {
                gridVertices[i, j] = startingPoint + new Vector3(i * offset, 0, j * offset);
            }
        }

        lineRenderer.widthMultiplier = 0.1f;
        lineRenderer.numPositions = linePointsSize;
        //Debug.Log(gridVertices);

        int imax = size + 1;
        int jmax = size + 1;

        linePoints[0] = gridVertices[0, 0];
        linePoints[1] = gridVertices[imax - 1, 0];
        linePoints[2] = gridVertices[imax - 1, jmax - 1];
        linePoints[3] = gridVertices[0, jmax - 1];

        int index = 4;

        for (int i = 0; i < imax - 1; i++)
        {
            int j = i % 2 == 0 ? 0 : jmax - 1;

            linePoints[index++] = gridVertices[i, j];
            linePoints[index++] = gridVertices[i + 1, j];

        }

        if (size % 2 == 0)
            linePoints[index++] = gridVertices[imax - 1, 0];
        linePoints[index++] = gridVertices[0, 0];
        for (int j = 0; j < jmax - 1; j++)
        {
            int i = j % 2 == 0 ? 0 : imax - 1;
            linePoints[index++] = gridVertices[i, j];
            linePoints[index++] = gridVertices[i, j + 1];
        }
        lineRenderer.SetPositions(linePoints);

        //Give it access to the cubes
        GameObject PuzzleCubes = GameObject.Find("Puzzle Cubes");
    }

    void Level1()
    {
        int Level1size = 4;
        size = Level1size;
        Resize(size);
        grid[0, 1].SetActive(true);
        grid[0, 2].SetActive(true);
        grid[0, 2].SetActive(true);
    }
}
