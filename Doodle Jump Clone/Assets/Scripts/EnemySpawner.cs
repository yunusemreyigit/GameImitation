using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    ObjectPool objectPool;
    Transform player;
    private void Start()
    {
        objectPool = ObjectPool.Instance;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    float timer;
    [SerializeField] private float duration;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= duration)
        {
            objectPool.SpawnFromPool("Enemy", new Vector2(Random.Range(-2, 2), player.position.y + 10), Quaternion.identity);
            timer = 0;
            duration = Random.Range(5, 10);
        }
    }
}
