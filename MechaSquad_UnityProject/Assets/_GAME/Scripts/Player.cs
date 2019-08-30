using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Author: Andrew Seba
/// Description: Most touch Input. Will be enabled when it's the players turn.
/// </summary>
public class Player : MonoBehaviour
{

    [Tooltip("Shows information about what the player is doing.")]
    public bool printDebug = false;
    GameObject selectedMech = null;
    float height;
    float width;

    private void Awake()
    {
        width = Screen.width / 2.0f;
        height = Screen.height / 2.0f;
    }

    public void Init(string name)
    {
        
    }

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 startPos = touch.position;

            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            Transform clickedObj = hit.collider.transform.parent;
            if(clickedObj.GetComponent<Mech>() != null)
            {
                if(ClickedDifferentMech(clickedObj.gameObject))
                {
                    selectedMech = clickedObj.gameObject;
                }
            }

            if(touch.phase == TouchPhase.Moved)
            {
                Vector2 pos = touch.position;
                //pos.x = (pos.x - width) / width;
                //pos.y = (pos.y - height) / height;
            }

            if(touch.phase == TouchPhase.Ended)
            {
                Debug.Log("Fire.");
            }
        }
    }

    void Shoot()
    {

    }

    /// <summary>
    /// Check to see if different mech was selected.
    /// </summary>
    /// <param name="pClickedObj"></param>
    /// <returns></returns>
    bool ClickedDifferentMech(GameObject pClickedObj)
    {
        if (pClickedObj != selectedMech)
        {
            Debug.Log("MechName// " + pClickedObj.GetComponent<Mech>().GetName());
            return true;
        }
        else
            return false;

    }
}
