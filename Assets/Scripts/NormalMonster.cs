using UnityEngine;

public class NormalMonster : EnemyBase
{
    protected override void OnEnterAttackState()
    {
        Debug.Log("Normal monster entered attack state");
    }

    protected override void OnAttack()
    {
        // Normal monster attack logic
        Debug.Log("Normal monster attacking with damage: " + Damage);
    }
}
