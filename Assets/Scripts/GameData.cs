using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    public static int minX = 0;
    public static int minY = 0;
    public static int maxX = 192;
    public static int maxY = 128;
    public static int subWidth = 58;
    public static int subHeight = 40;
    public static Vector2 regionOffset = new Vector3(9f, 4f);

    public static string sceneToLoad = "spring";

    public static bool isGamePaused = false;

    public static string springScene = "spring";
    public static string summerScene = "summer";
    public static string fallScene = "fall";
    public static string winterScene = "winter";

    // public static int HighScore
    // {
    //     get
    //     {
    //         return PlayerPrefs.GetInt("HighScore", 0);
    //     }
    //     set
    //     {
    //         PlayerPrefs.SetInt("HighScore", value);
    //     }
    // }

    public static void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0;
    }
    public static void ResumeGame()
    {
        isGamePaused = false;
        Time.timeScale = 1;
    }
}
