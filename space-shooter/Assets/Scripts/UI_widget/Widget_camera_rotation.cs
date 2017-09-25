using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Widget_camera_rotation : MonoBehaviour {
    public UIHandler uiHandler;
    public Button turnLeftButton;
    public Button turnRightButton;
    public GameObject operationPanel;
	// Use this for initialization
	void Start () {

        turnLeftButton.onClick.AddListener(processTurnLeftEvent);
        turnRightButton.onClick.AddListener(processTurnRightEvent);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void processTurnLeftEvent()
    {
        uiHandler.CameraRotate(true);
    }
    void processTurnRightEvent()
    {
        uiHandler.CameraRotate(false);
    }
}
