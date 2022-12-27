using System.Collections.Generic;
using UnityEngine;

public class SkillActivator : MonoBehaviour
{
    [SerializeField] Transform skillArchive = null;
    private List<Skill> skills = new List<Skill>();

    private void Awake()
    {
        skillArchive.GetComponentsInChildren<Skill>(skills);
    }

    private void Update()
    {
        if(Input.anyKeyDown)
            foreach(Skill skill in skills)
                if(Input.GetKeyDown(skill.activeKey))
                    skill.ActiveSkill();
    }
}
