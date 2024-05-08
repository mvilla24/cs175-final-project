using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public SpriteRenderer mainRenderer;
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
        mainRenderer = gameObject.GetComponent<SpriteRenderer>();
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
        if (speedOverride == 0f)
        {
            fadeSpeed = speedDefault;
        }
        else
        {
            fadeSpeed = speedOverride;
        }
        currentCoroutine = FadingOut(fadeTarget);
        StartCoroutine(currentCoroutine);
    }

    public void FadeInObject(float fadeTarget = 1f, float speedOverride = 0f)
    {
        if (isFading) {
            StopCoroutine(currentCoroutine);
        }
        if (speedOverride == 0f)
        {
            fadeSpeed = speedDefault;
        }
        else
        {
            fadeSpeed = speedOverride;
        }
        currentCoroutine = FadingIn(fadeTarget);
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
