using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class PersistingBGM : MonoBehaviour
{
    AudioSource source;
    public AudioMixer mixer;
    public AudioClip[] bgmSongs;

    // static bool hasInstance = false;

    // 0 - Spring; 1 - Summer, 2 - Fall, 3 - Winter
    public int bgmIndex = 0;

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
        source = GetComponent<AudioSource>();
        source.clip = bgmSongs[bgmIndex];
        mixer.SetFloat("BGMVolume", Mathf.Log10(0.0f) * 20);
        StartSong();
    }

    public void StartSong()
    {
        UpdateClipIndex();
        source.clip = bgmSongs[bgmIndex];
        StartCoroutine(FadeMixerGroup.StartFade(mixer, "BGMVolume", 0.5f, 1.0f));
        source.Play();
    }

    public void EndSong()
    {
        if (currentScene == GameData.sceneToLoad)
        {
            return;
        }
        StartCoroutine(FadeMixerGroup.StartFade(mixer, "BGMVolume", 0.5f, 0.0f));
    }

    public void UpdateClipIndex()
    {
        if (GameData.sceneToLoad == GameData.springScene)
        {
            bgmIndex = 0;
        }
        else if (GameData.sceneToLoad == GameData.summerScene)
        {
            bgmIndex = 1;
        }
        if (GameData.sceneToLoad == GameData.fallScene)
        {
            bgmIndex = 2;
        }
        if (GameData.sceneToLoad == GameData.winterScene)
        {
            bgmIndex = 3;
        }
        currentScene = GameData.sceneToLoad;
    }
}
