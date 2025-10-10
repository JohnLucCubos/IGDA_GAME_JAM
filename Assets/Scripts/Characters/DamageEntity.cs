using UnityEngine;

public class DamageEntity : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Entity")
        {
            return;
        }
        int damage = SwarmManager.Instance.getAnchovySwarmSize + 1;
        collision.gameObject.GetComponent<EntityHealth>().RemoveHealth(damage);
    }
}
