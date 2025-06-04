using UnityEngine;

public class NormalMonster : EnemyBase
{
    private float timer = 2f;
    protected override void Update()
    {
        base.Update();
        if (state == EnemyState.Attack)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                PoolManager.Instance.Despawn(this);
            }
        }

    }
    protected override void OnEnterAttackState()
    {
        Debug.Log("Normal monster entered attack state");
    }

    protected override void OnAttack()
    {
        // Normal monster attack logic
    }
    public override void OnSpawn()
    {
        base.OnSpawn();
        timer = 2f; // Reset timer on spawn
    }
    public override void OnDespawn()
    {
        base.OnDespawn();
    }
}
