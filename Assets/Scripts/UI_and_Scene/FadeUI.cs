using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeUI : MonoBehaviour
{
    public Image mainRenderer;
    public bool isTransparentAtStart = false;
    public bool fadesOutAtStart = false;
    // float fadeSpeed = 0.325f; Slow Speed
    public float fadeSpeed = 1.625f;
    float speedDefault;
    public bool isFading = false;
    public IEnumerator currentCoroutine;
    public bool fadesInAtStart = false;
    public float startFadeInTarget = 1f;
    public float startFadeOutTarget = 0f;
    // public GameObject highlight;

    void Awake()
    {
        speedDefault = fadeSpeed;
        mainRenderer = gameObject.GetComponent<Image>();
        // Debug.Log(mainRenderer.material);
        if (isTransparentAtStart)
        {
            InstantFadeOut();
        }
        if (fadesOutAtStart)
        {
            FadeOutObject(startFadeOutTarget);
        }
        if (fadesInAtStart)
        {
            FadeInObject(startFadeInTarget);
        }
    }

    public void InstantFadeOut()
    {
        Color tileColor = mainRenderer.color;
        tileColor.a = 0f;
        mainRenderer.color = tileColor;
    }

    public void InstantFadeIn()
    {
        Color tileColor = mainRenderer.color;
        tileColor.a = 1f;
        mainRenderer.color = tileColor;
    }

    public void FadeOutObject(float fadeTarget = 0f, float speedOverride = 0f)
    {
        if (isFading) {
            StopCoroutine(currentCoroutine);
        }
        currentCoroutine = FadingOut(fadeTarget);
        if (speedOverride == 0f)
        {
            fadeSpeed = speedDefault;
        }
        else
        {
            fadeSpeed = speedOverride;
        }
        StartCoroutine(currentCoroutine);
    }

    public void FadeInObject(float fadeTarget = 1f, float speedOverride = 0f)
    {
        if (isFading) {
            StopCoroutine(currentCoroutine);
        }
        currentCoroutine = FadingIn(fadeTarget);
        if (speedOverride == 0f)
        {
            fadeSpeed = speedDefault;
        }
        else
        {
            fadeSpeed = speedOverride;
        }
        StartCoroutine(currentCoroutine);
    }

    public IEnumerator FadingOut(float target)
    {
        // float fadeTime = 0;
        isFading = true;
        while (mainRenderer.color.a > target)
        {
            Color objectColor = mainRenderer.color;
            objectColor.a -= (fadeSpeed * Time.unscaledDeltaTime);
            // objectColor.a -= (fadeSpeed * Time.deltaTime);
            // mainRenderer.color = new Color(tileColor.r, tileColor.g, tileColor.b, fadeAmount);
            mainRenderer.color = objectColor;
            yield return null;
            // fadeTime += Time.deltaTime;
        }
        isFading = false;
        // Debug.Log(fadeTime);
    }

    public IEnumerator FadingIn(float target)
    {
        isFading = true;
        while (mainRenderer.color.a < target)
        {
            Color objectColor = mainRenderer.color;
            objectColor.a += (fadeSpeed * Time.unscaledDeltaTime);
            // objectColor.a += (fadeSpeed * Time.deltaTime);
            // mainRenderer.color = new Color(tileColor.r, tileColor.g, tileColor.b, fadeAmount);
            mainRenderer.color = objectColor;
            yield return null;
        }
        isFading = false;
    }

    // public void HighlightTile()
    // {
    //     FadeOut();
    //     highlight.SetActive(true);
    // }
}
