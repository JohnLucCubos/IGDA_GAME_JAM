using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using TMPro;
public class SwarmManager : MonoBehaviour
{
    private static SwarmManager _instance;
    public static SwarmManager Instance { get { return _instance; } }

    [SerializeField] const int SPAWN_VALUE = 5;
    [SerializeField] int consumeableMicroplastics;

    [SerializeField] GameObject anchovyPrefab;
    [SerializeField] Transform spawnPoint;

    [SerializeField] TextMeshProUGUI displayAnchovies;
    [SerializeField] TextMeshProUGUI displayUniqueFish;

    [SerializeField] List<GameObject> spawnedAnchovies = new List<GameObject>();
    public int getAnchovySwarmSize
    {
        get { return spawnedAnchovies.Count; }
    }

    private void Awake()
    {
        this.gameObject.tag = "SwarmManager";
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

        consumeableMicroplastics = 0;
    }

    public void AddMicroplastics(int value)
    {
        consumeableMicroplastics += value;

        ConsumeMicroplastics(value);
    }

    public void RemoveMicroplastics(int value)
    {
        consumeableMicroplastics -= value;
    }

    public void ConsumeMicroplastics(int value)
    {
        while (consumeableMicroplastics >= SPAWN_VALUE)
        {
            SpawnAnchovy();
            RemoveMicroplastics(SPAWN_VALUE);
        }
        // we don't want negatives
        if (consumeableMicroplastics < 0)
        {
            consumeableMicroplastics = 0;
        }
    }

    private void SpawnAnchovy()
    {
        // Current logic spawns

        // sets the anchovy spawning range
        float yOffset = Random.Range(-2.5f, 2.5f);
        float zOffset = Random.Range(-5f, 5f);
        // creates a new spawning location
        Vector3 spawnPosition = new Vector3(
            0,
            yOffset,
            zOffset
        );
        // spawns the anchovy
        GameObject anchovy = Instantiate(anchovyPrefab, spawnPosition, spawnPoint.rotation);
        // sets spawnPoint as the parent
        anchovy.transform.SetParent(spawnPoint);
        spawnedAnchovies.Add(anchovy);

        displayAnchovies.text = spawnedAnchovies.Count.ToString();
    }

    public void DeleteAnchovy(GameObject defeatedAnchovy)
    {
        int selected = spawnedAnchovies.IndexOf(defeatedAnchovy);
        if (selected == -1)
        {
            return;
        }
        if(spawnedAnchovies.Count == 0)
        {
            // call player lost function here
            return;
        }

        GameObject anchovy = spawnedAnchovies[selected];

        Destroy(anchovy);
        spawnedAnchovies.RemoveAt(selected);

        displayAnchovies.text = spawnedAnchovies.Count.ToString();
    }
}
