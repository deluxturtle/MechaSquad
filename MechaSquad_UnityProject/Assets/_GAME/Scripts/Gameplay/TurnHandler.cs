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
    List<Player> players = new List<Player>();
    byte pIndex = 0;//player index.
    Player curPlayer;

    public void NextTurn()
    {
        //Disable last player.
        if(curPlayer != null)
        {
            curPlayer.enabled = false;
        }
        pIndex++;
        if (pIndex >= players.Count)
        {
            pIndex = 0;
            round++;
            if(round > 100)
            {
                Debug.LogWarning("Round 100 Hit!");
                //TODO Max Round Feature.
            }
            
        }

        curPlayer = players[pIndex].GetComponent<Player>();
        curPlayer.enabled = true;
    }



    public void AddPlayer(Player newPlayer)
    {
        players.Add(newPlayer);
        pIndex++;
    }
}
