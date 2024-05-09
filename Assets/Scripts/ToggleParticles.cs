using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleParticles : MonoBehaviour
{
    private bool badWeather = true;
    public GameObject weatherParticles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (badWeather != GameData.badWeather)
        {
            badWeather = GameData.badWeather;
            weatherParticles.SetActive(badWeather);
        }
    }
}
