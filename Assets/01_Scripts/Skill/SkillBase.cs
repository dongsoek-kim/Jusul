using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkill
{
    void Active();
    void Deactive();
}
public class SkillBase : MonoBehaviour, ISkill
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Active()
    {
        Debug.Log("Skill Activated");
    }

    public virtual void Deactive()
    {
        Debug.Log("Skill Deactivated");
    }
}
