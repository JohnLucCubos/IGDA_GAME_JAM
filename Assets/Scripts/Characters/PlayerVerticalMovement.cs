using System.Collections;
using UnityEngine;

public class PlayerVerticalMovement : MonoBehaviour, IMovement
{
    [SerializeField] float _maxSpeed;
    [SerializeField] float _minSpeed;
    [SerializeField] float _currentSpeed;

    [SerializeField] float dashSpeed;

    [SerializeField] Rigidbody _rb;
    [SerializeField] bool isMoving;
    [SerializeField] bool hasDashed;
    [SerializeField] Vector2 mDirection;

    [SerializeField] Transform characterModel;
    [SerializeField] int dashDuration;
    [SerializeField] int dashCooldown;

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
    public void Dash()
    {
        if (hasDashed)
        {
            return;
        }
        Vector3 direction = new Vector3(0f, mDirection.y, mDirection.x);
        _rb.AddForce(direction * dashSpeed, ForceMode.Impulse);
        StartCoroutine(Cooldown(dashDuration, dashCooldown));
    }
    void FixedUpdate()
    {

        Vector3 direction = new Vector3(0f, mDirection.y, mDirection.x);
        transform.Translate(direction * _currentSpeed * Time.deltaTime);
    }

    void Rotate(Vector3 direction)
    {
        characterModel.transform.rotation = Quaternion.LookRotation(-direction);
    }

    IEnumerator Cooldown(int duration, int timer)
    {
        hasDashed = true;
        // dictates how far the player can dash
        yield return new WaitForSeconds(duration);
        _rb.linearVelocity = Vector3.zero;
        // dictates how long before player can dash again
        yield return new WaitForSeconds(timer);
        hasDashed = false;
    }

}
