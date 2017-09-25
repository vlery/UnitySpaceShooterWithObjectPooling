using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Widget_question_menu : MonoBehaviour {

    public Button nextQuesButton;
    public Button confirmButton;
    public Button backButton;
    
	// Use this for initialization
	void Start () {
        nextQuesButton.onClick.AddListener(processNextQuesEvent);
        confirmButton.onClick.AddListener(processConfirmEvent);
        backButton.onClick.AddListener(processBackEvent);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void processNextQuesEvent()
    {
        Levels.LoadNextLevel();
    }
    void processConfirmEvent()
    {
        GameObject.Find("SceneManager").GetComponent<SceneLoader>().LoadSolutionScene();
    }

    void processBackEvent()
    {
        GameObject.Find("SceneManager").GetComponent<SceneLoader>().LoadMenuScene();
    }
}
