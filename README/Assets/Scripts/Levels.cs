using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cube;
public class Levels : MonoBehaviour
{
    Grid grid;
    public bool isInGamePlay;

    private static int Level1ID = 1;
    private static int Level2ID = 2;
    private static int Level3ID = 3;
    private static int Level4ID = 4;
    private static int Level5ID = 5;
    private static int Level6ID = 6;

    private static string Level1Filename = "Level2x2A.JSON";
    private static string Level2Filename = "Level2x2B.JSON";
    private static string Level3Filename = "Level2x2C.JSON";
    private static string Level4Filename = "Level3x3A.JSON";
    private static string Level5Filename = "Level3x3B.JSON";
    private static string Level6Filename = "Level3x3C.JSON";
    private static int selectedLevelID = -1;
    private void Awake()
    {
        grid = GetComponent<Grid>();
    }
    void Start()
    {
        selectedLevelID = PlayerPrefs.GetInt("selectedLevel");
        if (selectedLevelID == Level1ID)
        {
            ProblemHandler.loadProblem(Level1Filename);
        }
        else if (selectedLevelID == Level2ID)
        {
            ProblemHandler.loadProblem(Level2Filename);
        }
        else if (selectedLevelID == Level3ID)
        {
            ProblemHandler.loadProblem(Level3Filename);
        }
        else if (selectedLevelID == Level4ID)
        {
            ProblemHandler.loadProblem(Level4Filename);
        }
        else if (selectedLevelID == Level5ID)
        {
            ProblemHandler.loadProblem(Level5Filename);
        }
        else if (selectedLevelID == Level6ID)
        {
            ProblemHandler.loadProblem(Level6Filename);
        }
        else
        {
            ProblemHandler.loadProblem(Level1Filename);
            //Debug.Log("could not find a legit player preference so the first scene is loading");
        }
        grid.Resize(ProblemHandler.GetProblemSize());
        GameObject.Find("Main Camera").GetComponent<CameraOrbit>().UpdatePivot(ProblemHandler.GetProblemSize(), grid.GetOffset());
        if (!isInGamePlay)
        {
            ProblemHandler.setGrid(grid);
        }
    }

    public static int getLevelID(int levelNum)
    {
        switch (levelNum)
        {
            case 1:
                return Level1ID;
            case 2:
                return Level2ID;
            case 3:
                return Level3ID;
            case 4:
                return Level4ID;
            case 5:
                return Level5ID;
            case 6:
                return Level6ID; 
            default:
                return -1;
        }
    }

    public static void LoadLevel(int levelID)
    {
        PlayerPrefs.SetInt("selectedLevel", levelID);
        PlayerPrefs.Save();
        GameObject.Find("SceneManager").GetComponent<SceneLoader>().LoadProblemScene();
    }

    public static void LoadNextLevel()
    {
        if (selectedLevelID == Level1ID)
        {
            selectedLevelID = Level2ID;
        }
        else if (selectedLevelID == Level2ID)
        {
            selectedLevelID = Level3ID;
        }
        else if(selectedLevelID == Level3ID)
        {
            selectedLevelID = Level4ID;
        }
        else if(selectedLevelID == Level4ID)
        {
            selectedLevelID = Level5ID;
        }
        else if(selectedLevelID == Level5ID)
        {
            selectedLevelID = Level6ID;
        }
        else if(selectedLevelID == Level6ID)
        {
            selectedLevelID = Level1ID;
        }
        LoadLevel(selectedLevelID);
    }

    public static void SaveProgress(int stars)
    {
        string key = Level1Filename;
        if(selectedLevelID == Level2ID)
        {
            key = Level2Filename;
        }
        else if (selectedLevelID == Level3ID)
        {
            key = Level3Filename;
        }
        else if (selectedLevelID == Level4ID)
        {
            key = Level4Filename;
        }
        else if (selectedLevelID == Level5ID)
        {
            key = Level5Filename;
        }
        else if (selectedLevelID == Level6ID)
        {
            key = Level6Filename;
        }
        key += ".stars";
        if (PlayerPrefs.GetInt(key,0)<stars)
        {
            PlayerPrefs.SetInt(key, stars);
        }
    }

    public static int GetStars(int levelID)
    {
        string key = Level1Filename;
        if (levelID == Level2ID)
        {
            key = Level2Filename;
        }
        else if (levelID == Level3ID)
        {
            key = Level3Filename;
        }
        else if (levelID == Level4ID)
        {
            key = Level4Filename;
        }
        else if (levelID == Level5ID)
        {
            key = Level5Filename;
        }
        else if (levelID == Level6ID)
        {
            key = Level6Filename;
        }
        key += ".stars";
        return PlayerPrefs.GetInt(key, 0);
    }

   // public static 
}
