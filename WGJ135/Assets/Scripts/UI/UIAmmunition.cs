using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAmmunition : MonoBehaviour
{
    List<Image> ammoSlots =  new List<Image>();
    public Sprite ammoPurple = null;
    public Sprite ammoRed = null;
    public Sprite ammoYellow = null;
    public Sprite ammoBlue = null;
    public Sprite ammoEmpty = null;

    private Sprite currentSprite;
    private void Start()
    {
        GameEvents.PlayerShoot += RemoveAmmo;
        GameEvents.BlueStar += SetAmmoTypeBlue;
        GameEvents.RedStar += SetAmmoTypeRed;
        GameEvents.YellowStar += SetAmmoTypeYellow;
        GameEvents.PurpleStar += SetAmmoTypePurple;
        
        currentSprite = ammoEmpty;
        
        foreach (Transform child in transform)
        {
            child.gameObject.GetComponent<Image>().sprite = currentSprite;
            ammoSlots.Add(child.gameObject.GetComponent<Image>());
        }
    }

    private void RemoveAmmo()
    {
        for (int i = ammoSlots.Count - 1; i >= 0; i--)
        {
            if (ammoSlots[i].sprite == currentSprite)
            {
                ammoSlots[i].sprite = ammoEmpty;
                break;
            }
        }
    }
    
    private void AddAmmo()
    {
        foreach (Image ammoSlot in ammoSlots)
        {
            ammoSlot.sprite = currentSprite;
        }
    }

    private void OnDestroy()
    {
        GameEvents.PlayerShoot -= RemoveAmmo;
        GameEvents.BlueStar -= SetAmmoTypeBlue;
        GameEvents.RedStar -= SetAmmoTypeRed;
        GameEvents.YellowStar -= SetAmmoTypeYellow;
        GameEvents.PurpleStar -= SetAmmoTypePurple;
    }

    private void SetAmmoTypeRed()
    {
        currentSprite = ammoRed;
        AddAmmo();
    }
    
    private void SetAmmoTypeBlue()
    {
        currentSprite = ammoBlue;
        AddAmmo();
    }
    
    private void SetAmmoTypeYellow()
    {
        currentSprite = ammoYellow;
        AddAmmo();
    }
    
    private void SetAmmoTypePurple()
    {
        currentSprite = ammoPurple;
        AddAmmo();
    }
}
