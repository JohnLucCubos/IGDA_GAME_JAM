using UnityEngine;

public class PlayerVerticalMovement : MonoBehaviour, IMovement
{
    [SerializeField] float _maxSpeed;
    [SerializeField] float _minSpeed;
    [SerializeField] float _currentSpeed;

    [SerializeField] Rigidbody _rb;
    [SerializeField] bool isMoving;
    [SerializeField] Vector2 mDirection;

    public Vector2 GetDirection {
        get {return mDirection;}
        private set {mDirection = value;}
    }

    void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    void Start()
    {
        _currentSpeed = _maxSpeed;
    }

    public void Move(Vector2 direction)
    {
        mDirection = direction;

        if(direction == Vector2.zero)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }

    void FixedUpdate()
    {

        Vector3 direction = new Vector3(0f, mDirection.y, mDirection.x);
        transform.Translate(direction * _currentSpeed * Time.deltaTime);
    }
}
