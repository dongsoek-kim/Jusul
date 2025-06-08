using UnityEngine;

public class FireMythic : ISkillBehaviour
{
    public void Execute(SkillBase skill)
    {
        ProjectileBase projectile = PoolManager.Instance.Spawn<ProjectileBase>("ProjectileBase");
        projectile.Init(skill);
    }
}