using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Andrew Seba
/// Description: Base object class for mechs
/// Holds info about mech and calls functions.
/// </summary>
public class Mech : MonoBehaviour
{
    //This will proabably be programaticly changed for custom guns.
    [Tooltip("This is where the bullet will come from.")]
    public Transform gunPos;
    //float fuel = 10f;
    float maxRange = 100f;//Of Raycast
    public ParticleSystem explosion;
    public PlayerType PlayerType { get; set; }
    public string Alias { get; set; } = "Siren_0x10";

    /// <summary>
    /// Shoots for the mech.
    /// </summary>
    /// <param name="dir">Direction of shot</param>
    public void Shoot(Vector3 dir)
    {
        Ray ray = new Ray(gunPos.position, dir);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, maxRange);
        Debug.DrawRay(gunPos.position, dir);
        Debug.Log(hit.collider);

        GameObject.Instantiate(explosion, hit.point, Quaternion.identity);
    }

    public void Move()
    {
        
    }

    /// <summary>
    /// Resets the movement and shooting resources.
    /// </summary>
    public void NewTurn()
    {

    }


    ///// <summary>
    ///// HitScan shooting style.
    ///// </summary>
    ///// <param name="pDir">Direction of Ray</param>
    //void Shoot(Vector3 pDir)
    //{
    //    /**NOTE:
    //     * Everything works except I think its hitting the collider in the mech
    //     * Might need to let the mech handle its own firing at this point.
    //     * */
    //Ray ray = new Ray(transform.position, pDir.normalized);
    //Debug.DrawRay(selectedMech.transform.position, ray.direction, Color.red, 1f);
    //    RaycastHit hit;
    //Physics.Raycast(ray, out hit, 100f);
    //    GameObject temp = Instantiate(explosion);
    //Debug.Log(hit.point);
    //    temp.transform.position = hit.point;

    //}
}
