using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    private int score = 0;

    public void gameOver()
    {
        Debug.Log("GameOver");
        Time.timeScale = 0;
    }

    public void setScore(int _score)
    {
        score = _score * 10;
    }
    public int getScore()
    {
        return score;
    }
}
