using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [Tooltip("Base Player Prefab to spawn with.")]
    GameObject playerPrefab;
    List<Player> players = new List<Player>();
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Spawning Players.");
        SpawnPlayer("Player1");
        SpawnPlayer("Player2");
    }

    void SpawnPlayer(string playerName)
    {
        GameObject newPlayer = Instantiate(playerPrefab);
        players.Add(newPlayer.GetComponent<Player>());
    }


}
