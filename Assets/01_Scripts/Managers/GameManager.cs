using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float spawnTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= 2f)  
        {
            PoolManager.Instance.Spawn<NormalMonster>("NormalMonster");
            spawnTimer = 0f;  
        }
    }
}
