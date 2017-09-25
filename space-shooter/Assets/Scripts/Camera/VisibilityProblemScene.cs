using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cube;
public class VisibilityProblemScene : MonoBehaviour
{

    Grid grid;
    Movement movement;
    Transform ghostCubeTransform;
    public Material transparentMat;
    public Material occupiedMat;
    public Material gridMat;

    // Use this for initialization
    void Awake()
    {
        grid = GameObject.Find("Grid").GetComponent<Grid>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //make sure grid is visible, i.e depending on size of problem
        //Only has condition for size = 3, presumes size 2 is default and that there is no size greater than 3. 
        //Can easily be changed to incorporate larger cubes
        if (grid.GetSize() == 3)
        {
            GameObject.Find("Grid").transform.localScale = new Vector3(.6f, .6f, .6f);
        }
    }

}
