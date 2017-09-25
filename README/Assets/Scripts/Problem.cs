using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Problem{
    [SerializeField]
    public int dimension;

    [SerializeField]
    public tileDataArray2D[] xTiles;

    public void Save(string filename){
        string json_str = JsonUtility.ToJson(this);
        string path = Application.streamingAssetsPath + "/Levels/" + filename;
        //Debug.Log("path is " + path);
    }

    public static Problem Load(string filename)
    {
       
        //Debug.Log("SA is " + Application.streamingAssetsPath);
        string path = Application.streamingAssetsPath + "/Levels/" + filename;
        //Debug.Log("path iz " + path);
        Problem problem;
        try
        {
            //**HACK FOR DEVICES**//
            string json_str;
            if (filename == "Level2x2A.JSON")
                json_str = HardcodedLevels.level1;
            else if (filename == "Level2x2B.JSON")
                json_str = HardcodedLevels.level2;
            else if (filename == "Level2x2C.JSON")
                json_str = HardcodedLevels.level3;
            else if (filename == "Level3x3A.JSON")
                json_str = HardcodedLevels.level4;
            else if (filename == "Level3x3B.JSON")
                json_str = HardcodedLevels.level5;
            else if (filename == "Level3x3C.JSON")
                json_str = HardcodedLevels.level6;
            else
                json_str = HardcodedLevels.level1;
            //**END OF HACK**//
            //string json_str = System.IO.File.ReadAllText(path);
            //Debug.Log("Loaded from " + path);
            problem = JsonUtility.FromJson<Problem>(json_str);
        }
        catch
        {
            problem = null;
        }
        return problem;
    }

    [System.Serializable]
    public struct tileData
    {
        public bool hasCube;
    }

    [System.Serializable]
    public struct tileDataArray
    {
        public tileData[] zTiles;
    }

    [System.Serializable]
    public struct tileDataArray2D
    {
        public tileDataArray[] yTiles;
    }
}
