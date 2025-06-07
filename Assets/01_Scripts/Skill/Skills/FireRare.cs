using UnityEngine;

public class FireRare : ISkillBehaviour
{
    public void Execute(SkillBase skill)
    {
        Debug.Log("FireRare 발사!");
    }
}