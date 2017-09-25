using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Widget_dynamic_menu : MonoBehaviour {
    public UIHandler uiHandler;
    public GameObject tilemode_panel;
    public GameObject grabmode_panel;
    public Button createNewButton;
    public Button grabButton;
    public Button deleteButton;
    public Button releaseButton;

	// Use this for initialization
	void Start () {
        createNewButton.onClick.AddListener(processCreateNewEvent);
        grabButton.onClick.AddListener(processGrabEvent);
        deleteButton.onClick.AddListener(processDeleteEvent);
        releaseButton.onClick.AddListener(processReleaseEvent);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
   public  void init()
    {
        switch2TileMode();
    }

   
    void processCreateNewEvent()
    {
        uiHandler.AddDeletePress();
    }
    void processGrabEvent()
    {
        uiHandler.GrabReleasePress();
    }
    void processDeleteEvent()
    {
        uiHandler.AddDeletePress();
    }
    void processReleaseEvent()
    {
        uiHandler.GrabReleasePress();
    }

    public void switch2GrabMode()
    {
        grabmode_panel.SetActive(true);
        tilemode_panel.SetActive(false);
    }

    public void switch2TileMode()
    {
        grabmode_panel.SetActive(false);
        tilemode_panel.SetActive(true);
    }

    public void switch2AddMode()
    {
        createNewButton.GetComponentInChildren<Text>().text = "ADD";
    }

    public void switch2DeleteMode()
    {
        createNewButton.GetComponentInChildren<Text>().text = "DELETE";
    }
}
