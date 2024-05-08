using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocationPicker : MonoBehaviour
{
    bool isSceneChosen = false;
    public ChangeScene sceneTransition;

    public void GoToSpring()
    {
        if (isSceneChosen)
        {
            return;
        }
        else
        {
            isSceneChosen = true;
        }
        sceneTransition.LoadTargetScene(GameData.springScene);
    }

    public void GoToSummer()
    {
        if (isSceneChosen)
        {
            return;
        }
        else
        {
            isSceneChosen = true;
        }
        sceneTransition.LoadTargetScene(GameData.summerScene);
    }

    public void GoToFall()
    {
        if (isSceneChosen)
        {
            return;
        }
        else
        {
            isSceneChosen = true;
        }
        sceneTransition.LoadTargetScene(GameData.fallScene);
    }

    public void GoToWinter()
    {
        if (isSceneChosen)
        {
            return;
        }
        else
        {
            isSceneChosen = true;
        }
        sceneTransition.LoadTargetScene(GameData.winterScene);
    }

}
