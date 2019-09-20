using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerType
{
    Player1,
    Player2,
    Bot
};

public class MechSpawnPoint : MonoBehaviour
{
    public PlayerType type;
}
