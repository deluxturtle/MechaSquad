using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{

    public List<Player> players;

    /// <summary>
    /// Adds player to the list of players to reference.
    /// </summary>
    /// <param name="player">Player</param>
    public void AddPlayer(Player player)
    {
        players.Add(player);
    }


}
