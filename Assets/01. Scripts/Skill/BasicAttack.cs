using System.Collections;
using UnityEngine;

public class BasicAttack : Skill
{
    [Space(10f)]
    [SerializeField] float startDelay = 0.5f;
    private bool onAttacking = false;

    public override void SkillAction()
    {
        if(onAttacking) return;
        onAttacking = true;

        StartCoroutine(AttackCoroutine(startDelay));
    }

    private IEnumerator AttackCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("때찌");

        onAttacking = false;
        currentStackCount--;
    }
}
