using UnityEngine;
using System.Collections;
public class WrapperEntityMovement : MonoBehaviour, IMovement
{
    [SerializeField] GameObject targetPosition;
    [SerializeField] Rigidbody _rb;
    [SerializeField] int durationInSeconds;
    [SerializeField] int timerInSeconds;
    [SerializeField] int dashSpeed;
    [SerializeField] bool hasDashed;
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move(Vector2.zero);
    }



    public void Move(Vector2 direction)
    {
        if (hasDashed)
        {
            return;
        }
        Vector3 playerDirection = targetPosition.transform.position - gameObject.transform.position;
        _rb.AddForce(playerDirection.normalized * dashSpeed, ForceMode.Impulse);
        Dash();
    }

    public void Dash()
    {
        StartCoroutine(Cooldown(durationInSeconds, timerInSeconds));
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
