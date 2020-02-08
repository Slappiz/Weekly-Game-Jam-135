﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpinner : MonoBehaviour
{
    public float rotationSpeed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, 1f) * rotationSpeed * Time.fixedDeltaTime);
    }
}
