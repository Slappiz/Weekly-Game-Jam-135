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
    public float timeUntilActive = 5f;

    private int cannonsDestroyed = 0;
    
    private void Start()
    {
        GameEvents.BlueCannon += BoostTurret;
        GameEvents.RedCannon += BoostTurret;
        GameEvents.YellowCannon += BoostTurret;
        GameEvents.PurpleCannon += BoostTurret;
        
        Invoke("StartTurret", timeUntilActive);
    }

    void StartTurret()
    {
        foreach (Shooter cannon in cannons)
        {
            if (cannon != null) cannon.StartShooting();
        }
    }

    void BoostTurret()
    {
        cannonsDestroyed++;
        if(cannonsDestroyed <= 4) GameEvents.OnLevelCompleted();
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
