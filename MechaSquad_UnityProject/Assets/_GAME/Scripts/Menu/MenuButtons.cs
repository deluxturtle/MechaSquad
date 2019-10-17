using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Author: Andrew Seba
/// Description: Changes scene music as well.
/// </summary>
public class MenuButtons : MonoBehaviour
{
    GameObject menuCamera;
    public MusicPlayer musicPlayer;

    private void Start()
    {
        menuCamera = gameObject;//this script is attached to main camera (MENU)
        if(musicPlayer == null)
        {
            musicPlayer = GetComponentInChildren<MusicPlayer>();
        }
    }

    //just does a direct load.
    public void _LoadSceneName(string sceneName)
    {
        if(sceneName == "2PlayerGame")
        {
            musicPlayer.PlayBattleSong();
        }
        SceneManager.LoadScene(sceneName);
    }

    public void _AddSceneName(string sceneName)
    {
        if(sceneName == "2PlayerGame")
        {
            musicPlayer.PlayBattleSong();
        }
        else if(sceneName == "Menu")
        {
            musicPlayer.PlayMenuSong();
        }
        StartCoroutine(LoadAsyncScene(sceneName));
    }

    /// <summary>
    /// Cool async loading for scenes.
    /// </summary>
    /// <param name="sceneName">Scene name of what you want to load.</param>
    /// <returns>Nothing</returns>
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
