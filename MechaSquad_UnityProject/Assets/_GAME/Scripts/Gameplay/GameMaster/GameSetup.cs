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
    [Tooltip("Mech Prefab to spawn.")]
    public GameObject mechPrefab;
    public List<MechSpawnPoint> player1SpawnPoints = new List<MechSpawnPoint>();
    public List<MechSpawnPoint> player2SpawnPoints = new List<MechSpawnPoint>();

    GameStatus gameStatus;
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
        SpawnMechs(PlayerType.Player2, mechLimit);
        turnHandlr.NextTurn();
    }

    void SpawnPlayer(string playerName)
    {
        GameObject playerObj = Instantiate(playerPrefab);
        playerObj.transform.SetParent(transform);
        Player player = playerObj.GetComponent<Player>();
        player.PlayerName = playerName;
        gameStatus.AddPlayer(player);

    }

    List<Mech> SpawnMechs(PlayerType playerType, int mechLimit)
    {
        List<Mech> mechs = new List<Mech>();
        for(int i = 0; i < mechLimit; i++)
        {
            //Fresh meat :3
            //Except its like fresh metal.
            GameObject freshMech = Instantiate(mechPrefab);
            Mech mechScript = freshMech.GetComponent<Mech>();
            mechs.Add(mechScript);
            mechScript.PlayerType = playerType;
            if(playerType == PlayerType.Player1)
            {
                freshMech.transform.position = player1SpawnPoints[i].transform.position;
                freshMech.transform.rotation = player1SpawnPoints[i].transform.rotation;
            }
            else if(playerType == PlayerType.Player2)
            {
                freshMech.transform.position = player2SpawnPoints[i].transform.position;
                freshMech.transform.rotation = player2SpawnPoints[i].transform.rotation;
            }
            freshMech.transform.SetParent(transform);
        }
        return mechs;
    }
}
