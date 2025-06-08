using UnityEngine;

public class EarthCommon : ISkillBehaviour
{
    public void Execute(SkillBase skill)
    {
       ProjectileBase projectile= PoolManager.Instance.Spawn<ProjectileBase>("ProjectileBase");
       projectile.Init(skill);
    }
}