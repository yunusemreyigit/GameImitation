using UnityEngine;

public class Wall : MonoBehaviour
{
    //public bool canReplace;
    float speed = 2.5f;
    private void FixedUpdate()
    {
        transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
    }
    private void Update()
    {
        if (transform.position.x <= -14)
        {
            gameObject.SetActive(false);
        }
    }
}
