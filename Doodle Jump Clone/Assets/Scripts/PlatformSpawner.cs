using System;
using System.Linq;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public String[] spawnObjectName;

    [SerializeField] private float duration;
    float timer = 0;
    public Transform platformSpawnPoint;
    private ObjectPool objectPool;
    private Transform camera;
    private void Start()
    {
        objectPool = ObjectPool.Instance;
        camera = Camera.main.transform;
    }
    private void Update()
    {
        if (Math.Abs(platformSpawnPoint.position.y - camera.position.y) < 30)
            spawnPlatform();
    }
    private void moveSpawnPoint()
    {
        platformSpawnPoint.Translate(Vector2.up * Time.deltaTime * 5);
    }
    void spawnPlatform()
    {
        moveSpawnPoint();

        timer += Time.deltaTime;
        if (timer >= duration)
        {
            int objIndex = UnityEngine.Random.Range(0, spawnObjectName.Length);
            float randomX = UnityEngine.Random.Range(-3.6f, 3.6f);
            objectPool.SpawnFromPool(spawnObjectName[objIndex], new Vector2(randomX, platformSpawnPoint.position.y), Quaternion.identity);
            duration = UnityEngine.Random.Range(0.05f, 0.5f);
            timer = 0;
        }
    }
}
