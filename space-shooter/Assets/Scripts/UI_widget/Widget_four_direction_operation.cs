using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Widget_four_direction_operation : MonoBehaviour {
    public UIHandler uiHandler;
    public GameObject operationPanel;
    public Button upButton;
    public Button downButton;
    public Button leftButton;
    public Button rightButton;

  
    public GameObject upOffImage;  
    public GameObject downOffImage;
    public GameObject leftOffImage;
    public GameObject rightOffImage;

    int direction;

	// Use this for initialization
	void Start () {
        //setInitDirection;
        direction = 0;
        setDirection(direction);
        upButton.onClick.AddListener(processUpEvent);
        downButton.onClick.AddListener(processDownEvent);
        leftButton.onClick.AddListener(processLeftEvent);
        rightButton.onClick.AddListener(processRightEvent);
    }
	


    void setDirection(int i)
    {
        // up :0  right :1 down:2 left :3

       
        upOffImage.SetActive(true);
        
        downOffImage.SetActive(true);
        
        leftOffImage.SetActive(true);
      
        rightOffImage.SetActive(true);
        switch (i)
        {
            case 0:
                upOffImage.SetActive(false);
                break;
            case 1:
                rightOffImage.SetActive(false);
                break;
            case 2:
                downOffImage.SetActive(false);
                break;
            case 3:
                leftOffImage.SetActive(false);
                break;
        }
    }


	// Update is called once per frame
	void Update () {
		
	}



    public void rotCameraLeft()
    {
        direction = (direction+1)%4;
        setDirection(direction);
    }
    public void rotCameraRight()
    {
        direction = (direction - 1);
        if (direction < 0)
        {
            direction = direction + 4;
        }
        direction = direction % 4;
        setDirection(direction);
    }


    void processUpEvent()
    {
       uiHandler.moveForward();
        /*
                switch (direction)
                {
                    case 0:
                        uiHandler.moveAbsForward();
                        break;

                    case 1:
                        uiHandler.moveAbsRight();
                        break;
                    case 2:
                        uiHandler.moveAbsBack();
                        break;
                    case 3:
                        uiHandler.moveAbsLeft();
                        break;
                }
        */
    }

    void processDownEvent()
    {
        uiHandler.moveBack();
        /*
        switch (direction)
        {
            case 0:
                uiHandler.moveAbsBack();
                break;

            case 1:
                uiHandler.moveAbsLeft();
                break;
            case 2:
                uiHandler.moveAbsForward();
                break;
            case 3:
                uiHandler.moveAbsRight();
                break;
        }
        */
    }
    void processLeftEvent()
    {
        uiHandler.moveLeft();
        /*
        switch (direction)
        {
            case 0:
                uiHandler.moveAbsLeft();
                break;

            case 1:
                uiHandler.moveAbsForward();
                break;
            case 2:
                uiHandler.moveAbsRight();
                break;
            case 3:
                uiHandler.moveAbsBack();
                break;
        }
        */
    }

    void processRightEvent()
    {
        //Debug.Log("dsds");
        uiHandler.moveRight();
        /*
        switch (direction)
        {
            case 0:
                uiHandler.moveAbsRight();
                break;

            case 1:
                uiHandler.moveAbsBack();
                break;
            case 2:
                uiHandler.moveAbsLeft();
                break;
            case 3:
                uiHandler.moveAbsForward();
                break;
        }
        */
    }


}
