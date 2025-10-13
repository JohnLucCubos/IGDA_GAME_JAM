using MyUnity.Utilities;
using UnityEngine;

public class AreaSoundTrigger : MonoBehaviour
{
    [SerializeField] string bgmName;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "Player")
        {
            return;
        }
        AudioManager.Instance.Play(bgmName);
    }
}
