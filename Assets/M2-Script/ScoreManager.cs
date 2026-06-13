using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI scoreText;

    private int huidigeScore = 0;

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

        ZetScoreZichtbaar(false);
    }

    private void Start()
    {
        ZetScoreZichtbaar(false);
        UpdateScoreUI();
    }

    public void ToonScoreTijdensSpelen()
    {
        ZetScoreZichtbaar(true);
    }

    public void VoegPuntenToe(int punten)
    {
        huidigeScore += punten;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + huidigeScore;
        }
    }

    private void ZetScoreZichtbaar(bool status)
    {
        if (scoreText != null)
        {
            scoreText.gameObject.SetActive(status);
        }
    }
}