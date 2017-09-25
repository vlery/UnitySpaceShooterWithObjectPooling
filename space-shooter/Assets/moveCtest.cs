using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCtest : MonoBehaviour {
    public Camera camera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Vector3 v = camera.transform.position;
            v.y = v.y + 1;
            camera.transform.position = v;
        }


    }
}
