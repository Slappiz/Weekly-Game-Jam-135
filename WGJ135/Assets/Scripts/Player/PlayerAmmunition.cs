using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAmmunition : MonoBehaviour
{
    public Star.STAR color;

    private void Start()
    {
        Destroy(this.gameObject, 3f);
    }
}
