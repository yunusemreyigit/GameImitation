using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoretxt;

    private void Update()
    {
        scoretxt.text = GameManager.Instance.getScore().ToString();
    }
}
