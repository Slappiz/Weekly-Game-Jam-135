using System;
using UnityEngine;

namespace WGJ.Controls
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        public float moveSpeed = 5;
        private Rigidbody2D rb;
        private Vector2 movement;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }

        private void FixedUpdate()
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}