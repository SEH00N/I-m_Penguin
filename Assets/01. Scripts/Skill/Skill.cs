using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    public bool ACTIVE = true;

    [Space(10f)]
    public KeyCode activeKey = KeyCode.None;

    [SerializeField] int stackableCount = 1;
    protected int currentStackCount = 0;

    [SerializeField] float coolTime = 10f;
    private float currentTimer = 0f;
    
    public void ActiveSkill()
    {
        if(ACTIVE == false) return;

        if(currentStackCount <= 0) return;

        SkillAction();
    }

    public abstract void SkillAction();

    protected virtual void Update()
    {
        if(currentStackCount >= stackableCount)
            return;

        currentTimer += Time.deltaTime;

        if(currentTimer >= coolTime)
        {
            currentStackCount++;
            currentTimer = 0f;
        }
    }
}
