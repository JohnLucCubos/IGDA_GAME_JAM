using UnityEngine;

public class AnchovySpawner : MonoBehaviour
{
    [SerializeField] GameObject anchovyPrefab;
    public void OnClick()
    {
        Instantiate(anchovyPrefab);
    }
}
