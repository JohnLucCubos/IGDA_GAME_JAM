using System.Collections;
using MyUnity.Utilities;
using UnityEngine;

public class CrabSpawner : MonoBehaviour
{
    [SerializeField] GameObject crabPrefab;
    [SerializeField] GameObject player;
    [SerializeField] float timer;
    [SerializeField] string bossTheme;
    [SerializeField] GameObject GameWinUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameWinUI.SetActive(false);
        StartCoroutine(Countdown());
    }

    void SpawnCrab()
    {
        Vector3 spawnPosition = new Vector3(4f, transform.position.y, transform.position.z);
        GameObject newCrab = Instantiate(crabPrefab, spawnPosition, Quaternion.identity);
        newCrab.GetComponent<CrabBehavior>().crabSpawner = this;
        newCrab.GetComponent<CrabBehavior>().targetPosition = player;
        newCrab.GetComponent<CrabBehavior>().GameWinUI = GameWinUI;
        AudioManager.Instance.Play(bossTheme);
    }
    public IEnumerator Countdown()
    {
        yield return new WaitForSeconds(timer);
        SpawnCrab();
    }
}
