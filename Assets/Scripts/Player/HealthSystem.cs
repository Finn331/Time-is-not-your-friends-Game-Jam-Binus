using System.Collections;
using UnityEngine;
using TMPro;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public TextMeshProUGUI healthText; // Reference to the TextMeshPro component for displaying health

    private void Start()
    {
        currentHealth = maxHealth;

        if (healthText != null)
        {
            UpdateHealthText();
        }

        StartCoroutine(ReduceHealthOverTime());
    }

    private IEnumerator ReduceHealthOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f); // Wait for 1 minute

            // Reduce health by 1 every minute
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthText(); // Update the displayed health text

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player has died!");
        // Add any additional actions upon death
    }

    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = currentHealth.ToString();
        }
    }
}
