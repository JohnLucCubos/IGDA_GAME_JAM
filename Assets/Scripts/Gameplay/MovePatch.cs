using UnityEngine;

public class MovePatch : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float _maxSpeed;
    [SerializeField] float _minSpeed;
    [SerializeField] float _currentSpeed;
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        _currentSpeed = _maxSpeed;
    }

    public void Move()
    {
        Vector3 lockedZPosition = new Vector3(
            gameObject.transform.position.x,
            gameObject.transform.position.y,
            player.position.z
        );
        gameObject.transform.position =Vector3.MoveTowards(
            gameObject.transform.position,
            lockedZPosition,
            _currentSpeed * Time.deltaTime
        );
    }
    void Update()
    {
        Move();
    }
}
