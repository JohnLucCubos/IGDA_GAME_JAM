using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
public class EntityHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    [SerializeField] int currentHealth;
    [SerializeField] float immunityDuration;
    [SerializeField] bool wasDamaged;
    public int getCurrentHealth {get{ return currentHealth; }}

    private void Start()
    {
        currentHealth = maxHealth;
        wasDamaged = false;
    }

    public void AddHealth(int value)
    {
        currentHealth += value;
    }

    public void RemoveHealth(int value)
    {
        if (wasDamaged)
        {
            return;
        }

        currentHealth -= value;

        IsDefeated();
    }

    void IsDefeated()
    {
        if (currentHealth > 0)
        {
            Cooldown();
            return;
        }

        Destroy(gameObject);
    }

    // dictates how long before it can be damaged again
    IEnumerator Cooldown()
    {
        wasDamaged = true;
        yield return new WaitForSeconds(immunityDuration);
        wasDamaged = false;
    }
}
