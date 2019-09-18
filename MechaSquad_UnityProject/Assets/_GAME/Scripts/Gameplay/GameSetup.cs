using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Andrew Seba
/// Description: Sets the game in motion.
/// </summary>
public class GameSetup : MonoBehaviour
{
    [Tooltip("Base Player Prefab to spawn with.")]
    public GameObject playerPrefab;
    TurnHandler turnHandlr;

    // Start is called before the first frame update
    void Start()
    {
        turnHandlr = GetComponent<TurnHandler>();
        Debug.Log("Spawning Players.");
        SpawnPlayer("Player1");
        SpawnPlayer("Player2");
        turnHandlr.NextTurn();
    }

    void SpawnPlayer(string playerName)
    {
        GameObject playerObj = Instantiate(playerPrefab);
        Player player = playerObj.GetComponent<Player>();
        player.PlayerName = playerName;
        turnHandlr.AddPlayer(player);
    }
}
