using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public String name;
        public GameObject prefab;
        public int size;
    }
    public List<Pool> pools;
    public Dictionary<String, Queue<GameObject>> pooDic;
    public static ObjectPool Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        pooDic = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (var i = 0; i < pool.size; i++)
            {
                GameObject myObject = Instantiate(pool.prefab);
                myObject.SetActive(false);
                objectPool.Enqueue(myObject);
            }
            pooDic.Add(pool.name, objectPool);
        }
    }

    public GameObject SpawnFromPool(String type, Vector2 positon, Quaternion rotation)
    {
        if (!pooDic.ContainsKey(type))
        {
            return null;
        }
        GameObject gameObject = pooDic[type].Dequeue();
        gameObject.transform.position = positon;
        gameObject.transform.rotation = rotation;
        if (type != "Enemy")
            gameObject.GetComponent<Platform>().spawnObject();
        gameObject.SetActive(true);

        pooDic[type].Enqueue(gameObject);

        return gameObject;
    }
}
