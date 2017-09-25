using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cube;

namespace KeyInput
{
    /*KeyboardInput.cs
     * This class handles input signals from the keyboard.
     */
    public class KeyboardInput : MonoBehaviour
    {
        private Movement movement;
        private CameraOrbit cameraOrbit;
        private SceneLoader sceneLoader;
        //private bool isInGamePlay = true;

        void Awake()
        {
            sceneLoader = GameObject.Find("SceneManager").GetComponent<SceneLoader>();
            if (sceneLoader.isSolutionScene())
            {
                movement = GameObject.Find("Player Controlled Cube").GetComponent<Movement>();
            }
            if (sceneLoader.isProblemScene() || sceneLoader.isSolutionScene())
            {
                cameraOrbit = GameObject.Find("Main Camera").GetComponent<CameraOrbit>();
            }
        }


        void Update()
        {

            //GameObject camera = GameObject.Find("Main Camera (1)");
            //Debug.Log("" + camera.transform.forward);

            //Input to move the cube
            if (sceneLoader.isSolutionScene())
            {
                if (Input.GetKeyDown(KeyCode.W)/*||Input.GetKeyDown(KeyCode.UpArrow)*/)
                {
                    movement.MoveForward();
                }
                if (Input.GetKeyDown(KeyCode.S) /*|| Input.GetKeyDown(KeyCode.DownArrow)*/)
                {
                    movement.MoveBackward();
                }
                if (Input.GetKeyDown(KeyCode.A) /*|| Input.GetKeyDown(KeyCode.LeftArrow)*/) //Left/Right arrow keys now move camera
                {
                    movement.MoveLeft();
                }
                if (Input.GetKeyDown(KeyCode.D) /*|| Input.GetKeyDown(KeyCode.RightArrow)*/)
                {
                    movement.MoveRight();
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    movement.MoveUp();
                }
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    movement.MoveDown();
                }
                if (Input.GetKeyDown(KeyCode.P))
                {
                    //"save to JSON a problem"
                    ProblemHandler.setProblem(GameObject.Find("Grid").GetComponent<Grid>());
                    ProblemHandler.saveProblem("Saved"+ System.DateTime.Now.ToString("yyyyMMddHHmmssfff")+".JSON");
                }
            }
            //Input to move the camera
            if (sceneLoader.isSolutionScene() || sceneLoader.isProblemScene())
            {
                if (Input.GetKeyDown(KeyCode.Alpha9))
                {
                    cameraOrbit.MoveHorizontal(true);
                }
                else if (Input.GetKeyDown(KeyCode.Alpha0))
                {
                    cameraOrbit.MoveHorizontal(false);
                }
                else if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    cameraOrbit.MoveVertical(true);
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    cameraOrbit.MoveVertical(false);
                }
            }
            //Input to change scenes
            if (sceneLoader.isProblemScene())
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    sceneLoader.LoadSolutionScene();
                }
            }


        }
    }
}
