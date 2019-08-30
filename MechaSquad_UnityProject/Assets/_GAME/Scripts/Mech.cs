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
    private string name = "Siren_0x10";

    public string GetName()
    {
        return name;
    }
}
