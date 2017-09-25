using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Widget_tutorial_panel : MonoBehaviour {
    public Button closeButton;
    public Button nextButton;
    public Button preButton;
    public GameObject wholePanel;
    public GameObject[] panels;
    private int crtPanel;
	// Use this for initialization
	void Start () {
        init();
        // wholePanel.SetActive(false);
        closeButton.onClick.AddListener(processCloseEvent);
        preButton.onClick.AddListener(processPreEvent);
        nextButton.onClick.AddListener(processNextEvent);

	}
	

    public void show()
    {
        init();
        wholePanel.SetActive(true);
    }

    void init()
    {
        crtPanel = 0;

        foreach (GameObject go in panels)
        {
            go.SetActive(false);
        }
        panels[crtPanel].SetActive(true);
        preButton.gameObject .SetActive(false);
    }
	// Update is called once per frame
	void Update () {
		
	}


    void processCloseEvent()
    {
        wholePanel.SetActive(false);
    }

    void processPreEvent()
    {
        panels[crtPanel].SetActive(false);
        crtPanel = 0;
        preButton.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(true);
        panels[crtPanel].SetActive(true);

    }

    void processNextEvent()
    {
        panels[crtPanel].SetActive(false);
        crtPanel = 1;
        preButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(false);
        panels[crtPanel].SetActive(true);
    }
}
