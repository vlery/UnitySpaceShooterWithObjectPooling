using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Widget_static_menu : MonoBehaviour {
    public UIHandler uiHandler;
    public Button restartButton;
    public Button backButton;
    public Button checkButton;

    // Use this for initialization
    void Start()
    {
        restartButton.onClick.AddListener(processRestartEvent);
        backButton.onClick.AddListener(processBackEvent);
        checkButton.onClick.AddListener(processCheckEvent);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void processRestartEvent()
    {
        uiHandler.RestartPress();
    }

    void processBackEvent()
    {
        uiHandler.BackPress();
    }


    void processCheckEvent()
    {
        uiHandler.CheckPress();
    }
}
