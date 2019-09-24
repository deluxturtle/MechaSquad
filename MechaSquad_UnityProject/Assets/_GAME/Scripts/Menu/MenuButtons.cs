using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Author: Andrew Seba
/// </summary>
public class MenuButtons : MonoBehaviour
{
    //just does a direct load.
    public void _LoadSceneName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void _AddSceneName(string sceneName)
    {
        StartCoroutine(LoadAsyncScene(sceneName));
    }

    IEnumerator LoadAsyncScene(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        while(!asyncLoad.isDone)
        {
            yield return null;
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneAt(1));
    }

}
