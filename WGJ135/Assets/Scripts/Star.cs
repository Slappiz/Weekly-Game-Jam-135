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
            //other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            // Todo: set weaponType
            Destroy(this.gameObject);
        }
    }
}
