using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Author: Andrew Seba
/// Description: Most touch Input. Will be enabled when it's the players turn.
/// </summary>
public class Player : MonoBehaviour
{
    [Tooltip("Testing Explosion Animation Obj")]
    public GameObject explosion;
    [Tooltip("Shows information about what the player is doing.")]
    public bool printDebug = false;
    Vector2 startPos;
    Vector3 shootDir;
    GameObject selectedMech = null;

    public void Init(string name)
    {
        
    }

    private void Update()
    {
        //Touch Input
        if(Input.touchCount > 0)
        {
            //touch is original touch (0)
            Touch touch = Input.GetTouch(0);

            //Grab the starting position of touch and do first contact actions.
            if (touch.phase == TouchPhase.Began)
            {
                startPos = touch.position;

                //Ray cast down to mech obj.
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                Physics.Raycast(ray, out hit);

                //Select Mech
                Transform clickedObj = hit.collider.transform.parent;
                if (clickedObj.GetComponent<Mech>() != null)
                {
                    if (ClickedDifferentMech(clickedObj.gameObject))
                    {
                        selectedMech = clickedObj.gameObject;
                    }
                }
            }

            //If dragging shoot bullet with the behavior of a slingshot.
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 pos = touch.position;
                Vector2 dist = pos - startPos;
                shootDir = new Vector3(-dist.x, 0, -dist.y);
            }

            if(touch.phase == TouchPhase.Ended)
            {
                //Shoot(shootDir);
                selectedMech.GetComponent<Mech>().Shoot(shootDir);
            }
        }

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
