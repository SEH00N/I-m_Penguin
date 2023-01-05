using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Header("Active")]
    public bool MOVEMENT = false;

    private Player player = null;
    private Movement movement = null;

    private void Awake()
    {
        player = GetComponent<Player>();
        movement = player.Movement;
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

        movement.MoveTo(new(x, y));
    }
}
