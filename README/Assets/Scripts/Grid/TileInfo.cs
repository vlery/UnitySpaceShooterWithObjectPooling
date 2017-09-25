using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cube;
public class TileInfo:MonoBehaviour {
    Vector3i tileIndex;
  
    public void SetTileIndex(Vector3i tileIndex)
    {
        this.tileIndex = tileIndex;
    }
    public Vector3i GetTileIndex()
    {
        return tileIndex;
    }
}
