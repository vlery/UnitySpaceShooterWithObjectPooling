using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    private string problemSceneName="ProblemScene";
    private string solutionSceneName= "GameplayScene";
    private string menuSceneName= "StartScene";
    private string levelsSceneName = "LevelScene";
    private string activeSceneName;
    // Use this for initialization
    void Awake()
    {
        activeSceneName = SceneManager.GetActiveScene().name;
        //Debug.Log(activeSceneName);
    }

    public bool isProblemScene()
    {
        return problemSceneName == activeSceneName;
    }

    public bool isSolutionScene()
    {
        return solutionSceneName == activeSceneName;
    }

    public bool isMenuScene()
    {
        return menuSceneName == activeSceneName;
    }

    public bool isLevelsScene()
    {
        return levelsSceneName == activeSceneName;
    }

    public void LoadProblemScene()
    {
        SceneManager.LoadScene(problemSceneName, LoadSceneMode.Single);
    }

    public void LoadSolutionScene()
    {
        SceneManager.LoadScene(solutionSceneName, LoadSceneMode.Single);
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(menuSceneName, LoadSceneMode.Single);
    }

    public void LoadLevelsScene()
    {
        SceneManager.LoadScene(levelsSceneName, LoadSceneMode.Single);
    }
}
