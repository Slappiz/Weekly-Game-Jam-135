using System;
using UnityEngine;

namespace WGJ.Controls
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerAim : MonoBehaviour
    {
        private Camera cam;
        private Vector2 mousePos;
        private Rigidbody2D rb;
        private void Start()
        {
            cam  = Camera.main;
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        private void FixedUpdate()
        {
            Vector2 lookDir = mousePos - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        }
    }
}