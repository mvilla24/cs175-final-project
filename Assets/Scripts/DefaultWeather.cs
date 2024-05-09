using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultWeather : MonoBehaviour
{
    // Update is called once per frame
    void Awake()
    {
        if (GameData.sceneToLoad == GameData.springScene
            || GameData.sceneToLoad == GameData.winterScene)
        {
           GameData.badWeather = true;
        }
        else
        {
            GameData.badWeather = false;
        }
    }

    public void ToggleWeather()
    {
        GameData.ToggleWeather();
    }
}
