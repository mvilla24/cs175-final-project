using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public GameObject sun;
    public GameObject moon;

    private Material daySkyBox;
    private Material nightSkyBox;
    public Material dayNormalSky;
    public Material nightNormalSky;
    public Material dayWeatherSky;
    public Material nightWeatherSky;

    private float dayIntensity = 1.25f;
    private float nightIntensity = 0.3f;

    public float sunAngle = 0f;
    public float dayLength = 20f;

    private float sunSpeed;

    public float moonAngle = 0f;
    public float nightLength = 20f;
    private float moonSpeed;

    public bool isDay = true;
    public bool isNight = false;

    public bool badWeather = true;

    static bool hasInstance = false;
    // Start is called before the first frame update
    void Start()
    {
        if (hasInstance)
        {
            Destroy(gameObject);
        }
        hasInstance = true;
        DontDestroyOnLoad(gameObject);
    
        badWeather = GameData.badWeather;
        if (!badWeather)
        {
            daySkyBox = dayNormalSky;
            nightSkyBox = nightNormalSky;
            sun.GetComponent<Light>().shadowStrength = 0.7f;
            moon.GetComponent<Light>().shadowStrength = 0.5f;
        }
        else
        {
            daySkyBox = dayWeatherSky;
            nightSkyBox = nightWeatherSky;
            sun.GetComponent<Light>().shadowStrength = 0.35f;
            moon.GetComponent<Light>().shadowStrength = 0.25f;
        }
        sunSpeed = 180f/dayLength;
        moonSpeed = 180f/nightLength;
        sun.transform.rotation = Quaternion.Euler(-10f, -30f, 0f);
        moon.transform.rotation = Quaternion.Euler(0f, -30f, 0f);

        // Show sunrise by default
        isDay = true;
        RenderSettings.skybox = daySkyBox;
        RenderSettings.ambientIntensity = dayIntensity;
        sun.SetActive(true);
        isNight = false;
        moon.SetActive(false);
    }

    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        // Separate cases in case overlap necessary later
        UpdateWeather();
        if (isDay)
        {
            DayCycle();
        }
        if (isNight)
        {
            NightCycle();
        }

    }

    void DayCycle() 
    {
        float sunStep = sunSpeed * Time.deltaTime;
        sunAngle += sunStep;
        sun.transform.Rotate(new Vector3(sunStep, 0f, 0f));
        if (sunAngle >= 188f)
        {
            // Show and start night
            isNight = true;
            RenderSettings.skybox = nightSkyBox;
            RenderSettings.ambientIntensity = nightIntensity;
            moon.SetActive(true);
            // Hide and reset day
            isDay = false;
            sun.SetActive(false);
            sunAngle = 0f;
            sun.transform.rotation = Quaternion.Euler(-10f, -30f, 0f);
        }
    }

    void NightCycle() 
    {
        float moonStep = moonSpeed * Time.deltaTime;
        moonAngle += moonStep;
        moon.transform.Rotate(new Vector3(moonStep, 0f, 0f));
        if (moonAngle >= 180f)
        {
            // Show and start day
            isDay = true;
            RenderSettings.skybox = daySkyBox;
            RenderSettings.ambientIntensity = dayIntensity;
            sun.SetActive(true);
            // Hide and reset night
            isNight = false;
            moon.SetActive(false);
            moonAngle = 0f;
            moon.transform.rotation = Quaternion.Euler(0f, -30f, 0f);
        }
    }

    public void UpdateWeather()
    {
        if (badWeather == GameData.badWeather)
        {
            return;
        }
        // Debug.Log("Updating Weather");
        badWeather = GameData.badWeather;
        if (!badWeather)
        {
            daySkyBox = dayNormalSky;
            nightSkyBox = nightNormalSky;
            sun.GetComponent<Light>().shadowStrength = 0.7f;
            moon.GetComponent<Light>().shadowStrength = 0.5f;
        }
        else
        {
            daySkyBox = dayWeatherSky;
            nightSkyBox = nightWeatherSky;
            sun.GetComponent<Light>().shadowStrength = 0.35f;
            moon.GetComponent<Light>().shadowStrength = 0.25f;
        }
        
        if (isDay)
        {
            RenderSettings.skybox = daySkyBox;
        }
        if (isNight)
        {
            RenderSettings.skybox = nightSkyBox;
        }
    }
}
