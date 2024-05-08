using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Image progressBar;
    // Start is called before the first frame update
    void Start()
    {
        GameData.ResumeGame();
        StartCoroutine(AsyncLoadScene());
    }

    IEnumerator AsyncLoadScene()
    {
        yield return new WaitForSeconds(0.5f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(GameData.sceneToLoad);
        operation.allowSceneActivation = false;

        bool isLoading = true;
        while (!operation.isDone && isLoading)
        {
            // Debug.Log(operation.progress);
            // progressBar.fillAmount = operation.progress;
            if (operation.progress >= 0.9f)
            {
                isLoading = false;
            }
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        operation.allowSceneActivation = true;
    }
}
