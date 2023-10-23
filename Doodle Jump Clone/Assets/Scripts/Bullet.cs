using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 15;
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        Destroy(this, 5);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
