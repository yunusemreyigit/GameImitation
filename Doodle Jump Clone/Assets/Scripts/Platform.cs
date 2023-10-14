using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;

    public void spawnObject()
    {
        var chance = Random.Range(0, 100);
        if (chance >= 85)
        {
            getObject(0);
        }
        if (chance <= 5)
        {
            getObject(1);
        }
    }

    private void getObject(int index)
    {
        Instantiate(objects[index],
                    new Vector2(transform.position.x, transform.position.y + 0.4f),
                    Quaternion.identity);
    }
}
