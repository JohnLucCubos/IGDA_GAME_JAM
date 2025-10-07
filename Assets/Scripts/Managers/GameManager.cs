using UnityEngine;
using TMPro;
using Unity.VisualScripting;
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    [SerializeField] int totalMicroplastics;
    [SerializeField] int consumeableMicroplastics;
    [SerializeField] const int SPAWN_VALUE = 5;
    [SerializeField] TextMeshProUGUI displayMicroplastics;

    [SerializeField] GameObject anchovyPrefab;
    [SerializeField] GameObject player;

    private void Awake()
    {
        this.gameObject.tag = "GameManager";
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

        totalMicroplastics = 0;
    }

    public void AddMicroplastics(int value)
    {
        totalMicroplastics += value;
        displayMicroplastics.text = totalMicroplastics.ToString();
        // TODO: Separate function call
        ConsumeMicroplastics(value);
    }

    public void RemoveMicroplastics(int value)
    {
        totalMicroplastics -= value;
        displayMicroplastics.text = totalMicroplastics.ToString();
    }

    public void ConsumeMicroplastics(int value)
    {
        consumeableMicroplastics += value;

        while (consumeableMicroplastics >= SPAWN_VALUE)
        {
            SpawnAnchovy();
            consumeableMicroplastics -= SPAWN_VALUE;
        }

        if (consumeableMicroplastics < 0)
        {
            consumeableMicroplastics = 0;
        }
    }

    private void SpawnAnchovy()
    {

        float yOffset = Random.Range(-5f, 1f);
        float zOffset = Random.Range(-5f, 5f);

        Vector3 spawnPosition = new Vector3(
            0,
            player.transform.position.y + yOffset,
            player.transform.position.z + zOffset
        );

        GameObject anchovy = Instantiate(anchovyPrefab, spawnPosition, player.transform.rotation);

        anchovy.transform.SetParent(player.transform);

        Debug.Log("Anchovy Spawned");
    }
}
