using System;
using UnityEngine;

[Serializable]
public class Player {

    public PlayerStats playerStats;

    private string playerName;

    public Player()
    {
        playerStats = new PlayerStats();
    }

    public void setPlayerName (string name) {
        playerName = name;
        Debug.Log("Character Created. Name set to: " + playerName);
    }

    public string getPlayerName()
    {
        return playerName;
    }
}
