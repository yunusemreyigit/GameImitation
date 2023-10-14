using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    private void Start()
    {
        Destroy(this.gameObject, 30);
    }
}
