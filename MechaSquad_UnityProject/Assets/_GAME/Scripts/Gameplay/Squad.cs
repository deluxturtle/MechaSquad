using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squad
{

    public List<Mech> mechaSquad = new List<Mech>();
    public Team Team;
    public int alive = 0;

    /// <summary>
    /// Simple squad setup that needs mechs added later.
    /// </summary>
    /// <param name="pTeam">Mech's Team</param>
    public Squad(Team pTeam)
    {
        Team = pTeam;
    }

    /// <summary>
    /// Quick squad creation.
    /// </summary>
    /// <param name="pTeam">Mech's Team.</param>
    /// <param name="mechs">List of Mechs for Squad.</param>
    public Squad(Team pTeam, List<Mech> mechs)
    {
        Team = pTeam;
        mechaSquad = mechs;
        alive += mechs.Count;
    }


    /// <summary>
    /// Adds mech to the squad and updates alive count.
    /// </summary>
    /// <param name="mech">Mech to be added to squad.</param>
    public void AddMech(Mech mech)
    {
        alive++;
        mechaSquad.Add(mech);
    }

    /// <summary>
    /// Doesn't remove mech but flags it as destroyed.
    /// </summary>
    public void RemoveMech(Mech mech)
    {
        foreach (Mech mecha in mechaSquad)
        {
            if (mech.Equals(mecha))
            {
                mech.Destroyed = true;
                alive--;
            }
        }
    }



}
