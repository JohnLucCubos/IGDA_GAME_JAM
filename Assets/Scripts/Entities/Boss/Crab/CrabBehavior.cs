using Unity.VisualScripting;
using UnityEngine;
using MyUnity.Utilities;
public class CrabBehavior : MonoBehaviour
{
    [SerializeField] CrabState state;
    public GameObject targetPosition;
    [SerializeField] bool canAttack;
    [SerializeField] Rigidbody rb;
    [SerializeField] float movementSpeed;
    [SerializeField] EntityHealth health;

    public CrabSpawner crabSpawner;
    public GameObject GameWinUI;
    public bool isPlayerInRange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = CrabState.moving;
        health = this.gameObject.GetComponent<EntityHealth>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (state)
        {
            case CrabState.moving:
                Move();
                break;
            case CrabState.attacking:
                Attack();
                break;
        }
        if(health.getCurrentHealth <= 0)
        {
            AudioManager.Instance.Play("Top side bgm");
            GameWinUI.SetActive(true);
        }
    }
    void Move()
    {
        Vector3 moveDirection = new Vector3(0f, 0f, targetPosition.transform.position.z);
        Vector3 newPosition = Vector3.MoveTowards(transform.position, moveDirection, movementSpeed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);
        if (isPlayerInRange)
        {
            state = CrabState.attacking;
        }
    }
    void Attack()
    {
        if (!isPlayerInRange)
        {
            state = CrabState.moving;
        }
        
    }
}

[System.Serializable]
enum CrabState
{
    moving,
    attacking,
}