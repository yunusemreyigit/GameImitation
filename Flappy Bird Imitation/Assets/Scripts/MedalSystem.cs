using UnityEngine;
using UnityEngine.UI;

public class MedalSystem : MonoBehaviour
{
    public Sprite[] medals;
    public Image image;

    public static MedalSystem Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void giveMedal(int score)
    {
        image.sprite = medals[4];
        if (score >= 10 && score < 20)
            image.sprite = medals[0];
        else if (score >= 20 && score < 30)
            image.sprite = medals[1];
        else if (score >= 30 && score < 40)
            image.sprite = medals[2];
        else if (score >= 40)
            image.sprite = medals[3];

    }
}
