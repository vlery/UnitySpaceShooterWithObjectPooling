using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cube;


public class ScoreCalculator : MonoBehaviour {

    public UIHandler uihandler;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static int StarRater(ProblemHandler.Vec4i score)
    {

        UIHandler uihandler = GameObject.Find("UIController").GetComponent<UIHandler>();
        Grid grid = GameObject.Find("Grid").GetComponent<Grid>();
        int timeThreshold = 60;
        float percent;
        //decides time threshold for 3 stars. 2x2 = 30 seconds. 3x3 = 60 seconds.
        if (grid.GetSize() == 2) timeThreshold = 30;

        //Debug.Log(timeThreshold);

        //FP,FN,TP,TN
        //TP / (TP + FP)
        percent = (float)(score.k) / (float)(score.k + score.i + score.j);

        //Debug.Log(percent);

        //Below 40% is 0 stars
        //Between 40% and 100% is 1 star
        //100% and over the time threshold is 2 stars
        //100% and under the time threshold is 3 stars
        if (percent < .4) return 0;
        if (percent < 1) return 1;
        //if (percent < 1) return 2;
        if (percent == 1 && uihandler.t < timeThreshold) return 3;
        else return 2;

    }

}
