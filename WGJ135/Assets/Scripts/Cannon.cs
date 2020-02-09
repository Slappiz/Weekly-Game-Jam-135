using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Star.STAR color;
    public int health = 25;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ammunition")
        {
            Star.STAR ammoColor = other.gameObject.GetComponent<PlayerAmmunition>().color;
            if (ammoColor == color)
            {
                TakeDamage();
                Destroy(other.gameObject);
            }
        }
    }

    private void TakeDamage()
    {
        health -= 1;
        if(health <= 0) Destroy(this.gameObject);
    }
}
