using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectilePrefab = null;
    public float projectileForce = 20f;
    public float timeBetweenShots = 1f;
    public CannonColor color = 0;

    public enum CannonColor
    {
        Blue, Red, Purple, Yellow
    }
    
    private void Start()
    {
        InvokeRepeating("Shoot", 1, timeBetweenShots);
    }

    public void StartShooting()
    {
        InvokeRepeating("Shoot", 0.1f, timeBetweenShots);
    }

    public void StopShooting()
    {
        CancelInvoke("Shoot");
    }

    private void PlayCannonSound()
    {
        switch (color)
        {
            case CannonColor.Blue:
                SoundManager.instance.Play("Cannon_Blue");
                break;
            case CannonColor.Red:
                SoundManager.instance.Play("Cannon_Red");
                break;
            case CannonColor.Yellow:
                SoundManager.instance.Play("Cannon_Yellow");
                break;
            case CannonColor.Purple:
                SoundManager.instance.Play("Cannon_Purple");
                break;
            default:
                break;
        }
    }

    public void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        projectile.transform.localRotation = transform.localRotation;
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * projectileForce, ForceMode2D.Impulse);
        Destroy(projectile, 5f);
        PlayCannonSound();
    }
}
