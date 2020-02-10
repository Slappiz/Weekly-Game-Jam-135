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
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            SoundManager.instance.Play(SceneManager.GetActiveScene().name);
        }
    }
}
