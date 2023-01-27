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

    private PlayerHealth playerHealth = null;
    public PlayerHealth PlayerHealth {
        get {
            if(playerHealth == null)
                playerHealth = GetComponent<PlayerHealth>();
            
            return playerHealth;
        }
    }
}
