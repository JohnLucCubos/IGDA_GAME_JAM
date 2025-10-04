using UnityEngine;

public class Consumable : MonoBehaviour
{
    [SerializeField] int microplasticValue;
    public int GetValue { get {return microplasticValue;} private set {microplasticValue = value;}}
}
