using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] MovementSO movementSO;

    private Rigidbody2D rb2d = null;

    private float currentVelocity = 0f;
    private Vector2 currentDir = Vector2.zero;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb2d.velocity = currentDir.normalized * currentVelocity;
    }

    public void MoveTo(Vector2 input)
    {
        if(input.sqrMagnitude > 0f)
        {
            if(Vector2.Dot(input, currentDir) < 0f)
                currentVelocity = 0f;
            
            currentDir = input.normalized;
        }

        currentVelocity = CalcSpeed(input);
    }

    private float CalcSpeed(Vector2 input)
    {
        if(input.sqrMagnitude > 0f)
            currentVelocity += movementSO.inAccel * Time.deltaTime;
        else 
            currentVelocity -= movementSO.deAccel * Time.deltaTime;

        return Mathf.Clamp(currentVelocity, 0, movementSO.maxSpeed);
    }

    public void StopImmediately()
    {
        currentDir = Vector2.zero;
        currentVelocity = 0f;
    }
}
