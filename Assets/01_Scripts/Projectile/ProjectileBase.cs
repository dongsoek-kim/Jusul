using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProjectileBase : MonoBehaviour,IPoolable
{
    SpriteRenderer sr;
    SkillData skillData;
    public float Speed = 2f;
    [Header("Spawn")]
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private Vector3 targetPosition;
    public void Init(SkillBase skill)
    {
        sr = GetComponent<SpriteRenderer>();
        skillData = skill.skillData;
        spawnPosition = new Vector3(0, 4f, 0);
        targetPosition = spawnPosition - new Vector3(0, skill.skillData.range, 0);
        transform.position = spawnPosition;
        gameObject.SetActive(true);
        SetSprite();
    }


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.down, Speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPosition) <= 0.1f)
        {
            PoolManager.Instance.Despawn(this);
        }
    }

    public void OnSpawn()
    {
    }

    public void OnDespawn()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        int monsterLayer = LayerMask.NameToLayer("Monster");
        if (collision.gameObject.layer == monsterLayer)
        {
            EnemyBase enemy = collision.GetComponent<EnemyBase>();
            if (enemy != null)
            {
                enemy.TakeDamage(skillData.attackPower);
            }
        }
    }
    private void SetSprite()
    {
        switch(skillData.elementType)
        {
            case ElementType.Earth:
                sr.color = Color.yellow ;
                break;
            case ElementType.Fire:
                sr.color = Color.red;
                break;
            case ElementType.Water:
                sr.color = Color.blue;
                break;
            default:
                Debug.LogError("Unknown Element Type");
                break;
        }
        switch(skillData.grade)
        {
            case SkillGrade.Common:
                sr.transform.localScale = Vector3.one * 0.5f;
                break;
            case SkillGrade.Rare:
                sr.transform.localScale = Vector3.one * 0.7f;
                break;
            case SkillGrade.Hero:
                sr.transform.localScale = Vector3.one * 1f;
                break;
            case SkillGrade.Legend:
                sr.transform.localScale = Vector3.one * 1.2f;
                break;
            case SkillGrade.Ancient:
                sr.transform.localScale = Vector3.one * 1.5f;
                break;
            case SkillGrade.Mythic:
                sr.transform.localScale = Vector3.one * 2f;
                break;
            default:
                Debug.LogError("Unknown Skill Grade");
                break;
        }
    }
}
