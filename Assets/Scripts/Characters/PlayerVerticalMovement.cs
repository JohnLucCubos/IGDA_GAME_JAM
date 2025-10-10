using UnityEngine;

public class PlayerVerticalMovement : MonoBehaviour, IMovement
{
    [SerializeField] float _maxSpeed;
    [SerializeField] float _minSpeed;
    [SerializeField] float _currentSpeed;

    [SerializeField] Rigidbody _rb;
    [SerializeField] bool isMoving;
    [SerializeField] Vector2 mDirection;

    [SerializeField] Transform characterModel;

    [SerializeField] float maxHeight;
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

        isMoving = direction != Vector2.zero;
        if(isMoving)
        {
            Vector3 rotation = new Vector3(0f, mDirection.y, mDirection.x);
            Rotate(rotation);
        }
    }

    void FixedUpdate()
    {

        Vector3 direction = new Vector3(0f, mDirection.y, mDirection.x);
        transform.Translate(direction * _currentSpeed * Time.deltaTime);
        LockHeight();
    }

    void Rotate(Vector3 direction)
    {

        characterModel.transform.rotation = Quaternion.LookRotation(-direction);

    }
    void LockHeight()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.y = Mathf.Clamp(currentPosition.y, -Mathf.Infinity, maxHeight);
        transform.position = currentPosition;
    }
}
