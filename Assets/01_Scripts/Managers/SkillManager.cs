using System;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance { get; private set; }

    [Header("정적 데이터")]
    public List<SkillData> SkillData;

    [Header("런타임 스킬 오브젝트")]
    public SkillBase skillPrefab;  
    [SerializeField]private SkillBase[] activeSkillObjects = new SkillBase[18];

    [Header("업그레이드")]
    public int earthUpgradeLevel=1;
    public int fireUpgradeLevel = 1;
    public int waterUpgradeLevel = 1;

    public int summonLevel = 1;

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



    public void IncreaseStack(int index)
    {
        activeSkillObjects[index].AddStack();

        if (activeSkillObjects[index].Stack == 1)
        {
            activeSkillObjects[index].Active();
        }
    }
}

