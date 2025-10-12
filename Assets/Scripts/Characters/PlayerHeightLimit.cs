using UnityEngine;

public class PlayerHeightLimit : MonoBehaviour
{
    [SerializeField] float maxHeight; // = -3
    void LockHeight()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.y = Mathf.Clamp(transform.position.y, -Mathf.Infinity, maxHeight);
        transform.position = currentPosition;
    }

    // Update is called once per frame
    void Update()
    {
        LockHeight();
    }
}
