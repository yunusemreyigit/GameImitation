using UnityEngine;

public class WallDetect : MonoBehaviour
{
    public bool wallDetected;
    void OnTriggerEnter2D(Collider2D other)
    {
        print("lalla");
        wallDetected = true;
    }
}
