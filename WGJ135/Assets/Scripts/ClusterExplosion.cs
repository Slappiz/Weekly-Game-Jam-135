using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClusterExplosion : MonoBehaviour
{
    public GameObject projectilePrefab = null;
    public bool destroyOnExplosion = true;
    public float timeToDetonate = 1f;
    public int numberOfProjectiles = 6;
    public float radius = 1f;
    public float projectileForce = 5f;
    private void Start()
    {
        Invoke("Explode", timeToDetonate);
    }

    private void Explode()
    {
        float angleStep = 360f / numberOfProjectiles;
        float angle = 0f;
        
        Vector2 startpos = new Vector2(this.transform.position.x, this.transform.position.y);
        for (int i = 0; i < numberOfProjectiles; i++)
        {
            float DirX = startpos.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float DirY = startpos.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;
            
            Vector2 projectileVector =  new Vector2(DirX, DirY);
            Vector2 projectileMoveDirection = (projectileVector - startpos).normalized * projectileForce;
            
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.transform.position = this.transform.position;
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);
            angle += angleStep;
            Debug.Log("cluster projectile spawned");
        }   
        if(destroyOnExplosion) Destroy(this.gameObject);
    }
}
