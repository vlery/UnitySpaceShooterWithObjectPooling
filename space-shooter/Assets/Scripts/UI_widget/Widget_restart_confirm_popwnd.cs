using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Widget_restart_confirm_popwnd : MonoBehaviour {
    public UIHandler uiHandler;
    public GameObject confirmPanel;
    public GameObject contentPanel;
    public Button confirmButton;
    public Button cancelButton;
    public Text confirmTxt;
    private int eventType;
	// Use this for initialization
	void Start () {
        confirmButton.onClick.AddListener(processConfirmEvent);
        cancelButton.onClick.AddListener(processCancelEvent);
	}
	

    public void show(int type)

    {
        switch (type)
        {
            case 0:  // for restart Request
                confirmTxt.text = "Do you want to give up?";
                break;
            case 1:
                confirmTxt.text = "Are you sure to QUIT?";
                break;
        }
        eventType = type;
        confirmPanel.SetActive(true);
    }

    public void hide()
    {
        confirmPanel.SetActive(false);
    }
	// Update is called once per frame
	void Update () {
		
	}

    void processConfirmEvent()
    {
      uiHandler.ConfirmPress(eventType); 
            

       
       
    }
    void processCancelEvent()
    {
        uiHandler.CancelPress();
    }
}
