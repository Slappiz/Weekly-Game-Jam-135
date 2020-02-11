using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    public Image winScreen = null;
    public Text winText = null;
    public GameObject clickTextObj = null;

    private void Awake()
    {
        GameEvents.LevelCompleted += ActivateScreen;
    }

    private void ActivateScreen()
    {
        Invoke("ActivateImage", 0.5f);
    }

    void ActivateImage()
    {
        winScreen.enabled = true;
        winText.enabled = true;
        Invoke("ActivateClick", 0.5f);
    }

    void ActivateClick()
    {
        clickTextObj.SetActive(true);
    }
    private void OnDestroy()
    {
        GameEvents.LevelCompleted -= ActivateScreen;
    }
}
