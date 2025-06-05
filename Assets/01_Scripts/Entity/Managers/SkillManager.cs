using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public SkillBase[] skills;
    void Start()
    {
        for(int i=0; i< Enum.GetValues(typeof(Skill)).Length;i++)
        {
            skills[i]= new SkillBase();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
