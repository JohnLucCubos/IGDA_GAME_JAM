using UnityEngine;

public class PlayerConsume : MonoBehaviour
{
    [SerializeField]
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "Consumable")
        {
            return;
        }
        int value = other.gameObject.GetComponent<Consumable>().MicroplasticValue;
        GameManager.Instance.AddMicroplastics(value);
        Destroy(other.gameObject);
    }
}
