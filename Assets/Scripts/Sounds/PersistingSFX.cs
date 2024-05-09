using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class PersistingSFX : MonoBehaviour
{
    AudioSource source;
    public AudioMixer mixer;
    public AudioClip[] sfxSongs;

    // static bool hasInstance = false;

    // 0 - Spring; 1 - Summer, 2 - Fall, 3 - Winter
    public int sfxIndex = 0;

    private string currentScene;

    // Start is called before the first frame update
    // void Start()
    // {
    //     if (hasInstance)
    //     {
    //         Destroy(gameObject);
    //     }
    //     hasInstance = true;
    //     DontDestroyOnLoad(gameObject);
    //     // yield return new WaitForSeconds(2f);
    // }

    void Start()
    {
        currentScene = GameData.sceneToLoad;
        source = GetComponent<AudioSource>();
        source.clip = sfxSongs[sfxIndex];
        mixer.SetFloat("SFXVolume", Mathf.Log10(0.0f) * 20);
        StartSong();
    }

    void Update()
    {
        CheckWeather();
    }

    public void StartSong()
    {
        UpdateClipIndex();
        // temp fix for no SFX
        if (sfxIndex != 3)
        {
            source.clip = sfxSongs[sfxIndex];
            StartCoroutine(FadeMixerGroup.StartFade(mixer, "SFXVolume", 0.5f, 1.0f));
            source.Play();
        }
        else
        {
            StartCoroutine(FadeMixerGroup.StartFade(mixer, "SFXVolume", 0.5f, 1.0f));
        }
    }

    public void EndSong()
    {
        if (currentScene == GameData.sceneToLoad)
        {
            return;
        }
        StartCoroutine(FadeMixerGroup.StartFade(mixer, "SFXVolume", 0.5f, 0.0f));
    }

    public void UpdateClipIndex()
    {
        if (GameData.sceneToLoad == GameData.springScene)
        {
            sfxIndex = 0;
        }
        else if (GameData.sceneToLoad == GameData.summerScene)
        {
            sfxIndex = 1;
        }
        if (GameData.sceneToLoad == GameData.fallScene)
        {
            sfxIndex = 2;
        }
        if (GameData.sceneToLoad == GameData.winterScene)
        {
            sfxIndex = 3;
        }
        currentScene = GameData.sceneToLoad;
    }

    void CheckWeather()
    {
        if (!GameData.badWeather && GameData.sceneToLoad == GameData.springScene)
        {
            source.Stop();
        }
        else if (!source.isPlaying)
        {
            StartSong();
        }
    }
}
