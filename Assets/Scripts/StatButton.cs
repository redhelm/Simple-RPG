using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatButton : MonoBehaviour {

    public enum StatName{
        Vitality, Strength, Intelligence, Range, Block, Dodge, AvailablePoints
    }

    public StatName statIncrease;

    void Update() {
        if (GameControl.player.playerStats.getAvailablePoints() <= 0) {
            gameObject.SetActive(false);
        }
    }

    public void ModifyStat() {
        GameControl.player.playerStats.IncreaseStat(statIncrease.ToString(), 1, false);
    }

}
