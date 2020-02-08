using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    List<Image> hearts =  new List<Image>();
    public Sprite heartFull = null;
    public Sprite heartEmpty = null;
    
    private void Start()
    {
        GameEvents.PlayerDamage += RemoveHeart;
        GameEvents.PlayerHeal += AddHeart;

        foreach (Transform child in transform)
        {
            child.gameObject.GetComponent<Image>().sprite = heartFull;
            hearts.Add(child.gameObject.GetComponent<Image>());
        }
    }

    private void RemoveHeart()
    {
        for (int i = hearts.Count - 1; i >= 0; i--)
        {
            if (hearts[i].sprite == heartFull)
            {
                hearts[i].sprite = heartEmpty;
                break;
            }
        }
    }
    
    private void AddHeart()
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            if (hearts[i].sprite == heartEmpty)
            {
                hearts[i].sprite = heartFull;
                break;
            }
        }
    }

    private void OnDestroy()
    {
        GameEvents.PlayerDamage -= RemoveHeart;
        GameEvents.PlayerHeal -= AddHeart;
    }
}
