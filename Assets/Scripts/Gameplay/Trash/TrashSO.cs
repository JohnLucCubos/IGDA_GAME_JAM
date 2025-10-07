using UnityEngine;

[CreateAssetMenu(fileName = "TrashSO", menuName = "TrashSO", order = 0)]
public class TrashSO : ScriptableObject
{
    public string ItemName;
    public GameObject Prefab;
    public int value;
}