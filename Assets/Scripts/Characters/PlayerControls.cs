using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    controls playerControls;
    IMovement movement;
    void Awake()
    {
        playerControls = new controls();

        movement = GetComponent<IMovement>();
    }
    void Start()
    {
        playerControls.Player.Move.performed += ctx => movement.Move(ctx.ReadValue<Vector2>());
        playerControls.Player.Move.canceled += ctx => movement.Move(Vector2.zero);

        playerControls.Player.Dash.performed += ctx => movement.Dash();
    }
    void OnEnable() => playerControls.Player.Enable();
    void OnDisable() => playerControls.Player.Disable();
}
