using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI lastScore;
    private void Awake()
    {
        highScore.text = "HIGH SCORE    " + FileHandler.loadFromJson("score.txt").highScore;
        lastScore.text = "LAST SCORE    " + FileHandler.loadFromJson("score.txt").lastScore;
    }
    public void playButton()
    {
        SceneManager.LoadScene(1);
    }
}
