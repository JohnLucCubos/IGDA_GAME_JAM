using UnityEngine;

public class Consumable : MonoBehaviour
{
    [SerializeField] int microplasticValue;

    public int MicroplasticValue
    {
        get
        {
            return microplasticValue;
        }
        set
        {
            microplasticValue = value;
        }
    }

}
