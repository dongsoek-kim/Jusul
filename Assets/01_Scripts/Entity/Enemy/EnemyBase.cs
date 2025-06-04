using UnityEngine;

public enum EnemyState
{
    Move,
    Attack
}

public class EnemyBase : MonoBehaviour , IPoolable
{
    public float Hp = 100f;
    public float Damage = 10f;
    public float Speed = 2f;

    protected Vector3 targetPosition;
    protected EnemyState state = EnemyState.Move;

    public virtual void Initialize(Vector3 spawnPos, Vector3 targetPos)
    {
        transform.position = spawnPos;
        targetPosition = targetPos;
        state = EnemyState.Move;
        gameObject.SetActive(true);
    }

    protected virtual void Update()
    {
        if (state == EnemyState.Move)
        {
            MoveToTarget();
        }
        else if (state == EnemyState.Attack)
        {
            OnAttack();
        }
    }

    protected void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, Vector3.up, Speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPosition) <= 0.1f)
        {
            state = EnemyState.Attack;
            OnEnterAttackState();
        }
    }

    protected virtual void OnEnterAttackState()
    {
    }

    protected virtual void OnAttack()
    {
    }

    public virtual void OnSpawn()
    {
        Initialize(new Vector3(0,-10,0),new Vector3(0,10,0));
    }
    public virtual void OnDespawn()
    {

    }

}
