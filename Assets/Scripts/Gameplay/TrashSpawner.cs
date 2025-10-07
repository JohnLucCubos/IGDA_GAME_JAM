using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    [SerializeField] List<TrashSO> trashList = new List<TrashSO>();
    [SerializeField] int duration;
    [SerializeField] int Magnitude;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() => StartCoroutine(Cooldown());

    IEnumerator Cooldown()
    {
        do
        {
            yield return new WaitForSeconds(duration);

            int getIndex = Random.Range(0, trashList.Count);
            GameObject trash = Instantiate(trashList[getIndex].Prefab);

            int value = trashList[getIndex].value;
            trash.GetComponent<Consumable>().MicroplasticValue = value;

            float randomFloatRange = Random.Range(-10f, 10f);
            Vector3 direction = new Vector3(0, 0, randomFloatRange);

            trash.GetComponent<Rigidbody>().AddForce(direction * Magnitude, ForceMode.Impulse);
        } while (true);
    }
}
