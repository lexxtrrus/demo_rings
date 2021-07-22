using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingCanvasFade : MonoBehaviour
{
    [SerializeField] private CanvasGroup loadingCanvas;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        loadingCanvas.alpha = 1f;
    }

    public void Hide()
    {
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        while (loadingCanvas.alpha > 0)
        {
            loadingCanvas.alpha -= 0.03f;
            yield return new WaitForSeconds(0.03f);
        }
        
        gameObject.SetActive(false);
    }
}
