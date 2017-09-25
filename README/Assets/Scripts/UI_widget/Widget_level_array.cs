using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Widget_level_array : MonoBehaviour
{
    public GameObject levelItem;
    private int levelIndex = 0;
    GameObject[] levels = new GameObject[3];

    public Widget_level_panel parentPanel;
    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }


    public void addLevel(int levelID,int index,bool ifPlayed,int star)
    {

        GameObject item = Instantiate(levelItem) as GameObject;
        item.transform.SetParent(this.transform);
        item.GetComponent<Widget_level_item>().parentArray = this;
        item.GetComponent<Widget_level_item>().init(levelID,index, ifPlayed, star);
        levels[levelIndex] = item;
        levelIndex++;
    }

    public void startLevel(int levelID)
    {
        parentPanel.startLevel(levelID);
    }
}
