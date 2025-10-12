using UnityEngine;

public class EntityMovement : MonoBehaviour, IMovement
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
    public void Move(Vector2 direction)
    {
        gameObject.transform.position =Vector3.MoveTowards(
            gameObject.transform.position,
            player.position,
            _currentSpeed * Time.deltaTime
        );
    }

    void Update()
    {
        Move(Vector2.zero);
    }
    public void Dash(){}
}
