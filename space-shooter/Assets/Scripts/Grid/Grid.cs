using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cube
{
    /*Grid.cs
     * The Grid class holds all information relative to the grid which is encapsulated as a 2D array of Tiles.
     * The functions allocate memory and setup the Tiles taking the size parameter into account.
     * Finally the rendering of the grid is handled here as well.
     */
    public class Grid : MonoBehaviour
    {
        //grid information
        private Tile[,,] tiles;
        private int size = 3;
        private float offset = 1.0f;

        //prefabs for setting up the Tiles
        [SerializeField]
        private GameObject cubePrefab;

        void Awake()
        {
            AllocateGrid(size);
        }

        // Use this for initialization
        void Start()
        {
            SetupGrid(size);
        }

        public void Resize(int size)
        {
            DeleteGrid();
            this.size = size;
            AllocateGrid(size);
            SetupGrid(size);

        }

        void AllocateGrid(int size)
        {
            tiles = new Tile[size, size,size];
        }

        void DeleteGrid()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    for (int k = 0; k < size; k++)
                    {
                        if (tiles[i, j, k] != null)
                        {
                            if (tiles[i, j, k].GetGameObject() != null)
                                Destroy(tiles[i, j, k].GetGameObject());
                            tiles[i, j, k] = null;
                        }
                    }
                }
            }
        }

        void SetupGrid(int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    for (int k = 0; k < size; k++)
                    {
                        GameObject gameObject = Instantiate(cubePrefab, new Vector3(i * offset, (j * offset) + .5f, k * offset), Quaternion.identity);
                        gameObject.transform.parent = this.transform;
                        //add tileinfo to the object
                        TileInfo tInfo = gameObject.AddComponent(typeof(TileInfo)) as TileInfo;
                        tInfo.SetTileIndex(new Vector3i(i, j, k));
                        tiles[i, j, k] = new Tile(gameObject, false);
                    }
                }
            }
        }

        //Getters/Setters
        public void SetActive(int i, int j,int k, bool flag)
        {
            tiles[i, j, k].SetActive(flag);
        }

        public bool GetActive(int i, int j,int k)
        {
            return tiles[i, j, k].GetIsOccupied();
        }

        public Tile GetTile(int i, int j, int k)
        {
            return tiles[i, j,k];
        }

        public int GetSize()
        {
            return size;
        }

        public void SetSize(int size)
        {
            this.size = size;
        }

        public float GetOffset()
        {
            return offset;
        }
    }
}
