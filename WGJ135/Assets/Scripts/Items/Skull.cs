using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : MonoBehaviour
{
    public int damage = 1;

    private void Start()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Invoke("ActivateSkull", 0.5f);
    }

    private void ActivateSkull()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            // Todo: set weaponType
            Destroy(this.gameObject);
        }
    }
}
