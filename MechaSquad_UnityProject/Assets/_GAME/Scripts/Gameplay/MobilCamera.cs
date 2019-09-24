using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Andrew Seba
/// Description: RTS Camera test.
/// </summary>
public class MobilCamera : MonoBehaviour
{

    public float heightLimit = 8f;
    [Tooltip("")]
    [Range(0, 10f)]
    public float dampen = 1f;

    Vector2 startPos;
    Vector2 endPos;
    Vector2 dir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Grab touch vector and add it to camera x,z.
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            startPos = touch.position;

            if(touch.phase == TouchPhase.Moved)
            {
                endPos = touch.position;
                dir = endPos - startPos;

            }
        }
    }


}
