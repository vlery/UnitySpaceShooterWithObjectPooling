using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Widget_TipPanel : MonoBehaviour {

    public Button bulbButton;
    public Button remainButton;
    public Button closeButton;
    public GameObject panel;
    public GameObject widget;
    public Text text;
    private bool ifShowPanel;
    private int count;
	// Use this for initialization
	void Start () {
        ifShowPanel = false;
        panel.SetActive(ifShowPanel);
        bulbButton.onClick.AddListener(processBulbEvent);
        remainButton.onClick.AddListener(processRemianEvent);
        closeButton.onClick.AddListener(processCloseEvent);
        count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void processBulbEvent()
    {

        ifShowPanel = !ifShowPanel;
        panel.SetActive(ifShowPanel);
        if (ifShowPanel)
        {
            count++;
            text.text = "you have click this " + count + " times";
        }
    }
    public void processRemianEvent()
    {
        ifShowPanel = false;
        panel.SetActive(ifShowPanel);
    }
    public void processCloseEvent()
    {
        widget.SetActive(false);
    }





}
