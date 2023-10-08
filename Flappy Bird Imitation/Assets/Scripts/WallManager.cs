using UnityEngine;

public class WallManager : MonoBehaviour
{
    [SerializeField] private GameObject[] walls;
    public int poolSize;
    public GameObject prefab;
    float timer;
    public float duration;

    private void Awake()
    {
        fillPool();
    }
    void fillPool()
    {
        walls = new GameObject[poolSize];
        for (var i = 0; i < poolSize; i++)
        {
            var item = Instantiate(prefab);
            prefab.SetActive(false);
            walls[i] = item;
        }
    }

    GameObject getWall()
    {
        foreach (var item in walls)
        {
            if (item.activeInHierarchy == false)
                return item;
        }
        return null;
    }
    void SpawnWall()
    {
        if (getWall() != null)
        {
            var wall = getWall();
            float yPos = Random.Range(-2, 4);
            wall.transform.position = new Vector2(13, yPos);
            wall.SetActive(true);
        }
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= duration)
        {
            SpawnWall();
            timer = 0;
        }
    }
}
