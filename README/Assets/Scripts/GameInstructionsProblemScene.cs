using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstructionsProblemScene : MonoBehaviour
{

    public GameObject[] InstructionsHolder;
    public GameObject[] InstructionsHolder2;
    private int buttonPressed = 0;

    public void instructions()
    {
        //if (buttonPressed == 0)
        //{
        //    for (int i = 0; i < InstructionsHolder.Length; i++)
        //    {
        //        InstructionsHolder[i].SetActive(!InstructionsHolder[i].activeInHierarchy);

        //    }
        //    buttonPressed = buttonPressed + 1;
        //    //}
        //    //}


        //    // public void instructions2()
        //    // {

        //}
        //else if (buttonPressed == 1)
        //{
        //    for (int i = 0; i < InstructionsHolder.Length; i++)
        //    {
        //        InstructionsHolder[i].SetActive(!InstructionsHolder[i].activeInHierarchy);

        //    }
        //    for (int i = 0; i < InstructionsHolder2.Length; i++)
        //    {
        //        InstructionsHolder2[i].SetActive(!InstructionsHolder2[i].activeInHierarchy);
        //    }
        //    buttonPressed = buttonPressed - 1;
        //}
        if (buttonPressed == 0)
        {
            for (int i = 0; i < InstructionsHolder.Length; i++)
            {
                InstructionsHolder[i].SetActive(true);

            }
            if (InstructionsHolder2.Length == 0)
            {
                buttonPressed = buttonPressed + 2;
            }
            else
            {
                buttonPressed = buttonPressed + 1;
            }

        }
        else if (buttonPressed == 1)
        {
            for (int i = 0; i < InstructionsHolder.Length; i++)
            {
                InstructionsHolder[i].SetActive(false);

            }
            for (int i = 0; i < InstructionsHolder2.Length; i++)
            {

                InstructionsHolder2[i].SetActive(true);
            }
            buttonPressed = buttonPressed + 1;
        }
        else if (buttonPressed == 2)
        {
            for (int i = 0; i < InstructionsHolder.Length; i++)
            {
                InstructionsHolder[i].SetActive(false);

            }
            for (int i = 0; i < InstructionsHolder2.Length; i++)
            {

                InstructionsHolder2[i].SetActive(false);
            }
            buttonPressed = buttonPressed - 2;

        }
    }

}
 
