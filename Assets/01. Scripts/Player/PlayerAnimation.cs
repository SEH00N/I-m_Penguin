using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator = null;
    private SpriteRenderer spriteRenderer = null;

    private int onMoveHash = Animator.StringToHash("OnMove");
    private int onDamageHash = Animator.StringToHash("OnDamage");
    private int onDieHash = Animator.StringToHash("OnDie");

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void MovementAnimation(Vector2 input) 
    {
        if(input.sqrMagnitude <= 0) {
            animator.SetBool(onMoveHash, false);
            return;
        } 

        animator.SetBool(onMoveHash, true);

        if(input.x != 0) {
            spriteRenderer.flipX = input.x < 0;
        }
    }

    public void OnDamageAnimation() 
    {
        animator.SetTrigger(onDamageHash);
    }

    public void OnDieAnimation() 
    {
        animator.SetBool(onDieHash, true);
    }
}
