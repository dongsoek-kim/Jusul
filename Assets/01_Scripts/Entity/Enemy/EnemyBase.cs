using UnityEngine;

public class EnemyBase : MonoBehaviour , IPoolable
{
    public float Hp = 100f;
    public float Damage = 10f;
    public float Speed = 2f;

    [Header("Spawn")]
    [SerializeField]private Vector3 spawnPosition;
    [SerializeField]private Vector3 targetPosition;
    protected EnemyState state = EnemyState.Move;

    public virtual void Init()
    {
        spawnPosition = new Vector3(0, -5f, 0);
        targetPosition = new Vector3(0, 3f, 0); 
        transform.position = spawnPosition;
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
        transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.up, Speed * Time.deltaTime);
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
        Init();
    }
    public virtual void OnDespawn()
    {

    }

}
