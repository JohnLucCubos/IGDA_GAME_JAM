using UnityEngine;

public class PlayerDetection : MonoBehaviour, IDetection
{
    [SerializeField] CrabBehavior crabBehavior;
    public void Detected(bool wasSeen)
    {
        crabBehavior.isPlayerInRange = wasSeen;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            return;
        }
        Detected(true);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            return;
        }
        Detected(false);
    }
}
