using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{

    CameraOrbit cam;

    // Use this for initialization
    void Start()
    {
        cam = GetComponent<CameraOrbit>();
    }

    // Update is called once per frame
    void Update()
    {
        //SceneManager.GetActiveScene().name;
        //if (input.getkeydown(keycode.alpha9))
        //{
        //    cam.movehorizontal(true);
        //}
        //else if (input.getkeydown(keycode.alpha0))
        //{
        //    cam.movehorizontal(false);
        //}
        //else if (input.getkeydown(keycode.alpha1) || input.getkeydown(keycode.leftarrow))
        //{
        //    cam.movevertical(true);
        //}
        //else if (input.getkeydown(keycode.alpha2) || input.getkeydown(keycode.rightarrow))
        //{
        //    cam.movevertical(false);
        //}


        //if (input.getkeydown(keycode.space))
        //{
        //    scenemanager.loadscene("sprint3", loadscenemode.single); //single vs additive, single will close other scenes, additive will not
        //}

    }
}
