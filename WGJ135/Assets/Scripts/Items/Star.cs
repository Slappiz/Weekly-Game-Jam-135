using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public enum STAR
    {
        Blue, Red, Yellow, Purple
    }

    public STAR starColor;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player") return;
        switch (starColor)
        {
            case STAR.Blue:
                GameEvents.OnBlueStar();
                break;
            case STAR.Red:
                GameEvents.OnRedStar();
                break;
            case STAR.Yellow:
                GameEvents.OnYellowStar();
                break;
            case STAR.Purple:
                GameEvents.OnPurpleStar();
                break;
            default:
                break;
        }

        Destroy(this.gameObject);
    }
}
