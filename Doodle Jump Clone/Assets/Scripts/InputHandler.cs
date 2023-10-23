using System;
using UnityEngine.SocialPlatforms.Impl;

[Serializable]
public class InputHandler
{
    public int highScore;
    public int lastScore;

    public InputHandler(int _highScore, int _score)
    {
        highScore = _highScore;
        lastScore = _score;
    }
}
