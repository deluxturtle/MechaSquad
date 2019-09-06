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
                
                Debug.DrawRay(selectedMech.transform.position, shootDir.normalized);
            }

            if(touch.phase == TouchPhase.Ended)
            {
                Shoot(shootDir);
            }
        }

    }

    /// <summary>
    /// HitScan shooting style.
    /// </summary>
    /// <param name="pDir">Direction of Ray</param>
    void Shoot(Vector3 pDir)
    {
        /**NOTE:
         * Everything works except I think its hitting the collider in the mech
         * Might need to let the mech handle its own firing at this point.
         */
        Ray ray = new Ray(selectedMech.transform.position, pDir.normalized);
        Debug.DrawRay(selectedMech.transform.position, ray.direction, Color.red, 1f);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 100f);
        GameObject temp = Instantiate(explosion);
        Debug.Log(hit.point);
        temp.transform.position = hit.point;

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
