using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [Header("Gun Settings")]
    public int ammoOnPickUp = 10;
    public Transform ammoSpawnPosition = null;
    public float projectileForce = 10f;
    public int ammoCount;
    public SpriteRenderer gunSprite = null;
    
    [Header("Ammunition Prefabs")]
    public GameObject redAmmoPrefab = null;
    public GameObject blueAmmoPrefab = null;
    public GameObject yellowAmmoPrefab = null;
    public GameObject purpleAmmoPrefab = null;

    private GameObject activeAmmo = null;

    private void Start()
    {
        ammoCount = 0;
        OutOfAmmo();
        
        GameEvents.RedStar += SetRedAmmo;
        GameEvents.BlueStar += SetBlueAmmo;
        GameEvents.YellowStar += SetYellowAmmo;
        GameEvents.PurpleStar += SetPurpleAmmo;
    }

    void SetRedAmmo()
    {
        SetAmmo();
        activeAmmo = redAmmoPrefab;
        gunSprite.color = Color.red;
    }
    
    void SetBlueAmmo()
    {
        SetAmmo();
        activeAmmo = blueAmmoPrefab;
        gunSprite.color = Color.blue;
    }
    
    void SetYellowAmmo()
    {
        SetAmmo();
        activeAmmo = yellowAmmoPrefab;
        gunSprite.color = Color.yellow;
    }
    
    void SetPurpleAmmo()
    {
        SetAmmo();
        activeAmmo = purpleAmmoPrefab;
        gunSprite.color = Color.magenta;
    }
    
    public void Shoot()
    {
        if (ammoCount == 0) return;
        
        GameObject projectile = Instantiate(activeAmmo, transform.position, transform.rotation);
        projectile.transform.localRotation = transform.localRotation;
        if (ammoSpawnPosition) projectile.transform.position = ammoSpawnPosition.position;
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * projectileForce, ForceMode2D.Impulse);
        Destroy(projectile, 5f);

        ammoCount -= 1;
        OutOfAmmo();
    }

    void SetAmmo()
    {
        ammoCount = ammoOnPickUp;
    }

    void OutOfAmmo()
    {
        if(ammoCount <= 0) gunSprite.color = Color.white;
    }

    private void OnDestroy()
    {
        GameEvents.RedStar -= SetRedAmmo;
        GameEvents.BlueStar -= SetBlueAmmo;
        GameEvents.YellowStar -= SetYellowAmmo;
        GameEvents.PurpleStar -= SetPurpleAmmo;
    }
}
