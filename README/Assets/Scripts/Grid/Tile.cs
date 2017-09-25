using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cube
{
    /*Tile.cs
     * The Tile class is responsible for holding all information relative to the cells of the grid.
     * The isOccupied flag refers to whether the cell is occupied by a cube while the GameObject is used to render that cell.
     * The isOccupied cannot be replaced by the Active state of the GameObject since there are cases where the move is grabbed and moved around
     * (the flag is false and the GameObject is Active). 
     */
    public class Tile
    {
        private GameObject gameObject;
        private bool isOccupied;

        private Material emptyMaterial;
        private Material occupiedMaterial;

        public Tile(GameObject gameObject, bool isOccupied)
        {
            this.gameObject = gameObject;
            this.isOccupied = isOccupied;

            emptyMaterial = Resources.Load("Materials/EmptyTile") as Material;
            occupiedMaterial = Resources.Load("Materials/OccupiedTile") as Material;
            gameObject.GetComponent<Renderer>().material = emptyMaterial;
        }


        public void SetActive(bool flag)
        {
            if (flag)
            {
                gameObject.GetComponent<Renderer>().material = occupiedMaterial;
            }
            else
            {
                gameObject.GetComponent<Renderer>().material = emptyMaterial;
            }
            isOccupied = flag;
        }

        public void SetGameObject(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public GameObject GetGameObject()
        {
            return gameObject;
        }

        public void SetIsOccupied(bool flag)
        {
            isOccupied = flag;
        }

        public bool GetIsOccupied()
        {
            return isOccupied;
        }



    }
}