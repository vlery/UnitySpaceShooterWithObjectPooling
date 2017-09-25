using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Cube;
public class UIHandler : MonoBehaviour
{

    private float startTime;
    private bool finished = false;

    //refactor

    public Widget_timer timer;
    public Widget_dynamic_menu dynamicMenu;
    public Widget_static_menu staticMenu;
    public Widget_win_popup winPopWnd;
    public Widget_restart_confirm_popwnd confirmPopWnd;
    public Widget_camera_rotation cameraRot;
    public Widget_lose_popwnd losePopWnd;
    public Widget_four_direction_operation fourDirMenu;
    public Widget_layer_operation layerMoveMenu;

    //test for star rating
    public int t;

    private Movement movement;
    private CameraOrbit mcamera;
    private Levels levelchecker;
    private Grid grid;


    void initWidget()
    {
        timer.uiHandler = this;
        dynamicMenu.uiHandler = this;
        staticMenu.uiHandler = this;
        winPopWnd.uiHandler = this;
        confirmPopWnd.uiHandler = this;
        cameraRot.uiHandler = this;
        losePopWnd.uiHandler = this;
        fourDirMenu.uiHandler = this;
        layerMoveMenu.uiHandler = this;
    }
    //-refactor


    void Awake()
    {
        movement = GameObject.Find("Player Controlled Cube").GetComponent<Movement>();
        mcamera = GameObject.Find("Main Camera").GetComponent<CameraOrbit>();
        levelchecker = GameObject.Find("Grid").GetComponent<Levels>();
        grid = GameObject.Find("Grid").GetComponent<Grid>();
    }
    
    // Use this for initialization
    void Start()
    {
        //refactor
        initWidget();
        //-refactor

        //Initialise timer
        startTime = Time.time;
        InvokeRepeating("CountDown", 0.0f, 1.0f);
        InitialiseUI();
    }

    void InitialiseUI()
    {
        ShutDownAll();
        confirmPopWnd.hide();
        dynamicMenu.init();
    }

    //DeActivates all UI elements
    void ShutDownAll()
    {
        confirmPopWnd.hide();
        winPopWnd.hide();
        losePopWnd.hide();
    }

    public void RestartPress()
    {
        ShutDownAll();
        confirmPopWnd.show(0);
    }

    public void ConfirmPress(int type)
    {
        if (type == 0)
        {
            ShutDownAll();
            GameObject.Find("SceneManager").GetComponent<SceneLoader>().LoadSolutionScene();
        }else if (type == 1)
        {

            ShutDownAll();
            GameObject.Find("SceneManager").GetComponent<SceneLoader>().LoadMenuScene();
        }
        //Back to main menu
    }

    public void SolutionCheckPass(int stars)
    {
        ShutDownAll();
        
        winPopWnd.show();
        winPopWnd.setStar(stars);
        Levels.SaveProgress(stars);
       // PlayerPrefs.DeleteAll();
        //winPopWnd.
        StopTimer();
        GameObject.Find("Main Camera").GetComponent<SoundManager>().playWin();
    }

    public void SolutionCheckFail()
    {
        ShutDownAll();

        losePopWnd.show();
        StopTimer();
        GameObject.Find("Main Camera").GetComponent<SoundManager>().playLose();
    }


    public void CancelPress()
    {
        ShutDownAll();

        InitialiseUI();
    }

    public void BackPress()
    {

        confirmPopWnd.show(1);
        // Do something else
    }


    // Update is called once per frame
    void Update()
    {
        //Timer related
        if (finished)
            return;

        UpdateTimer();
    }


    private void UpdateTimer()
    {
        //if(!finished)
        //{
        //amount of time since timer started (in seconds)
        //int t = (int)(Time.time - startTime);
        t = (int)(Time.time - startTime);

        //Debug.Log(t);
        string minutes = (t / 60).ToString();
            // limits float to "fx" decimal places
            string seconds = (t % 60).ToString("f0");


            if (t % 60 < 10)
                seconds = "0" + seconds;

                //timer.CountDown();

            timer.SetTime(minutes, seconds);
        //}
    }
    public void StopTimer()
    {
        finished = true;
    }

    void CountDown()
    {
        timer.CountDown();
    }


    public void switch2GrabMode()
    {
        dynamicMenu.switch2GrabMode();
    }
    public void switch2TileMode()
    {
        dynamicMenu.switch2TileMode();
    }

    public void switch2TileModeAdd()
    {

        switch2TileMode();
        dynamicMenu.switch2AddMode();
    }

    public void switch2TileModeDelete()
    {
        switch2TileMode();
        dynamicMenu.switch2DeleteMode();
    }

    public void GrabReleasePress()
    {
        movement.GrabRelease();
    }

    public void AddDeletePress()
    {
        movement.AddDelete();
    }

    // Camera Stuff
    public void CameraRotate(bool left)
    {
        if (left)
        {
            fourDirMenu.rotCameraLeft();
        }else
        {
            fourDirMenu.rotCameraRight();
        }

        mcamera.MoveVertical(left);
        
    }

    public void CheckPress()
    {          
        ProblemHandler.Vec4i score;
        ProblemHandler.checkSolution(grid,out score);
        int stars=ScoreCalculator.StarRater(score);
        if (stars>0)
        {
            SolutionCheckPass(stars);
        }
        else
        {
            SolutionCheckFail();
        }
    }

    // absolutly moving without taking care of rotation
    public void moveForward()
    {
        movement.MoveForward();
    }

    public void moveBack()
    {
        movement.MoveBackward();
    }

    public void moveLeft()
    {
        movement.MoveLeft();
    }
    public void moveRight()
    {
        movement.MoveRight();
    }

    public void move2UpLayer()
    {
        movement.MoveUp();
    }

    public void move2DownLayer()
    {
        movement.MoveDown();
    }

    public void ReloadProblemScene()
    {
        GameObject.Find("SceneManager").GetComponent<SceneLoader>().LoadProblemScene();
    }

    public void ContinueToNextProblem()
    {
        Levels.LoadNextLevel();
    }
}
