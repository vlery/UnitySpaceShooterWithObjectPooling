using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class SolutionList: MonoBehaviour {
    string path;
    string jsonString; 

    void Start()
    {
        path = Application.streamingAssetsPath + "/Solutions.json";
        jsonString = File.ReadAllText(path);
        Solutions solution = JsonUtility.FromJson<Solutions>(jsonString);
        //Debug.Log(solution.Level);
    }
  
}
[System.Serializable]
public class Solutions
{
    public string Level;
    public int[] Position;
}