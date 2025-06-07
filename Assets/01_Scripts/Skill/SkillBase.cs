using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBase : MonoBehaviour, ISkil
{
    [Header("스킬데이터")]
    public SkillData skillData; 
    public int Stack{ get; private set; }
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

    public virtual void AddStack()
    {
        Stack++;
        float reductionRatio = Mathf.Min(Stack - 1, 2) * 0.15f; 
        timer = skillData.cooldown * (1f - reductionRatio);
        Debug.Log($"Stack added: {Stack}");
    }
}
