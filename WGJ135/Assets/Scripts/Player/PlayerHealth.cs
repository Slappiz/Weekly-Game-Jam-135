using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
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

    public void HealDamage(int damage)
    {
        GameEvents.OnPlayerHeal();
        currentHealth += damage;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
            
        }
    }
}
