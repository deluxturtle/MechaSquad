﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Andrew Seba
/// Description: 
/// </summary>
public class PlayerAiming : MonoBehaviour
{
    public float minimum = -1.0f;
    public float maximum = 1.0f;
    float multiplyer = 0.5f;//how fast the pinging will be multiplied.
    bool stopLerp = false;
    float value = 0;
    // Start is called before the first frame update
    void OnEnable()
    {
        StartAiming();
    }

    /// <summary>
    /// Just incase the script or player gets disabled?
    /// </summary>
    void OnDisable()
    {
        StopCoroutine("LerpValue");
    }

    void Update()
    {
        Input();
    }

    /// <summary>
    /// (Handles input during aiming.)
    /// Space = Stop
    /// </summary>
    void Input()
    {
        //Uhhh we need to click the screen dingus.
        #if UNITY_EDITOR
        if(UnityEngine.Input.GetButtonDown("Jump"))
        {
            StopAiming();
        }
        #endif
        if(UnityEngine.Input.touchCount > 0)
        {
            Touch touch = UnityEngine.Input.GetTouch(0);
            //On touch stop aiming.
            if(touch.phase == TouchPhase.Began)
            {
                StopAiming();
            }
        }

    }

    /// <summary>
    /// Sets the lerping loop to escape.
    /// </summary>
    void StopAiming()
    {
        stopLerp = true;
    }

    void StartAiming()
    {
        value = 0;
        stopLerp = false;
        StartCoroutine("LerpValue");
    }

    /// <summary>
    /// Pings a value between 1 and 0 untill stopped by the boolean.
    /// </summary>
    /// <returns></returns>
    IEnumerator LerpValue()
    {
        
        float pos = 0;
        while(!stopLerp)
        {
            
            pos = Mathf.Lerp(minimum, maximum, value);
            value += multiplyer * Time.deltaTime;
            Debug.Log(pos);
            //https://docs.unity3d.com/ScriptReference/Mathf.Lerp.html
            //if hit the max flip the values and it will ping.
            //Pretty cool swap to save on memory.
            if(value > 1.0f)
            {
                float temp = maximum;
                maximum = minimum;
                minimum = temp;
                value = 0.0f;
            }
            yield return null;
        }
        //disable script when done.
        this.enabled = false;
    }
}
