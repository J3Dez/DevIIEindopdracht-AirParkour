using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI scoreText;

    private int huidigeScore = 0;
    private bool levelLoaded = false;

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

        Debug.Log("Score: " + huidigeScore);

        if (huidigeScore >= 120 && !levelLoaded)
        {
            Debug.Log("WE GAAN NAAR END SCENE!");

            levelLoaded = true;
            SceneManager.LoadScene("Endscene");
        }
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