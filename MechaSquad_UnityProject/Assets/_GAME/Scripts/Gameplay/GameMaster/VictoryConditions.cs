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
    SquadController squadController;
    TurnHandler turnHndlr;
    private void Start()
    {
        squadController = GetComponent<SquadController>();
        turnHndlr = GetComponent<TurnHandler>();
    }

    public void CheckForEnd()
    {
        //2player win conditions include
            //other team loosing all mechs.
        foreach(Squad squad in squadController.squads)
        {
            Team team = squad.Team;
            if(squad.alive <= 0)
            {
                if (team == Team.Player1)
                    EndGame(Team.Player2);
                if (team == Team.Player2)
                    EndGame(Team.Player1);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="team">Winner</param>
    void EndGame(Team team)
    {
        Debug.Log(team + " Wins the Game!");
        Debug.Log("Game Over.");
    }
}
