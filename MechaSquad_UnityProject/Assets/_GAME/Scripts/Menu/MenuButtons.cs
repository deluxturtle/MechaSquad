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
}
