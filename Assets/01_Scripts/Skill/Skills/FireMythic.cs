using UnityEngine;

public class FireMythic : ISkillBehaviour
{
    public void Execute(SkillBase skill)
    {
        Debug.Log("FireMythic 발사!");
    }
}