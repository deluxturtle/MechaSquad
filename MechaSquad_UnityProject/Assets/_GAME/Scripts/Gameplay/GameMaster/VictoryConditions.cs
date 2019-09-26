using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Andrew Seba
/// Description: 
/// - If a mech gets destroyed check to see if there are any more units.
/// </summary>
public class VictoryConditions : MonoBehaviour
{
    GameStatus gameStatus;
    TurnHandler turnHndlr;
    private void Start()
    {
        gameStatus = GetComponent<GameStatus>();
        turnHndlr = GetComponent<TurnHandler>();
    }

    public void CheckForEnd()
    {
        for(int i = 0; i < gameStatus.players.Count; i++)
        {
            //if()
        }
    }
}
