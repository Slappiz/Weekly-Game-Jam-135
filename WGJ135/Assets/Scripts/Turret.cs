using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Spinner spinner;
    public float spinneModifier = 25f;
    [Range(0, 1)]public float fireRateModifier = 0.9f;
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
        BoostCannons();
    }

    private void BoostCannons()
    {
        foreach (var cannon in cannons)
        {
            if (cannon != null)
            {
                Debug.Log("Boosting Cannon");
                cannon.StopShooting();
                cannon.timeBetweenShots *= fireRateModifier;
                cannon.StartShooting();
            }
        }
    }

    private void OnDestroy()
    {
        GameEvents.BlueCannon -= BoostTurret;
        GameEvents.RedCannon -= BoostTurret;
        GameEvents.YellowCannon -= BoostTurret;
        GameEvents.PurpleCannon -= BoostTurret;
    }
}
