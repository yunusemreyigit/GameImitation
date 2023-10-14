using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float springPower;
    [SerializeField] private float rocketPower;
    private bool isRocket;
    float speedY;
    GameManager gameManager;
    public Animator anim;
    private SpriteRenderer spriteRenderer;
    public AudioSource jumpSound;
    public AudioSource springSound;
    public AudioSource rocketSound;
    public GameObject rocket;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = GameManager.Instance;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        move();
        exitCameraView();
        float value = Camera.main.transform.position.y - transform.position.y;
        if (Math.Abs(value) > 8)
        {
            gameManager.gameOver();
        }
        rocketSettings();
        if (speedY < 0)
        {
            if (isRocket) isRocket = false;
        }
    }

    private void rocketSettings()
    {
        if (isRocket)
        {
            rocket.SetActive(true);
            rocketSound.Play();
            anim.Play("rocket");
        }
        else
        {
            rocket.SetActive(false);
            rocketSound.Stop();
        }
    }

    private void exitCameraView()
    {
        if (transform.position.x < -4.8f)
        {
            transform.position = new Vector2(4.8f, transform.position.y);
        }
        if (transform.position.x > 4.8f)
        {
            transform.position = new Vector2(-4.8f, transform.position.y);
        }
    }

    private void move()
    {
        float v = Input.GetAxis("Horizontal");
        speedY = rigidbody2D.velocity.y;
        if (v > 0) transform.rotation = Quaternion.Euler(0, 0, 0);
        if (v < 0) transform.rotation = Quaternion.Euler(0, 180, 0);

        rigidbody2D.velocity = new Vector2(v * maxSpeed, rigidbody2D.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (speedY <= 0)
        {
            if (other.gameObject.CompareTag("Platform"))
            {
                rigidbody2D.AddForce(Vector2.up * maxSpeed, ForceMode2D.Impulse);
                anim.SetBool("jump", true);
                jumpSound.Play();
            }
        }

    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            anim.SetBool("jump", false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (speedY <= 0)
        {
            if (other.gameObject.CompareTag("Spring"))
            {
                rigidbody2D.AddForce(Vector2.up * maxSpeed * springPower, ForceMode2D.Impulse);
                springSound.Play();
            }
            if (other.gameObject.CompareTag("Rocket"))
            {
                rigidbody2D.AddForce(Vector2.up * maxSpeed * rocketPower, ForceMode2D.Impulse);
                isRocket = true;
            }
        }
    }
}
