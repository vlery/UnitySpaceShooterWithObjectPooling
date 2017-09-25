using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Widget_win_popup : MonoBehaviour {
    public UIHandler uiHandler;
    public GameObject winPanel;
    public Button backButton;
    public Button restartButton;
    public Button continueButton;
    public Sprite[] star_imgs;
    public Image starImage;

    public Text msg;
    // Use this for initialization
    void Start () {
        backButton.onClick.AddListener(processBackEvent);
        restartButton.onClick.AddListener(processRestartEvent);
        continueButton.onClick.AddListener(processContinueEvent);
	}
	public void show()
    {
        winPanel.SetActive(true);
    }
    public void hide()
    {
        winPanel.SetActive(false);

    }

    public void setStar(int i)
    {
       
         starImage.sprite = star_imgs[i - 1];
        switch (i)
        {
            case 1:
                msg.text = "Watch out where you place cubes!";
                break;
            case 2:
                msg.text = "Try solving it faster next time!";
                break;
            case 3:
                msg.text = "Perfect!";
                break;
        }
        
    }
	// Update is called once per frame
	void Update () {
		
	}

    void processBackEvent()
    {
        uiHandler.BackPress();
    }
    void processRestartEvent()
    {
        uiHandler.ReloadProblemScene();
    }

    void processContinueEvent()
    {
        uiHandler.ContinueToNextProblem();
    }
}

