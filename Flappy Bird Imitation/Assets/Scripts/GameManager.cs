using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    private int bestScore = 0;
    int frameRate = 60;
    public Player player;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
        bestScore = int.Parse(DataHandling.Instance.Load("score"));
    }
    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = frameRate;
    }
    public void GameOver()
    {
        Destroy(player.gameObject);
        DataHandling.Instance.Save("score", bestScore.ToString());
        MedalSystem.Instance.giveMedal(score);
        UIManager.Instance.GameOver();
        AnimationManager.Instance.GameOver();
    }

    public void addScore()
    {
        score += 1;
        if (score >= bestScore)
            bestScore = score;
    }
    public int getScore()
    {
        return score;
    }
    public int getBestScore()
    {
        return bestScore;
    }

}
