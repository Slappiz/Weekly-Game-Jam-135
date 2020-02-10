using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Image gameOverScreen = null;
    public Text gameOverText = null;
    public GameObject clickTextObj = null;

    private void Awake()
    {
        GameEvents.GameOver += ActivateScreen;
    }

    private void ActivateScreen()
    {
        Invoke("ActivateImage", 0.5f);
    }

    void ActivateImage()
    {
        gameOverScreen.enabled = true;
        gameOverText.enabled = true;
        Invoke("ActivateClick", 0.5f);
    }

    void ActivateClick()
    {
        clickTextObj.SetActive(true);
    }
    private void OnDestroy()
    {
        GameEvents.GameOver -= ActivateScreen;
    }
}
