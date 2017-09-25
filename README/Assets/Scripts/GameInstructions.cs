using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstructions : MonoBehaviour {
    private string camInst = "";

    private bool show = false;

    // Use this for display your text on monitor
    void Start()
    {
        camInst = "";
        camInst += "- Click The Arrows to Move the Controller Cube ";
        camInst += "- and other instrusction\n";
       camInst += "- touch monitor with your head 2 play game\n";
       camInst += "\n iff you read this text you rule dude \n";

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {

        if (GUI.Button(new Rect(Screen.width - 720, 40, 35, 35), "!"))
        {
            show = !show;
        }

        if (show) GUI.Label(new Rect(Screen.width - 680, 50, 300, 500), camInst);
    }
}
