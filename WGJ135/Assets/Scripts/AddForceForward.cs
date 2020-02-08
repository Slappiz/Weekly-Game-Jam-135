using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceForward : MonoBehaviour
{
    private GameObject marble;
    private Rigidbody2D rb;
    public float forcePower;
    
    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){
        rb.AddForce(transform.up * forcePower, ForceMode2D.Force);
    }
}
