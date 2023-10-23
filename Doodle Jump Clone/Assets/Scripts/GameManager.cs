using UnityEngine;
using UnityEngine.SceneManagement;

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
    private int highScore;
    private void Start()
    {
        highScore = FileHandler.loadFromJson("score.txt").highScore;
    }

    public void gameOver()
    {
        if (score >= highScore)
        {
            highScore = score;
        }
        FileHandler.saveToJSON(new InputHandler(highScore, score), "score.txt");
        SceneManager.LoadScene(0);
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
