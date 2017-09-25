using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeRotations : MonoBehaviour
{

    public float thresholdRatio;
    public float thresholdLength;
    private Vector3 start;
    private Vector3 end;

    void Start()
    {
        thresholdRatio = 4.0f;
        thresholdLength = 150.0f;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            start = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            end = Input.mousePosition;

            //check if the movement is horizontal (compare xy axis)
            float movementRatio = Mathf.Abs(end.x - start.x) / Mathf.Abs(end.y - start.y);
            //check if movement is long enough
            float length = Mathf.Abs(end.x - start.x);
            //Debug.Log("Length:" + length);
            if (movementRatio > thresholdRatio && length > thresholdLength)
            {
                // Debug.Log("Swipe:"+movementRatio);
                if (start.x > end.x)
                {
                    GameObject.Find("UIController").GetComponent<UIHandler>().CameraRotate(true);
                }
                else
                {
                    GameObject.Find("UIController").GetComponent<UIHandler>().CameraRotate(false);
                }
            }
            else
            {
                // Debug.Log("No swipe:" + movementRatio);
            }
        }
    }
}
