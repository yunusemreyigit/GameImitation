using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestText;
    [SerializeField] private TextMeshProUGUI realtimeScoretxt;

    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        realtimeScoretxt.text = GameManager.Instance.getScore().ToString();
    }

    public void GameOver()
    {
        realtimeScoretxt.enabled = false;
        scoreText.text = GameManager.Instance.getScore().ToString();
        bestText.text = DataHandling.Instance.Load("score");
    }

    public void okBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void menuBtn()
    {
        SceneManager.LoadScene(0);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
