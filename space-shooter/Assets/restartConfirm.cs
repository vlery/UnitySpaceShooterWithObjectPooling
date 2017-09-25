using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class restartConfirm : MonoBehaviour {
    public Button RestartButton ;
  
    // Use this for initialization
    void Start () {
        Button btn = RestartButton.GetComponent<Button>();
        btn.onClick.AddListener(Confirm);
     

    }
	
	// Update is called once per frame
	void Confirm() {
        //Debug.Log("confirm");
        
		
	}
}
