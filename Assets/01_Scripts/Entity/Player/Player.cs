using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float maxHP = 1000f;
    [SerializeField]private float currentHP = 1000f;

    [SerializeField] private RectTransform hpBar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        float normalizedHP = Mathf.Clamp01(currentHP / maxHP); 
        hpBar.transform.localScale = new Vector3(normalizedHP, 1f, 1f);

        if (currentHP <= 0)
        {
            currentHP = 0;
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player has died.");
        // Add death logic here, such as playing an animation or respawning
    }
}
