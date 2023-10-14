using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : Platform
{
    [SerializeField] private float speed = 1.0f;
    void Update()
    {
        if (transform.position.x >= 3.5f || transform.position.x <= -3.5f)
        {
            speed = -speed;
        }
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
