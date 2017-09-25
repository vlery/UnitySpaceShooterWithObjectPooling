using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUIHandler: MonoBehaviour {



    public Button StartNewGameButton;

    public Button HelpButton;
    public GameObject tutorialPanel;

	// Use this for initialization
	void Start () {
        Button btn = StartNewGameButton.GetComponent<Button>();
        btn.onClick.AddListener(StartNewGame);
        HelpButton.onClick.AddListener(processHelpEvent);
        tutorialPanel.SetActive(false);
	}

    void StartNewGame()
    {
        GameObject.Find("SceneManager").GetComponent<SceneLoader>().LoadLevelsScene();
    }

    void processHelpEvent()
    {
        tutorialPanel.GetComponent<Widget_tutorial_panel>().show();
    }
}
