using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Spinner spinner;
    public float spinneModifier = 25f;
    public Shooter[] cannons;
    
    private void Start()
    {
        GameEvents.BlueCannon += BoostTurret;
        GameEvents.RedCannon += BoostTurret;
        GameEvents.YellowCannon += BoostTurret;
        GameEvents.PurpleCannon += BoostTurret;
    }

    void BoostTurret()
    {
        spinner.rotationSpeed += spinneModifier;
    }

    private void OnDestroy()
    {
        GameEvents.BlueCannon -= BoostTurret;
        GameEvents.RedCannon -= BoostTurret;
        GameEvents.YellowCannon -= BoostTurret;
        GameEvents.PurpleCannon -= BoostTurret;
    }
}
