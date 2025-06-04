using System;
using System.Collections.Generic;
using UnityEngine;

public enum PrefabType
{
    BossMonster,
    NormalMonster
}

public interface IPoolable
{
    void OnSpawn();
    void OnDespawn();
}

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance { get; private set; }

    private Dictionary<string, Queue<Component>> poolNames = new();
    private Dictionary<string, Transform> poolParents = new();
    private Dictionary<string, Component> prefabCache = new();
    private Dictionary<string, int> poolMaxCounts = new();

    [Header("Prefabs to Cache")]
    public GameObject[] prefabs;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        ReserveRegister();

    }

    private void ReserveRegister()
    {
        for (int i = 0; i < Enum.GetValues(typeof(PrefabType)).Length; i++)
        {
            string key = Enum.GetValues(typeof(PrefabType)).GetValue(i).ToString();
            RegisterPrefab(key, prefabs[i].GetComponent<Component>());
            poolMaxCounts[key] = 10;
        }
    }

    public void RegisterPrefab(string key, Component prefab)
    {
        if (!prefabCache.ContainsKey(key))
        {
            prefabCache[key] = prefab;
        }
        else
        {
            Debug.LogWarning($"Prefab with key {key} is already registered.");
        }
    }

    public T Spawn<T>(string key, Transform parent = null) where T : Component
    {
        if (!prefabCache.ContainsKey(key))
        {
            Debug.LogError($"Prefab with key {key} is not registered!");
            return null;
        }

        GameObject prefab = prefabCache[key].gameObject;
        Debug.Log($"Spawning prefab: {prefab.name} with key: {key}");
        string prefabName = prefab.gameObject.name;

        if (!poolNames.ContainsKey(prefabName))
        {
            poolNames[prefabName] = new Queue<Component>();
            GameObject poolParentObj = new GameObject(prefabName + "Pool");
            poolParentObj.transform.SetParent(this.transform);
            poolParents[prefabName] = poolParentObj.transform;
            Debug.Log($"Created new pool for prefab: {prefabName}");
        }

        T obj;

        if (poolNames[prefabName].Count > 0)
        {
            obj = poolNames[prefabName].Dequeue() as T;
            obj.transform.position = parent != null ? parent.position : obj.transform.position;
        }
        else
        {
            Transform spawnParent = parent != null ? parent : poolParents[prefabName];
            GameObject instance = Instantiate(prefab, spawnParent.position, spawnParent.rotation, spawnParent);
            obj = instance.GetComponent<T>();

        }

        if (obj != null)
        {
            obj.gameObject.SetActive(true);
            if (obj is IPoolable poolable)
                poolable.OnSpawn();
        }
        else
        {
            Debug.Log($"Failed to instantiate or retrieve object for key: {key}");
        }

        return obj;
    }


    public void Despawn<T>(T obj) where T : Component
    {
        string key = obj.gameObject.name.Replace("(Clone)", "").Trim();
        
        if (obj is IPoolable poolable)
            poolable.OnDespawn();

        obj.gameObject.SetActive(false);

        if (!poolNames.ContainsKey(key))
        {
            poolNames[key] = new Queue<Component>();
            GameObject poolParentObj = new GameObject(key + "Pool");
            poolParentObj.transform.SetParent(this.transform);
            poolParents[key] = poolParentObj.transform;
        }

        obj.transform.SetParent(poolParents[key]);

        if (poolNames[key].Count >= poolMaxCounts[key])
        {
            Destroy(obj.gameObject);
        }
        else
        {
            poolNames[key].Enqueue(obj);
        }
    }

    public void ClearPool()
    {
        poolNames.Clear();
        poolParents.Clear();
        prefabCache.Clear();
    }
}
