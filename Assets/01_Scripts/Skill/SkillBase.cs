using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBase : MonoBehaviour, ISkil
{
    [Header("스킬데이터")]
    public SkillData skillData; 
    public int Stack{ get; private set; }
    public float AdaptedCooldown { get; private set; }
    private float timer;
    [SerializeField]private bool isActive;

    public void Init(SkillData skillData)
    {
        this.skillData = skillData;
        AdaptedCooldown = skillData.cooldown;
        timer = skillData.cooldown;
    }
    void Update()
    {
        if (isActive)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                Debug.Log($"{skillData.skillEnum} Executed");
                skillData.behaviour.Execute(this);
                timer = AdaptedCooldown; // Reset the timer after execution
            }
        }
    }


    public virtual void Active()
    {
        isActive = true;
        AdaptedCooldown = skillData.cooldown;
        Debug.Log($"{skillData.skillEnum} Activated");
    }

    public virtual void Deactive()
    {
        isActive = false;
        Debug.Log($"{skillData.skillEnum} Deactivated");
    }

    public virtual void AddStack()
    {
        Stack++;
        int validStack = Mathf.Max(Stack, 1);
        float reductionRatio = Mathf.Min(validStack - 1, 2) * 0.15f;
        AdaptedCooldown = skillData.cooldown * (1f - reductionRatio);
    }
    public virtual void RemoveStack()
    {
        Stack -= 3;
        if (Stack > 0) 
        {
            int validStack = Mathf.Max(Stack, 1);
            float reductionRatio = Mathf.Min(validStack - 1, 2) * 0.15f;
            AdaptedCooldown = skillData.cooldown * (1f - reductionRatio);
        }
        else
        {
            Stack = 0;
            AdaptedCooldown = skillData.cooldown;
            timer = skillData.cooldown;
            Deactive();
        }
    }
}
