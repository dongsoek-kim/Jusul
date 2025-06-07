using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBase : MonoBehaviour, ISkil
{
    [Header("스킬데이터")]
    public SkillData skillData; 
    public int stack;
    private float timer;
    private bool isActive;

    public void Init(SkillData skillData)
    {
        this.skillData = skillData;
        timer = skillData.cooldown;
    }
    void Update()
    {
        if (isActive)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                skillData.behaviour.Execute(this);
                //timer = skillData.cooldown/stack;
            }
        }
    }


    public virtual void Active()
    {
        isActive = true;
        timer = skillData.cooldown;
        Debug.Log("Skill Activated");
    }

    public virtual void Deactive()
    {
        isActive = false;
        Debug.Log("Skill Deactivated");
    }
}
