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
        if (other.gameObject.tag == "Player")
        {
            if (starColor == STAR.Blue)
            {
                GameEvents.OnBlueStar();
            }else if (starColor == STAR.Red)
            {
                GameEvents.OnRedStar();
            }else if (starColor == STAR.Yellow)
            {
                GameEvents.OnYellowStar();
            }else if (starColor == STAR.Purple)
            {
                GameEvents.OnPurpleStar();
            }
            
            Destroy(this.gameObject);
        }
    }
}
