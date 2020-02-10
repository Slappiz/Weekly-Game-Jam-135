using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    private void Start()
    {
        PlayMusic();
    }

    void PlayMusic()
    {
        SoundManager.instance.Play(SceneManager.GetActiveScene().name);
    }
    
    void StopMusic()
    {
        SoundManager.instance.Stop(SceneManager.GetActiveScene().name);
    }
}
