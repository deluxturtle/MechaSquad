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
    public List<MechSpawnPoint> player1SpawnPoints = new List<MechSpawnPoint>();
    public List<MechSpawnPoint> player2SpawnPoints = new List<MechSpawnPoint>();


    TurnHandler turnHandlr;
    SettingsTwoPlayerGame settings;

    // Start is called before the first frame update
    void Start()
    {
        settings = FindObjectOfType<SettingsTwoPlayerGame>();
        int mechLimit = (int)settings.mechLimitSlider.value;
        if(settings == null)
        {
            Debug.Log("Settings not found.");
        }
        turnHandlr = GetComponent<TurnHandler>();
        Debug.Log("Spawning Players.");
        SpawnPlayer("Player1");
        SpawnMechs(PlayerType.Player1, mechLimit);
        SpawnPlayer("Player2");//TODO: seperate settings into 2 sliders?
        SpawnMechs(PlayerType.Player1, mechLimit);
        turnHandlr.NextTurn();
    }

    void SpawnPlayer(string playerName)
    {
        GameObject playerObj = Instantiate(playerPrefab);
        playerObj.transform.SetParent(transform);
        Player player = playerObj.GetComponent<Player>();
        player.PlayerName = playerName;
        turnHandlr.AddPlayer(player);

    }

    void SpawnMechs(PlayerType playerType, int mechLimit)
    {

    }
}
