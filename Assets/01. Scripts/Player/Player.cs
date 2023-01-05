using UnityEngine;

public class Player : MonoBehaviour
{
    private Movement movement = null;
    public Movement Movement {
        get {
            if(movement == null)
                movement = GetComponent<Movement>();

            return movement;
        }
    }
}
