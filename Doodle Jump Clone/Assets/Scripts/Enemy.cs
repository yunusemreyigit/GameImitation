using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 0.3f;
    private void Update()
    {
        if (transform.position.x >= 3f || transform.position.x <= -3f)
        {
            speed = -speed;
        }
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
