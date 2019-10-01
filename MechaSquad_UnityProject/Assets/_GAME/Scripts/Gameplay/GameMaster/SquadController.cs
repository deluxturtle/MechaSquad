using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Andrew Seba
/// Description: 
/// </summary>
public class SquadController : MonoBehaviour
{
    [HideInInspector]
    public List<Player> players = new List<Player>();
    public List<Squad> squads = new List<Squad>();

    /// <summary>
    /// Adds player to the list of players to reference.
    /// </summary>
    /// <param name="player">Player</param>
    public void AddPlayer(Player player)
    {
        players.Add(player);
    }

    public void AddSquad(Squad squad)
    {
        squads.Add(squad);
    }

    //public void AddSquadTo(Team pTeam, List<Mech> mechs)
    //{
    //    List<Mech> inboundSquad = mechs;
    //    Squad tempSquad = new Squad(pTeam, mechs);
    //    squads.Add(tempSquad);
    //}



}
