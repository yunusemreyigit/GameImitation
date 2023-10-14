using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float gap;
    float posY, tempPos;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        posY = transform.position.y;
    }
    void Update()
    {
        tempPos = gap + player.transform.position.y;
        if (tempPos >= posY)
        {
            posY = tempPos;
        }
        transform.position = new Vector3(0, posY, -10);
        GameManager.Instance.setScore((int)transform.position.y);
    }
}
