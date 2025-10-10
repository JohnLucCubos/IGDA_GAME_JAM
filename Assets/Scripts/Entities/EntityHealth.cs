using Unity.VisualScripting;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    [SerializeField] int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void AddHealth(int value)
    {
        currentHealth += value;
    }

    public void RemoveHealth(int value)
    {
        currentHealth -= value;
        IsDefeated();
    }

    void IsDefeated()
    {
        if (currentHealth > 0)
        {
            return;
        }

        Destroy(gameObject);
    }

}
