using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickNewScene : MonoBehaviour
{
    public bool isGameOver = false;
    public GameObject textAndCollider;
    private void Start()
    {
        textAndCollider.SetActive(false);
        Invoke("Activate", 1f);
    }

    private void Activate()
    {
        
        textAndCollider.SetActive(true);
    }

    private void OnMouseDown()
    {
        if(!isGameOver)SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
        else SceneManager.LoadScene (0);
    }
}
