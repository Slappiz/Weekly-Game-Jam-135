using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;
    public SpriteRenderer bodySprite = null;
    
    private void Start()
    {
        currentHealth = maxHealth;
        GameEvents.LevelCompleted += OnWin;
    }

    public void TakeDamage(int damage)
    {
        SetColorFeedback(Color.red);
        SoundManager.instance.Play("TakeDamage");
        GameEvents.OnPlayerDamage();
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            GameEvents.OnGameOver();
            Destroy(this.gameObject);
        }
        
    }

    void OnWin()
    {
        gameObject.tag = "Untagged";
    }

    void SetColorFeedback(Color color)
    {
        bodySprite.color = color;
        Invoke("SetColorWhite", 0.3f);
    }

    void SetColorWhite()
    {
        bodySprite.color = Color.white;
    }
    
    public void HealDamage(int damage)
    {
        SetColorFeedback(Color.green);
        SoundManager.instance.Play("HealDamage");
        GameEvents.OnPlayerHeal();
        currentHealth += damage;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    private void OnDestroy()
    {
        GameEvents.LevelCompleted -= OnWin;
    }
}
