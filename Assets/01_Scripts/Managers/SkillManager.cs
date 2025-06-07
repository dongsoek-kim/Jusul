using System;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [Header("정적 데이터")]
    public List<SkillData> SkillData;

    [Header("런타임 스킬 오브젝트")]
    public SkillBase skillPrefab;  
    [SerializeField]private SkillBase[] activeSkillObjects = new SkillBase[18];  

    void Awake()
    {
        foreach (var data in SkillData)
        {
            data.behaviour = CreateBehaviour(data.skillEnum);
        }

        for (int i = 0; i < SkillData.Count; i++)
        {
            var instance = Instantiate(skillPrefab, transform);
            instance.Init(SkillData[i]);
            activeSkillObjects[i] = instance;
        }
    }

    private void Start()
    {
        activeSkillObjects[3].Active();
    }
    public ISkillBehaviour CreateBehaviour(Skill skill)
    {
        string className = $"{skill}";
        string fullName = $"{className}, Assembly-CSharp"; 

        Type type = Type.GetType(fullName);
        if (type == null)
        {
            Debug.Log($"Type not found: {fullName}");
        }

        return Activator.CreateInstance(type) as ISkillBehaviour;
    }


    public void ActivateSkill(Skill skill)
    {
        int index = (int)skill;
        var skillObj = activeSkillObjects[index];
        if (!skillObj.gameObject.activeSelf)
        {
            skillObj.gameObject.SetActive(true);
            Debug.Log($"{skill} 활성화됨");
        }
    }

    //public void IncreaseStack(Skill skill)
    //{
    //    int index = (int)skill;
    //    SkillData[index].stack++;

    //    if (SkillData[index].stack == 1)
    //    {
    //        ActivateSkill(skill);
    //    }
    //}
}

