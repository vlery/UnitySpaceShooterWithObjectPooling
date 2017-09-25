using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
    public GameObject menuholder;
    public GameObject settingmenuholder;
    public Slider[] VolumeSliders;
    public Toggle[] ScreenResolution;
  
    public void Start()
    {
        VolumeSliders[0].normalizedValue = PlayerPrefs.GetFloat("MasterVolume",1.0f);
        VolumeSliders[1].normalizedValue = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        VolumeSliders[2].normalizedValue = PlayerPrefs.GetFloat("FXVolume", 0.5f);
    }
    public void settingsmenu()
    {
        menuholder.SetActive(false);
        settingmenuholder.SetActive(true);
    }

    public void mainmenu()
    {
        menuholder.SetActive(true);
        settingmenuholder.SetActive(false);
    }

    public void setFullscreen(bool isFullscreen)
    {

    }
    public void setMasterVolume(float value)
    {
        //Debug.Log("value is " + value);
        PlayerPrefs.SetFloat("MasterVolume", value);
       // AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Master);
    }
    public void setMusicVolume(float value)
    {
        PlayerPrefs.SetFloat("MusicVolume", value);
      //  AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Music);
    }
    public void setSoundFXVolume(float value)
    {
        PlayerPrefs.SetFloat("FXVolume", value);
      //  AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.SoundFx);
    }


   


}
