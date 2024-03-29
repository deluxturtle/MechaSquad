﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Author: Andrew Seba
/// Description: 
/// Most touch Input. Will be enabled when it's the players turn.
/// script starts disabled.
/// </summary>
public class Player : MonoBehaviour
{
    public bool move = false;
    [Tooltip("Testing Explosion Animation Obj")]
    public GameObject explosion;
    [Tooltip("Shows information about what the player is doing.")]
    public bool printDebug = false;
    public string PlayerName { get; set; } = "player";
    public Team Team { get; set; }

    //Private
    List<Mech> mechs = new List<Mech>();
    Vector2 startPos;
    Vector3 shootDir;
    GameObject selectedMech = null;
    RaycastHit debughit;
    PlayerAiming aimingScript;

    private void Start()
    {
        aimingScript = GetComponent<PlayerAiming>();
    }

    //public int MechLimit { get; set; }

    private void OnEnable()
    {
        Debug.Log("Player " + PlayerName + " is starting!");
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
                //Ray cast down to mech obj.
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                Physics.Raycast(ray, out hit);
                if (hit.collider != null)
                {
                    //Select Mech
                    Transform clickedObj = hit.collider.transform.parent;
                    if (clickedObj.GetComponent<Mech>() != null)
                    {
                        startPos = touch.position;//start tracking if clicked a mech.
                        if (ClickedDifferentMech(clickedObj.gameObject))
                        {
                            selectedMech = clickedObj.gameObject;
                            EnableAiming();
                            //RIGHT NOW IT ONLY ENABLES THE SCRIPT IF YOU CLICK A NEW MECH.
                        }

                    }
                    else//No mech under cursor
                    {
                        selectedMech = null;
                    }
                }

            }
            #if UNITY_EDITOR
            if(Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                Physics.Raycast(ray, out hit);
                if (hit.collider != null)
                {
                    //Select Mech
                    Transform clickedObj = hit.collider.transform.parent;
                    if (clickedObj.GetComponent<Mech>() != null)
                    {
                        //start tracking if clicked a mech.
                        startPos = Input.mousePosition;
                        if (ClickedDifferentMech(clickedObj.gameObject))
                        {
                            selectedMech = clickedObj.gameObject;
                            EnableAiming();
                        }

                    }
                    else//No mech under cursor
                    {
                        selectedMech = null;
                    }
                }
            }
            #endif

            // //If dragging shoot bullet with the behavior of a slingshot.
            // if (touch.phase == TouchPhase.Moved)
            // {
            //     if (move && selectedMech != null)
            //     {
            //         Ray ray = Camera.main.ScreenPointToRay(touch.position);
            //         RaycastHit hit;
            //         Physics.Raycast(ray, out hit);

            //         if(Vector3.Distance(hit.point, selectedMech.transform.position) > 1)
            //         {
            //             Debug.Log("ping");
            //             selectedMech.transform.position = hit.point;
            //         }
            //     }
            //     else
            //     {
            //         Vector2 pos = touch.position;
            //         Vector2 dist = pos - startPos;
            //         shootDir = new Vector3(-dist.x, 0, -dist.y);
            //     }
            // }

            // if (touch.phase == TouchPhase.Ended && selectedMech != null)
            // {
            //     selectedMech.GetComponent<Mech>().Shoot(shootDir);
            // }
        }

    }

    /// <summary>
    /// Enables the aiming script and starts the aiming process.
    /// </summary>
    void EnableAiming()
    {
        aimingScript.enabled = true;
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
            Debug.Log("MechName// " + pClickedObj.GetComponent<Mech>().Alias);
            return true;
        }
        else
            return false;

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(debughit.point, 2f);
    }
}
