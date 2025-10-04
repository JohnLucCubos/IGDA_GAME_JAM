using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    [SerializeField] int totalMicroplastics;
    [SerializeField] TextMeshProUGUI displayMicroplastics;

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
    }

    public void RemoveMicroplastics(int value)
    {
        totalMicroplastics -= value;
        displayMicroplastics.text = totalMicroplastics.ToString();
    }
}
