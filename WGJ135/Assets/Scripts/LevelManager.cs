using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.sceneLoaded += PlayMusic;
        SceneManager.sceneUnloaded += StopMusic;
    }

    void PlayMusic(Scene current, LoadSceneMode single)
    {
        SoundManager.instance.Play(current.name);
    }
    
    void StopMusic(Scene current)
    {
        SoundManager.instance.Stop(current.name);
    }
}
