using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string targetScene;
    FadeUI sceneTransition;
    // Start is called before the first frame update

    void Start()
    {
        sceneTransition = gameObject.GetComponent<FadeUI>();
    }
    
    public void LoadTargetScene(string target)
    {
        targetScene = target;
        StartCoroutine(SceneLoader());
    }

    public void DirectToTargetScene(string target)
    {
        targetScene = target;
        StartCoroutine(GoToTargetScene());
    }

    IEnumerator SceneLoader()
    {
        GameData.sceneToLoad = targetScene;
        sceneTransition.FadeInObject();
        yield return new WaitWhile (()=> sceneTransition.isFading);
        SceneManager.LoadScene("loading");
    }

    IEnumerator GoToTargetScene()
    {
        sceneTransition.FadeInObject();
        yield return new WaitWhile (()=> sceneTransition.isFading);
        SceneManager.LoadScene(targetScene);
    }
}
