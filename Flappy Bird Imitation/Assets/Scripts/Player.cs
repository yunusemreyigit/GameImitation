using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpPower = 2;
    [SerializeField] private Vector2 yBounder;
    private Rigidbody2D rigidbody;
    public AudioSource audio;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (transform.position.y > yBounder.x || transform.position.y < yBounder.y)
        {
            GameManager.Instance.GameOver();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.velocity = new Vector2(0, 0);
            rigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("gameover"))
        {
            GameManager.Instance.GameOver();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("score"))
        {
            GameManager.Instance.addScore();
            //score sound
            audio.Play();
        }
    }
}
