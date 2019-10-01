using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Andrew Seba
/// Description: Controls players ability to play when it's thier turn.
/// </summary>
public class TurnHandler : MonoBehaviour
{
    [SerializeField]
    private int round = 0;
    int pIndex = 0;//player index.
    Player curPlayer;
    SquadController squadController;

    private void Awake()
    {
        squadController = GetComponent<SquadController>();
    }

    public void StartGame()
    {
        pIndex = squadController.players.Count;
        NextTurn();
    }

    /// <summary>
    /// Disables player and activates next player in the list.
    /// </summary>
    public void NextTurn()
    {
        //Disable last player.
        if(curPlayer != null)
        {
            curPlayer.enabled = false;
        }
        pIndex++;
        if (pIndex >= squadController.players.Count)
        {
            pIndex = 0;
            round++;
            if(round > 100)
            {
                Debug.LogWarning("Round 100 Hit!");
                //TODO Max Round Feature.
            }
            
        }

        curPlayer = squadController.players[pIndex];
        curPlayer.enabled = true;
    }

}
