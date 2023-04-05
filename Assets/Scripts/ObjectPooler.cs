using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Pool
{
    public string tag;
    public ParticleCatcher prefab;
    public int size;
}

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;

    public List<Pool> pools;
    public Dictionary<string, Queue<ParticleCatcher>> poolDictionary;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<ParticleCatcher>>();

        foreach (Pool pool in pools)
        {
            Queue<ParticleCatcher> objectPool = new Queue<ParticleCatcher>();

            for (int i = 0; i < pool.size; i++)
            {
                ParticleCatcher obj = Instantiate(pool.prefab, transform);
                obj.gameObject.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public ParticleCatcher SpawnFromPool(string tag, Vector3 pos, Quaternion rot)
    {
        if (!poolDictionary.ContainsKey(tag))
            return null;

        ParticleCatcher objectToSpwan = poolDictionary[tag].Dequeue();

        objectToSpwan.gameObject.SetActive(true);
        objectToSpwan.transform.position = pos;
        objectToSpwan.transform.rotation = rot;

        poolDictionary[tag].Enqueue(objectToSpwan);

        return objectToSpwan;

    }
}
