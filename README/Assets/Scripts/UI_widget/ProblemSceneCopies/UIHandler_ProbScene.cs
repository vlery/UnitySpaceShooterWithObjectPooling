using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler_ProbScene : MonoBehaviour
{

    private float startTime;
    private float timeCounter;
    private bool finished = false;
    

    public Widget_timer_ProbScene timer;
    public Widget_camera_rotation_ProbScene cameraRot;

    //public Widget_dynamic_menu dynamicMenu;
    //public Widget_static_menu staticMenu;
    //public Widget_win_popup winPopWnd;
    //public Widget_restart_confirm_popwnd confirmPopWnd;
    //public Widget_lose_popwnd losePopWnd;
    //public Widget_four_direction_operation_ProbScene fourDirMenu;
    //public Widget_layer_operation layerMoveMenu;



    //private Movement movement;

    private CameraOrbit mcamera;
    private Levels levelchecker;
    private SceneLoader sceneloader;
    private SoundManager soundmanager;
    //private Grid grid;


    void initWidget()
    {
        timer.uiHandler = this;
        cameraRot.uiHandler = this;

        //dynamicMenu.uiHandler = this;
        //staticMenu.uiHandler = this;
        //winPopWnd.uiHandler = this;
        //confirmPopWnd.uiHandler = this;
        //losePopWnd.uiHandler = this;
        //fourDirMenu.uiHandler = this;
        //layerMoveMenu.uiHandler = this;
    }
  


    void Awake()
    {
        //movement = GameObject.Find("Player Controlled Cube").GetComponent<Movement>();
        mcamera = GameObject.Find("Main Camera").GetComponent<CameraOrbit>();
        soundmanager = GameObject.Find("Main Camera").GetComponent<SoundManager>();
        sceneloader = GameObject.Find("SceneManager").GetComponent<SceneLoader>();
        //levelchecker = GameObject.Find("Grid").GetComponent<Levels>();
        //grid = GameObject.Find("Grid").GetComponent<Grid>();
    }


    // Use this for initialization
    void Start()
    {
        //refactor
        initWidget();
        //-refactor

        //Initialise timer
        resetTimer();
        //startTime = Time.time;
        soundmanager.playTicToc();
        InvokeRepeating("CountDown", 0.0f, 1.0f);
        InitialiseUI();
    }

    void InitialiseUI()
    {
        ShutDownAll();
        //confirmPopWnd.hide();
        //dynamicMenu.init();
    }

    //DeActivates all UI elements
    void ShutDownAll()
    {
        //confirmPopWnd.hide();
        //winPopWnd.hide();
        //losePopWnd.hide();
    }

    //public void RestartPress()
    //{
    //    ShutDownAll();
    //    confirmPopWnd.show();
    //}
    //public void ConfirmPress()
    //{
    //    ShutDownAll();
    //    //SceneManager.LoadScene("GameplayScene");
    //    GameObject.Find("SceneManager").GetComponent<SceneLoader>().LoadSolutionScene();
    //    //SceneManager.LoadScene("Sprint3");
    //    //Back to main menu
    //}
    //public void SolutionCheckPass()
    //{
    //    ShutDownAll();
    //    winPopWnd.show();
    //    StopTimer();
    //    GameObject.Find("Main Camera").GetComponent<SoundManager>().playWin();
    //}
    //public void SolutionCheckFail()
    //{
    //    ShutDownAll();
    //    losePopWnd.show();
    //    StopTimer();
    //    GameObject.Find("Main Camera").GetComponent<SoundManager>().playLose();
    //}
    //public void CancelPress()
    //{
    //    ShutDownAll();
    //    InitialiseUI();
    //}
    //public void BackPress()
    //{
    //    ShutDownAll();
    //    GameObject.Find("SceneManager").GetComponent<SceneLoader>().LoadMenuScene();
    //    //SceneManager.LoadScene("StartScene");
    //    // Do something else
    //}


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
        timeCounter += Time.deltaTime;
        //amount of time since timer started (in seconds)
        //int t = (int)(startTime - Time.time);
        int t = (int)(startTime -timeCounter);

        string minutes = (t / 60).ToString();
        // limits float to "fx" decimal places
        string seconds = (t % 60).ToString("f0");

        if (t % 60 < 10)
            seconds = "0" + seconds;

        if (t < 15)
            timer.SetTimerTextRed();

        if (t == 0)
        {
            soundmanager.stopTicToc();
            sceneloader.LoadSolutionScene();
        }

        timer.SetTime(minutes, seconds);
        //}
    }
    public void StopTimer()
    {
        finished = true;
    }

    void resetTimer()
    {
        startTime = 30;
        timeCounter = 0;
        Debug.Log("Reset");
    }

    void CountDown()
    {
        timer.CountDown();
    }

    //public void switch2GrabMode()
    //{
    //    dynamicMenu.switch2GrabMode();
    //}
    //public void switch2TileMode()
    //{
    //    dynamicMenu.switch2TileMode();
    //}
    //public void switch2TileModeAdd()
    //{
    //    switch2TileMode();
    //    dynamicMenu.switch2AddMode();
    //}
    //public void switch2TileModeDelete()
    //{
    //    switch2TileMode();
    //    dynamicMenu.switch2DeleteMode();
    //}
    //public void GrabReleasePress()
    //{
    //    movement.GrabRelease();
    //}
    //public void AddDeletePress()
    //{
    //    movement.AddDelete();
    //}

    // Camera Stuff
    public void CameraRotate(bool left)
    {
        //if (left)
        //{
        //    fourDirMenu.rotCameraLeft();
        //}
        //else
        //{
        //    fourDirMenu.rotCameraRight();
        //}

        mcamera.MoveVertical(left);

    }
    //public void CheckPress()
    //{
    //    // @TODO JSON reimplementation
    //    //levelchecker.CheckLevel1Solution();
    //    //if (levelchecker.correctSolution)
    //    //  SolutionCheckPass();       
    //    if (ProblemHandler.checkSolution(grid))
    //    {
    //        SolutionCheckPass();
    //    }
    //    else
    //    {
    //        SolutionCheckFail();
    //    }
    //}
    //// absolutly moving without taking care of rotation
    //public void moveForward()
    //{
    //    movement.MoveForward();
    //}
    //public void moveBack()
    //{
    //    movement.MoveBackward();
    //}
    //public void moveLeft()
    //{
    //    movement.MoveLeft();
    //}
    //public void moveRight()
    //{
    //    movement.MoveRight();
    //}
    //public void move2UpLayer()
    //{
    //    movement.MoveUp();
    //}
    //public void move2DownLayer()
    //{
    //    movement.MoveDown();
    //}
    //public void ReloadProblemScene()
    //{
    //    GameObject.Find("SceneManager").GetComponent<SceneLoader>().LoadProblemScene();
    //}
}
