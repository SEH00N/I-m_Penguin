using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [Header("Active")]
    public bool MOVEMENT = false;

    private Player player = null;

    public UnityEvent<Vector2> OnMovementInput;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        if(MOVEMENT)
            MovementInput();
    }

    private void MovementInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        OnMovementInput?.Invoke(new Vector2(x, y));
    }
}
