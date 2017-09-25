using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cube;
public class Visibilty : MonoBehaviour {

    Grid grid;
    Movement movement;
    Transform ghostCubeTransform;
//    public Material transparentMat;
    public Material transparentMat1;
    public Material transparentMat2;
    public Material occupiedMat;
    public Material gridMat;

    // Use this for initialization
    void Awake()
    {
        grid = GameObject.Find("Grid").GetComponent<Grid>();
        ghostCubeTransform = GameObject.Find("Player Controlled Cube").transform;
        movement = GameObject.Find("Player Controlled Cube").GetComponent<Movement>();
    }
    void Start() {
        //Resize cubes if a 3x3 problem. 2x2 is default setting
        if (grid.GetSize() == 3)
        {
            GameObject.Find("Player Controlled Cube").transform.position = new Vector3(0, .3f, 0);
        }
    }

    // Update is called once per frame
    void Update() {
        //UpdateVisibilityRaycast();

        //make sure grid is visible, i.e depending on size of problem
        if (grid.GetSize() == 3)
        {
            GameObject.Find("Grid").transform.localScale = new Vector3(.6f, .6f, .6f);
            //Debug.LogError("called");
            GameObject.Find("Player Controlled Cube").transform.localScale = new Vector3(.69f, .69f, .69f);
        }

        UpdateVisibilitySlices();
        
    }

    int TileDepth(int i,int j,int k,Vector3i currentTile,Vector3i viewDirection)
    {
        if(viewDirection==new Vector3i(0, 0, 1))
        {
            return Mathf.Max(currentTile.k - k,j-currentTile.j);
        }
        else if (viewDirection==new Vector3i(1, 0, 0))
        {
            return Mathf.Max(currentTile.i - i,j-currentTile.j);
        }
        else if(viewDirection==new Vector3i(0, 0, -1))
        {
            return Mathf.Max(k - currentTile.k,j-currentTile.j);
        }
        else if(viewDirection == new Vector3i(-1, 0, 0))
        {
            return Mathf.Max(i - currentTile.i,j-currentTile.j);
        }
        return -1;
    }

    bool isTileOpaque(int i,int j, int k,Vector3i currentTile,Vector3i viewDirection)
    {
        i += viewDirection.i;
        j -= 1;
        k += viewDirection.k;
        if(viewDirection==new Vector3i(0, 0, 1))
        {
            if (j < currentTile.j && k > currentTile.k)
                return true;
        }
        else if(viewDirection == new Vector3i(1, 0, 0)){
            if (j < currentTile.j && i > currentTile.i)
                return true;
        }
        else if (viewDirection == new Vector3i(0, 0, -1))
        {
            if (j < currentTile.j && k < currentTile.k)
                return true;
        }
        else if (viewDirection == new Vector3i(-1, 0, 0))
        {
            if (j < currentTile.j && i < currentTile.i)
                return true;
        }
            return false;
    }

    void UpdateVisibilitySlices()
    {
        Vector3i viewDirection = movement.forwardVector;
        Vector3i currentTile = movement.GetCurrentTile();
        for (int i = 0; i < grid.GetSize(); i++)
        {
            for (int j = 0; j < grid.GetSize(); j++)
            {
                for (int k = 0; k < grid.GetSize(); k++)
                {
                    if (isTileOpaque(i, j, k, currentTile, viewDirection))
                    {
                        if (grid.GetTile(i, j, k).GetIsOccupied())
                        {
                            grid.GetTile(i, j, k).GetGameObject().GetComponent<Renderer>().material = occupiedMat;
                        }
                        else
                        {
                            grid.GetTile(i, j, k).GetGameObject().GetComponent<Renderer>().material = gridMat;
                        }
                    }
                    else
                    {
                        if (grid.GetTile(i, j, k).GetIsOccupied())
                        {
                            if (TileDepth(i, j, k, currentTile, viewDirection) == 1)
                            {
                                grid.GetTile(i, j, k).GetGameObject().GetComponent<Renderer>().material = transparentMat1;
                            }
                            else if (TileDepth(i, j, k, currentTile, viewDirection) == 2)
                            {
                                grid.GetTile(i, j, k).GetGameObject().GetComponent<Renderer>().material = transparentMat2;
                            }
                            else
                            {
                                grid.GetTile(i, j, k).GetGameObject().GetComponent<Renderer>().material = transparentMat2;
                               // Debug.LogError("Problem with depth:"+ TileDepth(i, j, k, currentTile, viewDirection)+" for "+i+","+k+" and "+currentTile.i+","+currentTile.k);
                            }
                            //grid.GetTile(i, j, k).GetGameObject().GetComponent<Renderer>().material = transparentMat1;
                        }
                    }
                }
            }
        }
        if (movement.isHoldingCube())
        {
            grid.GetTile(currentTile.i,currentTile.j,currentTile.k).GetGameObject().GetComponent<Renderer>().material = occupiedMat;
        }
    }

    void UpdateVisibilityRaycast()
    {
        //set cubes back to normal opacity
        for(int i = 0; i < grid.GetSize(); i++)
        {
            for(int j = 0; j < grid.GetSize(); j++)
            {
                for(int k = 0; k < grid.GetSize(); k++)
                {
                    if (grid.GetTile(i, j, k).GetIsOccupied())
                    {
                        grid.GetTile(i, j, k).GetGameObject().GetComponent<Renderer>().material = occupiedMat;
                    }
                    else
                    {
                        grid.GetTile(i, j, k).GetGameObject().GetComponent<Renderer>().material = gridMat;
                    }
                }
            }
        }
        //make the occluding ones transparent
        RaycastHit[] hits;
        hits=Physics.RaycastAll(transform.position, ghostCubeTransform.position - transform.position);
       for(int i = 0; i < hits.Length; i++)
        {
            Vector3i indices = hits[i].transform.GetComponent<TileInfo>().GetTileIndex();
            if (grid.GetTile(indices.i, indices.j, indices.k).GetIsOccupied())
            {
                //hits[i].transform.GetComponent<Renderer>().material = transparentMat;
            }
        }
    }
}
