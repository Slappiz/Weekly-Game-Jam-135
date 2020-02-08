using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectilePrefab = null;
    public float projectileForce = 20f;
    public float timeBetweenShots = 1f;

    private void Start()
    {
        InvokeRepeating("Shoot", 1, timeBetweenShots);
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * projectileForce, ForceMode2D.Impulse);
        Destroy(projectile, 5f);
    }
}
