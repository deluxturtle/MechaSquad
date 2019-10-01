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

    public SquadController squadController;
    TurnHandler turnHandlr;
    SettingsTwoPlayerGame settings;

    // Start is called before the first frame update
    void Start()
    {
        settings = FindObjectOfType<SettingsTwoPlayerGame>();
        if (settings == null)
        {
            Debug.Log("Settings not found.");
        }
        turnHandlr = GetComponent<TurnHandler>();

        int mechLimit = (int)settings.mechLimitSlider.value;

        
        //p1
        SpawnPlayer(Team.Player1,"Player1");
        SpawnMechs(Team.Player1, mechLimit);
        //p2
        SpawnPlayer(Team.Player2, "Player2");//TODO: seperate settings into 2 sliders?
        SpawnMechs(Team.Player2, mechLimit);

        turnHandlr.NextTurn();
    }

    void SpawnPlayer(Team team, string playerName)
    {
        GameObject playerObj = Instantiate(playerPrefab);
        playerObj.transform.SetParent(transform);
        Player player = playerObj.GetComponent<Player>();
        player.PlayerName = playerName;
        squadController.AddPlayer(player);

    }

    void SpawnMechs(Team team, int mechLimit)
    {
        //List<Mech> mechs = new List<Mech>();
        Squad squad = new Squad(team);
        for(int i = 0; i < mechLimit; i++)
        {
            //Fresh meat :3
            //Except its like fresh metal.
            GameObject freshMech = Instantiate(mechPrefab);
            Mech mechScript = freshMech.GetComponent<Mech>();
            mechScript.Squad = squad; //Each mech has a reference to their own squad.
            squad.AddMech(mechScript);
            //mechs.Add(mechScript);
            mechScript.PlayerType = team;
            if(team == Team.Player1)
            {
                freshMech.transform.position = player1SpawnPoints[i].transform.position;
                freshMech.transform.rotation = player1SpawnPoints[i].transform.rotation;
            }
            else if(team == Team.Player2)
            {
                freshMech.transform.position = player2SpawnPoints[i].transform.position;
                freshMech.transform.rotation = player2SpawnPoints[i].transform.rotation;
            }
            freshMech.transform.SetParent(transform);
        }
        squadController.AddSquad(squad);
        //return mechs;
    }
}
