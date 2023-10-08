using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator gameOverPanelAnimator;

    public static AnimationManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    public void GameOver()
    {
        gameOverPanelAnimator.SetBool("gameover", true);
    }
}
