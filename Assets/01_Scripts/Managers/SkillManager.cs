using System;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance { get; private set; }

    [Header("Skill Elements")]
    private SkillCreatHandler skillCreatHandler;

    [Header("정적 데이터")]
    [SerializeField] private List<SkillData> SkillData;

    [Header("런타임 스킬 오브젝트")]
    [SerializeField]private SkillBase skillPrefab;  
    [SerializeField]private SkillBase[] activeSkillObjects = new SkillBase[18];


    [Header("업그레이드")]
    public int earthUpgradeLevel=1;
    public int fireUpgradeLevel = 1;
    public int waterUpgradeLevel = 1;

    public int createLevel = 1;
    public int SkillAmount { get; private set; } = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }

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

        skillCreatHandler = new SkillCreatHandler();
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

    public void CreateSkill()
    {
        if (skillCreatHandler.CanCreat())
        {
            GameManager.Instance.UseMoney(skillCreatHandler.RequirementMoney);

            int index = skillCreatHandler.SkillCreat();
            IncreaseStack(index);
            SkillAmount++;
            UIManager.Instance.SkillUIUdate(index, activeSkillObjects[index].Stack, skillCreatHandler.RequirementMoney);
            skillCreatHandler.AddRequirementMoney();
        }

    }
    public void IncreaseStack(int index)
    {
        activeSkillObjects[index].AddStack();

        if (activeSkillObjects[index].Stack == 1)
        {
            activeSkillObjects[index].Active();
        }
    }
}

