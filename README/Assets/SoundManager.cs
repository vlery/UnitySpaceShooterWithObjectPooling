using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    private AudioClip backgroundMusic;
    private AudioClip RotateClip;
    private AudioClip MoveClip;
    private AudioClip AddClip;
    private AudioClip DeleteClip;
    private AudioClip WinClip;
    private AudioClip LoseClip;
    private AudioClip TicTocClip;
    private AudioSource backgroundSource;
    private AudioSource FXSource;
    private AudioSource TicTocSource;

    void Awake()
    {
        AudioSource[] sources= GameObject.Find("Main Camera").GetComponents<AudioSource>();
        backgroundSource = sources[0];
        FXSource = sources[1];
        TicTocSource = sources[2];
        RotateClip= Resources.Load("Sounds/RotateSound") as AudioClip;
        MoveClip = Resources.Load("Sounds/MoveSound") as AudioClip;
        AddClip = Resources.Load("Sounds/AddSound") as AudioClip;
        WinClip = Resources.Load("Sounds/WinSound") as AudioClip;
        LoseClip = Resources.Load("Sounds/LoseSound") as AudioClip;
        DeleteClip = Resources.Load("Sounds/RemoveSound") as AudioClip;
        TicTocClip = Resources.Load("Sounds/TimerSound") as AudioClip;
    }
    void Start()
    {
        backgroundSource.clip = backgroundMusic;
        TicTocSource.clip = TicTocClip;
        TicTocSource.loop = true;
        //set the volumes
        float masterVolume = PlayerPrefs.GetFloat("MasterVolume");
        setVolumeBackground(PlayerPrefs.GetFloat("MusicVolume")*masterVolume);
        setVolumeFX(PlayerPrefs.GetFloat("FXVolume") * masterVolume);
    }

    public void playBackGroundMusic()
    {
        backgroundSource.Play();
    }

    public void playRotate()
    {
        FXSource.clip = RotateClip;
        FXSource.Play();
    }
    public void playMove()
    {
        FXSource.clip = MoveClip;
        FXSource.Play();
    }

    public void playAdd()
    {
        FXSource.clip = AddClip;
        FXSource.Play();
    }

    public void playDelete()
    {
        FXSource.clip = DeleteClip;
        FXSource.Play();
    }

    public void playWin()
    {
        FXSource.clip = WinClip;
        FXSource.Play();
    }

    public void playLose()
    {
        FXSource.clip = LoseClip;
        FXSource.Play();
    }

    public void playTicToc()
    {
        TicTocSource.Play();
    }

    public void stopTicToc()
    {
        TicTocSource.Stop();
    }

    public void setVolumeBackground(float normalizedPercent)
    {
        backgroundSource.volume = normalizedPercent;
    }

    public void setVolumeFX(float normalizedPercent)
    {
        FXSource.volume = normalizedPercent;
        TicTocSource.volume = normalizedPercent;
    }
}
