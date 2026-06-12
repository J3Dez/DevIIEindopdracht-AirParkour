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
    [SerializeField] private float loadingTime = 3f;
    [SerializeField] private float fadeDuration = 1f;

    private void Start()
    {
        ShowRandomTip();

        Time.timeScale = 0f; // game pauze
        ShowRandomTip();

    }

    public void StartGame()
    {
        Time.timeScale = 1f; // game starten
        StartCoroutine(FadeOut());
    }

    private void ShowRandomTip()
    {
        if (tips == null || tips.Length == 0)
        {
            tipText.text = "No tips available.";
            return;
        }

        int randomIndex = Random.Range(0, tips.Length);
        tipText.text = tips[randomIndex];
    }

    private void StartFadeOut()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float time = 0f;

        while (time < fadeDuration)
        {
            canvasGroup.alpha = 1 - (time / fadeDuration);
            time += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 0;
        loadingScreen.SetActive(false);
    }
}