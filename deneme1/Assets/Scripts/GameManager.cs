using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int score = 0;
    public Text scoreText;
    public Image scoreImage; // Yeni eklenen Image

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        FindObjectOfType<ScoreAnimator>().AnimateScore();

        if (scoreText != null)
        {
            scoreText.text = "Puan: " + score;
        }

        // Opsiyonel: Puan arttıkça görüntüyü değiştirme
        if (score >= 2 && scoreImage != null)
        {
            scoreImage.color = Color.yellow; // Puan 2 yi geçince arkaplan değişsin
        }
    }
}