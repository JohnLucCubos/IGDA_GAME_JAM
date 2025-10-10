using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            return;
        }
        SwarmManager.Instance.DeleteAnchovy(collision.transform.gameObject);
    }
}
