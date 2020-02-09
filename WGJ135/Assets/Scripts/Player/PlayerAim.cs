using System;
using UnityEngine;

namespace WGJ.Controls
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PlayerGun))]
    public class PlayerAim : MonoBehaviour
    {
        private Camera cam;
        private Vector2 mousePos;
        private Rigidbody2D rb;
        private PlayerGun gun;
        private float fireCooldwon = 0.25f;
        private float timeSinceLastShot = 0f;
        
        private void Start()
        {
            cam  = Camera.main;
            rb = GetComponent<Rigidbody2D>();
            gun = GetComponent<PlayerGun>();
        }

        private void Update()
        {
            timeSinceLastShot += Time.deltaTime;
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                gun.Shoot();
                timeSinceLastShot = 0f;
            }
        }

        private void FixedUpdate()
        {
            Vector2 lookDir = mousePos - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        }
    }
}