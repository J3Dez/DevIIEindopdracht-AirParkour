using UnityEngine;
using TMPro;
using System.Collections;

public class LoadingScreenManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private TMP_Text tipText;
    [SerializeField] private CanvasGroup canvasGroup;

    [Header("Tips")]
    [SerializeField] private string[] tips;

    [Header("Settings")]
    [SerializeField] private float fadeDuration = 1f;

    private void Start()
    {
        Time.timeScale = 0f; // game pauze
        ShowRandomTip();

    }

    public void StartGame()
    {
        Time.timeScale = 1f; // game starten
        loadingScreen.SetActive(false);
    }

    private void ShowRandomTip()
    {
        if (tips == null || tips.Length == 0 || tipText == null)
        {
            Debug.LogWarning("Tips of TipText niet ingesteld!");
            return;
        }

        int randomIndex = Random.Range(0, tips.Length);
        tipText.text = tips[randomIndex];
    }

  

    private IEnumerator FadeOut()
    {
        float time = 0f;

        while (time < fadeDuration)
        {
            canvasGroup.alpha = 1 - (time / fadeDuration);
            time += Time.unscaledDeltaTime; 
            yield return null;
        }

        canvasGroup.alpha = 0;
        loadingScreen.SetActive(false);
    }
}